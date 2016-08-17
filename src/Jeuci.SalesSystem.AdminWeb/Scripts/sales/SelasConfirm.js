(function() {
    $(function() {
        $('#btn-confirm').on('click', function(e) {
            e.preventDefault();
            debugger;
            abp.ui.setBusy('#myModal',
                abp.ajax({
                    url: abp.appPath + "Sales/SalesSoftware/SalesService",
                    type: 'POST',
                    data: JSON.stringify($('#form1').serializeJSON())
                   
                }));

            $('#myModal').modal('hide');
        });
    });
})()