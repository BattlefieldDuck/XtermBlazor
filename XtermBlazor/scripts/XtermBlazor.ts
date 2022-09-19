import { ITerminalAddon, ITerminalOptions, Terminal } from 'xterm';

declare var DotNet: any;

interface ITerminalObject {
	terminal: Terminal,
	addons: Map<string, ITerminalAddon>,
	customKeyEventHandler: (event: KeyboardEvent) => boolean
}

class XtermBlazor {
	private readonly _ASSEMBLY_NAME = 'XtermBlazor';
	private readonly _terminals = new Map<string, ITerminalObject>();
	private readonly _addonList = new Map<string, ITerminalAddon>();

	/**
	 * Register Terminal
	 * @param id
	 * @param ref
	 * @param options
	 * @param addonIds
	 */
	registerTerminal(id: string, ref: HTMLElement, options: ITerminalOptions, addonIds: string[]) {
		// Setup the XTerm terminal
		const terminal = new Terminal(options);

		// Create Listeners	
		terminal.onBinary((data: string) => DotNet.invokeMethodAsync(this._ASSEMBLY_NAME, 'OnBinary', id, data));
		terminal.onCursorMove(() => DotNet.invokeMethodAsync(this._ASSEMBLY_NAME, 'OnCursorMove', id));
		terminal.onData((data: string) => DotNet.invokeMethodAsync(this._ASSEMBLY_NAME, 'OnData', id, data));
		terminal.onKey((event: { key: string, domEvent: KeyboardEvent }) => DotNet.invokeMethodAsync(this._ASSEMBLY_NAME, 'OnKey', id, this.convertToArgs(event.domEvent)));
		terminal.onLineFeed(() => DotNet.invokeMethodAsync(this._ASSEMBLY_NAME, 'OnLineFeed', id));
		terminal.onScroll((newPosition: number) => DotNet.invokeMethodAsync(this._ASSEMBLY_NAME, 'OnScroll', id, newPosition));
		terminal.onSelectionChange(() => DotNet.invokeMethodAsync(this._ASSEMBLY_NAME, 'OnSelectionChange', id));
		terminal.onRender((event: { start: number, end: number }) => DotNet.invokeMethodAsync(this._ASSEMBLY_NAME, 'OnRender', id, event));
		terminal.onResize((event: { cols: number, rows: number }) => DotNet.invokeMethodAsync(this._ASSEMBLY_NAME, 'OnResize', id, { columns: event.cols, rows: event.rows }));
		terminal.onTitleChange((title: string) => DotNet.invokeMethodAsync(this._ASSEMBLY_NAME, 'OnTitleChange', id, title));
		terminal.onBell(() => DotNet.invokeMethodAsync(this._ASSEMBLY_NAME, 'OnBell', id));
		terminal.attachCustomKeyEventHandler((event: KeyboardEvent) => {
			try {
				// Synchronous for Blazor WebAssembly apps only.
				return DotNet.invokeMethod(this._ASSEMBLY_NAME, 'AttachCustomKeyEventHandler', id, this.convertToArgs(event));
			} catch {
				// Asynchronous for both Blazor Server and Blazor WebAssembly apps.
				DotNet.invokeMethodAsync(this._ASSEMBLY_NAME, 'AttachCustomKeyEventHandler', id, this.convertToArgs(event));
				return this.getTerminalById(id).customKeyEventHandler?.call(event) ?? true;
            }
        });

		// Load and set addons
		const addons = new Map<string, ITerminalAddon>();
		addonIds.forEach(addonId => {
			const addon = Object.assign(Object.create(Object.getPrototypeOf(this._addonList.get(addonId))), this._addonList.get(addonId));
			terminal.loadAddon(addon);
			addons.set(addonId, addon);
		});

		// Opens the terminal
		terminal.open(ref);

		// Set the terminal
		this._terminals.set(id, {
			terminal: terminal,
			addons: addons,
			customKeyEventHandler: undefined,
		});
	}

