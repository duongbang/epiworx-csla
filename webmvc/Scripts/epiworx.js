$(function () {
   
    $("input.date").datepicker({
        showButtonPanel: true,
        prevText: "<<",
        nextText: ">>"
    });
   
    $("ul li:first-child").addClass("first");
    $("ul li:last-child").addClass("last");

});