const isProduction = process.env.BuildConfiguration && process.env.BuildConfiguration.toLowerCase() !== "debug";
console.log(`**Generating ${process.env.BuildConfiguration} web resources** \n`);

module.exports = {
    /*
     * Keep the entry object in alphabetical order
     * Webpack will start at the entry file, crawl all the module imports, and then bundle all dependencies together into a corresponding [name].library.js
     */
    entry: {
        'App': './src/index.ts'
    },
    module: {
        rules: [
            {
                test: /\.ts$/,
                enforce: 'pre',
                use: [{
                    loader: 'tslint-loader',
                    options: {
                        /*
                         * Some rules can be auto-fixed by uncommenting below (some rules need to be manually fixed)
                         * Ensure you have committed changes before to avoid mixing auto-fixes in with changes
                         * Double check auto-fixes to make sure they do not have any negative side-effects
                         */
                        // fix: true,
                        emitErrors: true
                    }
                }]
            },
            {
                test: /\.ts?$/,
                use: 'ts-loader',
                exclude: /node_modules/
            }
        ]
    },
    resolve: {
        extensions: ['.ts', '.js']
    },
    output: {
        filename: () => { return '/[name].js' },
        path: __dirname + '/bin',
        libraryTarget: 'var',
        library: ["AR", "WebResources", '[name]']
    },
    devtool: 'inline-source-map',
    mode: isProduction ? 'production' : 'development'
};
