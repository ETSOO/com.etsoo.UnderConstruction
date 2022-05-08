/// <binding BeforeBuild='Run - Production' ProjectOpened='Watch - Development' />
const path = require('path');
const fs = require('fs');

const entries = Object.fromEntries(
    fs.readdirSync('./Scripts/').filter((file) => file.endsWith('.ts') || file.endsWith('.tsx')).map(file => [file.split('.')[0], `./Scripts/${file}`])
);

module.exports = {
    entry: entries,
    module: {
        rules: [
            {
                test: /\.tsx?$/,
                use: 'ts-loader',
                exclude: /node_modules/
            }
        ]
    },
    resolve: {
        extensions: ['.tsx', '.ts', '.js', '.jsx']
    },
    output: {
        filename: '[name].js',
        path: path.resolve(__dirname, 'wwwroot/js/')
    },
    mode: 'development'
};
