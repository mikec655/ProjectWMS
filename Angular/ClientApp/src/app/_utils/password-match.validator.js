"use strict";
// @Author: Jason Watmore
// @Source: https://jasonwatmore.com/post/2018/11/07/angular-7-reactive-forms-validation-example
Object.defineProperty(exports, "__esModule", { value: true });
// custom validator to check that two fields match
function MustMatch(controlName, matchingControlName) {
    return function (formGroup) {
        var control = formGroup.controls[controlName];
        var matchingControl = formGroup.controls[matchingControlName];
        if (matchingControl.errors && !matchingControl.errors.mustMatch) {
            // return if another validator has already found an error on the matchingControl
            return;
        }
        // set error on matchingControl if validation fails
        if (control.value !== matchingControl.value) {
            matchingControl.setErrors({ mustMatch: true });
        }
        else {
            matchingControl.setErrors(null);
        }
    };
}
exports.MustMatch = MustMatch;
//# sourceMappingURL=password-match.js.map