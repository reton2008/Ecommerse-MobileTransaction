var dataTable;

$(document).ready(function () {
    loadDataTable()
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/mobileFinance/walletAccount/GETALL", 
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "phoneNumber", "width": "50%" },
            { "data": "mobileFinanceServices.name", "width": "20%" },
            { "data": "mobileOperator.name", "width": "20%" },
            { "data": "balance", "width": "20%" },
            { "data": "active", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div  class="text-center"><a href = "/MobileFinance/walletAccount/Upsert/${data}" class='btn btn-success text-while' style='cursor:pointer; width:100px;'><i class='far fa-edit'></i> Edit </a> </div>
                             &nbsp;
                             <div class="text-center"><a onclick =Delete("/MobileFinance/walletAccount/Delete/${data}") class='btn btn-danger text-while' style='cursor:pointer; width:100px;'><i class='far fa-trash-alt'></i> Delete</a></div>
                           `;
                }, "width": "30%"
            }
        ],
        "language": {
            "emptyTable": "No records found."
        },
        "width": "100%"
    })
}

function Delete(url) {
    swal({
        title: "Are you sure you want to  delete?",
        text: "you will not be able to restore the content",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Yes, delete it!",
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

