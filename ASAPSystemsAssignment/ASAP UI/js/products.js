$(document).ready(function () {
    
    var notification = $("#notification").kendoNotification({
        position: {
            pinned: true,
            top: 30,
            right: 30
        },
        autoHideAfter: 3000,
        stacking: "down",
        templates: [{
            type: "success",
            template: "<div class='k-notification-success'>#= message #</div>"
        }]
    }).data("kendoNotification");

    $("#grid").kendoGrid({
        dataSource: {
            transport: {
                read: {
                    url: "https://localhost:7086/api/Product/GetProducts",
                    type: "GET",
                    dataType: "json",
                    contentType: "application/json",
                    xhrFields: {
                        withCredentials: true
                    }
                },
                create: {
                    url: "https://localhost:7086/api/Product/AddProduct",
                    type: "POST",
                    contentType: "application/json",
                    dataType: "json",
                    
                    xhrFields: {
                        withCredentials: true
                    }
                },
                update: {
                    url: function (data) { return "https://localhost:7086/api/Product/UpdateProduct" },
                    type: "PUT",
                    contentType: "application/json",
                    dataType: "json",
                     
                    xhrFields: {
                        withCredentials: true
                    }
                },
                destroy: {
                    url: function (data) { return "https://localhost:7086/api/Product/DeleteProduct/" + data.id; },
                    type: "DELETE",
                   
                    xhrFields: {
                        withCredentials: true
                    }
                },
                parameterMap: function (data, type) {
                    if (type !== "read") return JSON.stringify(data);
                }
            },
            schema: {
                model: {
                    id: "id",
                    fields: {
                        name: { type: "string", validation: { required: true } },
                        description: { type: "string" },
                        price: { type: "number", validation: { required: true, min: 0 } }
                    }
                }
            },
            pageSize: 10,
               // ✅ Handle requestEnd to reload data and show notifications
         requestEnd: function (e) {
            if (e.type === "create") {
                notification.show({ message: "Product added successfully!" }, "success");
                setTimeout(function () {
                    $("#grid").data("kendoGrid").dataSource.read();
                }, 3000);
            }
            else if (e.type === "update") {
                notification.show({ message: "Product updated successfully!" }, "success");
                setTimeout(function () {
                    $("#grid").data("kendoGrid").dataSource.read();
                }, 3000);
            }
            else if (e.type === "destroy") {
                notification.show({ message: "Product deleted successfully!" }, "success");
                
                setTimeout(function () {
                    $("#grid").data("kendoGrid").dataSource.read();
                }, 3000);
            }
        },
        // ✅ Also handle error (e.g., 401)
        error: function (e) {
            debugger;
            if (e.xhr.status === 401) {
                window.location.href = "index.html";
            } else {
                alert("Error occurred: " + e.xhr.responseText);
            }
        }
        // error: function (e) {
        //     alert(JSON.stringify(e) );
        //     if (e.xhr && e.xhr.status === 401) {
        //         // Redirect to your login page
        //         window.location.href = "index.html";
        //     } else {
        //         alert("An error occurred: " + (e.errors || e.statusText));
        //     }
        // }
        },
        toolbar: ["create"],
        pageable: true,
        editable: "popup",
        columns: [
            { field: "name", title: "Name" },
            { field: "description", title: "Description" },
            { field: "price", title: "Price", format: "{0:c}" },
            {
                command: [
                    "edit",
                    {
                        name: "destroy",
                        text: "Delete",
                        click: function (e) {
                            e.preventDefault();
                            const tr = $(e.target).closest("tr");
                            const data = this.dataItem(tr);

                            $("<div></div>").kendoDialog({
                                title: "Confirm Delete",
                                content: `Are you sure you want to delete <strong>${data.name}</strong>?`,
                                actions: [
                                    { text: "Cancel" },
                                    {
                                        text: "Delete", primary: true, action: function () {
                                            $.ajax({
                                                url: "https://localhost:7086/api/Product/DeleteProduct" + data.id,
                                                type: "DELETE",
                                                
                                                success: function () {
                                                    $("#grid").data("kendoGrid").dataSource.read();
                                                }
                                            });
                                        }
                                    }
                                ]
                            }).data("kendoDialog").open();
                        }
                    }
                ]
            }
        ]
        
    });
});
