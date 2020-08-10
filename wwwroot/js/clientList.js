var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_Load').DataTable({
        "ajax": {
            "url": "/api/client",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "width": "20%" },
            { "data": "car", "width": "20%" },
            { "data": "status", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                    <a href="/ClientList/Edit?id=${data}" class='btn btn-success text-white' style='cursor:pointer;width:70px;'>
                        Edytuj
                    </a>
                    &nbsp;
                    <a class='btn btn-danger text-white' style='cursor:pointer;width:70px;'
                    onclick=Delete('/api/client?id='+${data})>
                        Usuń 
                    </a>
                    </div>`;
                }, "width": "40%"
            }
        ],
        "language": {
            "emptyTable": "Nie znaleziono żadnych danych",
            "processing": "Przetwarzanie...",
            "search": "Szukaj:",
            "lengthMenu": "Pokaż _MENU_ pozycji",
            "info": "Pozycje od _START_ do _END_ z _TOTAL_ łącznie",
            "infoEmpty": "Pozycji 0 z 0 dostępnych",
            "infoFiltered": "(filtrowanie spośród _MAX_ dostępnych pozycji)",
            "infoPostFix": "",
            "loadingRecords": "Wczytywanie...",
            "zeroRecords": "Nie znaleziono pasujących pozycji",
            "paginate": {
                "first": "Pierwsza",
                "previous": "Poprzednia",
                "next": "Następna",
                "last": "Ostatnia"
            },
            "aria": {
                "sortAscending": ": aktywuj, by posortować kolumnę rosnąco",
                "sortDescending": ": aktywuj, by posortować kolumnę malejąco"
            }
        },
        "width":"100%"
    })
}

function Delete(url) {
    swal({
        title: "Jesteś pewny?",
        text: "Usuniętych danych nie można w żaden sposób przywrócić",
        icon: "warning",
        buttons:["Anuluj","Ok"],
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