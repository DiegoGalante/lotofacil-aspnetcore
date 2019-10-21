var enumConfiguracao = {
    CalcularDezenasSemPontuacao: 1,
    EmailManual: 2,
    ValorMinimoParaEnviarEmail: 3,
    EmailAutomatico: 4,
    VerificaJogoOnline: 5
}

var enumValoresJogos = {
    _15Dezenas: 2.0,
    _16Dezenas: 32.0,
    _17Dezenas: 272.0,
    _18Dezenas: 1632.0
}

var enumDezenas = {
    Um: 1,
    Dois: 2,
    Tres: 3,
    Quatro: 4,
    Cinco: 5,

    Seis: 6,
    Sete: 7,
    Oito: 8,
    Nove: 9,
    Dez: 10,

    Onze: 11,
    Doze: 12,
    Treze: 13,
    Quatorze: 14,
    Quinze: 15,

    Dezesseis: 16,
    Dezessete: 17,
    Dezoito: 18,
    Dezenove: 19,
    Vinte: 20,

    VinteEUm: 21,
    VinteEDois: 22,
    VinteETres: 23,
    VinteEQuatro: 24,
    VinteECinco: 25,
}

function formatNumber(num) {
    return num
        .toFixed(2) // always two decimal digits
        .replace(".", ",") // replace decimal point character with ,
        .replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1.") // use . as a separator
}