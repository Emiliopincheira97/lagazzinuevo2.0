var dataTable;

$(document).ready(function () {

    cargarDataTable();


})

function cargarDataTable() {

    dataTable = $("#tblTrabajador").DataTable({

        "ajax": {
            "url": "/admin/Trabajadores/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", "width": "5%" },
            { "data": "run", "width": "10%" },
            { "data": "nombres", "width": "10%" },
            { "data": "apellidos", "width": "10%" },
            { "data": "correo", "width": "10%" },
            { "data": "tipoTrabajador.nombre", "width": "15%" },
            { "data": "estado.nombre", "width": "10%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                                <div class="text-center">
                                <a href='/Admin/Trabajadores/EditarTrabajador/${data}' class='btn btn-success text-white' style='cursor:pointer; width:100px;'>
                                <i class='fas fa-edit'></i> Editar
                                </a>
                                &nbsp;
                                <a onclick=Delete("/Admin/Trabajadores/BorrarTrabajador/${data}")  class='btn btn-danger text-white' style='cursor:pointer; width:100px;'>
                                <i class='fas fa-trash-alt'></i> Borrar
                                </a>
                        
                                    
                            `;
                },"width": "30%"
            }

        ],
        "language": {
            "emptyTable": "No hay registros"
        },
        "width":"100%"


    });
}

function Delete(url) {
    swal({
        title: "Esta seguro de borrar?",
        text: "Este contenido no se puede recuperar!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Si, borrar!",
        cancelButtonText: "No, cancelar!",
        closeOnconfirm: true

    }, function () {
        $.ajax({
            type: 'DELETE',
            url: url,
            success: function (data) {
                if (data.success) {
                    toastr.success(data.message);
                    dataTable.ajax.reload();
                }
                else {
                    toastr.error(data.message);
                }

            }
        });
    });
  
}