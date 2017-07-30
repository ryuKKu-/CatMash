import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'plusMinus'
})
export class PlusMinusPipe implements PipeTransform {
    transform(value: number, args?: any): string {
        return value > 0 ? `+${value}` : `${value}`;
    }
}
