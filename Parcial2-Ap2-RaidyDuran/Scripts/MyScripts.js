/*Modal Eliminar*/
function showModalEliminar() {
    $("#ModalEliminar").modal('show');
}

$(function () {
    $("#EnviarAlModalEliminar").click(function () {
        showModalEliminar();
    });
});

/*Modal Modificar*/
function showModalModificar() {
    $("#ModalModificar").modal('show');
}

$(function () {
    $("#EnviarAlModalModificar").click(function () {
        showModalModificar();
    });
});