﻿
//실제 페이지 이동
var goPage = function (pageUrl) {

	showLoading();
	location.href = pageUrl;
	//hideAlert();
}

var goPageNum = function (pageNum) {

	showLoading();
	var params = "";
	params = removeURLParameter(location.href, "pageNum");
	params = removeParameter(params, "idx");

	if (params != "") {
		goPage("./?" + params + "&pageNum=" + pageNum);
	} else {
		goPage("./?" + "pageNum=" + pageNum);
	}
	
}

var goBack = function () {
	showLoading();
	history.back();
}

var goList = function (url) {

	//location.href = "/" + url + "?" + removeParameter(location.href, "idx");
	showLoading();
	goPage("/" + url + "?" + removeParameter(location.href, "idx"));
}

var goView = function (url, idx) {

	showLoading();
	location.href = url + "?idx=" + idx + "&" + removeParameter(location.href, "idx");
}

var doProcess = function (url_, frmId_, successFunc) {

	$.ajax({
		url: url_,
		global: false,
		type: "POST",
		data: $("#" + frmId_).serialize(),
		dataType: "json",
		async: true,
		clearForm: true,
		resetForm: true,
		success: function (data) {

			if (data.RESULT == "OK") {
				(successFunc != "") ? eval(successFunc) : "";
			} else {
				showAlert(data.RESULT, data.MSG, false);
			}
			
		},
		beforeSend: function () {
			showLoading();
		}, complete: function () {
			//hideAlert();
		}
		, error: function (response, textStatus, errorThrown) {
			showAlert(textStatus, errorThrown + "<br>" + response.responseText, false);
		}
	});

}

var getProcess = function (url_, data_, successFunc) {

	$.ajax({
		url: url_,
		global: false,
		type: "POST",
		data: data_,
		dataType: "json",
		async: true,
		clearForm: true,
		resetForm: true,
		success: function (data) {
			hideAlert();

			(successFunc != "") ? eval(successFunc) : "";
		},
		beforeSend: function () {
			showLoading();
		}, complete: function () {
			//hideAlert();
		}
		, error: function (response, textStatus, errorThrown) {
			showAlert(textStatus, errorThrown + "<br>" + response.responseText, false);
		}
	});

}





/**
 * GET 방식으로 넘어온 Parameter 가져오기
 * @returns {String}
 */
var getURLParams = function () {
	var thisUrl = unescape(location.href);
	var params = "";
	if (thisUrl.indexOf("?") > -1 ) {
		params = thisUrl.split("?")[1];
	} else {
		params = "";
	}
	return (params != "") ? "&" + params : "";
}

var getParameter = function(strParamName) {
	var arrResult = null;
	if (strParamName) {
		arrResult = location.search.match(new RegExp("[&?]" + strParamName + "=(.*?)(&|$)"));
	}
	return arrResult && arrResult[1] ? arrResult[1] : "";
}

var removeParameter = function (url, parameter) {
	//prefer to use l.search if you have a location/link object
	var urlparts = url.split('?');
	if (urlparts.length >= 2) {

		var prefix = encodeURIComponent(parameter) + '=';
		var pars = urlparts[1].split(/[&;]/g);

		//reverse iteration as may be destructive
		for (var i = pars.length; i-- > 0;) {
			//idiom for string.startsWith
			if (pars[i].lastIndexOf(prefix, 0) !== -1) {
				pars.splice(i, 1);
			}
		}

		url = pars.join('&');
		return url;
	} else {
		return "";
	}
}

var removeURLParameter = function(url, parameter) {
	//prefer to use l.search if you have a location/link object
	var urlparts = url.split('?');
	if (urlparts.length >= 2) {

		var prefix = encodeURIComponent(parameter) + '=';
		var pars = urlparts[1].split(/[&;]/g);

		//reverse iteration as may be destructive
		for (var i = pars.length; i-- > 0;) {
			//idiom for string.startsWith
			if (pars[i].lastIndexOf(prefix, 0) !== -1) {
				pars.splice(i, 1);
			}
		}

		url = urlparts[0] + '?' + pars.join('&');
		return url;
	} else {
		return url;
	}
}

var getURLPage = function() {
	var result = '';
	var thisUrl = unescape( location.href );
	var url = thisUrl.split('?')[0];
	var arrData = url.split("/");
	
	return arrData[arrData.length-1];
}