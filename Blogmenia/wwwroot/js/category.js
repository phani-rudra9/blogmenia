var dataTable;

$(document).ready(function () {
    loadDataTable();
    $("#dvHolder").fadeIn(400);
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/Category",
            "dataSrc": "",
            "type": "GET",
            "datatype": "json",
            "headers": {
                "XSRF-TOKEN":
                    $('input[name="__RequestVerificationToken"]').val()
            },
        }, "columnDefs": [
            {
                "render": function (data, type, row) {
                    console.log(row);
                    var result = "<a class='aLnk' href='" + $("#hdBaseUrl").val() + "Category/" + row["slug"] + "'>  " + row["name"] + " </a><br/> Id : " + row["categoryId"]+" - "+ row["description"] ;
                  //  console.log(result);
                    return result;
                },
                "targets": 1,
            },

        ], "rowCallback": function (nRow, aData, iDisplayIndex) {
            var oSettings = this.fnSettings();
            $("td:first", nRow).html(oSettings._iDisplayStart + iDisplayIndex + 1);
            return nRow;
        },
        "columns": [
            { "data": "categoryId", "width": "5%" },
            { "data": "Name", "width": "70%" },           
            { "data": "isActive", "width": "10%" },
            {
                "data": "categoryId",
                "render": function (data) {
                    return `<div class="text-center">

<a href="/Admin/CustomCategory/Upsert?categoryId=${data}" class='btn btn-success btn-sm mr-2' style='cursor:pointer;display:none; '>
                            View
                        </a>
  &nbsp;
                        <a href="/Admin/CustomCategory/Upsert?categoryId=${data}" class='btn btn-primary btn-sm' style='cursor:pointer; '>
                            Edit
                        </a>
                        &nbsp;
                        <a class='btn btn-danger btn-sm text-white' style='cursor:pointer;'
                            onclick=Delete('/Admin/CustomCategory/Upsert?categoryId='+${data})>
                            Delete
                        </a>
                        </div>`;
                }, "width": "40%"
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%",
        "aaSorting": []
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