# XtermBlazor
[![Dotnet Package](https://github.com/BattlefieldDuck/XtermBlazor/actions/workflows/dotnet-package.yml/badge.svg)](https://github.com/BattlefieldDuck/XtermBlazor/actions/workflows/dotnet-package.yml)
[![NuGet Version](http://img.shields.io/nuget/v/XtermBlazor.svg?style=flat)](https://www.nuget.org/packages/XtermBlazor/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/XtermBlazor.svg)](https://www.nuget.org/packages/XtermBlazor/)

Brings [xterm.js](https://github.com/xtermjs/xterm.js) to Blazor

Live Demo: [https://xtermblazor.pages.dev](https://xtermblazor.pages.dev)

## Demo
- [XtermBlazor.Demo.Server](/XtermBlazor.Demo.Server/Pages/Index.razor)
- [XtermBlazor.Demo.Wasm](/XtermBlazor.Demo.Wasm/Pages/Index.razor)

## Prerequisites

- [.NET 6.0](https://dotnet.microsoft.com/download/dotnet/6.0)
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

### Basic Usage

```razor
<Xterm @ref="_terminal" Options="_options" OnFirstRender="@OnFirstRender" />

@code {
    private Xterm _terminal;

    private TerminalOptions _options = new TerminalOptions
    {
        CursorBlink = true,
        CursorStyle = CursorStyle.Bar,
        Theme =
        {
            Background = "#17615e",
        },
    };
    
    private async Task OnFirstRender()
    {
        await _terminal.WriteLine("Hello World");
    }
}
```

## Addons
Xterm supports [Addons](https://github.com/xtermjs/xterm.js/tree/master/addons)

To use `xterm-addon-fit` addon, you need to add the following to your HTML body section either `index.html` or `_Host.cshtml`.

```html
<!-- xterm-addon-fit CDN -->
<script src="https://cdn.jsdelivr.net/npm/xterm-addon-fit@0.7.0/lib/xterm-addon-fit.min.js"></script>

<!-- Register addon to XtermBlazor -->
<script>XtermBlazor.registerAddons({"xterm-addon-fit": new FitAddon.FitAddon()});</script>
```

### Usage with addons

```razor
<Xterm @ref="_terminal" Options="_options" AddonIds="_addonIds" OnFirstRender="@OnFirstRender" />

@code {
    private Xterm _terminal;

    private TerminalOptions _options = new TerminalOptions
    {
        CursorBlink = true,
        CursorStyle = CursorStyle.Bar,
    };
    
    private string[] _addonIds = new string[]
    {
        "xterm-addon-fit",
    };
    
    private async Task OnFirstRender()
    {
        // Invoke fit() function
        await _terminal.InvokeAddonFunctionVoidAsync("xterm-addon-fit", "fit");
        
        await _terminal.WriteLine("Hello World");
    }
}
```
