﻿var dataTable;

$(document).ready(function () {

    cargarDataTable();


})

function cargarDataTable() {

    dataTable = $("#tblTipoTrabajador").DataTable({

        "ajax": {
            "url": "/admin/TiposTrabajadores/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", "width": "5%" },
            { "data": "nombre", "width": "50%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                                <div class="text-center">
                                <a href='/Admin/TiposTrabajadores/EditarTipoTrabajador/${data}' class='btn btn-success text-white' style='cursor:pointer; width:100px;'>
                                <i class='fas fa-edit'></i> Editar
                                </a>
                                &nbsp;
                                <a onclick=Delete("/Admin/TiposTrabajadores/BorrarTipoTrabajador/${data}")  class='btn btn-danger text-white' style='cursor:pointer; width:100px;'>
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