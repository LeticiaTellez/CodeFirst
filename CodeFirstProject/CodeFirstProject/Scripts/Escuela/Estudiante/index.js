$(document).ready(function () {
    fnCargarTabla();
    fnCargarFormularioEditar();
})

function fnCargarTabla() {
    var table = $("#tblEstudiantes").DataTable({
        "ajax": {
            "url": 'ObtenerEstudiantes',
            "type": "GET",
            "dataSrc": function (data) {
                return data;
            }
        },
        "columns": [
            { "data": "Nombre" },
            {
                "data": "Nombre",
                "render": function (data) { return moment(data).format('DD/MM/YYYY') }
            },
            { "data": "Estatura" },
            { "data": "Peso" },
            { "data": "GradoNombre" },
            {
                "data": "EstudianteId",
                "className": "text-center acciones",
                "orderable": false,
                "render": function (data) {
                    return '<button class="btn btn-info btn-icon editar" type="button" title="Actualizar registro"  data-id="' + data + '"><i class="la la-pencil icon-lg"></i></buttom>' +
                            '<button class="btn btn-danger btn-icon eliminar" type="button" title="Eliminar registro"  data-id="' + data + '"><i class="la la-trash icon-lg"></i></buttom>';
                }
            }
        ],
        "buttons": [
            {
                text: 'Nuevo',
                className: "btn btn-info",
                action: function () {
                    fnCargarFormularioCrear();
                }
            }
        ]
    });
}

function fnCargarFormularioCrear() {
    $.get("Formulario", function (html) {
        $('#content-index-est').hide();
        $("#content-form-est").html(html);
        $('#content-form-est').show();
    }).fail(function (data) {
        swal("Error", "Error al realizar la petición", "error")
    });
}

function fnCargarFormularioEditar() {
    $("#tblEstudiantes").on('click', 'button.editar', function () {
        var _this = this;

        $.get("Estudiantes/Formulario", function (html) {
            $('#content-index-est').hide();
            $("#content-form-est").html(html);
            $('#content-form-est').show();

            LlenarCamposEditar(_this)
        }).fail(function (data) {
            swal("Error", "Error al realizar la petición", "error")
        });
    })
    
}

function LlenarCamposEditar(_this) {
    var row = $(_this).closest('tr');
    if ($(row).hasClass('child')) {
        row = $(row).prev();
    }
    var data = $("#tblEstudiantes").DataTable().row(row).data();

    $("#EstudianteId").val(data.EstudianteId);
    $("#GradoId").selectpicker('val', data.GradoId);
    $("#Nombre").val(data.Nombre);
    $("#FechaNacimiento").val(moment(data.FechaNacimiento).format('DD/MM/YYYY'));
    $("#Estatura").val(data.Estatura);
    $("#Peso").val(data.Peso);
}