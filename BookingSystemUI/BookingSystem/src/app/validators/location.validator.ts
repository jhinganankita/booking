import { FormGroup } from '@angular/forms';

export function LocationValidator(controlName: string, matchingControlName: string){
  return (formGroup: FormGroup) => {
      const control = formGroup.controls[controlName];
      const matchingControl = formGroup.controls[matchingControlName];
      if (matchingControl.errors && !matchingControl.errors['locationValidator']) {
          return;
      }
      if (control.value == matchingControl.value) {
          matchingControl.setErrors({ locationValidator: true });
      } else {
          matchingControl.setErrors(null);
      }
  }
}
