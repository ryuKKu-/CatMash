import { Component, OnInit } from '@angular/core';
import { CatService } from '../_services/cat.service';
import { Cat } from '../_model/models';
import { ActivatedRoute } from '@angular/router';

class MatchHistory {
    date: string;
    opponent: Cat;
    result: boolean;
    newRating: number;
}

@Component({
    selector: 'app-stats',
    templateUrl: './stats.component.html',
    styleUrls: ['./stats.component.css'],
})
export class StatsComponent implements OnInit {
    public cat: Cat;
    public matchesHistory: MatchHistory[];

    constructor(private _catService: CatService, private _route: ActivatedRoute) { }

    ngOnInit() {
        this._route.params.subscribe(params => {
            this._catService.getCat(params['id']).subscribe(cat => {
                this.cat = cat;

                this.matchesHistory = this.cat.histories.map(history => {
                    let matchHistory: MatchHistory = new MatchHistory();
                  
                    matchHistory.opponent = (history.match.catA !== undefined) ? history.match.catA : history.match.catB;
                    matchHistory.date = history.date;

                    if (history.match.result === 0 && history.match.catA !== undefined)
                        matchHistory.result = false;
                    else if (history.match.result === 1 && history.match.catB !== undefined)
                        matchHistory.result = false;
                    else
                        matchHistory.result = true;

                    let ratingBefore = (history.match.catA !== undefined) ? history.match.ratingB : history.match.ratingA;
                    matchHistory.newRating = history.rating - ratingBefore;

                    return matchHistory;
                });

                this.matchesHistory.sort((a, b) => {
                    let dateA = new Date(a.date);
                    let dateB = new Date(b.date);
                    return dateA > dateB ? -1 : dateA < dateB ? 1 : 0;
                });
            });
        });
    }
}
