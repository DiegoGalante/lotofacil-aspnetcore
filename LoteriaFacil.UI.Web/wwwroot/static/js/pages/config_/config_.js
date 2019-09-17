_objConfiguration = new Object();
_objSaveConfiguration = new Object();
_valor_antigo = 0;

var imported = document.createElement('script');
imported.src = '/static/js/utils.js';
document.head.appendChild(imported);

imported.src = '/static/js/pages/index/pr_grafico.js';
document.head.appendChild(imported);

$(document).ready(function () {
    carregaConfiguracao();
});

function carregaConfiguracao() {
    $.ajax({
        type: 'POST',
        contentType: 'application/json',
        async: true,
        url: '/loadConfiguration',
        success: (function (data) {
            _objConfiguration = data[0];
            _valor_antigo = _objConfiguration.valor_Minimo_Para_Envio_Email;
            console.log("CARREGANDO CONFIGURAÇÃO..");
           // console.log(_objConfiguration);

            $('#CalcularDezenasSemPontuacao').prop('checked', false);
            $('#VerificaJogoOnline').prop('checked', false);
            $('#EmailAutomatico').prop('checked', false);
            $('#EmailManual').prop('checked', false);
            $('#minAmountToSentEmail').val('');

            //Preenche os devidos campos
            if (_objConfiguration.calcular_Dezenas_Sem_Pontuacao === true) {
                $('#CalcularDezenasSemPontuacao').prop('checked', true);
            }

            if (_objConfiguration.checar_Jogo_Online === true) {
                $('#VerificaJogoOnline').prop('checked', true);
            }

            if (_objConfiguration.enviar_Email_Automaticamente === true) {
                $('#EmailAutomatico').prop('checked', true);
            }

            if (_objConfiguration.enviar_Email_Manualmente === true) {
                $('#EmailManual').prop('checked', true);
            }

            if (_objConfiguration.valor_Minimo_Para_Envio_Email > 0) {
                novo_valor = Number(parseFloat(_objConfiguration.valor_Minimo_Para_Envio_Email)).toFixed(2);
                $("#minAmountToSentEmail").val(novo_valor);
            }

            validateConfiguration();

        }),
        error: (function (erro) {
            console.log("ERRO CARREGAR CONFIGURACAO");
        })
    });
}

function validateConfiguration() {
    try {
        if (_objConfiguration.check_game_online === true) {
            $('#btn-checkOnline').removeClass('hide');
        }
        else {
            $('#btn-checkOnline').addClass('hide');
        }

        if (_objConfiguration.send_email_manually === true) {
            $('#btn-email').removeClass('hide');
        }
        else {
            $('#btn-email').addClass('hide');
        }
    } catch (error) {
        console.log(error);
    }


}

function saveConfig(config) {
    console.log(JSON.stringify(config));
    $.ajax({
        type: 'POST',
        contentType: 'application/json',
        async: true,
        url: '/saveConfiguration',
        data: JSON.stringify(config),
        success: (function (obj) {

            if (obj.result) {
                limpaObjetoNovaCofiguracao();
            }
            carregaConfiguracao();
        }),
        error: (function (erro) {
            console.log(erro);
            // TrataErroAjax(erro);
        })
    });
}

function limpaObjetoNovaCofiguracao() {
    _objSaveConfiguration.Id = 0;
    //_objSaveConfiguration.pes_id = 0;
    _objSaveConfiguration.valor_campo = 0;
    _objSaveConfiguration.enum_config = 0;
}


$("#minAmountToSentEmail").keydown(function (e) {

    if (e.currentTarget.value.length >= 2 && e.currentTarget.value[0] == 0) {
        // console.log(e.currentTarget.value)
        e.currentTarget.value = e.currentTarget.value.slice(1, e.currentTarget.value.length);
        $("#minAmountToSentEmail").val(e.currentTarget.value);
    }
    // Allow: backspace, delete, tab, escape, enter and .
    if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
        // Allow: Ctrl/cmd+A
        (e.keyCode == 65 && (e.ctrlKey === true || e.metaKey === true)) ||
        // Allow: Ctrl/cmd+C
        (e.keyCode == 67 && (e.ctrlKey === true || e.metaKey === true)) ||
        // Allow: Ctrl/cmd+X
        (e.keyCode == 88 && (e.ctrlKey === true || e.metaKey === true)) ||
        // Allow: home, end, left, right
        (e.keyCode >= 35 && e.keyCode <= 39)) {
        // let it happen, don't do anything
        return;
    }
    // Ensure that it is a number and stop the keypress
    if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
        e.preventDefault();
    }
});

