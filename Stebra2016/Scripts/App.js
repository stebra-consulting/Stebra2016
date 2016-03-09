$(document).ready(function () {
    $("#omStebra").click(function () {
        if (!$("#helper").is(":visible")) {

            $("#helper").show();
        }
        else {

            $("#helper").hide();
        }

    });
    $("#helper").click(function () {
        if ($("#colorPicker").is(":visible")) {

            $("#colorPicker").hide();
        }
        else {
            $("#colorPicker").show();
        }


    });
    $(".x").click(function () {
        if ($("#colorPicker").is(":visible")) {

            $("#colorPicker").hide();
        }


    });

    var colorThis;
    $(".chooseDivider").click(function () {
        colorThis = $(this).text();
        
    });

    $(".thisColor").click(function () {
        var fullName = ".dividers" + colorThis;
        $(fullName).css("background-color", $(this).text());
    });

    $("#change").click(function () {
        var fullName = ".dividers" + colorThis;
        $(fullName).css("background-color", $("#customColor").val());
    });



    //Navbar Hide on click outside 
    $(".navbar-nav li a").click(function (event) {
        $(".navbar-collapse").collapse('hide');
    });
    //or inside body
    $("body").click(function (event) {
        $(".navbar-collapse").collapse('hide');
    });



    //contact us form maintain scroll position
    if (document.getElementById('isPostBack')) {

        //commenting this out since Safari browser triggers it too early
        //window.location.hash = '#kontakta'; 

        alert("Tack, vi har tagit emot ditt meddelande");
    }

    //hover portrait images
    var src;
    $(".person").hover(function () {
        src = $(this).attr('src');
        var substring = $(this).attr('src').split('.');
        var newSrc = substring[0] + "_hover." + substring[1];
        $(this).attr('src', newSrc);
    }, function () { //change it back
        $(this).attr('src', src);
    });




    //GA COMMENT MADE IN LOCAL WORK
    (function (i, s, o, g, r, a, m) {
        i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
            (i[r].q = i[r].q || []).push(arguments)
        }, i[r].l = 1 * new Date(); a = s.createElement(o),
        m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
    })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

    ga('create', 'UA-73305552-1', 'auto');
    ga('send', 'pageview');



    $(window).scroll(function () {
        if ($(document).scrollTop() > 400) {
            $('nav').addClass('shrink');
            $("#navImg").attr("src", "/Images/Logo/stebra_logo_white_notagline.png");

        } else {
            $('nav').removeClass('shrink');
            $("#navImg").attr("src", "/Images/Logo/stebra_logo_white.png");//stor med slogan
        }
    });


});