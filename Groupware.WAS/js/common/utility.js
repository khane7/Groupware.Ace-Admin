var showAlert = function (title, body, isConfirm, successFunc) {

	$("#myModalLabel").html(title);
	$("#myModalBody").html(body);
	if (isConfirm == false) {
		$('#btn-modal-save').hide();
	} else {
		$('#btn-modal-save').show();
		$('#btn-modal-save').click(function () {
			eval(successFunc);
		});
	}

	$("#myModal").modal("show");

}

var hideAlert = function () {

	$("#myModal").modal("hide");

}


//실제 페이지 이동
var goPage = function (pageUrl) {

	showAlert("Wait", "Loading...", false);
	location.href = pageUrl;
	hideAlert();
}

var goPageNum = function (pageNum) {

	showAlert("Wait", "Loading...", false);
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
	history.back();
}

var goList = function (url) {

	//location.href = "/" + url + "?" + removeParameter(location.href, "idx");
	goPage("/" + url + "?" + removeParameter(location.href, "idx"));
}

var goView = function (url, idx) {

	location.href = url + "?idx=" + idx + "&" + removeParameter(location.href, "idx");

}

var goProcess = function (url_, frmId_, successFunc) {

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
			//hideAlert();

			if (data.RESULT == "OK") {
				(successFunc != "") ? eval(successFunc) : "";
			} else {
				showAlert(data.RESULT, data.MSG, false);
			}
			
		},
		beforeSend: function () {
			showAlert("Process", "Loading...", false);
		}
		, error: function (response, textStatus, errorThrown) {
			showAlert(textStatus, errorThrown + "<br>" + response.responseText, false);
		}
	});

}

var goSimpleProcess = function (url_, data_, successFunc) {

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
			showAlert("Process", "Loading...", false);
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