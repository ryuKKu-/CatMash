import { TestBed, inject } from '@angular/core/testing';
import { HttpModule } from '@angular/http';

import { CatService } from './cat.service';
import { Cat } from '../_model/models';

describe('CatService', () => {
    beforeEach(() => {
        TestBed.configureTestingModule({
            providers: [CatService],
            imports: [HttpModule]
        });
    });

    it('should be created', inject([CatService], (service: CatService) => {
        expect(service).toBeTruthy();
    }));

    it('should return a list of cats', inject([CatService], (service: CatService) => {
        service.getLeaderboard().subscribe(cats => {
            expect(cats).toBeDefined();
            expect(cats.length).toBeGreaterThan(0);
        });
    }));

    it('should return a cat', inject([CatService], (service: CatService) => {
        service.getCat('c8a').subscribe(cat => {
            expect(cat).toBeDefined();
            expect(cat.catId).toBe('c8a');
        });
    }));
});
