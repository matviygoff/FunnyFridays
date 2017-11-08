/*указать Angularу, как запускать наше приложение
Этот код инициализирует платформу, которая запускает приложение, и затем использует эту платформу для загрузки модуля AppModule
*/
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { AppModule } from './app/app.module';
var platform = platformBrowserDynamic();
platform.bootstrapModule(AppModule);
//# sourceMappingURL=main.js.map