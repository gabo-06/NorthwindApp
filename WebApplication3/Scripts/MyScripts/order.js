var northwind = northwind || {};
northwind.mantenimientoOrden = {};

northwind.mantenimientoOrden.inicio = function ()
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

	$("#tblOrdenes > tbody").on("click", "tr", function (e)
	{
		$(this).find("td:eq(0)").toggleClass("OrderIDno").toggleClass("OrderID");
	});
};

$(northwind.mantenimientoOrden.inicio);
