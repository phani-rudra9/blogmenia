var dataTable;

$(document).ready(function () {
    loadDataTable();
    $("#dvHolder").fadeIn(400);
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/Posts/DemoList",
            "type": "GET",
            "datatype": "json",
            "dataSrc": "",
            "headers": {
                "XSRF-TOKEN":
                    $('input[name="__RequestVerificationToken"]').val()
            },
        },
        "columns": [
            { "data": "demoId", "width": "5%" },
            { "data": "slug", "width": "10%" },
            {
                "data": "contentBody",
                "render": function (data) {

                    return '<textarea rows="7" style="width:100%;" readonly>' + data + '</textarea>';
                },
                "width": "70%"
            },
            {
                "data": "demoId",
                "render": function (data) {
                    return `<div class="text-center">

<a href="/Admin/Editor/Upsert?DemoId=${data}" class='btn btn-success btn-sm mr-2' style='cursor:pointer'>
                            View
                        </a>
  &nbsp;
                        <a href="/Admin/Editor/Upsert?DemoId=${data}" class='btn btn-primary btn-sm' style='cursor:pointer; '>
                            Edit
                        </a>
                        &nbsp;
                        <a class='btn btn-danger btn-sm text-white' style='cursor:pointer;'
                            onclick=Delete('/Admin/Editor/Upsert?DemoId='+${data})>
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