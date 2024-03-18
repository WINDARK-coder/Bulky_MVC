



$(document).ready(function () {
    loadDataTable();
})

function loadDataTable() {

    dataTable = $('#tblData').DataTable({
        "ajax": { url:'/admin/product/getall'},
        "columns": [
            { data: 'title', width: "25%" },
            { data: 'isbn', width: "15%" },
            { data: 'author', width: "10%" },
            { data: 'listPrice', width: "20%" },
            { data: 'category.name', width: "15%" },
            {
                data: 'id',
                "render": function (data) {
                    `<div class="w-75 btn-group" role="group">
                        <a asp-area="Admin" asp-controller="Product" asp-action="Upsert" asp-route-id="${data}" class="btn btn-primary mx-2">
                            <i class="bi bi-pencil-square"></i> Edit
                        </a>
                        <a asp-area="Admin" asp-controller="Product" asp-action="Delete" asp-route-id="${data}" class="btn btn-danger mx-2">
                            <i class="bi bi-trash-fill"></i> Delete
                        </a>
                    </div>`
                },
                width: "15%"
            }

        ]
    });
}