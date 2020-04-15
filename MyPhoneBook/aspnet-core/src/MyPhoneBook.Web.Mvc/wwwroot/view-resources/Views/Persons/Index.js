(function () {
    $(function () {
        //类似于localhost:1222/Ipersonservice，abp自动拦截过来的，方便进行编辑
        var _personService = abp.services.app.person;
        //创建编辑联系人模态框
        var _$modal = $("#PersonCreateModal");
        var _$form = _$modal.find('form');
        //创建添加电话号码模态框
        var _$modal1 = $("#PhoneNumberAddModal");
        var _$form1 = _$modal1.find('form');
        //编辑联系人模态框
        var _$modal2 = $("#PersonEditModal");
        var _$form2 = _$modal2.find('form');



        //添加联系人（全部信息的提交）
        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();//取消submit原本的特性，禁止提交，要跟着我的逻辑走
            if (!_$form.valid()) {//jQuery封装的
                return;
            }
            var personEditDto = _$form.serializeFormToObject();//序列化表单为对象，要和JQuery对应，封装好的函数
            //人和电话号码是一对多的关系，所以电话号码是数组
            personEditDto.PhoneNumbers = [];//后台拿到的是数组,先进行声明
            var phoneNumber = {};
            phoneNumber.Type = personEditDto.PhoneNumberType;
            phoneNumber.Number = personEditDto.PhoneNumber;

            personEditDto.PhoneNumbers.push(phoneNumber);//添加到数组里使用push


            abp.ui.setBusy(_$modal);//设置页面繁忙，防止乱提交信息，页面会有加载标志
            //abp约定：使用框架时，约定大于配置。createOrUpdatePerson是调用后台的CreateOrUpdatePersonAsync方法
            _personService.createOrUpdatePerson({ personEditDto }).done(function () {
                _$modal.modal('hide');//模态框隐藏
                refreshPersonList();//数据页面刷新，调用的
            }).always(function () {//关闭页面繁忙设置
                abp.ui.clearBusy(_$modal);
            });

        });

        //编辑联系人（基本信息，除了电话号码的提交）
        _$form2.find('button[type="submit"]').click(function (e) {
            e.preventDefault();//取消submit原本的特性，禁止提交，要跟着我的逻辑走
            if (!_$form2.valid()) {//jQuery封装的
                return;
            }
            var personBaseEditDto = _$form2.serializeFormToObject();//序列化表单为对象，要和JQuery对应，封装好的函数
            //人和电话号码是一对多的关系，所以电话号码是数组
           // personEditDto.PhoneNumbers = [];//后台拿到的是数组,先进行声明
          //  var phoneNumber = {};
          //  phoneNumber.Type = personEditDto.PhoneNumberType;
           // phoneNumber.Number = personEditDto.PhoneNumber;

          //  personEditDto.PhoneNumbers.push(phoneNumber);//添加到数组里使用push


            abp.ui.setBusy(_$modal2);//设置页面繁忙，防止乱提交信息，页面会有加载标志
            //abp约定：使用框架时，约定大于配置。createOrUpdatePerson是调用后台的CreateOrUpdatePersonAsync方法
            _personService.updateBasePerson({ personBaseEditDto }).done(function () {//done这里出错
                _$modal2.modal('hide');//模态框隐藏
                refreshPersonList();//数据页面刷新，调用的
            }).always(function () {//关闭页面繁忙设置
                abp.ui.clearBusy(_$modal2);
            });

        });


        /*  //为了获取添加电话号码的联系人的Id
            var personId;
            $('.btn_add_phonenumber').click(function (e) {
                e.preventDefault();//去消掉默认功能
                personId = $(this).attr("data-person-id");               
            });


        //添加电话号码的提交
      _$form1.find('button[type="submit"]').click(function (e) {
            e.preventDefault();//取消submit原本的特性，禁止提交，要跟着我的逻辑走
            if (!_$form1.valid()) {//jQuery封装的
                return;
           }       
            var phoneNumbersEditDto = _$form1.serializeFormToObject();//序列化表单为对象，要和JQuery对应，封装好的函数
            phoneNumbersEditDto.PersonId = personId;
            //人和电话号码是一对多的关系，所以电话号码是数组
           // phoneNumbersEditDto.PhoneNumbers = [];//后台拿到的是数组,先进行声明
          //  var phoneNumber = {};
            //personEditDto.PhoneNumbers.Type = phoneNumbersEditDto.PhoneNumberType;
            //personEditDto.PhoneNumbers.Number = phoneNumbersEditDto.PhoneNumber;

          //  phoneNumbersEditDto.PhoneNumbers.push(phoneNumber);//添加到数组里使用push


            abp.ui.setBusy(_$modal1);//设置页面繁忙，防止乱提交信息，页面会有加载标志
            //abp约定：使用框架时，约定大于配置。
            _personService.createPhoneNumber({ phoneNumbersEditDto }).done(function () {
                _$modal1.modal('hide');//模态框隐藏
                refreshPersonList();//数据页面刷新，调用的
            }).always(function () {//关闭页面繁忙设置
                abp.ui.clearBusy(_$modal1);
            });

        });

*/

        //为了获取添加电话号码的联系人的Id
        var personId;
        var Name;
        var EmailAddress;
        var Address;
        $('.btn_add_phonenumber').click(function (e) {
            e.preventDefault();//去消掉默认功能
            personId = $(this).attr("data-person-id");
            //除了id和电话号码之外的数据要从数据库中获得
            _personService.getPersonForEdit({ id: personId }).done(function (data) {//回调，使用data接收,首字母都要小写，这是ABP自动生成序列化的规定
                Name = data.person.name;
                EmailAddress = data.person.emailAddress;
                Address = data.person.address;
            });
        });
       //添加电话号码
        _$form1.find('button[type="submit"]').click(function (e) {
            e.preventDefault();//取消submit原本的特性，禁止提交，要跟着我的逻辑走
            if (!_$form1.valid()) {//jQuery封装的
                return;
            }
            var personEditDto = _$form1.serializeFormToObject();//序列化表单为对象，要和JQuery对应，封装好的函数
            personEditDto.Id = personId;
            personEditDto.Name = Name;
            personEditDto.EmailAddress = EmailAddress;
            personEditDto.Address = Address;    
            //人和电话号码是一对多的关系，所以电话号码是数组                      
            personEditDto.PhoneNumbers = [];//后台拿到的是数组,先进行声明
            var phoneNumber = {};
            phoneNumber.Type = personEditDto.PhoneNumberType;
            phoneNumber.Number = personEditDto.PhoneNumber;

            personEditDto.PhoneNumbers.push(phoneNumber);//添加到数组里使用push


            abp.ui.setBusy(_$modal1);//设置页面繁忙，防止乱提交信息，页面会有加载标志
            //abp约定：使用框架时，约定大于配置。createOrUpdatePerson是调用后台的CreateOrUpdatePersonAsync方法
            _personService.createOrUpdatePerson({ personEditDto }).done(function () {
                _$modal1.modal('hide');//模态框隐藏
                refreshPersonList();//数据页面刷新，调用的
            }).always(function () {//关闭页面繁忙设置
                abp.ui.clearBusy(_$modal1);
            });

        });
     
       
        //编辑联系人（基本信息，除了电话号码）这就是把数据库中的数据填写到表单中，为了方便编辑
        $('.edit-person').click(function (e) {
            e.preventDefault();//去消掉默认功能
            var personId = $(this).attr("data-person-id");

            _personService.getPersonForEdit({ id: personId }).done(function (data) {//回调，使用data接收,首字母都要小写，这是ABP自动生成序列化的规定
                $("input[name=Id]").val(data.person.id);
                $("input[name=Name]").val(data.person.name).parent().addClass('focused');
                $("input[name=EmailAddress]").val(data.person.emailAddress).parent().addClass('focused');
                $("input[name=Address]").val(data.person.address).parent().addClass('focused');

            });
        });



        //刷新操作
        $('#RefreshButton').click(function () {
            refreshPersonList();
        });





        //刷新联系人列表，实现复用
        function refreshPersonList() {
            location.reload(true);
        }




 //删除联系人（全部信息，包括电话号码）
        $('.delete-person').click(function () {
            var personId = $(this).attr("data-person-id");
            var personName = $(this).attr('data-person-name');
            deletePerson(personId, personName);
        });

       
        function deletePerson(id, name) {
            abp.message.confirm(
                "是否删除姓名为" + name + "的联系人信息", function (isConfirmed) {
                    if (isConfirmed) {
                        _personService.deletePerson({ id }).done(function () {
                            refreshPersonList();//做完后回调进行刷新
                        });
                    }

                }
            );

        }





        //模态框操作
        $('#PersonCreateModal').on('hide.bs.modal',
            function () {
                // 执行一些动作...
                _$form[0].reset();//表单清空
            });

        $('#PhoneNumberAddModal').on('hide.bs.modal',
            function () {
                // 执行一些动作...
                _$form[0].reset();//表单清空
            });













    });
})();