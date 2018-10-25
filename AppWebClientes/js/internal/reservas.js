

window._wpemojiSettings = { "baseUrl": "https:\/\/s.w.org\/images\/core\/emoji\/11\/72x72\/", "ext": ".png", "svgUrl": "https:\/\/s.w.org\/images\/core\/emoji\/11\/svg\/", "svgExt": ".svg", "source": { "concatemoji": "http:\/\/www.falconmasters.com\/wp-includes\/js\/wp-emoji-release.min.js?ver=4.9.8" } };
!function (a, b, c) { function d(a, b) { var c = String.fromCharCode; l.clearRect(0, 0, k.width, k.height), l.fillText(c.apply(this, a), 0, 0); var d = k.toDataURL(); l.clearRect(0, 0, k.width, k.height), l.fillText(c.apply(this, b), 0, 0); var e = k.toDataURL(); return d === e } function e(a) { var b; if (!l || !l.fillText) return !1; switch (l.textBaseline = "top", l.font = "600 32px Arial", a) { case "flag": return !(b = d([55356, 56826, 55356, 56819], [55356, 56826, 8203, 55356, 56819])) && (b = d([55356, 57332, 56128, 56423, 56128, 56418, 56128, 56421, 56128, 56430, 56128, 56423, 56128, 56447], [55356, 57332, 8203, 56128, 56423, 8203, 56128, 56418, 8203, 56128, 56421, 8203, 56128, 56430, 8203, 56128, 56423, 8203, 56128, 56447]), !b); case "emoji": return b = d([55358, 56760, 9792, 65039], [55358, 56760, 8203, 9792, 65039]), !b }return !1 } function f(a) { var c = b.createElement("script"); c.src = a, c.defer = c.type = "text/javascript", b.getElementsByTagName("head")[0].appendChild(c) } var g, h, i, j, k = b.createElement("canvas"), l = k.getContext && k.getContext("2d"); for (j = Array("flag", "emoji"), c.supports = { everything: !0, everythingExceptFlag: !0 }, i = 0; i < j.length; i++)c.supports[j[i]] = e(j[i]), c.supports.everything = c.supports.everything && c.supports[j[i]], "flag" !== j[i] && (c.supports.everythingExceptFlag = c.supports.everythingExceptFlag && c.supports[j[i]]); c.supports.everythingExceptFlag = c.supports.everythingExceptFlag && !c.supports.flag, c.DOMReady = !1, c.readyCallback = function () { c.DOMReady = !0 }, c.supports.everything || (h = function () { c.readyCallback() }, b.addEventListener ? (b.addEventListener("DOMContentLoaded", h, !1), a.addEventListener("load", h, !1)) : (a.attachEvent("onload", h), b.attachEvent("onreadystatechange", function () { "complete" === b.readyState && c.readyCallback() })), g = c.source || {}, g.concatemoji ? f(g.concatemoji) : g.wpemoji && g.twemoji && (f(g.twemoji), f(g.wpemoji))) }(window, document, window._wpemojiSettings);

function convertDateInFormat(date) {
	
	var d;

	if (date == null) {
		d = new Date();
	}
	else {
		d = new Date(date);
	}

	var month = '' + (d.getMonth() + 1);
	var day = '' + d.getDate();
	var year = d.getFullYear();

	if (month.length < 2) month = '0' + month;
	if (day.length < 2) day = '0' + day;

	return [year, month, day].join('-');

}

function convertTimeInFormat(time) {
	var t;

	if (time == null) {
		t = new Date();
	}
	else {
		t = new Date(time);
	}

	var hour = '' + (t.getHours());
	//var minutes = '' + t.getMinutes();
	//var seconds = t.getSeconds();

	if (hour.length < 2) hour = '0' + hour;

	return [hour+":00"];
	
}

var namePattern = "^[a-z A-Z]{4,30}$";
var numberPattern = "^[0-9]$";
var telPattern = "^[0-9]{8,9}$";
var ciPattern = "^[0-9]{8}$";
var emailPattern = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,4}$";

function checkInput(idInput, pattern) {
	return $(idInput).val().match(pattern) ? true : false;
}