$("#minAmountToSentEmail").blur(function () {

    //novo_valor = Number(parseFloat($("#minAmountToSentEmail").val())).toFixed(2);

    //$("#minAmountToSentEmail").val(novo_valor);

    //_objSaveConfiguration.Id = _objConfiguration.Id;
    //_objSaveConfiguration.pes_id = _objConfiguration.person;
    //_objSaveConfiguration.valor_campo = parseFloat(novo_valor);
    //_objSaveConfiguration.valor_antigo = _valor_antigo;
    //_objSaveConfiguration.enum_config = enumConfiguracao.ValorMinimoParaEnviarEmail;


    novo_valor = parseFloat($("#minAmountToSentEmail").val()).toFixed(2);

    //    novo_valor = parseFloat($("#minAmountToSentEmail").val()).toFixed(2);
    //$("#minAmountToSentEmail").val(currencyFormat(novo_valor));
    $("#minAmountToSentEmail").val(novo_valor);
    //_objSaveConfiguration.valor_campo = parseFloat(novo_valor);

    _objConfiguration.Id = _objConfiguration.Id;
    _objConfiguration.calcular_Dezenas_Sem_Pontuacao = _objConfiguration.calcular_Dezenas_Sem_Pontuacao;
    _objConfiguration.checar_Jogo_Online = _objConfiguration.checar_Jogo_Online;
    _objConfiguration.enviar_Email_Automaticamente = _objConfiguration.enviar_Email_Automaticamente;
    _objConfiguration.enviar_Email_Manualmente = _objConfiguration.enviar_Email_Manualmente;
    _objConfiguration.valor_Minimo_Para_Envio_Email = parseFloat(novo_valor);

    console.log(novo_valor);
    saveConfig(_objConfiguration);
});

function currencyFormat(num) {
    return "$" + num.toFixed(2).replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,")
}

$('#CalcularDezenasSemPontuacao').click(function () {
    //_objSaveConfiguration.pes_id = _objConfiguration.person
    //_objSaveConfiguration.valor_campo = $('#CalcularDezenasSemPontuacao')[0].checked;
    //_objSaveConfiguration.enum_config = enumConfiguracao.CalcularDezenasSemPontuacao;


    _objConfiguration.Id = _objConfiguration.Id;
    _objConfiguration.calcular_Dezenas_Sem_Pontuacao = $('#CalcularDezenasSemPontuacao')[0].checked;
    _objConfiguration.checar_Jogo_Online = _objConfiguration.checar_Jogo_Online;
    _objConfiguration.enviar_Email_Automaticamente = _objConfiguration.enviar_Email_Automaticamente;
    _objConfiguration.enviar_Email_Manualmente = _objConfiguration.enviar_Email_Manualmente;
    _objConfiguration.valor_Minimo_Para_Envio_Email = _objConfiguration.valor_Minimo_Para_Envio_Email;

    //console.log(_objConfiguration);
    saveConfig(_objConfiguration);
    carregaPagina();
});

$('#VerificaJogoOnline').click(function () {
    //_objSaveConfiguration.pes_id = _objConfiguration.person
    //_objSaveConfiguration.valor_campo = $('#VerificaJogoOnline')[0].checked;
    //_objSaveConfiguration.enum_config = enumConfiguracao.VerificaJogoOnline;



    _objConfiguration.Id = _objConfiguration.Id;
    _objConfiguration.calcular_Dezenas_Sem_Pontuacao = _objConfiguration.calcular_Dezenas_Sem_Pontuacao;
    _objConfiguration.checar_Jogo_Online = $('#VerificaJogoOnline')[0].checked;
    _objConfiguration.enviar_Email_Automaticamente = _objConfiguration.enviar_Email_Automaticamente;
    _objConfiguration.enviar_Email_Manualmente = _objConfiguration.enviar_Email_Manualmente;
    _objConfiguration.valor_Minimo_Para_Envio_Email = _objConfiguration.valor_Minimo_Para_Envio_Email;

    // console.log(_objSaveConfiguration)
    saveConfig(_objConfiguration);
});

$('#EmailAutomatico').click(function () {
    //_objSaveConfiguration.Id = _objConfiguration.Id;
    //_objSaveConfiguration.pes_id = _objConfiguration.person
    //_objSaveConfiguration.valor_campo = $('#EmailAutomatico')[0].checked;
    //_objSaveConfiguration.enum_config = enumConfiguracao.EmailAutomatico;

    _objConfiguration.Id = _objConfiguration.Id;
    _objConfiguration.calcular_Dezenas_Sem_Pontuacao = _objConfiguration.calcular_Dezenas_Sem_Pontuacao;
    _objConfiguration.checar_Jogo_Online = _objConfiguration.checar_Jogo_Online;
    _objConfiguration.enviar_Email_Automaticamente = $('#EmailAutomatico')[0].checked;
    _objConfiguration.enviar_Email_Manualmente = _objConfiguration.enviar_Email_Manualmente;
    _objConfiguration.valor_Minimo_Para_Envio_Email = _objConfiguration.valor_Minimo_Para_Envio_Email;

    saveConfig(_objConfiguration);
});

$('#EmailManual').click(function () {
    //_objSaveConfiguration.Id = _objConfiguration.Id;
    //_objSaveConfiguration.pes_id = _objConfiguration.person
    //_objSaveConfiguration.valor_campo = $('#EmailManual')[0].checked;
    //_objSaveConfiguration.enum_config = enumConfiguracao.EmailManual;


    _objConfiguration.Id = _objConfiguration.Id;
    _objConfiguration.calcular_Dezenas_Sem_Pontuacao = _objConfiguration.calcular_Dezenas_Sem_Pontuacao;
    _objConfiguration.checar_Jogo_Online = _objConfiguration.checar_Jogo_Online;
    _objConfiguration.enviar_Email_Automaticamente = _objConfiguration.enviar_Email_Automaticamente;
    _objConfiguration.enviar_Email_Manualmente = $('#EmailManual')[0].checked;
    _objConfiguration.valor_Minimo_Para_Envio_Email = _objConfiguration.valor_Minimo_Para_Envio_Email;

    saveConfig(_objConfiguration);
});




