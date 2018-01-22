$(document).ready(function () {
    $("#ManageCategories").click(function (e) {
        RenderCategories();
    });

    $(document).on('click', '.get-subcategories', function () {
        $(".main-acp-nav-container li").removeClass("active-category");
        $(this).parents("li").addClass("active-category");

        RenderSubCategories($(this).attr("id"));
    });

    $(document).on('click', '.main-article-load-images', function () {
        RenderEditImages($(this).attr('id'));
    });

    $("#ManageArticles").click(function () {
        RenderAddArticle();
        RenderAllArticles();
    });

    $(document).on('focus', '.autocomplete-off', function () {
        $(this).attr("autocomplete", "off");
    });

    function RenderCategories() {
        $("#subcategory-display").empty();
        $("#image-category").empty();
        $.ajax({
            type: "GET",
            url: "Acp/LoadManageCategories",
            success: function (response) {
                $("#main-acp-display").html(response);
            },
            error: function () {
                alert("Error!");
            }
        });
    }

    function RenderSubCategories(id) {
        $.ajax({
            type: "GET",
            url: "Acp/LoadManageSubCategories",
            data: { categoryId: id },
            contentType: "application/json; charset=utf-8",
            dataType: "html",
            success: function (response) {
                $("#subcategory-display").html(response);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    }

    function RenderAddArticle() {
        $("#subcategory-display").empty();
        $.ajax({
            type: "GET",
            url: "Acp/LoadNewArticles",
            success: function (response) {
                $("#main-acp-display").html(response);
            },
            error: function () {
                alert("Error!");
            }
        });
    }

    function RenderAllArticles() {
        $.ajax({
            type: "GET",
            url: "Acp/LoadManageArticles",
            success: function (response) {
                $("#subcategory-display").html(response);
            },
            error: function () {
                alert("Error!");
            }
        });
    }

    function RenderEditArticle(id) {
        $.ajax({
            type: "GET",
            url: "Acp/LoadEditArticle",
            data: { articleId: id },
            contentType: "application/json; charset=utf-8",
            dataType: "html",
            success: function (response) {
                $("#main-acp-display").html(response);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    }

    function RenderEditImages(id) {
        $.ajax({
            type: "GET",
            url: "Acp/LoadEditImages",
            data: { articleId: id },
            contentType: "application/json; charset=utf-8",
            dataType: "html",
            success: function (response) {
                $("#image-category").html(response);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    }

    if (UrlParams('render') === 'cat') {
        RenderCategories();
    }

    if (UrlParams('render') === 'sub') {
        RenderCategories();
        var cid = UrlParams('catId');
        RenderSubCategories(cid);
    }

    if (UrlParams('render') === 'art') {
        RenderAddArticle();
        RenderAllArticles();
    }

    if (UrlParams('render') === 'editart') {
        var eid = UrlParams('articleId');

        RenderEditArticle(eid);
        RenderAllArticles();
    }

    if (UrlParams('render') === 'img') {
        var iid = UrlParams('articleId');

        RenderAddArticle();
        RenderAllArticles();
        RenderEditImages(iid);
    }

    $(document).on('click', '.delete-button', function () {
        return confirm("Are you sure you want to delete?");
    });

    function UrlParams(prop) {
        var params = {};
        var search = decodeURIComponent(window.location.href.slice(window.location.href.indexOf('?') + 1));
        var definitions = search.split('&');
        definitions.forEach(function (val, key) {
            var parts = val.split('=', 2);
            params[parts[0]] = parts[1];
        });
        return (prop && prop in params) ? params[prop] : params;
    }
});