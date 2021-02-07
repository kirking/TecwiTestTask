import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'ageFilter'
})
export class AgeFilterPipe implements PipeTransform {

  transform(value: any, input: string): any {
    if (input) {
      return value.filter(val => val.age.toString().includes(input));
    }
    else {
      return value;
    }
  }
}
