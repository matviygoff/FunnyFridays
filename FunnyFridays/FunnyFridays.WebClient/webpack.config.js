/*
сборщик webpack
Данный файл предоставляет информацию загрузчику модулей о том, где искать модули приложения, а также регистрирует все необходимые пакеты.
*/

var path = require('path');
var webpack = require('webpack');
var UglifyJSPlugin = require('uglifyjs-webpack-plugin'); // плагин минимизации
module.exports = {
	//В секции entry определяются входные файлы для компиляции и имена сборок
	entry: {
		'polyfills': './src/polyfills.ts',
		'app': './src/main.ts'
	},
	//В секции output определяется, что сборки будут находиться в каталоге public, и для них будут созданы файлы с названиями сборок. Плейсхолдер[name] будет передать название сборки, то есть polyfills или app.
	output: {
		path: path.resolve(__dirname, './public'),     // путь к каталогу выходных файлов - папка public
		publicPath: '/public/',
		filename: "[name].js"       // название создаваемого файла
	},
	//В секции resolve указываются расширения, которые будут применяться к модулям в файлах typescript.
	resolve: {
		extensions: ['.ts', '.js']
	},
	//Секция module.rules определяет загрузчики файлов typescript, которые будут использоваться для сборки проекта.
	module: {
		rules: [   //загрузчик для ts
			{
				test: /\.ts$/, // определяем тип файлов
				use: [
					{
						loader: 'awesome-typescript-loader',
						options: { configFileName: path.resolve(__dirname, 'tsconfig.json') }
					},
					'angular2-template-loader'
				]
			}
		]
	},
	plugins: [
		//позволяет управлять путями к файлам вне зависимости используем мы Windows или Linux
		new webpack.ContextReplacementPlugin(
			/angular(\\|\/)core/,
			path.resolve(__dirname, 'src'), // каталог с исходными файлами
			{} // карта маршрутов
		),
		//позволяет оптимизировать код сборок
		new webpack.optimize.CommonsChunkPlugin({
			name: ['app', 'polyfills']
		}),
		//минифицирует код сборок
		new UglifyJSPlugin()
	]
}