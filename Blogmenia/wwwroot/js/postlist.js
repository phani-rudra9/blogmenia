var dataTable;

$(document).ready(function () {
    loadDataTable();
    $("#dvHolder").fadeIn(400);
});


function formattedDate(dtvalue) {

    var date = new Date(dtvalue);
    var formattedDate = ((date.getMonth() > 8) ? (date.getMonth() + 1) : ('0' + (date.getMonth() + 1))) + '/' + ((date.getDate() > 9) ? date.getDate() : ('0' + date.getDate())) + '/' + date.getFullYear();
    console.log(formattedDate);
    return formattedDate;
} 

function loadDataTable() {
  

    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/Posts/AllLatestPost",
            "dataSrc": "",
            "type": "GET",
            "datatype": "json",
            "headers": {
                "XSRF-TOKEN": $('input[name="__RequestVerificationToken"]').val()
            },
        }, "columnDefs": [
            {
                "render": function (data, type, row) {                   
                    var result = '<div class="dvItem"> <b> <a class="text-dark ptitle" style="width:100%;" href="' + $("#hdBaseUrl").val() + row["slug"] + '"> ' + row["title"] + '  </a> </b></br>';
                    result += '<span >  Id  - ' + row["id"] + ' </span >  ,  <span>Published on ' + formattedDate(row["publishDate"]) + '</span>  ,  <span>  Modified on ' + formattedDate(row["modifiedDate"]) +' </span></div >';

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
            { "data": "id", "width": "5%" },
            { "data": "title", "width": "70%" },
            { "data": "status", "width": "10%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">

<a href="/Admin/BlogPost/Upsert?Id=${data}" class='btn btn-success btn-sm mr-2' style='cursor:pointer; '>
                            View
                        </a>
  &nbsp;
                        <a href="/Admin/BlogPost/Upsert?Id=${data}" class='btn btn-primary btn-sm' style='cursor:pointer; '>
                            Edit
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