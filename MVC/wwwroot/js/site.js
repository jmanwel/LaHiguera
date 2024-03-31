// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function filter_patientes() {
    var input, filter, table, tr, td, i, j, visible;
    input = document.querySelector("#input_data");
    filter = input.value.toUpperCase();
    table = document.querySelector("#active_patients");
    tr = table.querySelectorAll("tr");
    for (i = 1; i < tr.length; i++) {
        visible = false;
        td = tr[i].querySelectorAll("td");
        for (j = 0; j < td.length; j++) {
            if (td[j] && td[j].innerHTML.toUpperCase().indexOf(filter) > -1) {
                visible = true;
            }
        }
        if (visible === true) {
            tr[i].style.display = "";
        } else {
            tr[i].style.display = "none";
        }
    }
}


