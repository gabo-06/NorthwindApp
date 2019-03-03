/*
UserInterface.js
----------------
Contiene métodos y funciones generales para controlar la interactividad 
de las páginas como cuadros de diálogo, notificaciones, mensajes de estado, etc.
*/

// #region Definición de Espacios de nombres.
var northwind = northwind || {}; // Comprueba si el espacio de nombres ya está creado, si no lo crea.
northwind.userInterface = {}; // Crea el contexto de este archivo "UserInterface.js".
// #endregion

northwind.userInterface.configurarControlDeFecha = function (controlFecha)
{
	controlFecha.datepicker({
		autoclose: true,
		language: "es",
		// format: "yyyy-mm-dd"
		format: "dd/mm/yyyy",
		orientation: "bottom auto"
	});
};

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