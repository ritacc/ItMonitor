$(document).ready(function () {
    var layout = $.getLayout(window.top);
    var divmain = $(".divgrid");
    if (divmain.height() < layout.innerHeight - 180) {
        var overflow_grid = $(".overflow_grid");
        var height = layout.innerHeight - 272;
        overflow_grid.height(height);
    }
});