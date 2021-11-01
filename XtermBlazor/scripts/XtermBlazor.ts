import { Terminal, ITerminalOptions } from 'xterm'

declare var DotNet: any

class XtermBlazor {
	private readonly _ASSEMBLY_NAME = 'XtermBlazor'
	private readonly _terminals = new Map<string, Terminal>()

	registerTerminal(id: string, ref: HTMLElement, options: ITerminalOptions) {
		// Setup the XTerm terminal
		const terminal = new Terminal(options)

		// Create Listeners	
		terminal.onBinary(async (data: string) => {
			await DotNet.invokeMethodAsync(this._ASSEMBLY_NAME, 'OnBinary', id, data)
		})
		terminal.onCursorMove(async () => {
			await DotNet.invokeMethodAsync(this._ASSEMBLY_NAME, 'OnCursorMove', id)
		})
		terminal.onData(async (data: string) => {
			await DotNet.invokeMethodAsync(this._ASSEMBLY_NAME, 'OnData', id, data)
		})
		terminal.onKey(async (event: { key: string, domEvent: KeyboardEvent }) => {
			await DotNet.invokeMethodAsync(this._ASSEMBLY_NAME, 'OnKey', id, event)
		})
		terminal.onLineFeed(async () => {
			await DotNet.invokeMethodAsync(this._ASSEMBLY_NAME, 'OnLineFeed', id)
		})
		terminal.onScroll(async (newPosition: number) => {
			await DotNet.invokeMethodAsync(this._ASSEMBLY_NAME, 'OnScroll', id, newPosition)
		})
		terminal.onSelectionChange(async () => {
			await DotNet.invokeMethodAsync(this._ASSEMBLY_NAME, 'OnSelectionChange', id)
		})
		terminal.onRender(async (event: { start: number, end: number }) => {
			await DotNet.invokeMethodAsync(this._ASSEMBLY_NAME, 'OnRender', id, event)
		})
		terminal.onResize(async (event: { cols: number, rows: number }) => {
			const newEvent = { columns: event.cols, rows: event.rows } // Change cols to columns
			await DotNet.invokeMethodAsync(this._ASSEMBLY_NAME, 'OnResize', id, newEvent)
		})
		terminal.onTitleChange(async (title: string) => {
			await DotNet.invokeMethodAsync(this._ASSEMBLY_NAME, 'OnTitleChange', id, title)
		})
		terminal.onBell(async () => {
			await DotNet.invokeMethodAsync(this._ASSEMBLY_NAME, 'OnBell', id)
		})

		terminal.open(ref)

		this._terminals.set(id, terminal)
	}

	disposeTerminal(id: string) {
		this.getTerminal(id).dispose()
		this._terminals.delete(id)
	}

	// Functions
	getRows = (id: string) => this.getTerminal(id).rows
	getCols = (id: string) => this.getTerminal(id).cols
	blur = (id: string) => this.getTerminal(id).blur()
	focus = (id: string) => this.getTerminal(id).focus()
	resize = (id: string, columns: number, rows: number) => this.getTerminal(id).resize(columns, rows)
	hasSelection = (id: string) => this.getTerminal(id).hasSelection()
	getSelection = (id: string) => this.getTerminal(id).getSelection()
	getSelectionPosition = (id: string) => this.getTerminal(id).getSelectionPosition()
	clearSelection = (id: string) => this.getTerminal(id).clearSelection()
	select = (id: string, column: number, row: number, length: number) => this.getTerminal(id).select(column, row, length)
	selectAll = (id: string) => this.getTerminal(id).selectAll()
	selectLines = (id: string, start: number, end: number) => this.getTerminal(id).selectLines(start, end)
	scrollLines = (id: string, amount: number) => this.getTerminal(id).scrollLines(amount)
	scrollPages = (id: string, pageCount: number) => this.getTerminal(id).scrollPages(pageCount)
	scrollToTop = (id: string) => this.getTerminal(id).scrollToTop()
	scrollToBottom = (id: string) => this.getTerminal(id).scrollToBottom()
	scrollToLine = (id: string, line: number) => this.getTerminal(id).scrollToLine(line)
	clear = (id: string) => this.getTerminal(id).clear()
	write = (id: string, data: string) => this.getTerminal(id).write(data)
	writeln = (id: string, data: string) => this.getTerminal(id).writeln(data)
	paste = (id: string, data: string) => this.getTerminal(id).paste(data)
	refresh = (id: string, start: number, end: number) => this.getTerminal(id).refresh(start, end)
	reset = (id: string) => this.getTerminal(id).reset()

	getTerminal(id: string): Terminal {
		const terminal = this._terminals.get(id)

		if (!terminal) {
			throw new Error('Fail to get terminal by reference id')
		}

		return terminal
	}
}

declare global {
	interface Window {
		XtermBlazor: XtermBlazor
	}
}

window.XtermBlazor = new XtermBlazor()
