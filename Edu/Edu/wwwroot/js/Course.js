"use strict"



var btnLoad = document.querySelector(".btn-load");

btnLoad.addEventListener("click", function () {
    var parent = document.querySelector(".parent-load");
    var take = parseInt(document.querySelector(".input-load").value);
    var skip = parent.children.length;

    var productsCount = parseInt(parent.getAttribute("data-count"));

    if (take <= 0 || take >= productsCount - skip) {
        take = skip;
    }

    fetch(`Course/LoadMore?skip=${skip}&take=${take}`)
        .then(response => response.text())
        .then(result => {
            var parser = new DOMParser();
            var html = parser.parseFromString(result, "text/html");
            var partialView = html.querySelector(".parent-load");

            parent.innerHTML += partialView.innerHTML;
            document.querySelector(".input-load").value = "";
            skip = parent.children.length;

            if (skip >= productsCount) {
                btnLoad.classList.add("d-none");
                document.querySelector(".input-load").classList.add("d-none");
            }
        })
       
});
