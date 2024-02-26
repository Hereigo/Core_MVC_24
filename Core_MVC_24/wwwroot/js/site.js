
// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

document.addEventListener("DOMContentLoaded", function () {

    // Extend size for List page.

    const mainContainer = document.getElementById("main-container");

    if (document.getElementById("isWideList")) {
        mainContainer.classList.remove("container");
        mainContainer.classList.add("wide-container");
    } else {
        mainContainer.classList.remove("wide-container");
        mainContainer.classList.add("container");
    }

    // Loader while submit is processing.

    const homeForm = document.getElementById("homeForm");
    const homeLoader = document.getElementById("homeLoader");

    if (homeForm) {
        homeForm.style.display = "block";
        homeLoader.style.display = "none";

        homeForm.addEventListener("submit", () => {
            homeForm.style.display = "none";
            homeLoader.style.display = "block";
        });
    }
});