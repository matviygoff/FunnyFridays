import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { HttpModule } from "@angular/http";
import { RouterModule } from "@angular/router";

import { AppComponent } from "./components/app/app.component";
import { NavMenuComponent } from "./components/navmenu/navmenu.component";
import { HomeComponent } from "./components/home/home.component";
import { ProfileComponent } from "./components/profile/profile.component";
import { MapsComponent } from "./components/maps/maps.component";

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        ProfileComponent,
        MapsComponent,
        HomeComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: "", redirectTo: "home", pathMatch: "full" },
            { path: "home", component: HomeComponent },
            { path: "profile", component: ProfileComponent },
            { path: "maps", component: MapsComponent },
            { path: "**", redirectTo: "home" }
        ])
    ]
})
export class AppModuleShared {
}
