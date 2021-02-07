import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'nameFilter'
})
export class NameFilterPipe implements PipeTransform {

  transform(value: any, input: string): any {
    if (input) {
      return value.filter(val => val.name.toUpperCase().includes(input.toUpperCase()));
    }
    else {
      return value;
    }
  }
}
