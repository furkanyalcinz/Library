$(document).ready(function () {
    $('#loginSubmit').prop('disabled', true);
    $('#emailInputLogin, #InputPasswordLogin').on('input', function () {
        var email = $("#emailInputLogin").val();
        var password = $("#InputPasswordLogin").val();
        console.log(email);
        if (email && password) {
            $('#loginSubmit').prop('disabled', false);
        } else {
            $('#loginSubmit').prop('disabled', true);
        }
    });
});

$(document).ready(function () {
    // Disable the button initially
    $('#registerSubmit').prop('disabled', true);

    // Listen for input changes
    $('#nameInput, #surnameInput, #emailInput, #InputPassword').on('input', function () {
        // Get the values from the input fields
        var name = $('#nameInput').val();
        var surname = $('#surnameInput').val();
        var email = $('#emailInput').val();
        var password = $('#InputPassword').val();

        // Enable/disable the button based on the values
        if (name && surname && email && password) {
            $('#registerSubmit').prop('disabled', false);
        } else {
            $('#registerSubmit').prop('disabled', true);
        }
    });
});




$(document).ready(function () {
    
    $('#registerForm').submit(function (event) {
        event.preventDefault();

        var name = $('#nameInput').val(); 
        var surname = $('#surnameInput').val(); 
        var email = $('#emailInput').val(); 
        var password = $('#InputPassword').val();
        
       
            console.log("heree");
            
        

      
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
                    document.getElementById("RegisterResponse").innerHTML = '<div class="alert alert-warning" role="alert">' + response.message + '</div>';
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
                console.log(error);
                document.getElementById("LoginResponse").innerHTML = '<div class="alert alert-danger" role="alert">' + error.message + '</div>'
            }
            
        });
    });
});
$(document).ready(function () {  
    $("#btnBorrow").click(function () {
        console.log($(this));
        var bookId = $(this).data("book-id");
        var datePicker = "#datepicker_" + bookId
        var returnDate = $(datePicker).val();
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
                console.log(error.responseText);
                alert(error.responseText);
            }
            
        });
    });
});
$(document).ready(function () {
    $(".form-control.bg-gradient").each(function () {
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




