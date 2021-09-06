$(document).ready(function () {

    $(`.product-button`).click(function () {


        var id = $(this).attr('data-productID');
        var name = $(this).attr('data-productName');

        var data = new FormData();

        $('#productIDp').text(id);
        $('#productNamep').text(name);
        data.append("ID", id);

        $(`#delete-selected`).click(function () {

            $.ajax({
                type: "POST",
                url: '/Product/DeleteProduct',
                processData: false,
                contentType: false,
                data: data,
                success: function (response) {
                    location.reload();
                },
                error: function (er) {
                    alert(er);
                }
            });


        });


    });


});