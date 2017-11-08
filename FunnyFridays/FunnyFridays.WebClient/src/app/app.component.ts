import { Component } from '@angular/core';

@Component({
	selector: 'ff-app',
	template: `<h1>Welcome to Funny Fridays</h1>
				<label>Input your phone</label>
                 <input [(ngModel)]="phone" placeholder="+380_________">
                 <h1>Now you registered as {{phone}}!</h1>`
})
export class AppComponent {
	phone = '';
}