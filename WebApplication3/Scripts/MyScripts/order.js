// #region Definición de Espacios de nombres.
var northwind = northwind || {};
northwind.mantenimientoOrden = {};

northwind.mantenimientoOrden.formulario = {};
northwind.mantenimientoOrden.formulario.controles = {};
northwind.mantenimientoOrden.formulario.controles.NewCustomer = {};

northwind.mantenimientoOrden.tablaMantenimiento = {};
northwind.mantenimientoOrden.tablaMantenimiento.fila = {};
// #endregion

// #region Configuraciones
northwind.mantenimientoOrden.configurarTablaDataTables = function ()
{
	northwind.mantenimientoOrden.tabla = $("#tblOrdenes").DataTable({
		"pagingType": "simple_numbers",
		"proccessing": true,
		"serverSide": true,
		"ajax": {
			"url": "/Order/dataOrdenes",
			"type": "POST",
			"dataType": "JSON"
		},
		"columnDefs":
			[
				{
					"targets": [0],
					"createdCell": function (column, cellData, rowData, rowIndex, columnIndex)
					{
						var row;
						row = $(column).parent();
						$(column).addClass("OrderID");
						$(row).attr("Order-ID", rowData.orderID);
						$(row).attr("Customer-ID", rowData.customer.CustomerID);
					}
				}
			],
		"columns":
			[
				{ data: "customer.CompanyName" },
				{
					"data": "orderDate",
					"render": function (data, type, full, meta)
					{
						return northwind.utilities.convertDate(data);
					}
				},
				{
					data: "requiredDate",
					"render": function (data, type, full, meta)
					{
						return northwind.utilities.convertDate(data);
					}
				},
				{
					data: "shippedDate",
					"render": function (data, type, full, meta)
					{
						return northwind.utilities.convertDate(data);
					}
				},
				{ data: "shipName" },
				{ data: "shipAddress" },
				{ data: "shipCity" },
				{ data: "shipRegion" },
				{ data: "shipCountry" },
				{ data: "shipPostalCode" }
			],
		"language": {
			"processing": "DataTables is currently busy"
		}
	});
};
// #endregion Configuraciones
// #region	Métodos
northwind.mantenimientoOrden.tablaMantenimiento.fila.expandeContenidoCompleto = function (e)
{
	const celda = $(e.toElement);

	if (celda.hasClass('OrderID') || celda.hasClass('OrderIDno')) // Verifica si la celda sobre la que se hizo click es la primera para poder expander el contenido completo de la fila.
		celda.toggleClass("OrderIDno").toggleClass("OrderID");
};
// #endregion
// #region Eventos
northwind.mantenimientoOrden.formulario.controles.NewCustomer.click = function ()
{
	alert("Abre registro de nuevo cliente");
};
northwind.mantenimientoOrden.tablaMantenimiento.fila.click = function (e)
{
	northwind.mantenimientoOrden.tablaMantenimiento.fila.expandeContenidoCompleto(e);
};
// #endregion Eventos

northwind.mantenimientoOrden.inicio = function ()
{
	// #region Configuraciones
	northwind.userInterface.configurarControlDeFecha($("#dtpOrderDate"));
	northwind.userInterface.configurarControlDeFecha($("#dtpRequiredDate"));
	northwind.userInterface.configurarControlDeFecha($("#dtpShippedDate"));

	northwind.userInterface.configurarComboSelect2($("#cmbCountry"), null, "Select a country...");
	northwind.userInterface.configurarComboSelect2($("#cmbRegion"), null, "Select a region...");
	northwind.userInterface.configurarComboSelect2($("#cmbCity"), null, "Select a city...");

	northwind.mantenimientoOrden.configurarTablaDataTables();
	// #endregion
	// #region Eventos
	$("#NewCustomer").on("click", northwind.mantenimientoOrden.formulario.controles.NewCustomer.click);
	$("#tblOrdenes > tbody").on("click", "tr", northwind.mantenimientoOrden.tablaMantenimiento.fila.click);
	// #endregion
};

$(northwind.mantenimientoOrden.inicio);