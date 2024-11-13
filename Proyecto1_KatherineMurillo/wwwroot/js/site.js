// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Selecciona todos los elementos input en el documento
var input = document.querySelectorAll('input');         //FUNCION AUTO LENGTH
//Recorre cada elemento de entrada seleccionado
for (i = 0; i < input.length; i++) {
    //Establece el size del input basado en la longitud del texto en el placeholder
    input[i].setAttribute('size', input[i].getAttribute('placeholder').length);
}
//Función para validar el formulario
function validarFormulario() {
    //Obtiene el elemento donde se mostrará el mensaje de retroalimentación
    const feedbackElement = document.getElementById('estadoFeedback');
    //Obtiene el valor del campo estado
    valor = document.getElementById("estado").value;
    //Verifica si nulo, está vacío o contiene solo espacios en blanco
    if (valor == null || valor.length == 0 || /^\s+$/.test(valor)) {
        return false;
        //Actualiza el texto de retroalimentación para indicar un error
        feedbackElement.textContent = "debe digitar algún estado";
    }
}
