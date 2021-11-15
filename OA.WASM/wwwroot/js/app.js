
function AddClass(selector, className) {

    var element = document.querySelector(selector);
    if (!element.classList.contains(className))
        element.classList.add(className);

}

function RemoveClass(selector, className) {

    var element = document.querySelector(selector);
    if (element.classList.contains(className))
        element.classList.remove(className);

}
