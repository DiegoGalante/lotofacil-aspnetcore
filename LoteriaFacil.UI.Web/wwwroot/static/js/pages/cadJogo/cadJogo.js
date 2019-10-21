var imported = document.createElement('script');
imported.src = '~/static/js/utils.js';
document.head.appendChild(imported);

var Grupo1 = "",
    Grupo2 = "", Grupo3 = "",
    Grupo4 = "", Grupo5 = "",
    Grupo6 = "", Grupo7 = "";

var ListDezenasFixas = []; //List<int>

var ListGrupo1 = [],
    ListGrupo2 = [], ListGrupo3 = [],
    ListGrupo4 = [], ListGrupo5 = [],
    ListGrupo6 = [], ListGrupo7 = [];

//FAZER NO CSS btn-nome_da_cor PRA FICAR MELHOR O MANUSEIO DA COR DO BOTAO

var CorDezenasFixas = "MistyRose";
//var CorGrupo1 = str.fontColor("Brown");
//var CorGrupo2 = str.fontColor("BlueViolet");
//var CorGrupo3 = str.fontColor("BurlyWood");
//var CorGrupo4 = str.fontColor("DarkGray");
//var CorGrupo5 = str.fontColor("DarkViolet");
//var CorGrupo6 = str.fontColor("Goldenrod");
//var CorGrupo7 = str.fontColor("Indigo");
var CorPadrao = "#F4F4F4";

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
var btnGerarJogo = $('#btnGerarJogo');
var btnGerarJogoAutomatico = $('#btnSalvarJogos');
var btnLimpar = $('#btnLimpar');

var txtNumSelecionados = $('#txtNumSelecionados');

$(document).ready(function () {


    Btn1.click(function () {
        Btn1_Click();
    });

    ResetaTela();
});

function ResetaTela() {

    concursoASerSorteado = 0;
    cont = 1;
    //lbAjuda.Text = "Selecione as dezenas Fexas!";
    //lbHover.Text = "";

    $('#btnGerarJogo').removeClass('Hide');
    $('#btnGerarJogoAutomatico').removeClass('Hide');

    for (var i = 0; i <= 25; i++) {
        PintarNumero(i, CorPadrao);
    }

    txtNumSelecionados.html = txtDezenaPadrao;

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

    //limpar as duas tabelas!!

    //btnSalvarJogos.Visible = false;
    //btnEnviarJogosPorEmail.Visible = false;
}

function PintarNumero(numero, corPintar) {
    $('#btn' + numero).BackColor = corPintar;
}

function Btn1_Click() {

    if (Btn1.hasClass('btn-default')) {
        DezenaEscolhida(parseInt(enumDezenas.Um));
    }
    else
        alert('NAO É BrANCO');
    //    RemoverDezena((int)Enums.Dezenas.Um, VerificaQualGrupoDezenaEsta((int)Enums.Dezenas.Um));
}

