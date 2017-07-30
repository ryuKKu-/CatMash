import { Injectable } from '@angular/core';
import { Http, RequestOptions, URLSearchParams } from '@angular/http';
import 'rxjs/Rx';
import { Match } from '../_model/models';


@Injectable()
export class MatchService {

    private baseAPI: string = '/api/match';

    constructor(private _httpService: Http) { }

    createMatch(winnerId?: string, position?: number) {
        let requestOptions = new RequestOptions();

        if (winnerId !== undefined && position !== undefined) {
            let params: URLSearchParams = new URLSearchParams();
            params.set('winnerId', winnerId);
            params.set('position', position.toString());
            requestOptions.params = params;
        }

        return this._httpService.get(`${this.baseAPI}`, requestOptions)
            .map(value => value.json() as Match);
    }


    sendResult(matchId: number, result: number) {
        return this._httpService.post(`${this.baseAPI}/${matchId}`, { result: result })
            .map(x => x.text());
    }
}
