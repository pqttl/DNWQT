
function jsShowUpdateOneDetailOrder(intIdDetail,strIdHtmlRowTr) {
    var ebiInput = document.getElementById(strIdHtmlRowTr);
    var ebiTemp = document.createElement('tr');
    //ebiTemp.appendChild(ebiInput.cloneNode(true));
    ebiTemp.innerHTML = ebiInput.innerHTML;
    ebiTemp.removeChild(ebiTemp.lastElementChild);

    var strHtmlStart = '' +
        '<div class="table-responsive mt-1" style="max-width: 450px;" id="idDivTableShowDetail">' +
        '   <table id="infoTable" class="table table-bordered table-sm mb-0">' +
        '      <tbody>' +
        '         <tr class="align-middle">' +
        '';

    var strHtmlEnd = '' +
        '</tr>' +
        '      </tbody>' +
        '   </table>' +
        '</div>' +
        '';

    var strOutput = strHtmlStart + ebiTemp.innerHTML + strHtmlEnd;

    var ebiOutput = document.getElementById('idDivTableShowDetail');
    ebiOutput.outerHTML = strOutput;

    document.getElementById("idABack").href = "#"+strIdHtmlRowTr;
    document.getElementById("idASaveChange").title = "" + intIdDetail;

    jsCollapseDivSuaViThuoc(false);

    var ebiTemp2 = document.getElementById("idInputSuaSoLuong");
    ebiTemp2.focus();
    ebiTemp2.select();
}



