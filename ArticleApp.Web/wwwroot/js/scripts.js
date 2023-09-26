/*!
* Start Bootstrap - Clean Blog v6.0.9 (https://startbootstrap.com/theme/clean-blog)
* Copyright 2013-2023 Start Bootstrap
* Licensed under MIT (https://github.com/StartBootstrap/startbootstrap-clean-blog/blob/master/LICENSE)
*/
window.addEventListener('DOMContentLoaded', () => {
    let scrollPos = 0;
    const mainNav = document.getElementById('mainNav');
    const headerHeight = mainNav.clientHeight;
    window.addEventListener('scroll', function() {
        const currentTop = document.body.getBoundingClientRect().top * -1;
        if ( currentTop < scrollPos) {
            // Scrolling Up
            if (currentTop > 0 && mainNav.classList.contains('is-fixed')) {
                mainNav.classList.add('is-visible');
            } else {
                console.log(123);
                mainNav.classList.remove('is-visible', 'is-fixed');
            }
        } else {
            // Scrolling Down
            mainNav.classList.remove(['is-visible']);
            if (currentTop > headerHeight && !mainNav.classList.contains('is-fixed')) {
                mainNav.classList.add('is-fixed');
            }
        }
        scrollPos = currentTop;
    });
})


$(document).ready(function () {

     //For Card Number formatted input
     var cardNum = document.getElementById('cr_no');
     cardNum.onkeyup = function (e) {
          if (this.value == this.lastValue) return;
          var caretPosition = this.selectionStart;
          var sanitizedValue = this.value.replace(/[^0-9]/gi, '');
          var parts = [];

          for (var i = 0, len = sanitizedValue.length; i < len; i += 4) {
               parts.push(sanitizedValue.substring(i, i + 4));
          }

          for (var i = caretPosition - 1; i >= 0; i--) {
               var c = this.value[i];
               if (c < '0' || c > '9') {
                    caretPosition--;
               }
          }
          caretPosition += Math.floor(caretPosition / 4);

          this.value = this.lastValue = parts.join('-');
          this.selectionStart = this.selectionEnd = caretPosition;
     }

     //For Date formatted input
     var expDate = document.getElementById('exp');
     expDate.onkeyup = function (e) {
          if (this.value == this.lastValue) return;
          var caretPosition = this.selectionStart;
          var sanitizedValue = this.value.replace(/[^0-9]/gi, '');
          var parts = [];

          for (var i = 0, len = sanitizedValue.length; i < len; i += 2) {
               parts.push(sanitizedValue.substring(i, i + 2));
          }

          for (var i = caretPosition - 1; i >= 0; i--) {
               var c = this.value[i];
               if (c < '0' || c > '9') {
                    caretPosition--;
               }
          }
          caretPosition += Math.floor(caretPosition / 2);

          this.value = this.lastValue = parts.join('/');
          this.selectionStart = this.selectionEnd = caretPosition;
     }

     // Radio button
     $('.radio-group .radio').click(function () {
          $(this).parent().find('.radio').removeClass('selected');
          $(this).addClass('selected');
     });

})