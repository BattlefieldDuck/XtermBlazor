# XtermBlazor

Brings xterm.js to Blazor

Live Demo: [https://xtermblazor.project.tatlead.com](https://xtermblazor.project.tatlead.com)

## Prerequisites

- [.NET 5.0](https://dotnet.microsoft.com/download/dotnet/5.0)
- [Node.js](https://nodejs.org/en/download/)

## Installation

### 1. Install the package

Find the package through NuGet Package Manager or install it with following command.

```sh
dotnet add package XtermBlazor
```

### 2. Add Imports

After the package is added, you need to add the following in your `_Imports.razor`

```razor
@using XtermBlazor
```

### 3. Add CSS & Font references

Add the following to your HTML head section, it's either `index.html` or `_Host.cshtml` depending on whether you're running WebAssembly or Server.

```html
<link href="_content/XtermBlazor/XtermBlazor.css" rel="stylesheet" />
```

In the HTML body section of either `index.html` or `_Host.cshtml` add this:

```html
<script src="_content/XtermBlazor/XtermBlazor.min.js"></script>
```

## Usage

```razor
<Xterm @ref="_terminal" Options="_options" OnFirstRender="@OnFirstRender" />

@code {
    private Xterm _terminal;

    private TerminalOptions _options = new TerminalOptions
    {
        CursorBlink = true,
        CursorStyle = CursorStyle.Bar,
    };
    
    private async Task OnFirstRender()
    {
        await _terminal.WriteLine("Hello World");
    }
}
```

## Demo
- [XtermBlazor.Demo.Server](/XtermBlazor.Demo.Server/Pages/Index.razor)
- [XtermBlazor.Demo.Wasm](/XtermBlazor.Demo.Wasm/Pages/Index.razor)

