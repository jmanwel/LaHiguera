// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready( function () {
    $('#patients_list').DataTable({
        initComplete: function () {
            this.api()
                .columns()
                .every(function () {
                    let column = this;
                    let title = column.footer().textContent;
     
                    // Create input element
                    let input = document.createElement('input');
                    input.placeholder = title;
                    input.setAttribute('id', 'txtSearch' + column.index());
                    if(column.index() == 7){
                        input.value = "SI";
                    }
                    column.footer().replaceChildren(input);
     
                    // Event listener for user input
                    input.addEventListener('keyup', () => {
                        if (column.search() !== this.value) {
                            column.search(input.value).draw();
                        }
                    });
                });
            this.api().column(7).search("SI").draw();
        },
        autoWidth: false,
        language: {
            search: 'Busqueda:',
            info: 'Mostrando _START_ a _END_ de _TOTAL_ entradas',
            lengthMenu: 'Mostrar _MENU_ entradas',
            entries: {
                _: 'pacientes',
                1: 'paciente'
            }
        },
        layout: {
            top2Start: {
                buttons:['excel']
            }
        }
    });    
} );


function calcula_imc_pediatria() {
    let talla = document.querySelector("#pediatria_talla").value;
    let peso = document.querySelector("#pediatria_peso").value;
    if (talla == "" || peso == "") {
        alert("Por favor, complete los campos talla/peso");
        document.querySelector("#pediatria_peso").focus();
    } else {
        let imc = document.querySelector("#pediatria_imc");
        talla = parseFloat(document.querySelector("#pediatria_talla").value);
        peso = parseFloat(document.querySelector("#pediatria_peso").value);
        if (talla == 0) {
            alert("Talla debe ser mayor a 0");
            document.querySelector("#pediatria_talla").focus();
        } else {
            let imc_parsed = (peso / Math.pow((talla / 100), 2)).toFixed(2).replace(".", ",");
            imc.value = imc_parsed;
        }
    }
}

function calcula_imc_historia() {
    let talla = document.querySelector("#historia_talla").value;
    let peso = document.querySelector("#historia_peso").value;
    if (talla == "" || peso == "") {
        alert("Por favor, complete los campos talla/peso");
        document.querySelector("#historia_peso").focus();
    } else {
        let imc = document.querySelector("#historia_imc");
        talla = parseFloat(document.querySelector("#historia_talla").value);
        peso = parseFloat(document.querySelector("#historia_peso").value);
        if (talla == 0) {
            alert("Talla debe ser mayor a 0");
            document.querySelector("#historia_talla").focus();
        } else {
            let imc_parsed = (peso / Math.pow((talla / 100), 2)).toFixed(2).replace(".", ",");
            imc.value = imc_parsed;
        }
    }
}