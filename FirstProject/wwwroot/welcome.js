


let user = JSON.parse(sessionStorage.getItem("details"))
let name = user[0].firstName;
document.getElementById("aa").innerHTML = name;


