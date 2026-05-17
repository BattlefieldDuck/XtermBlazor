const { EsbuildPlugin } = require("esbuild-loader");
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const path = require("path");
const { merge } = require("webpack-merge");

const common = {
  entry: {
    "XtermBlazor.min": "./index.ts",
  },
  output: {
    filename: "[name].js",
    path: path.resolve(__dirname, "../wwwroot"),
    clean: true,
  },
  resolve: {
    extensions: [".ts", ".tsx", ".js", ".jsx"],
  },
  module: {
    rules: [
      {
        test: /\.css$/,
        use: [MiniCssExtractPlugin.loader, "css-loader"],
      },
      {
        test: /\.[jt]sx?$/,
        loader: "esbuild-loader",
        options: {
          target: "es2015",
        },
      },
    ],
  },
  plugins: [
    new MiniCssExtractPlugin({
      filename: "[name].css",
    }),
  ],
  performance: {
    maxAssetSize: 400000,
    maxEntrypointSize: 400000,
  },
};

module.exports = (env) => {
  if (env && env.production) {
    return merge(common, {
      mode: "production",
      optimization: {
        minimize: true,
        minimizer: [
          new EsbuildPlugin({
            target: "es2015",
            css: true,
          }),
        ],
      },
    });
  }

  return merge(common, {
    mode: "development",
    devtool: "inline-source-map",
  });
};
