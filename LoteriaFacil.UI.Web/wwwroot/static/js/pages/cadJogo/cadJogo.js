var Grupo1 = "",
    Grupo2 = "", Grupo3 = "",
    Grupo4 = "", Grupo5 = "",
    Grupo6 = "", Grupo7 = "";

var ListDezenasFixas = []; //List<int>

var ListGrupo1 = [],
    ListGrupo2 = [], ListGrupo3 = [],
    ListGrupo4 = [], ListGrupo5 = [],
    ListGrupo6 = [], ListGrupo7 = [];

var CorDezenasFixas = str.fontColor("MistyRose");
var CorGrupo1 = str.fontColor("Brown");
var CorGrupo2 = str.fontColor("BlueViolet");
var CorGrupo3 = str.fontColor("BurlyWood");
var CorGrupo4 = str.fontColor("DarkGray");
var CorGrupo5 = str.fontColor("DarkViolet");
var CorGrupo6 = str.fontColor("Goldenrod");
var CorGrupo7 = str.fontColor("Indigo");
var CorPadrao = str.fontColor("White");

var concursoASerSorteado = 0;
var txtDezena = "";
var dezenasExistentes = "";
var cont = 1;
var txtDezenaPadrao = "00-00-00-00-00-00-00-00-00-00-00";


var Btn1 = $('#btn1'), Btn2 = $('#btn2'), Btn3 = $('#btn3'),
    Btn4 = $('#btn4'), Btn5 = $('#btn5'), Btn6 = $('#btn6'),
    Btn7 = $('#btn7'), Btn8 = $('#btn8'), Btn9 = $('#btn9'),
    Btn10 = $('#btn10'), Btn11 = $('#btn11'), Btn12 = $('#btn12'),
    Btn13 = $('#btn13'), Btn14 = $('#btn14'), Btn15 = $('#btn15'),
    Btn16 = $('#btn16'), Btn17 = $('#btn17'), Btn18 = $('#btn18'),
    Btn19 = $('#btn19'), Btn20 = $('#btn20'), Btn21 = $('#btn21'),
    Btn22 = $('#btn22'), Btn23 = $('#btn23'), Btn24 = $('#btn24'),
    Btn25 = $('#btn25');

var btnSalvarJogos = $('#btnSalvarJogos');


$(document).ready(function () {

    ResetaTela();


});


function ResetaTela() {

    concursoASerSorteado = 0;
    cont = 1;
    lbAjuda.Text = "Selecione as dezenas Fexas!";
    lbHover.Text = "";

    $('#btnGerarJogo').removeClass('Hide');
    $('#btnGerarJogoAutomatico').removeClass('Hide');

    for (var i = 0; i <= 25; i++) {
        PintarNumero(i, CorPadrao);
    }

    txtNumSelecionados.Text = txtDezenaPadrao;

    listAutomaticoParFixa = [];
    listAutomaticoImparFixa = [];

    ListDezenasFixas = [];
    ListGrupo1 = [];
    ListGrupo2 = [];
    ListGrupo3 = [];
    ListGrupo4 = [];
    ListGrupo5 = [];
    ListGrupo6 = [];
    ListGrupo7 = [];

    dezenasExistentes = "";

    btnSalvarJogos.Visible = false;
    btnEnviarJogosPorEmail.Visible = false;
}

function PintarNumero(numero, corPintar) {

    //experiemtnar esse cara!
    //$('#btn' + numero).BackColor = corPintar;

    switch (parseInt(numero)) {
        case 1:
            Btn1.BackColor = corPintar;
            break;
        case 2:
            Btn2.BackColor = corPintar;
            break;
        case 3:
            Btn3.BackColor = corPintar;
            break;
        case 4:
            Btn4.BackColor = corPintar;
            break;
        case 5:
            Btn5.BackColor = corPintar;
            break;
        case 6:
            Btn6.BackColor = corPintar;
            break;
        case 7:
            Btn7.BackColor = corPintar;
            break;
        case 8:
            Btn8.BackColor = corPintar;
            break;
        case 9:
            Btn9.BackColor = corPintar;
            break;
        case 10:
            Btn10.BackColor = corPintar;
            break;
        case 11:
            Btn11.BackColor = corPintar;
            break;
        case 12:
            Btn12.BackColor = corPintar;
            break;
        case 13:
            Btn13.BackColor = corPintar;
            break;
        case 14:
            Btn14.BackColor = corPintar;
            break;
        case 15:
            Btn15.BackColor = corPintar;
            break;
        case 16:
            Btn16.BackColor = corPintar;
            break;
        case 17:
            Btn17.BackColor = corPintar;
            break;
        case 18:
            Btn18.BackColor = corPintar;
            break;
        case 19:
            Btn19.BackColor = corPintar;
            break;
        case 20:
            Btn20.BackColor = corPintar;
            break;
        case 21:
            Btn21.BackColor = corPintar;
            break;
        case 22:
            Btn22.BackColor = corPintar;
            break;
        case 23:
            Btn23.BackColor = corPintar;
            break;
        case 24:
            Btn24.BackColor = corPintar;
            break;
        case 25:
            Btn25.BackColor = corPintar;
            break;

        default:
            break;
    }
}