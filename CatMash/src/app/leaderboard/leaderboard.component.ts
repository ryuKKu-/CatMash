import { Component, OnInit } from '@angular/core';
import { CatService } from '../_services/cat.service';
import { Cat } from '../_model/models';

@Component({
    selector: 'app-leaderboard',
    templateUrl: './leaderboard.component.html',
    styleUrls: ['./leaderboard.component.css']
})
export class LeaderboardComponent implements OnInit {
    public cats: Cat[];

    constructor(private _catService: CatService) { }

    ngOnInit() {
        this._catService.getLeaderboard().subscribe(values => {
            this.cats = values;
        });
    }
}
