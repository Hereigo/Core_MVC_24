
// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

document.addEventListener("DOMContentLoaded", function () {

    const mainContainer = document.getElementById("main-container");

    if (document.getElementById("isWideList")) {
        mainContainer.classList.remove("container");
        mainContainer.classList.add("wide-container");
    } else {
        mainContainer.classList.remove("wide-container");
        mainContainer.classList.add("container");
    }
});