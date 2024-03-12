// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function setDeactivate(str_id) {
    console.log(str_id);
    $.ajax({
        url: '/Paciente/setDeactivate',
        id: Number(str_id),
        contentType: 'application/json;charset=UTF-8',
        type: 'POST',
        success: function (result) {
            console.log("Usuario desactivado correctamente");
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            var _err = '';
            switch (errorThrown) {
                case "Bad Request":
                    _err = '400 - Tipo de dato incorrecto';
                    break;
                case "Unauthorized":
                    _err = '401 - No autorizado a realizar la operación';
                    break;
                case "Forbidden":
                    _err = '403 - Acceso restringido';
                    break;
                case "Not Found":
                    _err = '404 - No encontrado';
                    break;
                case "Method Not Allowed":
                    _err = '405 - No es posible realizar esta operación';
                    break;
                case "Not Acceptable":
                    _err = '406 - Solicitud no aceptada';
                    break;
                case "Timeout":
                    _err = '408 - Tiempo de respuesta excesivo';
                    break;
                    console.log(_err);
            }
        }
    });
}