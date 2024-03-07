import path from 'path';
import MiniCssExtractPlugin from 'mini-css-extract-plugin';
import CssMinimizerPlugin from 'css-minimizer-webpack-plugin';
import { merge } from 'webpack-merge';
import { Configuration } from 'webpack';

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
        test: /\.ts$/,
        use: 'ts-loader',
        exclude: /node_modules/,
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
    ],
  },
  performance: {
    maxAssetSize: 300000,
    maxEntrypointSize: 300000,
  }
};

export default (env: any, argv: { mode: string; }) => {
  if (argv.mode === 'development') {
    return merge(common, {
      mode: 'development',
      devtool: 'inline-source-map',
      entry: {
        'XtermBlazor': './index.ts',
      }
    });
  }

  if (argv.mode === 'production') {
    return merge(common, {
      mode: 'production',
      entry: {
        'XtermBlazor.min': './index.ts',
      }
    });
  }
};
