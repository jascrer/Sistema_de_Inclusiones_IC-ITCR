/* File Created: December 27, 2013 */

/*----------------------------------------------*/

$(function () {
    $(".accordion").accordion();
});

$(function () {
    $("#sortable").sortable();
    $("#sortable").disableSelection();
});

//(function ($) {

//    var allPanels = $('.accordion > div').hide();

//    $('.accordion > dt > a').click(function () {
//        allPanels.slideUp();
//        $(this).parent().next().slideDown();
//        return false;
//    });

//})(jQuery);