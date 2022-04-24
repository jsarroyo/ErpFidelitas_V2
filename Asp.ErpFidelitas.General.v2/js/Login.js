 

var LoginJS = function(){
    email: $("#txtEmail").val();
    password: $("#txtPassword").val();

    this.Iniciologin = function () {
        $("#txtEmail").val("");
        $("#txtPassword").val("");

        $("#txtEmailValidationText").text("");
        $("#txtPasswordValidationText").text("");

/*        $("#lnkLogin").click(function (e) { userOne.login(); });*/
        $("#formLogin").submit(userOne.login);
        $("#formRegister").submit(userOne.register);
        $("#txtEmail").keypress(function (e) { userOne.EliminaMensajes(); });
        $("#txtPassword").keypress(function (e) { userOne.EliminaMensajes(); });
    };

    this.login = function () {
        email = $("#txtEmail").val();
        password= $("#txtPassword").val();

        //validations
        if (IsEmpty(email)) {
            $("#txtEmailValidationText").text("Debe indicar el email");
            alertify.alert('Debe indicar el email');
            $("#txtEmail").focus();
            return false;
        }
        if (IsUndefined(email)) {
            $("#txtEmailValidationText").text("Debe indicar el email");
            alertify.alert('Debe indicar el email');
            $("#txtEmail").focus();
            return false;
        }
        if (IsEmpty(password)) {
            $("#txtPasswordValidationText").text("Debe indicar la contraseña.");
            alertify.alert('Debe indicar la contraseña');
            $("#txtPassword").focus();
            return false;
        }
        if (IsUndefined(password)) {
            $("#txtEmailValidationText").text("Debe indicar la contraseña");
            alertify.alert('Debe indicar el email');
            $("#txtEmail").focus();
            return false;
        }
        if (!IsValidEmailFormat()) {
            alertify.alert('Formato de email incorrecto.')
            return false;
        }

        return true;
    };

    this.register = function () {
        email = $("#txtEmail").val();
        name = $("#txtName").val();
        username = $("#txtUserName").val();
        password = $("#txtPassword").val();
        password2 = $("#txtPassword2").val();
        if (password != password2) {
            alertify.alert('Las contraseñas no coinciden');
            $("#txtPassword").focus();
            return false;
        }

        if (IsEmpty(email)) {
            $("#txtEmailValidationText").text("Debe indicar el email");
            alertify.alert('Debe indicar el email');
            $("#txtEmail").focus();
            return false;
        }
        if (IsUndefined(email)) {
            $("#txtEmailValidationText").text("Debe indicar el email");
            alertify.alert('Debe indicar el email');
            $("#txtEmail").focus();
            return false;
        }
        if (IsEmpty(name)) {
            alertify.alert('Debe indicar un nombre');
            $("#txtName").focus();
            return false;
        }
        if (IsUndefined(name)) {
            alertify.alert('Debe indicar un nombre');
            $("#txtName").focus();
            return false;
        }
        if (IsEmpty(username)) {
            alertify.alert('Debe indicar un nombre de usuario');
            $("#txtUserName").focus();
            return false;
        }
        if (IsUndefined(username)) {
            alertify.alert('Debe indicar un nombre de usuario');
            $("#txtUserName").focus();
            return false;
        }
        if (IsEmpty(password)) {
            $("#txtPasswordValidationText").text("Debe indicar la contraseña.");
            alertify.alert('Debe indicar la contraseña');
            $("#txtPassword").focus();
            return false;
        }
        if (IsUndefined(password)) {
            $("#txtEmailValidationText").text("Debe indicar el email");
            alertify.alert('Debe indicar el email');
            $("#txtEmail").focus();
            return false;
        } if (IsEmpty(password2)) {
            alertify.alert('Debe indicar la contraseña de verificación.');
            $("#txtPassword2").focus();
            return false;
        }
        if (IsUndefined(password2)) {
            alertify.alert('Debe indicar la contraseña de verificación.');
            $("#txtPassword2").focus();
            return false;
        }
        if (!IsValidEmailFormat()) {
            alertify.alert('Formato de email incorrecto.')
            return false;
        }

        return true;
    }

    this.EliminaMensajes = function () {
        if ($("#txtEmail").val().length >= 1) {
            $("#txtEmailValidationText").text(""); 
        }
        if ($("#txtPassword").val().length >= 1) { 
            $("#txtPasswordValidationText").text("");
        }
    };
    this.logout = function () {
        console.log(this.email, 'has logged out');
    };

    function IsValidEmailFormat() {
        var EmailRegex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
        return EmailRegex.test(email);
    }
    function IsEmpty(mystr) {
        return (mystr =="");
    }
    function IsUndefined(mystr) {
        return (mystr == undefined);
    }
};
var userOne = new LoginJS();
 