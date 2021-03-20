let searchButton = document.querySelector("#searchButton");
let searchView1 = document.querySelector("#searchView1");
let searchView2 = document.querySelector("#searchView2");
let searchView3 = document.querySelector("#searchView3");
let searchViewClose1 = document.querySelector("#close1");
let searchViewClose2 = document.querySelector("#close2");
let searchViewClose3 = document.querySelector("#close3");
let yourselfInfo = document.querySelector("#yourselfInfo");
let dataStatistics = document.querySelector("#dataStatistics");


searchButton.onclick = () => {
    searchView1.style.transform = "translateY(0%)";
}

searchViewClose1.onclick = () => {
    searchView1.style.transform = "translateY(100%)";
    searchView2.style.transform = "translateY(100%)";
}
searchViewClose2.onclick = () => {
    searchView1.style.transform = "translateY(100%)";
    searchView2.style.transform = "translateY(100%)";
}
searchViewClose3.onclick = () => {
    searchView2.style.transform = "translateY(100%)";
    searchView3.style.transform = "translateY(100%)";
}

dataStatistics.onclick = () => {
    searchView3.style.transform = "translateY(0%)";
}

yourselfInfo.onclick = () => {
    searchView2.style.transform = "translateY(0%)";
}

yourselfInfo.onclick = () => {
    searchView2.style.transform = "translateY(100%)";
}
yourselfInfo.onclick = () => {
    searchView2.style.transform = "translateY(0%)";
}



