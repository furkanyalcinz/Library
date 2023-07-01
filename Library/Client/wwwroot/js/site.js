
$(document).ready(function () {
    $('#registerForm').submit(function (event) {
        event.preventDefault();

        var name = $('#nameInput').val(); 
        var surname = $('#surnameInput').val(); 
        var email = $('#emailInput').val(); 
        var password = $('#InputPassword').val(); 

      
        $.ajax({
            url: '/Home/Register', 
            type: 'POST', 
            data: {
                name: name,
                surname: surname,
                email: email,
                password: password
            },
            success: function (response) {
                console.log(response);
                if (response.success) {
                    document.getElementById("RegisterResponse").innerHTML = '<div class="alert alert-success" role="alert">Registration is success. Redireting to Login page.</div>';
                    setTimeout(function () {
                        window.location.href = '/Home/Login';
                    }, 2000);
                } else {
                    document.getElementById("RegisterResponse").innerHTML = '<div class="alert alert-warning" role="alert">'+response.message+'</div>';
                }
                
            },
            error: function (error) {
                document.getElementById("RegisterResponse").innerHTML = '<div class="alert alert-danger" role="alert">'+error+'</div>';
            }
        });
    });
});

$(document).ready(function () {
    $('#loginForm').submit(function (event) {
        event.preventDefault();

        var email = $('#emailInputLogin').val();
        var password = $('#InputPasswordLogin').val();


        $.ajax({
            url: '/Home/Login',
            type: 'POST',
            data: {
                email: email,
                password: password
            },
            success: function (response) {
                if (response.success) {
                    window.location.href = '/Home/Login';
                } else {
                    document.getElementById("LoginResponse").innerHTML = '<div class="alert alert-warning" role="alert">' + response.message + '</div>'
                }
                
            },
            error: function (error) {
                document.getElementById("LoginResponse").innerHTML = '<div class="alert alert-danger" role="alert">' + response.message + '</div>'
            }
            
        });
    });
});
$(document).ready(function () {  
    $("#btnBorrow").click(function () {
        console.log($(this));
        var bookId = $(this).data("book-id");
        var returnDate = $("#datepicker").val();
        $.ajax({
            url: '/Home/Borrow',
            type: "POST",
            data: {
                bookId: bookId,
                date: returnDate
            },
            success: function (response) {

                alert("Success" + response);
                location.reload()
            },
            error: function (error) {
                alert(error);
            }
            
        });
    });
});
$(document).ready(function () {
    $(".form-control").each(function () {
        $(this).datepicker({
            format: 'yyyy-mm-dd',
            changeMonth: true,
            changeYear: true,
            minDate: '0d'
        });

    });
})


//});

//function datepic(event) {
//    eId = "#" + event.target.id;
//    $(document).ready(function () {
//        $(eId).datepicker({
//            console.log(eId);
//            format: 'yyyy-mm-dd',
//            changeMonth: true,
//            changeYear: true,
//            minDate: '0d'
//        });


//    });
//}




