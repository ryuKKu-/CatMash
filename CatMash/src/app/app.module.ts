import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

var modules = [
    BrowserModule,
    FormsModule,
    HttpModule,
    RouterModule.forRoot([
        { path: '', component: MatchComponent },
        { path: '**', component: MatchComponent }
    ]),
];

import { AppComponent } from './app.component';
import { MatchComponent } from './match/match.component';

var components = [
    AppComponent,
    MatchComponent
];

import { CatService } from './_services/cat.service';
import { MatchService } from './_services/match.service';

var providers = [
    CatService,
    MatchService,
];

@NgModule({
    declarations: [
        ...components,
    ],
    imports: [
        ...modules
    ],
    providers: [
        ...providers
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
