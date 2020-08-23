$(function () {
    $(".selectpicker").selectpicker("refresh");
    $("#dateNacimiento").datetimepicker({
        locale: 'es',
        format: 'DD/MM/YYYY'
    });
})

function fnEventoRegresar() {
    $("#btnRegresarEstudiante").click(function () {
        $('#content-form-est').hide();
        $("#content-form-est").html('');
        $('#content-index-est').show();
    })
}
function fnEventoGuardar() {
    $("#btnGuardarEstudiante").click(function () {
        var modelo = fnDatosFormulario();

        fnGuardarRegistro(modelo);
    })
}

function fnDatosFormulario() {
    return {
        EstudianteId: $("#EstudianteId").val(),
        Nombre: $("#Nombre").val(),
        FechaNacimiento: $("#FechaNacimiento").val(),
        Estatura: $("#Estatura").val(),
        Peso: $("#Peso").val(),
        GradoId: $("#GradoId").val()
    };
}

function fnGuardarRegistro(modelo) {
    var url = "Estudiantes/GuardarEstudiante";
    if (modelo.EstudianteId != "")
        url = "Estudiantes/ActualizarEstudiante";

    $.post(url, modelo, function (json) {
        if (json.estado) {
            swal({
                title: "Notificación",
                text: "Guardado correctamente",
                icon: "success"
            }, function () {
                $('#tblEstudiantes').DataTable().ajax.reload();
                $('#content-index-est').show();
                $("#content-form-est").html('');
                $("#content-form-est").hide();
            });
        } else {
            $.each(json.formErrors, function () {
                $("[data-valmsg-for=" + this.key + "]").html(this.errors.join());
            });
        }
    })
}