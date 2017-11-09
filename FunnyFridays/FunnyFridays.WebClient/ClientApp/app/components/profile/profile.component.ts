import { Component } from "@angular/core";

export class User {
	phone: string;
	password: string;
	username: string;

	constructor(phone: string, password: string, username: string) {
		this.phone = phone;
		this.password = password;
		this.username = username;
	}
}

@Component({
	selector: "profile",
	templateUrl: "./profile.component.html"
})
export class ProfileComponent {
	users: User[] =
	[
		{ phone: "1", password: "1", username: "1" },
		{ phone: "2", password: "2", username: "2" },
		{ phone: "3", password: "3", username: "3" }
	];
	addUser(phone: string, password: string, username: string): void {

		if (phone == null || phone == undefined || phone.trim() === "")
			return;
		if (password == null || password == undefined)
			return;
		if (username == null || username == undefined || username.trim() === "")
			return;
		this.users.push(new User(phone, password, username));
	}

	getUser(phone: string, password: string): User | undefined {
		return this.users.find(_ => _.phone === phone && _.password === password);
	}

	getUserName(phone: string, password: string): string {
		const user = this.users.find(_ => _.phone === phone && _.password === password);
		if (user == undefined) {
			return "";
		}

		return user.username;
	}

	showMessage(text: string): void {
		alert(text);
	}
}
