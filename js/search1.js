let dataCheck = document.querySelector("#dataCheck");
let searchView4 = document.querySelector("#searchView4");
let searchViewClose4 = document.querySelector("#close4");

searchViewClose4.onclick = () => {
    searchView4.style.transform = "translateY(100%)"
}

dataCheck.onclick = () => {
    searchView4.style.transform = "translateY(0%)"
}
