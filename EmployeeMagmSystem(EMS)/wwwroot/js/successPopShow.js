//document.addEventListener("DOMContentLoaded", function () {
//    const button = document.getElementById("showToastBtn"),
//        toast = document.querySelector(".custom-toast"),
//        closeIcon = document.querySelector(".close"),
//        progress = document.querySelector(".progress");

//    let timer1, timer2;

//    button.addEventListener("click", () => {
//        toast.classList.add("active");
//        progress.classList.add("active");

//        timer1 = setTimeout(() => {
//            toast.classList.remove("active");
//        }, 5000);

//        timer2 = setTimeout(() => {
//            progress.classList.remove("active");
//        }, 5300);
//    });

//    closeIcon.addEventListener("click", () => {
//        toast.classList.remove("active");
//        setTimeout(() => {
//            progress.classList.remove("active");
//        }, 300);
//        clearTimeout(timer1);
//        clearTimeout(timer2);
//    });

//});


    //var $toast = $(".custom-toast"),
    //    $closeIcon = $(".custom-toast .close"),
    //    $progress = $(".custom-toast .progress"),
    //    timer1, timer2;

    //// Show toast automatically if it exists (for TempData alert)
    //if ($toast.length) {
    //    $toast.addClass("active");
    //    $progress.addClass("active");

    //    timer1 = setTimeout(function () {
    //        $toast.removeClass("active");
    //    }, 5000);

    //    timer2 = setTimeout(function () {
    //        $progress.removeClass("active");
    //    }, 5300);
    //}

    //// Close button click
    //$closeIcon.on("click", function () {
    //    $toast.removeClass("active");
    //    setTimeout(function () {
    //        $progress.removeClass("active");
    //    }, 300);

    //    clearTimeout(timer1);
    //    clearTimeout(timer2);
    //});

