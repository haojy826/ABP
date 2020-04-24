//------------------------系统管理-->组织信息--------------------------------//
//显示数据
function initable() {
    $("#dgOrg").treegrid({
        //url: "/Orgs/List",//通过控制器中的list方法获取数据
       url: abp.appPath + "api/services/app/org/GetAllOrgs",//修改
        method: "GET",//修改
        title: "组织管理",
        //pagination: false,
        pagination: true,//开启分页功能
        pageSize: 2,//默认页面数量
        pageList: [2, 10, 20],//分页列表框
        fit: true,
        fitColumns: false,
        loadMsg: "正在加载组织信息...",
        nowarp: false,
        border: false,
        // idField: "Id",//    //idField指定的是对象的code（为唯一值）非父code
       //sortName: "Id",
        idField: "id",//修改，将服务器端使用的数据改成小驼峰式
        sortName: "id",//修改，将服务器端使用的数据改成小驼峰式
        sortOrder: "asc",
        // treeField: "Name",//指定文件夹在哪一列
       treeField: "name",//修改，将服务器端使用的数据改成小驼峰式
        frozenColumns: [[//冻结列
            {
                field: "chk", checkbox: true, align: "left", width: 50
            }

        ]],
        columns: [[
            { title: "编号", field: "id", width: 50, sortable: true },
            { title: "组织名称", field: "name", width: 200, sortable: true },
            { title: "代码", field: "bizCode", width: 100, sortable: true },
            { title: "海关代码", field: "customCode", width: 100, sortable: true },
            { title: "状态", field: "status", width: 80, sortable: false },
            { title: "类型", field: "type", width: 80, sortable: false },
            { title: "父节点", field: "parentName", width: 120, sortable: false },
            { title: '创建时间', field: 'creationTime', width: 130, align: 'center' }
        ]]
        /* columns: [[
            { title: "编号", field: "Id", width: 50, sortable: true },
            { title: "组织名称", field: "Name", width: 200, sortable: true },
            { title: "代码", field: "BizCode", width: 100, sortable: true },
            { title: "海关代码", field: "CustomCode", width: 100, sortable: true },
            { title: "状态", field: "Status", width: 80, sortable: false },
            { title: "类型", field: "Type", width: 80, sortable: false },
            { title: "父节点", field: "ParentName", width: 120, sortable: false },

            { title: '创建时间', field: 'CreationTime', width: 130, align: 'center' }
        ]]*/
       
   });
}

function reloaded() {   //reload

    $("#reload").click(function () {
        $('#dgOrg').treegrid('reload');
    });
}

//修改点击按钮事件
function updOrgInfo() {

    $("#edit").click(function () {
        BindTree();//表单中有一个空需要显示所有节点名称

        //判断选择的行
        var row = $("#dgOrg").treegrid('getSelected');
        if (row) {//已经选中某一行信息
            $.messager.confirm('编辑', '您想要编辑吗？', function (r) {//$.messager.confirm(title, msg, fn) easyUI的方法
                if (r) {
                    //先绑定 ，把数据库中的数据显示到表单上                  
                    showOrg(row);

                    //打开对话框编辑，以模态框的形式打开
                    $("#divAddUpdOrg").dialog({
                        closed: false,
                        title: "修改组织信息",
                        modal: true,
                        width: 600,
                        height: 450,
                        collapsible: true,
                        minimizable: true,
                        maximizable: true,
                        resizable: true,
                    });
                   
                }
            });
            
        }
        else
        {
            $.messager.alert('提示', ' 请选择要编辑的行！', 'warning');
        }
    });
}

//删除
function deleteOrg() {
    $("#del").click(function () {
        var rows = $("#dgOrg").datagrid("getSelections");
        if (rows.length > 0) {//已经选中一行或者多行信息
            $.messager.confirm("提示", "确定要删除吗?", function (res) {
                if (res) {
                    var codes = []; //重要不是{}
                    for (var i = 0; i < rows.length; i++) {//一行一行的进行删除
                        codes.push(rows[i].id);//将Id放到数组中
                        _orgService.delete({//调用删除的方法根据Id进行删除
                            id: rows[i].id
                        }).done(function () {
                            $.messager.alert("提示", "删除成功！");
                            $("#dgOrg").datagrid("clearChecked");
                            $("#dgOrg").datagrid("clearSelections");
                            $('#dgOrg').treegrid('reload');
                        });
                    }
                }
            });
        }
        else {
            $.messager.alert('提示', ' 请选择要删除的行！', 'warning');

        }
    })
}

