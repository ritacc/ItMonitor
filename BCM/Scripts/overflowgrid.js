
$(document).ready(function () {
    var layout = $.getLayout(window);

    var overflow_grid = $(".overflow_grid_select");
    var height = layout.innerHeight - 275;
    if (overflow_grid.height() < height) {
        overflow_grid.height(height);
    }

    var overflow = $(".overflow_grid");
    var gridheight = layout.innerHeight - 241;

    if (overflow.height() < gridheight) {
        overflow.height(gridheight);
    }

    var idoverflow = $("#overgrid");
    if (idoverflow.height() < gridheight) {
        idoverflow.height(gridheight);
    }

    var Defaultoverflow_grid = $(".page_overflow_grid");
    var defaultgridheight = layout.innerHeight - 211;
    if (Defaultoverflow_grid.height() < defaultgridheight) {
        Defaultoverflow_grid.height(defaultgridheight);
    }

    var divNoOther = $(".ClassNoOther");
    var varNother = layout.innerHeight - 187;
    if (divNoOther.height() < varNother) {
        divNoOther.height(varNother);
    }


    $(window).resize(function () {
        var layout = $.getLayout(window);
        var height = layout.innerHeight - 275;
        if (overflow_grid.height() < height) {
            overflow_grid.height(height);
        }

        var gridheight = layout.innerHeight - 241;
        if (overflow.height() < gridheight) {
            overflow.height(gridheight);
        }

        if (idoverflow.height() < gridheight) {
            idoverflow.height(gridheight);
        }

        var defaultgridheight = layout.innerHeight - 211;
        if (Defaultoverflow_grid.height() < defaultgridheight) {
            Defaultoverflow_grid.height(defaultgridheight);
        }
        //没有其它内容，高度处理
        if (divNoOther.height() < varNother) {
            divNoOther.height(varNother);
        }
    });
});