	/**
	 * Register Addon
	 * @param addonId
	 * @param addon
	 */
	registerAddon(addonId: string, addon: ITerminalAddon) {
		this._addonList.set(addonId, addon);
	}

	/**
	 * Dispose Terminal
	 * @param id
	 */
	disposeTerminal(id: string) {
		this._terminals.get(id)?.terminal.dispose();
		this._terminals.delete(id);
	}

	// Xterm Functions
	getRows = (id: string) => this.getTerminalById(id).terminal.rows;
	getCols = (id: string) => this.getTerminalById(id).terminal.cols;
	getOptions = (id: string) => this.getTerminalById(id).terminal.options;
	setOptions = (id: string, options: ITerminalOptions) => this.getTerminalById(id).terminal.options = options;
	blur = (id: string) => this.getTerminalById(id).terminal.blur();
	focus = (id: string) => this.getTerminalById(id).terminal.focus();
	resize = (id: string, columns: number, rows: number) => this.getTerminalById(id).terminal.resize(columns, rows);
	hasSelection = (id: string) => this.getTerminalById(id).terminal.hasSelection();
	getSelection = (id: string) => this.getTerminalById(id).terminal.getSelection();
	getSelectionPosition = (id: string) => this.getTerminalById(id).terminal.getSelectionPosition();
	clearSelection = (id: string) => this.getTerminalById(id).terminal.clearSelection();
	select = (id: string, column: number, row: number, length: number) => this.getTerminalById(id).terminal.select(column, row, length);
	selectAll = (id: string) => this.getTerminalById(id).terminal.selectAll();
	selectLines = (id: string, start: number, end: number) => this.getTerminalById(id).terminal.selectLines(start, end);
	scrollLines = (id: string, amount: number) => this.getTerminalById(id).terminal.scrollLines(amount);
	scrollPages = (id: string, pageCount: number) => this.getTerminalById(id).terminal.scrollPages(pageCount);
	scrollToTop = (id: string) => this.getTerminalById(id).terminal.scrollToTop();
	scrollToBottom = (id: string) => this.getTerminalById(id).terminal.scrollToBottom();
	scrollToLine = (id: string, line: number) => this.getTerminalById(id).terminal.scrollToLine(line);
	clear = (id: string) => this.getTerminalById(id).terminal.clear();
	write = (id: string, data: string) => this.getTerminalById(id).terminal.write(data);
	writeln = (id: string, data: string) => this.getTerminalById(id).terminal.writeln(data);
	paste = (id: string, data: string) => this.getTerminalById(id).terminal.paste(data);
	refresh = (id: string, start: number, end: number) => this.getTerminalById(id).terminal.refresh(start, end);
	reset = (id: string) => this.getTerminalById(id).terminal.reset();

	/**
	 * Invoke addon function
	 * @param id
	 * @param addonId
	 * @param functionName
	 */
	invokeAddonFunction(id: string, addonId: string, functionName: string) {
		return this.getTerminalById(id).addons.get(addonId)[functionName](...arguments[3]);
	}

	/**
	 * Get Terminal object by Id
	 * @param id
	 */
	getTerminalById(id: string): ITerminalObject {
		const terminal = this._terminals.get(id);

		if (!terminal) {
			throw new Error('Fail to get terminal by reference id');
		}

		return terminal;
	}

	/**
	 * Convert to Microsoft.AspNetCore.Components.Web.KeyboardEventArgs
	 * @param event
	 */
	private convertToArgs(event: KeyboardEvent) {
		return {
			key: event.key,
			code: event.code,
			location: event.location,
			repeat: event.repeat,
			ctrlKey: event.ctrlKey,
			shiftKey: event.shiftKey,
			altKey: event.altKey,
			metaKey: event.metaKey,
			type: event.type
		};
	}
}

declare global {
	interface Window {
		XtermBlazor: XtermBlazor;
	}
}

window.XtermBlazor = new XtermBlazor();
