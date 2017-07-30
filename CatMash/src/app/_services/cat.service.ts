import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Cat } from '../_model/models';
import 'rxjs/Rx';


@Injectable()
export class CatService {

    private baseAPI = '/api/cats';

    constructor(private _httpService: Http) { }

    getCat(id: string) {
        return this._httpService.get(`${this.baseAPI}/${id}`)
            .map(response => response.json() as Cat);
    }

    getLeaderboard() {
        return this._httpService.get(this.baseAPI)
            .map(response => response.json() as Cat[]);
    }
}
