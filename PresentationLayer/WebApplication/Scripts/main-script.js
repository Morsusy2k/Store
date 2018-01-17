$(document).ready(function () {
    $(".main-top-bar-hover").mouseenter(function () {
        $(".main-top-bar-container").stop().animate({
            top: "-30"
        },200);
    });
    $(".main-top-bar-hover").mouseleave(function () {
        $(".main-top-bar-container").stop().animate({
            top: "-52"
        }, 200);
    });

    $('#main-nav-lava').lavalamp({
        easing: 'easeOutBack',
        duration: 200,
        deepFocus: true
    });

    $("li.lavalamp-item a").mouseenter(function () {
        if (!$(this).parent().hasClass("active")) {
            $("li.active a").css("color","deepskyblue");
        }
    });
    $("li.lavalamp-item a").mouseleave(function () {
        $("li.active a").css("color", "white");
    });
});