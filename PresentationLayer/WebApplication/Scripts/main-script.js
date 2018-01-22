$(document).ready(function () {
    $(".main-cover").fadeIn('fast');
    $(".main-footer").css("top",$(document).height()+30);

    $(".main-top-bar-hover").mouseenter(function () {
        $(".main-top-bar-container").stop().animate({
            top: "0"
        }, 200);
    });
    $(".main-top-bar-hover").mouseleave(function () {
        $(".main-top-bar-container").stop().animate({
            top: "-22"
        }, 200);
    });

    $('#main-nav-lava').lavalamp({
        easing: 'easeOutBack',
        duration: 200,
        deepFocus: true
    });

    $("li.lavalamp-item").mouseenter(function () {
        if (!$(this).hasClass("active")) {
            $("li.active a").css("color", "deepskyblue");
        }
    });
    $("li.lavalamp-item").mouseleave(function () {
        $("li.active a").css("color", "white");
    });

    $("ul.main-navbar li.main-category").hover(
        function () {
            $(".main-category-dropdown").stop().fadeIn('fast');
            $(".main-login-form").stop().animate({ opacity: "0" }, 200).hide();
            $(".main-cover-text").stop().animate({ opacity: "0" }, 200).hide();
            $(".main-cover-search").stop().animate({ opacity: "0" }, 200).hide();
        }, function () {
            $(".main-category-dropdown").stop().fadeOut('fast');
            $(".main-login-form").show().stop().animate({ opacity: "0.9" }, 200);
            $(".main-cover-text").show().stop().animate({ opacity: "0.9" }, 200);
            $(".main-cover-search").show().stop().animate({ opacity: "0.7" }, 200);
        }
    );
    $("li.main-sub-cat").hover(
        function () {
            $(this).children('ul').stop().fadeIn('fast');
            $(".main-cover-text").stop().animate({ opacity: "0" }, 200).hide();
            $(".main-cover-search").stop().animate({ opacity: "0" }, 200).hide();
        }, function () {
            $(this).children('ul').stop().fadeOut('fast');
            $(".main-cover-text").show().stop().animate({ opacity: "0.9" }, 200);
            $(".main-cover-search").show().stop().animate({ opacity: "0.7" }, 200);
        }
    );

    
});