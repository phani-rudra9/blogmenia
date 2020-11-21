var dataTable;

$(document).ready(function () {
    loadDataTable();
    $("#dvHolder").fadeIn(400);
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/Comment",
            "type": "GET",
            "datatype": "json",
            "headers": {
                "XSRF-TOKEN":
                    $('input[name="__RequestVerificationToken"]').val()
            },
        },
        "columns": [
            { "data": "comment_ID", "width": "5%" },
            { "data": "comment_content", "width": "70%" },
            { "data": "comment_approved", "width": "10%" },
            {
                "data": "comment_ID",
                "render": function (data) {
                    return `<div class="text-center">

<a href="/Admin/Comment/Details/?comment_ID=${data}" class='btn btn-success btn-sm mr-2' style='cursor:pointer'>
                            View
                        </a>
  &nbsp;
                        <a href="/Admin/Comment/Edit/?comment_ID=${data}" class='btn btn-primary btn-sm' style='cursor:pointer; '>
                            Edit
                        </a>
                        &nbsp;
                        <a class='btn btn-danger btn-sm text-white' style='cursor:pointer;'
                            onclick=Delete('/Admin/Comment/Delete/?comment_ID='+${data})>
                            Delete
                        </a>
                        </div>`;
                }, "width": "40%"
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}

function Delete(url) {
    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
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
        }
    });
}