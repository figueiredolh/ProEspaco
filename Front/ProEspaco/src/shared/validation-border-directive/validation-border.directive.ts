import { Directive, HostBinding } from '@angular/core';
import { NgControl } from '@angular/forms';

@Directive({
  selector: '[ValidationBorder]'
})
export class ValidationBorderDirective {

  constructor(private ngControl: NgControl) { }

  @HostBinding('style.borderColor')
  get borderColor(){
    return this.ngControl.errors && this.ngControl.touched ? 'red' : null;
  }

}