function DezenaEscolhida(dezenaString) {

    var dezena = 0;
    txtDezena = string.Empty;
    dezena = parseInt(dezenaString);

    var escolhidas = txtNumSelecionados.Text.Split('-');

    var pos = -1;
    for (var i = 0; i < escolhidas.Length; i++) {
        var d = 0;
        d = parseInt(escolhidas[i]);
        if (d === 0) {
            pos = i;
            escolhidas[i] = dezena.ToString();
            break;
        }
    }

    for (var j = 0; j < escolhidas.Length; j++) {
        txtDezena += FormataDezena(escolhidas[j]);
        if (txtDezena.Length >= 2 && txtDezena.Length <= 30)
            txtDezena += "-";
    }

    //já embutir a cor que é pra pintar o botão!
    //fazer retonou como out no parametro do metodo
    if (ListDezenasFixas.length === 0 || ListDezenasFixas.length !== 11) {
        txtDezena = "";

        ListDezenasFixas.push(parseInt(FormataDezena(dezenaString.ToString())));
        PintarNumero(parseInt(dezenaString), CorDezenasFixas);
    }
    //else
    //    if (ListGrupo1.Count == 0 || ListGrupo1.Count != 2) {
    //        txtDezena = "";
    //        ListGrupo1.Add(Convert.ToByte(FormataDezena(dezenaString.ToString())));
    //        for (int i = 0; i < ListGrupo1.Count; i++)
    //        {
    //            txtDezena += FormataDezena(ListGrupo1[i].ToString());
    //            if (txtDezena.Length >= 2 && txtDezena.Length <= 30)
    //                txtDezena += "-";
    //        }

    //        Grupo1 = txtDezena;
    //        PintarNumero((int)dezenaString, CorGrupo1);
    //    }
    //    else
    //        if (ListGrupo2.Count == 0 || ListGrupo2.Count != 2) {
    //            txtDezena = "";
    //            ListGrupo2.Add(Convert.ToByte(FormataDezena(dezenaString.ToString())));
    //            for (int i = 0; i < ListGrupo2.Count; i++)
    //            {
    //                txtDezena += FormataDezena(ListGrupo2[i].ToString());
    //                if (txtDezena.Length >= 2 && txtDezena.Length <= 30)
    //                    txtDezena += "-";
    //            }

    //            Grupo2 = txtDezena;
    //            PintarNumero((int)dezenaString, CorGrupo2);
    //        }
    //        else
    //            if (ListGrupo3.Count == 0 || ListGrupo3.Count != 2) {
    //                txtDezena = "";
    //                ListGrupo3.Add(Convert.ToByte(FormataDezena(dezenaString.ToString())));
    //                for (int i = 0; i < ListGrupo3.Count; i++)
    //                {
    //                    txtDezena += FormataDezena(ListGrupo3[i].ToString());
    //                    if (txtDezena.Length >= 2 && txtDezena.Length <= 30)
    //                        txtDezena += "-";
    //                }

    //                Grupo3 = txtDezena;

    //                PintarNumero((int)dezenaString, CorGrupo3);
    //            }
    //            else
    //                if (ListGrupo4.Count == 0 || ListGrupo4.Count != 2) {
    //                    txtDezena = "";
    //                    ListGrupo4.Add(Convert.ToByte((FormataDezena(dezenaString.ToString()))));
    //                    for (int i = 0; i < ListGrupo4.Count; i++)
    //                    {
    //                        txtDezena += FormataDezena(ListGrupo4[i].ToString());
    //                        if (txtDezena.Length >= 2 && txtDezena.Length <= 30)
    //                            txtDezena += "-";
    //                    }

    //                    Grupo4 = txtDezena;
    //                    PintarNumero((int)dezenaString, CorGrupo4);
    //                }

    //                else
    //                    if (ListGrupo5.Count == 0 || ListGrupo5.Count != 2) {
    //                        txtDezena = "";
    //                        ListGrupo5.Add(Convert.ToByte(FormataDezena(dezenaString.ToString())));
    //                        for (int i = 0; i < ListGrupo5.Count; i++)
    //                        {
    //                            txtDezena += FormataDezena(ListGrupo5[i].ToString());
    //                            if (txtDezena.Length >= 2 && txtDezena.Length <= 30)
    //                                txtDezena += "-";
    //                        }

    //                        Grupo5 = txtDezena;
    //                        PintarNumero((int)dezenaString, CorGrupo5);
    //                    }
    //                    else
    //                        if (ListGrupo6.Count == 0 || ListGrupo6.Count != 2) {
    //                            txtDezena = "";
    //                            ListGrupo6.Add(Convert.ToByte(FormataDezena(dezenaString.ToString())));
    //                            for (int i = 0; i < ListGrupo6.Count; i++)
    //                            {
    //                                txtDezena += FormataDezena(ListGrupo6[i].ToString());
    //                                if (txtDezena.Length >= 2 && txtDezena.Length <= 30)
    //                                    txtDezena += "-";
    //                            }

    //                            Grupo6 = txtDezena;
    //                            PintarNumero((int)dezenaString, CorGrupo6);
    //                        }
    //                        else
    //                            if (ListGrupo7.Count == 0 || ListGrupo7.Count != 2) {
    //                                txtDezena = "";
    //                                ListGrupo7.Add(Convert.ToByte(FormataDezena(dezenaString.ToString())));
    //                                for (int i = 0; i < ListGrupo7.Count; i++)
    //                                {
    //                                    txtDezena += FormataDezena(ListGrupo7[i].ToString());
    //                                    if (txtDezena.Length >= 2 && txtDezena.Length <= 30)
    //                                        txtDezena += "-";
    //                                }

    //                                Grupo7 = txtDezena;
    //                                PintarNumero((int)dezenaString, CorGrupo7);
    //                            }

    //AtualizarDadosTela();


}

function FormataDezena(dezenaString) {
    var dezena = 0;
    dezena = parseInt(dezenaString);
    var retorno = "";

    switch (dezena) {
        case 0:
        case 1:
        case 2:
        case 3:
        case 4:
        case 5:
        case 6:
        case 7:
        case 8:
        case 9:
            retorno = "0" + dezena.ToString().Trim();
            break;
        default:
            retorno = dezena.ToString();
            break;
    }

    return retorno;
}