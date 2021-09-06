$(document).ready(function () {

    $(`#save`).click(function () {

        //var myfile = document.getElementById("ImgFile");
        var myfiles = $("#ImgFile")[0].files[0];
        //var formData = new FormData();

        //if (myfile.files.length > 0) {
        //    for (var i = 0; i < myfile.files.length; i++) {
        //        formData.append('file-' + i, myfile.files[i]);
        //    }
        //}


        var data = new FormData();
        /*    var files = $("#Img").get(0).files;*/
        var imgPath = $("#Img").val();
        var name = $("#Name").val();
        var price = $("#Price").val();
        var quantuty = $("#Quantuty").val();
        var description = $("#Description").val();


        //if (files.lenght > 0) {
        //    data.append("Img", files[0]);
        //}

        if (name.trim() == '' || price.trim() == '' || quantuty.trim() == '') {

            $("#Error").html("შეავსე აუცილებელი ველები!!!")
        } else {

            data.append('Name', name);
            data.append('Price', price);
            data.append('Quantuty', quantuty);
            data.append('Description', description);
            data.append('Img', imgPath);
            data.append('ImgFile', myfiles);



            var lastId = parseFloat($('table tr:last-child td:first-child').html()) + 1;




            $.ajax({
                type: "POST",
                url: '/Product/InsertProduct',
                //url: 'Product/InsertProduct',
                //type: "POST",
                processData: false,
                contentType: false,
                data: data,
                success: function (response) {
                    /* $('#productTable').append(`<tr><td>` + lastId + `</td><td><img src="` + imgPath + `" width="100"></td><td>` + name + `</td><td>` + price + `.00` + `</td><td>` + quantuty + `.00` + ` </td><td class="button-column" style="vertical-align:middle!important;"> <a class="btn btn-outline-dark"> <i class="fas fa-pencil-alt"></i>&nbspშეცვლა </a> <button type="buttonid="delete-selected" class="btn btn-danger" data-toggle="modal" data-target="#delete-selected-action-confirmation" > <i class="far fa-trash-alt"></i> წაშლა</button></td> </tr> `);*/
                    //$('#productTable tbody').append(response);
                    location.reload();

                },
                error: function (er) {
                    alert(er);
                }

            });
        }

    });
});
