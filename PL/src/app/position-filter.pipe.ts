import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'positionFilter'
})
export class PositionFilterPipe implements PipeTransform {

  transform(value: any, input: string): any {
    if (input) {
      return value.filter(val => val.position.toUpperCase().includes(input.toUpperCase()));
    }
    else {
      return value;
    }
  }
}
