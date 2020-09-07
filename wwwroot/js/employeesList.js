var dataTable;
var isFree = {
    0: "tak",
    1: "nie"
};
var profession = {
    0:"elektryk",
    1:"mechanik",
    2:"blacharz",
    3:"wulkanizator",
    4:"pomocnik"
};

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_Load_Employees').DataTable({
        "ajax": {
            "url": "/api/employee",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "getFullName", "width": "19%" },
            {
                "data": "profession",
                "render": function (data) {
                    return profession[data];
                }, "width": "17%"
            },
            {
                "data": "isFree",
                "render": function (data) {
                    return isFree[data];
                }, "width": "17%"
            },
            { "data": "phone", "width": "17%" },
            {
                "data": "employeeID",
                "render": function (data) {
                    return `<div class="text-center">
                    <a href="/ServiceList/UpsertEmployee?id=${data}" class='btn btn-success text-white' style='cursor:pointer;width:70px;'>
                        Edytuj
                    </a>
                    &nbsp;
                    <a class='btn btn-danger text-white' style='cursor:pointer;width:70px;'
                    onclick=Delete('/api/Employee?id='+${data})>
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