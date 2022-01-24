
function numero(xx) {
    pantalla = document.getElementById("textoPantalla");
    valor = document.getElementById("valores");
    if (xx == -2) {
        pantalla.innerHTML = "";
        valor.value = "";
    }
    else {
        if (pantalla.innerHTML.length == 4 || pantalla.innerHTML.length == 9 || pantalla.innerHTML.length == 14)
            pantalla.innerHTML += "-";
        pantalla.innerHTML += xx;
        valor.value += xx;
    }
}

function tomarNumero(num) {
    var arrayNum = num.split("-");
    var result = arrayNum[0] + arrayNum[1] + arrayNum[2] + arrayNum[4]; 
    return result;
}