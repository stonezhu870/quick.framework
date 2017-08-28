$(function () {
    //var i = 2;
    //alert(i++ * ++i);

    $('#bjui-hnav-navbar li a').on('click', function () {
        var id = $(this).attr('data-id');
        if (id === 'datagridTab') {
            BJUI.ajax('doajax', {
                url: '/Plugins/B-JUI/json/menu-base.json',
                //loadingmask: true,
                type: 'get',
                okCallback: function (json, options) {
                    renderSideBar(json);
                }
            });
        }

    });

    $("#bjui-sidenav-box").on("click", ".nav > li > a", function () {
        var datatitle = $(this).attr("data-title");
        var dataurl = $(this).attr("data-url");
        // var title = $(this).html();
        console.log(datatitle);
        console.log(dataurl);
        //taburl(dataurl, dataid, title);
    });
});

function renderSideBar(data) {
    if (!$.isArray(data)) {
        return;
    }

    var html = '';
    var dlen = data.length;
    if (dlen === 0) {
        $('#bjui-sidenav-box').html('');
    }
    html += '<ul class="nav">';
    for (var j = 0; j < dlen; j++) {
        if (j === 0) {
            html += '<li class="open">';
        } else {
            html += '<li>';
        }

        html += '<a href="javascript:void(0);" class="right-arrow">';
        html += '<i class="fa fa-caret-right"></i>&nbsp;' + data[j].name + '<b><i class="fa fa-angle-right"></i></b></a>';

        var dchild = data[j].children;
        if (dchild.length > 0) {
            html += '<ul class="nav" style="display: block;">';
            var dlength = dchild.length;
            var dataItem = dchild;
            for (var i = 0; i < dlength; i++) {
                html += '<li class="navtab-base-navtab">';
                html += '<a href="javascript:void(0);" onclick="showtab(this)" data-url="' + dataItem[i].url + '" data-title="' + dataItem[i].name + '">';
                html += '<i class="fa fa-caret-right"></i>&nbsp;' + dataItem[i].name + '</a>';
                html += '</li>';
            }
            html += '</ul></li>';
        }

    }
    html += '</ul>';

    $('#bjui-sidenav-box').html(html);

}


function showtab(obj) {
    var datatitle = $(obj).attr("data-title");
    var dataurl = $(obj).attr("data-url");
    // var title = $(this).html();
    console.log(datatitle);
    console.log(dataurl);

    var tabid = 'bjui-new-tab';
    BJUI.navtab('closeTab', tabid);
    BJUI.navtab({
        //external:true,
        id: tabid,
        url: dataurl,
        title: datatitle
    });
}