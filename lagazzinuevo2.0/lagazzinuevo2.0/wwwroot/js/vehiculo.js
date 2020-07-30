var dataTable;

$(document).ready(function () {

    cargarDataTable();


})

function cargarDataTable() {

    dataTable = $("#tblVehiculo").DataTable({

        "ajax": {
            "url": "/admin/Vehiculos/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", "width": "5%" },
            { "data": "marca", "width": "10%" },
            { "data": "modelo", "width": "10%" },
            { "data": "patente", "width": "10%" },
            { "data": "anio", "width": "10%" },
            { "data": "tipoVehiculo.nombre", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                                <div class="text-center">
                                <a href='/Admin/Vehiculos/EditarVehiculo/${data}' class='btn btn-success text-white' style='cursor:pointer; width:100px;'>
                                <i class='fas fa-edit'></i> Editar
                                </a>
                                &nbsp;
                                <a onclick=Delete("/Admin/Vehiculos/BorrarVehiculo/${data}")  class='btn btn-danger text-white' style='cursor:pointer; width:100px;'>
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