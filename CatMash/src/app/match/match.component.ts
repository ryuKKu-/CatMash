import { Component, OnInit } from '@angular/core';
import { MatchService } from '../_services/match.service';
import { Cat } from '../_model/models';

@Component({
    selector: 'app-match',
    templateUrl: './match.component.html',
    styleUrls: ['./match.component.css'],
})
export class MatchComponent implements OnInit {
    public catA: Cat;
    public catB: Cat;
    private matchId: number;

    public styleA = {};
    public styleB = {};

    public killA: boolean = false;
    public killB: boolean = false;
    public loadingA: boolean = true;
    public loadingB: boolean = true;

    constructor(private _matchService: MatchService) { }

    ngOnInit() {
        this.updateView();
    }

    select(result: number) {
        if (!this.inactive()) {
            if (result == 0)
                this.killB = true;
            else
                this.killA = true;

            setTimeout(() => {
                if (result == 0)
                    this.loadingB = true;
                else
                    this.loadingA = true;

                setTimeout(() => {
                    this._matchService.sendResult(this.matchId, result)
                        .subscribe(winnerId => this.updateView(winnerId, result));
                }, 1000);
            }, 1000);
        }
    }

    private updateView(winnerId?: string, position?: number) {
        this._matchService.createMatch(winnerId, position).subscribe(match => {
            this.catA = match.catA;
            this.catB = match.catB;
            this.killA = false;
            this.killB = false;
            this.loadingA = false;
            this.loadingB = false;

            this.styleA = this.createStyle(this.catA);
            this.styleB = this.createStyle(this.catB);

            this.matchId = match.matchId;
        });
    }

    inactive() {
        return this.killA || this.killB || this.loadingA || this.loadingB;
    }

    private createStyle(cat: Cat) {
        return {
            'background': 'url("' + cat.imageUrl + '") center center / cover no-repeat',
        }
    }
}
