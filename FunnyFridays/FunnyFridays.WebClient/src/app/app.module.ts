/* Entry point Module */
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser'; /*работы с браузером также требуется модуль BrowserModule*/
import { FormsModule } from '@angular/forms';	/*Так как наш компонент использует элемент input или элемент формы*/
import { AppComponent } from './app.component'; /*импортируется созданный ранее компонент*/
@NgModule({
	imports: [BrowserModule, FormsModule],
	declarations: [AppComponent],
	bootstrap: [AppComponent]
})
export class AppModule { }