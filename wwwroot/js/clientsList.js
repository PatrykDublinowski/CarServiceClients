var dataTable;
var allPaid = {
    0: "tak",
    1: "nie"
};

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_Load_Clients').DataTable({
        "ajax": {
            "url": "/api/client",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "getFullName", "width": "19%" },
            {
                "data": "allPaid",
                "render": function (data) {
                    return allPaid[data];
                }, "width": "17%"
            },
            { "data": "phone", "width": "17%" },
            { "data": "mail", "width": "17%" },
            {
                "data": "clientID",
                "render": function (data) {
                    return `<div class="text-center">
                    <a href="/ServiceList/UpsertClient?id=${data}" class='btn btn-success text-white' style='cursor:pointer;width:70px;'>
                        Edytuj
                    </a>
                    &nbsp;
                    <a class='btn btn-danger text-white' style='cursor:pointer;width:70px;'
                    onclick=Delete('/api/Client?id='+${data})>
                        Usuń 
                    </a>
                    </div>`;
                }, "width": "30%"
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
        "width": "100%"
    })
}