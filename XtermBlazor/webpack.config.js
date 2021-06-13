const path = require('path');
const CopyPlugin = require('copy-webpack-plugin');

module.exports = {
    mode: 'production',
    resolve: {
        extensions: ['.ts', '.js']
    },
    devtool: 'inline-source-map',
    module: {
        rules: [
            {
                test: /\.ts?$/,
                loader: 'ts-loader'
            }
        ]
    },
    entry: {
        'XtermBlazor': './scripts/XtermBlazor.ts'
    },
    plugins: [
        new CopyPlugin({
            patterns: [
                { from: path.join(__dirname, './node_modules/xterm/css/xterm.css'), to: path.join(__dirname, '/wwwroot/XtermBlazor.css') }
            ]
        })
    ],
    output: {
        path: path.join(__dirname, '/wwwroot'),
        filename: '[name].min.js'
    }
};
