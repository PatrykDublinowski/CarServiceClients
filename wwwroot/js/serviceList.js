var dataTable;
var statusEnum = {
    0: "wprowadzony",
    1: "realizowany",
    2: "zakończony"
};
var noYes = {
    0: "nie",
    1: "tak"
};

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_Load').DataTable({
        "ajax": {
            "url": "/api/service",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            {
                "data": "serviceID",
                "render": function (data) {
                    return "#"+data;
                }, "width": "12%"
            },
            {
                "data": "status",
                "render": function (data) {
                    return statusEnum[data];
                },"width": "12%"
            },
            { "data": "description", "width": "22%" },
            {
                "data": "lastEditDate", "render": function (data) {
                    var dateWithoutMs = data.split('.');
                    var dateTimeReady = dateWithoutMs[0].split('T');
                    return dateTimeReady[0] + " " + dateTimeReady[1];
                }, "width": "12%" },
            {
                "data": "isPaid",
                "render": function (data) {
                    return noYes[data];
                }, "width": "12%"
            },
            {
                "data": "serviceID",
                "render": function (data) {
                    return `<div class="text-center">
                    <a href="/ServiceList/Upsert?id=${data}" class='btn btn-success text-white' style='cursor:pointer;width:70px;'>
                        Edytuj
                    </a>
                    &nbsp;
                    <a class='btn btn-danger text-white' style='cursor:pointer;width:70px;'
                    onclick=Delete('/api/service?id='+${data})>
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
        "width":"100%"
    })
}