function ToggleInvisible(prompt) {
    var element = document.querySelector("" + prompt);
    if (element == null) {
        return;
    }
    element.classList.toggle("invisible");
}
function ToggleLoggedUserMenu() {
    ToggleInvisible(".user-greeting + ul");
}
