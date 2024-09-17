import { ITerminalAddon, ITerminalOptions, Terminal } from '@xterm/xterm';
import './node_modules/@xterm/xterm/css/xterm.css';

declare var DotNet: any;

interface ITerminalObject {
  terminal: Terminal,
  addons: Map<string, ITerminalAddon>,
  customKeyEventHandler: (event: KeyboardEvent) => boolean
  customWheelEventHandler: (event: WheelEvent) => boolean
}

class XtermBlazor {
  private readonly _ASSEMBLY_NAME = 'XtermBlazor';
  private readonly _terminals = new Map<string, ITerminalObject>();
  private readonly _addonList = new Map<string, ITerminalAddon>();

  /**
   * This function registers a new terminal instance with the specified parameters.
   * @param ref - The HTML element where the terminal will be attached.
   * @param options - The configuration options for the terminal.
   * @param addonIds - An array of addon identifiers to be used with the terminal.
   */
  registerTerminal(id: string, ref: HTMLElement, options: ITerminalOptions, addonIds: string[]) {
    // Setup the XTerm terminal
    const terminal = new Terminal(options);

    // Create Listeners
    terminal.onBinary(data => DotNet.invokeMethodAsync(this._ASSEMBLY_NAME, 'OnBinary', id, data));
    terminal.onCursorMove(() => DotNet.invokeMethodAsync(this._ASSEMBLY_NAME, 'OnCursorMove', id));
    terminal.onData(data => DotNet.invokeMethodAsync(this._ASSEMBLY_NAME, 'OnData', id, data));
    terminal.onKey(({ key, domEvent }) => DotNet.invokeMethodAsync(this._ASSEMBLY_NAME, 'OnKey', id, { Key: key, DomEvent: this.parseKeyboardEvent(domEvent) }));
    terminal.onLineFeed(() => DotNet.invokeMethodAsync(this._ASSEMBLY_NAME, 'OnLineFeed', id));
    terminal.onScroll(newPosition => DotNet.invokeMethodAsync(this._ASSEMBLY_NAME, 'OnScroll', id, newPosition));
    terminal.onSelectionChange(() => DotNet.invokeMethodAsync(this._ASSEMBLY_NAME, 'OnSelectionChange', id));
    terminal.onRender(event => DotNet.invokeMethodAsync(this._ASSEMBLY_NAME, 'OnRender', id, event));
    terminal.onResize(({ cols, rows }) => DotNet.invokeMethodAsync(this._ASSEMBLY_NAME, 'OnResize', id, { columns: cols, rows: rows }));
    terminal.onTitleChange(title => DotNet.invokeMethodAsync(this._ASSEMBLY_NAME, 'OnTitleChange', id, title));
    terminal.onBell(() => DotNet.invokeMethodAsync(this._ASSEMBLY_NAME, 'OnBell', id));
    terminal.attachCustomKeyEventHandler(event => {
      try {
        // Synchronous for Blazor WebAssembly apps only.
        return DotNet.invokeMethod(this._ASSEMBLY_NAME, 'AttachCustomKeyEventHandler', id, this.parseKeyboardEvent(event));
      } catch {
        // Asynchronous for both Blazor Server and Blazor WebAssembly apps.
        DotNet.invokeMethodAsync(this._ASSEMBLY_NAME, 'AttachCustomKeyEventHandler', id, this.parseKeyboardEvent(event));
        return this.getTerminalObjectById(id).customKeyEventHandler(event);
      }
    });
    terminal.attachCustomWheelEventHandler(event => {
      try {
        // Synchronous for Blazor WebAssembly apps only.
        return DotNet.invokeMethod(this._ASSEMBLY_NAME, 'AttachCustomWheelEventHandler', id, event);
      } catch {
        // Asynchronous for both Blazor Server and Blazor WebAssembly apps.
        DotNet.invokeMethodAsync(this._ASSEMBLY_NAME, 'AttachCustomWheelEventHandler', id, event);
        return this.getTerminalObjectById(id).customWheelEventHandler(event);
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
      customKeyEventHandler: (event: KeyboardEvent) => true,
      customWheelEventHandler: (event: WheelEvent) => true,
    });
  }

  /**
   * This function registers a new addon for the terminal.
   * @param addonId {string} - The unique identifier for the addon.
   * @param addon {ITerminalAddon} - The addon instance to be registered.
   *
   * The function adds the addon to the internal addon list using the provided addonId as the key.
   */
  registerAddon(addonId: string, addon: ITerminalAddon) {
    this._addonList.set(addonId, addon);
  }

  /**
   * This function registers multiple addons for the terminal.
   * @param addons {Object} - An object where the keys are addon identifiers and the values are addon instances.
   *
   * The function iterates over the addons object and registers each addon using the registerAddon function.
   */
  registerAddons(addons: { [id: string]: ITerminalAddon }) {
    Object.keys(addons).forEach(addonId => this.registerAddon(addonId, addons[addonId]));
  }

  /**
   * This function disposes of a terminal instance.
   * @param id {string} - The unique identifier for the terminal to be disposed.
   *
   * The function retrieves the terminal instance using the provided id, disposes of the terminal, and removes it from the internal terminals list.
   */
  disposeTerminal(id: string) {
    this._terminals.get(id)?.terminal.dispose();
    return this._terminals.delete(id);
  }

  // Xterm Functions
  getRows = (id: string) => this.getTerminalById(id).rows;
  getCols = (id: string) => this.getTerminalById(id).cols;
  getOptions = (id: string) => this.getTerminalById(id).options;
  setOptions = (id: string, options: ITerminalOptions) => this.getTerminalById(id).options = options;
  blur = (id: string) => this.getTerminalById(id).blur();
  focus = (id: string) => this.getTerminalById(id).focus();
  input = (id: string, data: string, wasUserInput: boolean) => this.getTerminalById(id).input(data, wasUserInput);
  resize = (id: string, columns: number, rows: number) => this.getTerminalById(id).resize(columns, rows);
  hasSelection = (id: string) => this.getTerminalById(id).hasSelection();
  getSelection = (id: string) => this.getTerminalById(id).getSelection();
  getSelectionPosition = (id: string) => this.getTerminalById(id).getSelectionPosition();
  clearSelection = (id: string) => this.getTerminalById(id).clearSelection();
  select = (id: string, column: number, row: number, length: number) => this.getTerminalById(id).select(column, row, length);
  selectAll = (id: string) => this.getTerminalById(id).selectAll();
  selectLines = (id: string, start: number, end: number) => this.getTerminalById(id).selectLines(start, end);
  scrollLines = (id: string, amount: number) => this.getTerminalById(id).scrollLines(amount);
  scrollPages = (id: string, pageCount: number) => this.getTerminalById(id).scrollPages(pageCount);
  scrollToTop = (id: string) => this.getTerminalById(id).scrollToTop();
  scrollToBottom = (id: string) => this.getTerminalById(id).scrollToBottom();
  scrollToLine = (id: string, line: number) => this.getTerminalById(id).scrollToLine(line);
  clear = (id: string) => this.getTerminalById(id).clear();
  write = (id: string, data: string) => this.getTerminalById(id).write(data);
  writeln = (id: string, data: string) => this.getTerminalById(id).writeln(data);
  paste = (id: string, data: string) => this.getTerminalById(id).paste(data);
  refresh = (id: string, start: number, end: number) => this.getTerminalById(id).refresh(start, end);
  reset = (id: string) => this.getTerminalById(id).reset();

  /**
   * This function invokes a specific function of an addon associated with a terminal.
   * @param id {string} - The unique identifier for the terminal.
   * @param addonId {string} - The unique identifier for the addon.
   * @param functionName {string} - The name of the function to be invoked.
   *
   * The function retrieves the terminal instance using the provided id, then retrieves the addon using the addonId. It then invokes the specified function on the addon with any additional arguments.
   */
  invokeAddonFunction(id: string, addonId: string, functionName: string) {
    const addon: { [key: string]: any } = this.getTerminalObjectById(id).addons.get(addonId);
    return addon[functionName](...arguments[3]);
  }

  /**
   * This function retrieves a terminal object by its unique identifier.
   * @param id {string} - The unique identifier for the terminal.
   * @returns {ITerminalObject} - The terminal object associated with the provided id.
   *
   * The function retrieves the terminal instance from the internal terminals list using the provided id. If no terminal is found, it throws an error.
   */
  getTerminalObjectById(id: string): ITerminalObject {
    const terminal = this._terminals.get(id);

    if (!terminal) {
      throw new Error(`Terminal with ID "${id}" not found.`);
    }

    return terminal;
  }

  /**
   * This function retrieves a Terminal instance by its unique identifier.
   * @param id {string} - The unique identifier for the terminal.
   * @returns {Terminal} - The Terminal instance associated with the provided id.
   *
   * The function retrieves the Terminal instance by calling the `getTerminalObjectById` method with the provided id. If no terminal is found, it throws an error.
   */
  getTerminalById(id: string): Terminal {
    return this.getTerminalObjectById(id).terminal;
  }

  /**
   * Converts KeyboardEvent properties to a key-value object.
   * @param event - The KeyboardEvent to parse.
   * @returns An object containing key-value pairs from the event.
   */
  private parseKeyboardEvent(event: KeyboardEvent) {
    // Create an object to store properties from KeyboardEvent.prototype
    const keyboardEvent = {
      ...Object.entries(Object.getOwnPropertyDescriptors(KeyboardEvent.prototype))
        .filter(([_, descriptor]) => typeof descriptor.get === 'function')
        .reduce((acc: { [key: string]: any }, [key, _]) => {
          // Assign each property from the event to the corresponding key in the 'acc' object
          acc[key] = event[key as keyof KeyboardEvent];
          return acc;
        }, {}), ...{ type: event.type }
    };

    return keyboardEvent;
  }
}

declare global {
  var XtermBlazor: XtermBlazor;
}

globalThis.XtermBlazor = new XtermBlazor();
