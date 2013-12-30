/* File Created: December 27, 2013 */

/*----------------------------------------------*/

$(function () {
    $(".accordion").accordion();
});

$(function () {
    $(".sortable tbody").sortable();
    $(".sortable tbody").disableSelection();
});

/* JQUERY WIDGET: AUTOCOMPLETE */
$(function () {
    //Definir esta variable en el formulario !!! Antes de llamar este script
    var cursosDisponibles = [
      "ActionScript",
      "AppleScript",
      "Asp",
      "BASIC",
      "C",
      "C++",
      "Clojure",
      "COBOL",
      "ColdFusion",
      "Erlang",
      "Fortran",
      "Groovy",
      "Haskell",
      "Java",
      "JavaScript",
      "Lisp",
      "Perl",
      "PHP",
      "Python",
      "Ruby",
      "Scala",
      "Scheme"
    ];
    $(".autocomplete").autocomplete({
        source: cursosDisponibles
    });
});
//(function ($) {

//    var allPanels = $('.accordion > div').hide();

//    $('.accordion > dt > a').click(function () {
//        allPanels.slideUp();
//        $(this).parent().next().slideDown();
//        return false;
//    });

//})(jQuery);