

const baseUrl = "https://localhost:7069"

$(document).ready(function () {
    loadData();
})

function loadData() {
    $.ajax({
        url: `${baseUrl}/api/categories`,
        type: "GET",
        contentType: "application/json",
        success: function (data) {
            const list = data;
            const table = $("#table");
            const tableBody = table.find("tableBody");
            tableBody.empty(); 

            if (list.length === 0) {
                table.append("<div>Không có dữ liệu</div>");
                return;
            }

            list.forEach(item => {
                tableBody.append(`
                    <tr>
                        <td>${item.id}</td>
                        <td>${item.name}</td>
                        <td>${item.description}</td>
                        <td>
                            <button class="btn btn-primary" onclick="editCategory(${item.id})">Sửa</button>
                            <button class="btn btn-primary" onclick="detailCategory(${item.id})">Chi tiết</button>
                            <button class="btn btn-danger" onclick="deleteCategory(${item.id})">Delete</button>
                        </td>
                    </tr>
                `);
            })
        },
        error: function (error) {
            console.log("Error loading categories:", error);

        }
    })
}