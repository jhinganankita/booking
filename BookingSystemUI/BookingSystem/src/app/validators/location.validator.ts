import { FormGroup, AbstractControl } from '@angular/forms';

// export function LocationValidator(controlName: string, matchingControlName: string){
//   return (formGroup: FormGroup) => {
//       const control = formGroup.controls[controlName];
//       const matchingControl = formGroup.controls[matchingControlName];
//       if (matchingControl.errors && !matchingControl.errors['locationValidator']) {
//           return;
//       }
//       if (control.value == matchingControl.value) {
//           matchingControl.setErrors({ locationValidator: true });
//       } else {
//           matchingControl.setErrors(null);
//       }
//   }
// }

export function locationValidator(control: AbstractControl): { [key: string]: any } | null {
  const sourceId = control.get('sourceId')?.value;
  const destinationId = control.get('destinationId')?.value;

  return sourceId === destinationId ? { 'locationValidator': true } : null;
}
