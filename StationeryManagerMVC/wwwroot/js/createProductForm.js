

// Tùy chỉnh danh sách từ server khi cần
let subCategoryList = [];

const baseUrl = "https://localhost:7069";

const token = localStorage.getItem("authToken");

function init() {
    loadSubCategoryList();
}

function loadSubCategoryList() {
    $.ajax({
        url: `${baseUrl}/api/subCategories`,
        type: 'GET',
        success: function (data) { 
            console.log("res: ", data)
            subCategoryList = data;
            renderCreateProductForm();
        },
        error: function (error) {
            console.error("Error loading subcategories:", error);
        }
    });
}

function renderCreateProductForm(containerId = "#formContainer") {
    const formHtml = `
        <h1>Thêm mới sản phẩm</h1>
        <a href="/Products" class="btn btn-secondary">Danh sách sản phẩm</a>
        <form method="post" id="createForm" action="/Products/Create" enctype="multipart/form-data">
            <div class="row">
                <div class="col">
                    ${renderInput("Tên sản phẩm", "Name")}
                    ${renderSelect("Danh mục sản phẩm", "SubCategoryId", subCategoryList)}
                    ${renderInput("Mã SKU", "Sku")}
                    ${renderInput("Giá nhập", "Price")}
                    ${renderInput("Giá bán", "PriceSale")}
                    ${renderInput("Mô tả", "Description")}
                </div>

                <div class="col">
                    <div class="form-group">
                        <label>Ảnh sản phẩm</label>
                        <input type="file" name="ImageFile" class="form-control" onchange="previewImage(this)" />
                        <br />
                        <img id="preview" src="#" alt="Preview" style="display:none; width: 100%; height: auto;" />
                    </div>
                </div>
            </div>

            <div class="form-group">
                <input type="submit" value="Thêm mới" class="btn btn-primary" />
            </div>
        </form>
    `;

    $(containerId).html(formHtml);
}

function renderInput(label, name) {
    return `
        <div class="form-group">
            <label for="${name}">${label}</label>
            <input type="text" name="${name}" id="${name}" class="form-control" />
            <span class="text-danger" id="${name}Error"></span>
        </div>
    `;
}

function renderSelect(label, name, list) {
    let opts = list.map(opt => `<option value="${opt.id}">${opt.name}</option>`).join('');
    return `
        <div class="form-group">
            <label for="${name}">${label}</label>
            <select name="${name}" id="${name}" class="form-control">
                ${opts}
            </select>
            <span class="text-danger" id="${name}Error"></span>
        </div>
    `;
}

function previewImage(input) {
    const preview = document.getElementById("preview");
    const file = input.files[0];
    if (file) {
        const reader = new FileReader();
        reader.onload = e => {
            preview.src = e.target.result;
            preview.style.display = "block";
        };
        reader.readAsDataURL(file);
    }
}

$(document).on("submit", "form", function (e) {
    e.preventDefault();
    submitCreateProductForm();
});


async function submitCreateProductForm(apiUrl = "/api/products") {
    try {
        

        const nameInput = $("#Name").val();
        const priceStr = $("#Price").val();
        const priceSaleStr = $("#PriceSale").val();
        const subcategoryIdInput = $("#SubCategoryId").val();

        if (nameInput === "" || priceStr === "" || priceSaleStr === "" || subcategoryIdInput === "") {
            alert("Điền các thông tin bắt buộc phải có");
            return;
        }

        const imageUrl = await uploadImage(); 

        const formData = {
            name: nameInput,
            sku: $("#Sku").val(),
            price: parseFloat(priceStr),
            priceSale: parseFloat(priceSaleStr),
            description: $("#Description").val(),
            subCategoryId: subcategoryIdInput,
            imageUrl: imageUrl
        };

        $.ajax({
            url: `${baseUrl}${apiUrl}`,
            type: "POST",
            headers: {
                "Authorization": `Bearer ${token}` 
            },
            contentType: "application/json",
            data: JSON.stringify(formData),
            success: function (response) {
                alert("Thêm mới sản phẩm thành công!");
                window.location.href = "/Products";
            },
            error: function (xhr) {
                if (xhr.responseJSON && xhr.responseJSON.errors) {
                    showValidationErrors(xhr.responseJSON.errors);
                } else {
                    alert("Đã xảy ra lỗi khi thêm sản phẩm.");
                    console.error(xhr);
                }
            }
        });

    } catch (error) {
        alert("Lỗi khi upload ảnh hoặc gửi dữ liệu.");
        console.error(error);
    }
}


function uploadImage() {
    return new Promise((resolve, reject) => {
        const fileInput = document.querySelector('input[type="file"]');
        const file = fileInput.files[0];
        if (!file) {
            resolve("");
            return;
        }

        const formData = new FormData();
        formData.append("file", file);

        $.ajax({
            url: `${baseUrl}/api/media/upload`,
            type: "POST",
            headers: {
                "Authorization": `Bearer ${token}`
            },
            data: formData,
            contentType: false,
            processData: false,
            success: function (data) {
                resolve(data);
            },
            error: function (err) {
                reject(err);
            }
        });
    });
}

function showValidationErrors(errors) {
    // Xoá lỗi cũ
    $("span.text-danger").text("");

    for (const key in errors) {
        const messages = errors[key];
        const errorElement = document.getElementById(`${key}Error`);
        if (errorElement) {
            errorElement.textContent = messages.join(", ");
        }
    }
}


