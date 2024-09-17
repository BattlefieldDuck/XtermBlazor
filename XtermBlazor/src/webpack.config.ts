import CssMinimizerPlugin from 'css-minimizer-webpack-plugin';
import { EsbuildPlugin } from 'esbuild-loader';
import MiniCssExtractPlugin from 'mini-css-extract-plugin';
import path from 'path';
import { Configuration } from 'webpack';
import { merge } from 'webpack-merge';

const common: Configuration = {
    output: {
        filename: '[name].js',
        path: path.resolve(__dirname, '../wwwroot'),
    },
    module: {
        rules: [
            {
                test: /\.css$/,
                use: [MiniCssExtractPlugin.loader, 'css-loader']
            },
            {
                test: /\.[jt]sx?$/,
                loader: 'esbuild-loader'
            }
        ],
    },
    plugins: [
        new MiniCssExtractPlugin({
            filename: '[name].css',
        }),
    ],
    optimization: {
        minimizer: [
            new CssMinimizerPlugin(),
            new EsbuildPlugin({
                css: true
            })
        ],
    },
    performance: {
        maxAssetSize: 300000,
        maxEntrypointSize: 300000,
    }
};

export default (env: { production: boolean }) => {
    if (env.production) {
        return merge(common, {
            mode: 'production',
            entry: {
                'XtermBlazor.min': './index.ts',
            }
        });
    }

    return merge(common, {
        mode: 'development',
        devtool: 'inline-source-map',
        entry: {
            'XtermBlazor.min': './index.ts',
        }
    });
};
