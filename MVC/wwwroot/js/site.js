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
            topStart: {
                buttons:['excel']
            }
        }
    });    
} );


