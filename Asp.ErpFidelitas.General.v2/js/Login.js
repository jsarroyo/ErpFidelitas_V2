 

var LoginJS = function(){
    email: $("#txtEmail").val();
    password: $("#txtPassword").val();

    this.Iniciologin = function () {
        $("#txtEmail").val("");
        $("#txtPassword").val("");

        $("#txtEmailValidationText").text("");
        $("#txtPasswordValidationText").text("");

        $("#lnkLogin").attr("onclick", "");
        $("#lnkLogin").click(function (e) { userOne.login(); });
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
            return;
        }
        if (IsUndefined(email)) {
            $("#txtEmailValidationText").text("Debe indicar el email");
            alertify.alert('Debe indicar el email');
            $("#txtEmail").focus();
            return;
        }
        if (IsEmpty(password)) {
            $("#txtPasswordValidationText").text("Debe indicar la contraseña.");
            alertify.alert('Debe indicar la contraseña');
            $("#txtPassword").focus();
            return;
        }
        if (IsUndefined(password)) {
            $("#txtEmailValidationText").text("Debe indicar el email");
            alertify.alert('Debe indicar el email');
            $("#txtEmail").focus();
            return;
        }
        if (!IsValidEmailFormat()) {
            return;
        }

        console.log(this.email, 'has logged in');
    };

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
 