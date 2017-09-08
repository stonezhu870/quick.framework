var clients = {};
$(function () {
    clients = $.clientsInit();
    $.menuInit();
});
$.clientsInit = function () {
    var dataJson = {
        user: {},
        menu: []
    };
    var init = function () {
        $.ajax({
            async: false,
            url: "/Home/GetRoleMenu",
            type: "GET",
            data: null,
            cache: false,
            dataType: 'json',
            success: function (res, textStatus, jqXHr) {
                if (res.Status) {
                    //dataJson.user = res.MyObjectA;
                    dataJson.menu = res.Data;
                } else {
                    dataJson.user.id = '';
                }
            }

        });

    };

    init();
    return dataJson;
}
$.menuInit = function () {
    //console.log(clients.menu);
    $('#bjui-hnav-navbar li a').on('click', function () {
        var id = $(this).attr('data-id');
        var title = $(this).attr('data-title');
        var pli = $(this).parent();
        if (id !== '') {

            var childmenu = getchildMenus(id);
            renderSideBar(childmenu, title);
        }
        $(pli).siblings().removeClass("active");
        $(pli).addClass("active");
    });

    //$("#bjui-sidenav-box").on("click", ".nav > li > a", function () {
    //    var datatitle = $(this).attr("data-title");
    //    var dataurl = $(this).attr("data-url");
    //    // var title = $(this).html();
    //   // console.log(datatitle);
    //    //console.log(dataurl);
    //    //taburl(dataurl, dataid, title);
    //});
}

function renderSideBar(data, pname) {
    if (!$.isArray(data)) {
        return;
    }

    var html = '';
    var dlen = data.length;
    if (dlen === 0) {
        $('#bjui-sidenav-box').html('');
    }
    html += '<ul class="nav">';
    //for (var j = 0; j < dlen; j++) {
       var j = 0;
        if (j === 0) {
            html += '<li class="open">';
        } else {
            html += '<li>';
        }

        html += '<a href="javascript:void(0);" class="right-arrow">';
        html += '<i class="fa fa-caret-right"></i>&nbsp;' + pname + '<b><i class="fa fa-angle-right"></i></b></a>';

        var dchild = data;
        if (dchild.length > 0) {
            html += '<ul class="nav" style="display: block;">';
            var dlength = dchild.length;
            var dataItem = dchild;
            for (var i = 0; i < dlength; i++) {
                html += '<li class="navtab-base-navtab">';
                html += '<a href="javascript:void(0);" onclick="showtab(this)" data-id="' + dataItem[i].id+ '" data-url="' + dataItem[i].menu_url + '" data-title="' + dataItem[i].menu_name + '">';
                html += '<i class="fa fa-caret-right"></i>&nbsp;' + dataItem[i].menu_name + '</a>';
                html += '</li>';
            }
            html += '</ul></li>';
        }

    //}
    html += '</ul>';

    $('#bjui-sidenav-box').html(html);

}


function showtab(obj) {
    var datatitle = $(obj).attr("data-title");
    var dataurl = $(obj).attr("data-url");
    var dataid = $(obj).attr("data-id");
    // var title = $(this).html();
    //console.log(datatitle);
    //console.log(dataurl);

    var tabid = 'bjui-new-tab';
    //BJUI.navtab('closeTab', tabid);
    BJUI.navtab('closeAllTab');
    BJUI.navtab({
        //external:true,
        id: tabid,
        url: dataurl,
        title: datatitle
    });
    locache.set("pageid", dataid);
}


//获取子菜单
function getchildMenus(pid) {
    var list = [];
    var menuList = clients.menu;
    if (menuList.length > 0) {

        $.each(menuList, function (i, v) {
            if (v.parent_id == pid) {
                list.push(v);
            }
        });
    }

    return list;
}


function modifyPwd() {
    jutils.dialog('changePwd', '/Login/ModifyPwd','密码修改');
}