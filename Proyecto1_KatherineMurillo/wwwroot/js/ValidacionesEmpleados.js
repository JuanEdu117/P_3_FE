//Validación de campo de la cédula 
document.getElementById("Cedula").addEventListener("input", function (e) {
    this.value = this.value.replace(/\D/g, ''); //Elimina todo lo que no sea dígito
});
//Validación de campo de nombre
document.getElementById("nombre").addEventListener("keypress", function (e) {
    var char = String.fromCharCode(e.which);
    var regex = /^[a-zA-Z\s]*$/; //Solo letras y espacios
    if (!regex.test(char)) {
        e.preventDefault(); //Bloquea cualquier carácter que no sea permitido
    }
});
//Validación de campo de salario por hora 
document.getElementById("SalarioHora").addEventListener("input", function (e) {
    //Elimina cualquier caracter que no sea número o un punto decimal
    this.value = this.value.replace(/[^0-9.]/g, '');

    //Evita que haya más de un punto decimal
    const parts = this.value.split('.');
    if (parts.length > 2) {
        this.value = parts[0] + '.' + parts[1]; //Solo permite un punto decimal
    }

    //No permite que el primer carácter sea un punto
    if (this.value[0] === '.') {
        this.value = '';
    }
});