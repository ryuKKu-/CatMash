import { Component } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {
    currentUrl: string;

    constructor(private _router: Router) {
        _router.events.subscribe((value: NavigationEnd) => {
            this.currentUrl = value.url;
            window.scrollTo(0, 0);
        });
    }
}
