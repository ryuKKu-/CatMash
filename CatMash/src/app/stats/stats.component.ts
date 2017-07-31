import { Component, OnInit } from '@angular/core';
import { CatService } from '../_services/cat.service';
import { Cat } from '../_model/models';
import { ActivatedRoute } from '@angular/router';
import * as moment from 'moment';

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
    cat: Cat;
    matchesHistory: MatchHistory[];

    view: any[] = [760, 400];
    values: any[] = [];
    showLegend = false;
    showXAxis = false;
    showXAxisLabel = false;
    showYAxis = true;
    showYAxisLabel = true;
    yAxisLabel = 'Elo Rating';
    colorScheme = {
        domain: ['#e98c8c']
    };

    tab: number = 0;

    constructor(private _catService: CatService, private _route: ActivatedRoute) { }

    ngOnInit() {
        let ratingSeries = [];

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

                    ratingSeries.push({ "name": moment(history.date).format('DD/MM/YYYY HH:mm:ss'), "value": history.rating });

                    return matchHistory;
                });

                this.values = [{
                    name: "rating",
                    series: ratingSeries
                }];

                this.matchesHistory.sort((a, b) => {
                    let dateA = new Date(a.date);
                    let dateB = new Date(b.date);
                    return dateA > dateB ? -1 : dateA < dateB ? 1 : 0;
                });
            });
        });
    }

    switchTab(value) {
        this.tab = value;
    }
}
