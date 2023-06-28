import * as CopyPlugin from 'copy-webpack-plugin';
import * as path from 'path';

const config = {
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
                {
                    from: path.join(__dirname, './node_modules/xterm/css/xterm.css'),
                    to: path.join(__dirname, '/wwwroot/XtermBlazor.css')
                }
            ]
        })
    ],
    output: {
        path: path.join(__dirname, '/wwwroot'),
        filename: '[name].min.js'
    }
};

export default config;
