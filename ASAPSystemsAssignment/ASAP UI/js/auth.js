$(document).ready(function () {
    $("#login-btn").click(function () {
        const data = {
            name: $("#username").val(),
            password: $("#password").val()
        };

        $.ajax({
            url: "https://localhost:7086/api/auth/login", // your API URL
            method: "POST",
            contentType: "application/json",
            data: JSON.stringify(data),
            xhrFields: { withCredentials: true },
            success: function (response) {
             
                window.location.href = "dashboard.html";
            },
            error: function () {
                $("<div />").kendoDialog({
                    title: "Login Failed",
                    content: "Invalid username or password.",
                    actions: [{ text: "OK", primary: true }]
                }).data("kendoDialog").open();
            }
        });
    });
});