function checkSelect(idSelect) {
	return $(idSelect).val() ? true : false;
}



$(document).ready(function load() {



	



	



	$("#frmSetData").hide();
	$("#frmSetReserve").hide();
	$("#divGetTurns").hide();
	$("#divSetAsientos").hide();



	//$(function () {
	//	$('[data-toggle="tooltip"]').tooltip()
	//});


	
	$("#btnOkSetCi").click(function (e) {
		e.preventDefault();

		if (!checkInput("#txtSetCi", ciPattern)) {
			$("#txtSetCi").attr("placeholder", "Formato Incorrecto");
			$("#erSetCi").text("Ingrese solo numeros, sin puntos ni guion");
		}
		else if (!checkSelect("#sltTypeOperation"))
		{
			$("#erSetCi").text("Seleccione el tipo de operacion");
		}
		else
		{

			var ci = $("#txtSetCi").val();


			$.ajax({
				type: "GET",
				contentType: "application/json",
				dataType: "json",
				url: "http://localhost:54993/api/cliente/getCliente?ci=+"+ci+"",
				success: function (ApiResponse) {
					var response = JSON.parse(ApiResponse);

					alert(response.nombre);

				},
				error: function (Apiresponse) {

				}
			});

			$("#frmSetCi").hide();
			$("#lblGetCi").text($("#txtSetCi").val());

			$("#frmSetData").show();

		}


	});
	
	$("#btnOkSetData").click(function (e) {
		e.preventDefault();

		if (!checkInput("#txtSetName", namePattern)) {
			$("#txtSetName").attr("placeholder", "Formato incorrecto");
			$("#erSetData").text("Jessica Cabrera"); 
		}
		else if (!checkInput("#txtSetTel", telPattern)) {
			$("#txtSetTel").attr("placeholder", "Formato incorrecto");
			$("#erSetData").text("Ej: 094113405 o 44323351");
		}
		else if (!checkInput("#txtSetMail", emailPattern) && $("#txtSetMail").val() != "") {
			$("#txtSetMail").attr("placeholder","Formato incorrecto")
			$("#erSetData").text("Ej: Jessuger@gmail.com");
		}
		else {

			$("#dtSetDtTurn").val(convertDateInFormat()); // carga al Date de la fecha del turno con la fecha actual
			$("#dtSetDtTurn").attr("min", (convertDateInFormat())); // carga al Date de la fecha del turno con la fecha actual

			// carga al select de hora aproximada la hora actual aprox
			for (var i = 0; i < document.getElementById("sltSetAproxHour").options.length; i++) {

				item = document.getElementById("sltSetAproxHour").options[i];
				if (item.value == convertTimeInFormat()) {
					document.getElementById("sltSetAproxHour").value = item.value;
					break;
				}
			}


			$("#frmSetData").hide();
			$("#frmSetReserve").show();
		}

	});

	$("#btnOkSetReserve").click(function (e) {
		e.preventDefault();


		if (!checkInput("#txtSetCi", ciPattern)) {
			$("#txtSetCi").attr("placeholder", "Formato Incorrecto");
			$("#erSetCi").text("Ingrese solo numeros, sin puntos ni guion");
		}
		else if (!checkSelect("#sltSetOrigin")) {
			$("#erSetReserve").text("Seleccione el origen");
		}
		else if (!checkSelect("#sltSetOrigin")) {
			$("#erSetReserve").text("Seleccione el destino");
		}
		else if (!checkSelect("#sltSetAproxHour")) {
			$("#erSetReserve").text("Seleccione la hora aproximada");
		}
		else {

			$("#frmSetCi").hide();
			$("#lblGetCi").text($("#txtSetCi").val());

			$("#frmSetData").show();

		}





		$("#divSetAsientos").show();

		$("#frmSetReserve").hide();
		$("#divGetTurns").show();

	});

	$("input[name*='btnCancel']").click(function (e) {
		e.preventDefault();

		$("#frmSetReserve")[0].reset();
		$("#frmSetCi")[0].reset();
		$("#frmSetData")[0].reset();
		window.location.href = "reservas.html";

	});


});










