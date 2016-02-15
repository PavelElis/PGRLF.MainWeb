function hideElement(element) {
    $(element).hide(500);
}

function showElement(element) {
    $(element).show(500);
}

function showLastLabelAdd(div) {
    var labelAdd = $(div + " > .callout").last().find(".label.add");
    showElement(labelAdd);
}

function updateFyzickaOsoba() {
    hideElement("#divPravnickaOsoba");
    hideElement("#divSvazekObci");
    hideElement("#divPlanovaneUkonceni");

    showElement("#divFyzickaOsoba");
    showElement("#divObchodniRejstrik");
    updateFOMistoPodnikani();
    updateProdejPodniku();
    updateUkonceniCinnosti();
}

function updatePravnickaOsoba() {
    hideElement("#divFyzickaOsoba");
    hideElement("#divSvazekObci");

    showElement("#divPravnickaOsoba");
    showElement("#divObchodniRejstrik");
    showElement("#divPlanovaneUkonceni");
    showLastLabelAdd("#divZodpovednaOsobaList");
    updatePOMistoPodnikani();
    updateProdejPodniku();
    updateUkonceniCinnosti();
}

function updateSvazekObci() {
    hideElement("#divFyzickaOsoba");
    hideElement("#divPravnickaOsoba");
    hideElement("#divObchodniRejstrik");
    hideElement("#divPlanovaneUkonceni");

    showElement("#divSvazekObci");
}

function updateFOMistoPodnikani() {
    if ($("#cbFOMistoPodnikani").prop("checked")) {
        hideElement("#divFOMistoPodnikani");
    } else {
        showElement("#divFOMistoPodnikani");
    }
}

function updatePOMistoPodnikani() {
    if ($("#cbPOMistoPodnikani").prop("checked")) {
        hideElement("#divPOMistoPodnikani");
    } else {
        showElement("#divPOMistoPodnikani");
    }
}
        
function updateProdejPodniku() {
    if ($("#cbProdejPodniku").prop("checked")) {
        showElement("#divProdejPodnikuDatum");
    } else {
        hideElement("#divProdejPodnikuDatum");
    }
}

function updateUkonceniCinnosti() {
    if ($("#cbUkonceniCinnosti").prop("checked")) {
        showElement("#divUkonceniCinnostiDatum");
    } else {
        hideElement("#divUkonceniCinnostiDatum");
    }
}

function updatePravniForma() {
    switch ($("input[name=PravniForma]:checked").prop("id")) {
        case "rbFyzickaOsoba":
            updateFyzickaOsoba();
            break;
        case "rbPravnickaOsoba":
            updatePravnickaOsoba();
            break;
        case "rbSvazekObci":
            updateSvazekObci();
            break;
    }
}

function updateDeMinimis() {
    switch ($("input[name=DeMinimis\\.DM1UcetniObdobi]:checked").prop('id')) {
        case "rbDM1UcetniObdobiKR":
            hideElement("#divDM1UcetniObdobiZacatek");
            hideElement("#divDM1UcetniObdobiKonec");
            break;
        case "rbDM1UcetniObdobiHR":
            showElement("#divDM1UcetniObdobiZacatek");
            showElement("#divDM1UcetniObdobiKonec");
            break;
    }
    switch ($("input[name=DeMinimis\\.DM2Propojeni]:checked").prop('id')) {
        case "rbDM2NeniPropojen":
            hideElement("#divDM2Propojeni");
            break;
        case "rbDM2JePropojen":
            showElement("#divDM2Propojeni");
            showLastLabelAdd("#divDM2PropojeniList");
            break;
    }
    switch ($("input[name=DeMinimis\\.DM3Spojeni]:checked").prop('id')) {
        case "rbDM3NevzniklSpojenim":
            hideElement("#divDM3Spojeni");
            break;
        case "rbDM3VzniklSpojenim":
            showElement("#divDM3Spojeni");
            showLastLabelAdd("#divDM3SpojeniList");
            break;
        case "rbDM3Prevzal":
            showElement("#divDM3Spojeni");
            showLastLabelAdd("#divDM3SpojeniList");
            break;
    }
    switch ($("input[name=DeMinimis\\.DM4Rozdeleni]:checked").prop('id')) {
        case "rbDM4NevzniklRozdelenim":
            hideElement("#divDM4Rozdeleni");
            break;
        case "rbDM4VzniklRozdelenim":
            showElement("#divDM4Rozdeleni");
            showLastLabelAdd("#DM4RozdeleniPodporaList");
            break;
    }
}

function updateView() {
    updatePravniForma();
    updateDeMinimis();
}

$.validator.addMethod("mustbetrue", function(value) {
    return value;
});

$.validator.unobtrusive.adapters.addBool("mustbetrue");