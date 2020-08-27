function Delete(url) {
    swal({
        title: "Jesteś pewny?",
        text: "Usuniętych danych nie można w żaden sposób przywrócić",
        icon: "warning",
        buttons: ["Anuluj", "Ok"],
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