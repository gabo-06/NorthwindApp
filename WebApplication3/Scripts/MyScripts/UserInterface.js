/*
UserInterface.js
----------------
Contiene métodos y funciones generales para controlar la interactividad 
de las páginas como cuadros de diálogo, notificaciones, mensajes de estado, etc.
*/

var northwind = northwind || {}; // Comprueba si el espacio de nombres ya está creado, si no lo crea.
northwind.userInterface = {}; // Crea el contexto de este archivo "UserInterface.js".

// Convierte un combo normal en combo select2.
northwind.userInterface.configurarComboSelect2 = function (combo, data, placeholder) {
    combo.html('').select2({
        width: '100%',
        data: data,
        allowClear: true,
        placeholder: placeholder,
        language: {
            noResults: function () {
                return "No hay datos";
            },
            searching: function () {
                return "Buscando..";
            }
        }
    });
    combo.val(null).trigger('change');
};