//清空文本框
function clearAll() {
    $("#IDUpdate").val("");
    $("#UpdBizCode").val("");
    $("#NameUpdate").val("");
    $("#UpdCustomCode").val("");
    $("#UpdStatus").val("");
    $("#UpdIconName").val("");
    $("#UpdType").val("");

    $(':input[name]', this).each(function () {
        $(this).val("");
    });

}

var _orgService = abp.services.app.org;//webapi实现
var _$modal = $("#divAddUpdOrg").parent();
var _$form = _$modal.find('form');

//弹出 添加对话框
function showOrgDialog() {

    $("#add").click(function () {
        clearAll();
        BindTree();

        $("#divAddUpdOrg").dialog({
            closed: false,
            title: "添加组织信息",
            modal: true,
            width: 600,
            height: 450,
            collapsible: true,
            minimizable: true,
            maximizable: true,
            resizable: true
        });
    });


    //保存按钮
    $("#btnSave").click(function () {
        //保存
        if (!_$form.valid()) {
            return;
        }
        var id = $("#IDUpdate").val();
        if (id == "" || id == undefined || id == "0") {
            //验证
            $.messager.confirm('确认', '您确认要保存吗？', function (r) {
                if (r) {

                    $("#IDUpdate").val("0");
                    var postData = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js
                    if (postData == null || postData == undefined || postData.name == "" || postData.bizCode == "") {
                        $.messager.alert('提示', ' 请填写相关必填项！', 'warning');

                        return;
                    }

                    abp.ui.setBusy(_$modal);
                    _orgService.create(postData).done(function () {

                        $.messager.alert("提示", "保存成功！");
                        $("#IDUpdate").val("");
                        _$modal.modal('hide');
                        $("#divAddUpdOrg").dialog("close");
                        initable(); //reload page to see new user!

                    }).always(function () {
                        abp.ui.clearBusy(_$modal);

                    });
                }
            })
        }
        else {
            saveDetail();
        }
    });
    //取消按钮
    $("#btnCancle").click(function () { $("#divAddUpdOrg").dialog("close"); });
}

//修改数据保存，这里貌似没有使用到
function saveDetail() {
    if (!_$form.valid()) {
        return;
    }
    $.messager.confirm('确认', '您确认要修改吗？', function (r) {

        var postData = _$form.serializeFormToObject();
        if (postData == null || postData == undefined || postData.bizCode == "" || postData.name == "") {
            $.messager.alert('提示', ' 请填写相关必填项！', 'warning');
            return;
        }

        abp.ui.setBusy(_$modal);
        _orgService.update(postData).done(function () {
            $.messager.alert("提示", "修改成功！");
            _$modal.modal('hide');
            $("#divAddUpdOrg").dialog("close");
            initable(); //reload page to see new user!

        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });

    })
}
//修改时，获取数据库中的信息到表单页面
function showOrg(row) {
    $("#IDUpdate").val(row.id);
    $("#NameUpdate").val(row.name);
    $("#UpdBizCode").val(row.bizCode);

    $("#UpdType").val(row.type);
    $("#UpdCustomCode").val(row.customCode);
    $("#UpdIsAutoExpand").val(row.isAutoExpand);

    $("#UpdIsLeaf").val(row.isLeaf);
    $("#UpdStatus").val(row.status);
    $("#UpdHotKey").val(row.hotKey);

    $("#UpdIconName").val(row.iconName);
    $("#RemarkUpdate").val(row.remark);

    $("#AddTree").combotree('setValue', row.parentId);
    $("#AddTree").combotree('setText', row.parentName);
    $('#UpdParentId').val(row.parentId);
    $('#UpdParentName').val(row.parentName);

}
//显示选项中的树形分支信息
function BindTree() {
    $('#AddTree').combotree({
        url: '/Orgs/GetJsonTree',//控制器中的方法，获取所有节点的信息

        valueField: 'id',
        textField: 'name',
        multiple: false,
        editable: false,
        method: 'get',
        panelHeight: 'auto',
        checkbox: false,
        //required: true,
        //全部折叠

        onLoadSuccess: function (node, data) {
            $('#AddTree').combotree('tree').tree("expandAll"); //collapseAll
        },
        onSelect: function (node) {
            $('#UpdParentName').val(node.text);
            $("#UpdParentId").val(node.id);
        }
    });
}
//------------------------系统管理-->组织信息结束------------------------------//