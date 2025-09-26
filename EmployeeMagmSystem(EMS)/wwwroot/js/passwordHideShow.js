
    $(document).ready(function () {
        $("#closed").hide(); // hide the closed eye by default

    $("#open").click(function () {
        $("#open").hide();
        $("#closed").show();
        $("#password").attr("type", "text");
       
            });

    $("#closed").click(function () {
        $("#closed").hide();
        $("#open").show();
        $("#password").attr("type", "password");
  
    });
    });

$(document).ready(function () {

    $("#closed1").hide();
    $("#open1").click(function () {
        $("#open1").hide();
        $("#closed1").show();
        $("#Confirmpassword").attr("type", "text");
    });

    $("#closed1").click(function () {
        $("#closed1").hide();
        $("#open1").show();
        $("#Confirmpassword").attr("type", "password");
    });
});
