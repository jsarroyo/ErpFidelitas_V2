 

var LoginJS = function(){ 

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

  //      if ($("#txtMensajes").val() != "") {
  //          alertify.alert('No fue posible contactar el servidor ' + $("#txtMensajes").val());
		//}
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
    this.AddMovimientoInv = function () {
        if ($("#ddlTipoDocumento").val() == "" || $("#ddlTipoDocumento").val() == null) {
            alertify.alert("Seleccione un tipo de documento");
            return;
        }
        if ($("#ddlArticulo").val() == "" || $("#ddlArticulo").val() == null) {
            alertify.alert("Seleccione un artículo");
            return;
        }
        if ($("#txtCantidad").val() == "0" || $("#txtCantidad").val() == null) {
            alertify.alert("Cantidad no puede ser cero o vacío");
            return;
        }
        if ($("#ddlMoneda").val() == "" || $("#ddlMoneda").val() == null) {
            alertify.alert("Seleccione una moneda");
            return;
        } 
        fila = '<tr class="odd">';
        fila = fila + '<td class="sorting_1"> <input type="text" class="form-control-plaintext" name="DocumentTypeId" value="' + $("#ddlTipoDocumento").val() + '"></td>';
        fila = fila + '<td > <input class="form-control-plaintext" type="text" name="ProductId" value="' + $("#ddlArticulo").val() + '"></td>';
        fila = fila + '<td > <input class="form-control-plaintext" type="text" name="Quantity" value="' + $("#txtCantidad").val() + '"></td>';
        fila = fila + '<td > <input class="form-control-plaintext" type="text" name="UnitCost" value="' + $("#txtPrecio").val() + '"></td>';
        fila = fila + '<td > <input class="form-control-plaintext" type="text" name="CostCurrencyId" value="' + $("#ddlMoneda").val() + '"></td>';
        fila = fila + '</tr>';

        //$("#dataTable_wrapper > tbody").append(fila);
        $('#dataTable').append(fila);
    }

    this.AddMovimientoCXP = function () {
        if ($("#ddlPersona").val() == "") {
            alertify.alert("Seleccione la persona");
            return;
        }
        if ($("#ddlArticulo").val() == "") {
            alertify.alert("Seleccione un artículo");
            return;
        }
        if ($("#txtCantidad").val() == "0") {
            alertify.alert("Cantidad no puede ser cero o vacío");
            return;
        }
        if ($("#ddlMoneda").val() == "") {
            alertify.alert("Seleccione una moneda");
            return;
        }

        fila = '<tr class="odd">';
        fila = fila + '<td>' + $("#ddlPersona").val() + '</td>';
        fila = fila + '<td class="sorting_1">' + $("#ddlTipoDocumento").val() + '</td>';
        fila = fila + '<td>' + $("#txtMonto").val() + '</td>';
        fila = fila + '<td>' + $("#ddlMoneda").val() + '</td>';
        fila = fila + '</tr>';

        //$("#dataTable_wrapper > tbody").append(fila);
        $('#dataTable').append(fila);
    }
};
var userOne = new LoginJS();



