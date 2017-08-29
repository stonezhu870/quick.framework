var jutils = {};

//页面上只有一个grid的时候获取权限按钮
jutils.loadToolBar = function (gridId) {
    var toolbarDiv = $.CurrentNavtab.find(gridId+' .datagrid-toolbar');
    if ($(toolbarDiv).length > 0) {
        //console.log('显示toolbar');
        var toolbarButtons = initToolBar();
        $(toolbarDiv).html(toolbarButtons);
    } else {
       // console.log('不显示toolbar');
    }
}

//添加额外按钮
jutils.loadToolBarExt=function(gridId,extButtons) {
    var toolbarDiv = $.CurrentNavtab.find(gridId+' .datagrid-toolbar');
    if ($(toolbarDiv).length > 0) {
        //console.log('显示toolbar');
        var toolbarButtons = initToolBar(extButtons);
        $(toolbarDiv).html(toolbarButtons);
    } else {
        // console.log('不显示toolbar');
    }
}

//extButton对象： [{text:'按钮',func:'add',icon:'tag'}]
function initToolBar(extButtons) {



    var html = '';
    html += '<div class="btn-group" role="group">';
    html += '<button type="button" class="btn btn-blue" data-icon="plus" onclick="add()"><i class="fa fa-plus"></i> 添加</button>';
    html += '<button type="button" class="btn btn-green" data-icon="edit" onclick="edit()"><i class="fa fa-edit"></i> 编辑</button>';
    html += '<button type="button" class="btn btn-red" data-icon="times" onclick="del()"><i class="fa fa-times"></i> 删除</button>';

    html += '</div>';

    var extHtml = '';
    if ($.isArray(extButtons)) {
        if (extButtons.length > 0) {
            extHtml += '<div class="btn-group" role="group">';
            for (var i = 0; i < extButtons.length; i++) {
                var exbtn = extButtons[i];
                extHtml += '<button type="button" class="btn btn-blue" data-icon="' + exbtn.icon + 'plus" onclick="' + exbtn.func+ '()"><i class="fa fa-' + exbtn.icon + '"></i> '+exbtn.text+'</button>';
            }
            extHtml += '</div>';
        }
    }

    if (extHtml !== '') {
        html += extHtml;
    }
    //html += '<div class="btn-group" role="group">';
    //html += '<button type="button" class="btn btn-orange" data-icon="undo" onclick="undo()"><i class="fa fa-undo"></i> 取消</button>';
    //html += '<button type="button" class="btn btn-default" data-icon="save" onclick="save()"><i class="fa fa-save"></i> 保存</button>';
    //html += '</div>';
    //html += '<div class="btn-group" role="group">';
    //html += '<button type="button" class="btn btn-green" data-icon="refresh" onclick="refresh()"><i class="fa fa-refresh"></i> 刷新</button>';
    //html += '</div>';
    //html += '<div class="btn-group" role="group">';
    //html += '<button type="button" class="btn btn-blue" data-icon="sign-in" onclick="import()"><i class="fa fa-sign-in"></i> 导入</button>';
    //html += '<button type="button" class="btn btn-green" data-icon="sign-out" onclick="export()"><i class="fa fa-sign-out"></i> 导出</button>';
    //html += '<button type="button" class="btn btn-green" data-icon="filter" onclick="filter()"><i class="fa fa-filter"></i> 导出筛选</button>';
    //html += '</div>';
    return html;
}

//信息提示 确认
jutils.confirm=function(msg,okfunc,cancelfunc) {
    msg = msg || '你确定要执行该操作吗';
    BJUI.alertmsg('confirm',msg, {
        okCall: function() {
           if ($.isFunction(okfunc)) {
               okfunc();
           }
        },
        cancelCall: function () {
        }
    });
}
//ok提示
jutils.ok = function (msg, okfunc) {
    msg = msg || '操作成功';
    BJUI.alertmsg('ok', msg, {
        okCall: function () {
            if ($.isFunction(okfunc)) {
                okfunc();
            }
        }

    });
}
//普通信息提示
jutils.info = function (msg, okfunc) {
    msg = msg || '信息提示';
    BJUI.alertmsg('info', msg, {
        okCall: function () {
            if ($.isFunction(okfunc)) {
                okfunc();
            }
        }

    });
}
//警告
jutils.warn = function (msg, okfunc) {
    msg = msg || '信息提示';
    BJUI.alertmsg('warn', msg, {
        okCall: function () {
            if ($.isFunction(okfunc)) {
                okfunc();
            }
        }

    });
}

jutils.ajax = function (reqType,url, data, func) {
    BJUI.ajax('doajax', {
        url: url,
        type: reqType,
        data: data,
        loadingmask: true,
        okalert: false,
        //ajaxTimeout: 10,
        callback: function (json, options) {
            if ($.isFunction(func)) {
                func(json);
            }
        },
        failCallback:function() {
            BJUI.alertmsg('error', '请求失败！');
        },
        errCallback:function() {
            BJUI.alertmsg('error', '请求出错！');
        }
    });
}

jutils.ajaxGet=function(url,data,okfunc) {
    BJUI.ajax('doajax', {
        url: url,
        type: 'get',
        data: data,
        loadingmask: true,
        //ajaxTimeout:10,
        okCallback: function (json, options) {
            if ($.isFunction(okfunc)) {
                okfunc(json);
            }
        },
        failCallback: function () {
            BJUI.alertmsg('error', '请求失败！');
        },
        errCallback: function () {
            BJUI.alertmsg('error', '请求出错！');
        }
    });
}
jutils.ajaxPost = function (url, data, okfunc) {
    BJUI.ajax('doajax', {
        url: url,
        type: 'post',
        data: data,
        loadingmask: true,
        //ajaxTimeout: 10,
        okCallback: function (json, options) {
            if ($.isFunction(okfunc)) {
                okfunc(json);
            }
        },
        failCallback: function () {
            BJUI.alertmsg('error', '请求失败！');
        },
        errCallback: function () {
            BJUI.alertmsg('error', '请求出错！');
        }
    });
}

//dialog弹框
jutils.dialog = function (id, url, title, width, height,closeFunc) {
    var did = id || 'bjui-new-dialog';
    var dtitle = title || '弹框';
    var dwight = width || 800;
    var dheight = height || 500;
    BJUI.dialog({
        id: did,
        url: url,
        title: dtitle,
        width: dwight,
        height: dheight,
        mask: true,
        onClose: function () {
          if ($.isFunction(closeFunc)) {
              closeFunc();
          }
        }
    });
}
//填充表单
jutils.loadFormData = function (form, data) {
    if (form == null || typeof data == "undefined")
        return;
    for(var name in data) {
        var val = data[name];
        //!_checkField(name, val&& !_npCombotreeField(name, val)
        if (!_checkField(name, val)) {
            form.find("input[name=\"" + name + "\"]").val(val);
            form.find("textarea[name=\"" + name + "\"]").val(val);
            form.find("select[name=\"" + name + "\"]").val(val);
        }
    }

    function _checkField(pName, pValue) {
        var cc = $(form).find("input[name=\"" + pName + "\"][type=radio], input[name=\"" + pName + "\"][type=checkbox]");
        if (cc.length) {
            //cc._propAttr('checked', false);
            cc.each(function () {
                var f = $(this);
                f.prop("checked", false);
                if (f.val() === String(pValue) || $.inArray(f.val(), $.isArray(pValue) ? pValue : [pValue]) >= 0) {
                    f.prop("checked", true);
                }
            });
            return true;
        }
        return false;
    }

};