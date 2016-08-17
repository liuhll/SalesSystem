(function() {
    $(function() {
        $('.lottery-seed').click(function () {
            $.ajax({
                url: $(this).data('url'),
                type: "GET",
                data: { id: $(this).attr('id') },
                dataType: "html",
                success: function(data) {
                    $('#modal-dialog').html(data);
                }
            });
        });
    });
})();