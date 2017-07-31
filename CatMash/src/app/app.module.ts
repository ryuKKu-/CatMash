import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { MomentModule } from 'angular2-moment';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { NgxChartsModule } from '@swimlane/ngx-charts';


var modules = [
    BrowserModule,
    FormsModule,
    HttpModule,
    RouterModule.forRoot([
        { path: '', component: MatchComponent },
        { path: 'leaderboard', component: LeaderboardComponent },
        { path: 'stats/:id', component: StatsComponent },
        { path: '**', component: MatchComponent }
    ]),
    MomentModule,
    BrowserAnimationsModule,
    NgxChartsModule
];

import { AppComponent } from './app.component';
import { MatchComponent } from './match/match.component';
import { LeaderboardComponent } from './leaderboard/leaderboard.component';
import { StatsComponent } from './stats/stats.component';
import { PlusMinusPipe } from './plus-minus.pipe';
import { DefaultImageDirective } from './_utils/image.directive';

var components = [
    AppComponent,
    MatchComponent,
    LeaderboardComponent,
    StatsComponent
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
        PlusMinusPipe,
        DefaultImageDirective
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
