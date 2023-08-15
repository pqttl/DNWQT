
function voidConvertNumberToCurrency(nNumber, strBegin, strEnd, nSoKyTuThapPhan) {
    //FractionDigits ký tự thập phân
    //Nếu số có phần thập phân thì để nSoKyTuThapPhan chữ số sau dấu thập phân
    if (nNumber % 1 == 0) {
        return strBegin + nNumber.toFixed(0).replace(/\B(?=(\d{3})+(?!\d))/g, ',') + strEnd;
    }

    let nMulti10 = 1;
    for (let i = 0; i < nSoKyTuThapPhan; i++) {
        if (i > nSoKyTuThapPhan) {
            return strBegin + nNumber.toFixed(nSoKyTuThapPhan).replace(/(\d)(?=(\d{3})+\.)/g, '$1,') + strEnd;
        }

        //nMulti10 *= 10;
        nMulti10 = math.multiply(nMulti10, 10);

        //var temp = nNumber * nMulti10;
        var temp = math.multiply(nNumber, nMulti10);
        if (temp % 1 == 0) {
            return strBegin + nNumber.toFixed(i+1).replace(/\B(?=(\d{3})+(?!\d))/g, ',') + strEnd;
        }
    }

    return strBegin + nNumber.toFixed(nSoKyTuThapPhan).replace(/(\d)(?=(\d{3})+\.)/g, '$1,') + strEnd;
}
