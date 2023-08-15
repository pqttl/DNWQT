
function capitalizeFirstLetter(string) {
    return string.charAt(0).toUpperCase() + string.slice(1);
}

function voidChangeWidthTwoSpanChoBangNhau(objParam1, objParam2) {
    objParam1.css('width', 'auto');
    objParam2.css('width', 'auto');

    var n1 = objParam1.width();
    var n2 = objParam2.width();
    if (n1<n2) {
        n1 = n2;
    }
    objParam2.width(n1);
    objParam1.width(n1);
}

function voidInputXEnterThiIdYClick(ebiInputX, ebiIdY) {
    ebiInputX.addEventListener("keydown", function (e) {
        if (e.keyCode == 13) {
            /*If the ENTER key is pressed, prevent the form from being submitted,*/
            e.preventDefault();
            ebiIdY.click();
        }
    });
}

function sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}

function toggleCollapseForId(jqoInput) {
    if (!jqoInput.hasClass("collapse") && !jqoInput.hasClass("show")) {
        jqoInput.addClass("collapse");
        return;
    }
    if (jqoInput.hasClass("collapse") && jqoInput.hasClass("show")) {
        jqoInput.removeClass("show");
        return;
    }
    if (jqoInput.hasClass("collapse") && !jqoInput.hasClass("show")) {
        jqoInput.addClass("show");
        return;
    }
}

function setCollapseForId(jqoInput, blnHideCollapse) {
    jqoInput.removeClass("collapse");
    jqoInput.removeClass("show");

    if (blnHideCollapse == true) {

        jqoInput.addClass("collapse");
        return;
    }

    jqoInput.addClass("collapse");
    jqoInput.addClass("show");
}

function setDisableAllForIdAndChild(jqoInput, blnDisable) {
    if (blnDisable == true) {
        jqoInput.addClass("disabledElement");
        //jqoInput.find("a").addClass("disabledElement");
    } else {
        jqoInput.removeClass("disabledElement");
        //jqoInput.find("a").removeClass("disabledElement");
    }

    //// This will disable just the div
    //ebiHTMLDOMObj.disabled = blnDisable;

    jqoInput.find("*").prop('disabled', blnDisable);

    //if (blnSetForChild == false) {
    //    return;
    //}

    //jqoInput.find('input').each(function () {
    //    $(this).attr('disabled', 'disabled');
    //});

    //// This will disable all the children of the div
    //var nodes = ebiHTMLDOMObj.getElementsByTagName('*');
    //for (var i = 0; i < nodes.length; i++) {
    //    nodes[i].disabled = blnDisable;
    //}
}

function voidChangeTextIfOldText(objInput, strOld, strNew) {
    if (objInput.innerHTML == strOld) {
        objInput.innerHTML = strNew;
    }
}

function voidResetTextAndFocus(ebiInput, strText) {
    ebiInput.value = strText;
    ebiInput.focus();
}

function StrDateddmmyyyy(d) {
    var datestring = ("0" + d.getDate()).slice(-2) + "/"
        + ("0" + (d.getMonth() + 1)).slice(-2) + "/" +
        d.getFullYear();
    return datestring;
}

function voidSetDateForIdByString(strId, strDate) {
    document.getElementById(strId).value = strDate;
    $("#" + strId).datepicker('setDate', $("#" + strId).val());
}

//https://codepen.io/vsfvjiuv-the-typescripter/pen/mdMeJwL
//https://uxsolutions.github.io/bootstrap-datepicker/?markup=input&format=&weekStart=&startDate=&endDate=&startView=0&minViewMode=0&maxViewMode=4&todayBtn=false&clearBtn=false&language=en&orientation=auto&multidate=&multidateSeparator=&keyboardNavigation=on&forceParse=on#sandbox

function voidSetupDatePickerForId(strId) {
    $("#" + strId).datepicker({
        format: "dd/mm/yyyy",
        weekStart: 1,
        todayBtn: "linked",
        clearBtn: true,
        language: "vi",
        daysOfWeekHighlighted: "0",
        autoclose: true,
        todayHighlight: true
    });
}

function voidCallAjaxGetByUrlArrayInput(strUrl, arrayStrInput) {
    $.ajax({
        type: 'GET',
        url: strUrl,
        traditional: true,
        data: { arrayStrInput: arrayStrInput },
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (res) {
            voidAfterUseAjax(res);
        }
    });
}

function voidCallAjaxGetByUrlWith1ResultArrayInput(strUrl, arrayStrInput, resultJsonBefore) {
    $.ajax({
        type: 'GET',
        url: strUrl,
        traditional: true,
        data: { arrayStrInput: arrayStrInput },
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (res) {
            voidAfterUseAjaxWith1Result(res, resultJsonBefore);
        }
    });
}

function voidShowLoadingWithTitlePercent(strTitle, strPercent) {

    if (strTitle!="") {
        return;
    }

    document.getElementById("idStrTitle").innerHTML = strTitle;
    document.getElementById("idStrPercent").innerHTML = strPercent;
    //setCollapseForId($("#idButtonAccept"), true);
    setCollapseForId($("#idButtonClose"), true);
    $("#idDivStaticBackdropLivePopup").modal('show');

}

function voidLoadHtmlAndRunJs(strIdHtml, strUrlHtml, strIdJs, strUrlJs, arrayStrInput, resultJson) {

    document.getElementById(strIdHtml).innerHTML = "";
    let ebiTemp = document.getElementById(strIdJs);
    if (ebiTemp != null) {
        ebiTemp.outerHTML = "";
    }

    $('#' + strIdHtml).load(strUrlHtml, function () {
        //alert( "Load was performed." );

        voidCallAjaxGetByUrlWith1ResultArrayInput(strUrlJs, arrayStrInput, resultJson);
        //-> voidAfterUseAjax
        //-> JsonResult...

    });

}

function voidBasicToCopy() {

}
