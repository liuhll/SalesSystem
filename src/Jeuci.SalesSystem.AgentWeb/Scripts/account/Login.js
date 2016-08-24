(function () {
    $(function () {
        $('#LoginButton').click(function (e) {
            e.preventDefault();
            abp.ui.setBusy(
                $('#LoginArea'),
                abp.ajax({
                    url: abp.appPath + 'Account/Login?returnUrl=' + $('#ReturnUrl').val(),
                    type: 'POST',
                    data: JSON.stringify({
                        userName: $('#UserNameInput').val(),
                        password: encryptPassword($('#UserNameInput').val(), $('#PasswordInput').val()),//$('#PasswordInput').val(),
                        rememberMe: $('#RememberMeInput').is(':checked')
                    })
                })
            );
        });
    });

    function encryptPassword(nameStr, passwordStr) {
        var passwordStrSha256 = SHA256Encrypt(passwordStr);
        var privateSha256 = SHA256Encrypt(nameStr + passwordStrSha256);
        return privateSha256;
    }

})();