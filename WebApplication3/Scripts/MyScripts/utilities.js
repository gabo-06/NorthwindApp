var northwind = northwind || {};
northwind.utilities = {};

northwind.utilities.paddy = function (num, padlen, padchar)
{
	var pad_char = typeof padchar !== 'undefined' ? padchar : '0';
	var pad = new Array(1 + padlen).join(pad_char);

	return (pad + num).slice(-pad.length);
}

northwind.utilities.convertDate = function (dateString)
{
	var dateObject = new Date(parseInt(dateString.replace('/Date(', '')));
	var month = northwind.utilities.paddy(dateObject.getMonth() + 1, 2);
	var day = northwind.utilities.paddy(dateObject.getDate(), 2);
	var year = dateObject.getFullYear();
	var newDateString = month + "/" + day + "/" + year;

	return newDateString;
};