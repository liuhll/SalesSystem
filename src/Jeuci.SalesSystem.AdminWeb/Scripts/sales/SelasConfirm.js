(function() {
    $(function() {
        $('#btn-confirm').on('click', function(e) {
            e.preventDefault();
        
            abp.ui.setBusy('#myModal',
                abp.ajax({
                    url: abp.appPath + "Sales/SalesSoftware/SalesService",
                    type: 'POST',
                    data: JSON.stringify($('#form1').serializeJSON())
                   
                }).done(function (data) {
                    debugger;
                    abp.message.success(data["Message"],"成功");
                    $('#myModal').modal('hide');
                  
                }));
        });
    });
})()