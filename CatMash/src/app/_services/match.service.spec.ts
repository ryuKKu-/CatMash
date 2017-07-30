import { TestBed, inject } from '@angular/core/testing';
import { HttpModule } from '@angular/http';

import { MatchService } from './match.service';

describe('MatchService', () => {
    beforeEach(() => {
        TestBed.configureTestingModule({
            providers: [MatchService],
            imports: [HttpModule]
        });
    });

    it('should be created', inject([MatchService], (service: MatchService) => {
        expect(service).toBeTruthy();
    }));

    it('should create a match', inject([MatchService], (service: MatchService) => {
        service.createMatch().subscribe(match => {
            expect(match).toBeDefined();
            expect(match.catA).toBeDefined();
            expect(match.catB).toBeDefined();
        });
    }));

    it('should send the result', inject([MatchService], (service: MatchService) => {
        service.createMatch().subscribe(match => {
            service.sendResult(match.matchId, 0).subscribe(res => {
                expect(res).toBe(match.catA.catId);
            });
        });
    }));
});
