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
<<<<<<< HEAD
            console.log("CARREGANDO CONFIGURAÇÃO..");
            //console.log(_objConfiguration);
=======
>>>>>>> bb62a41bc85e88da28e7beb1e178c80831789707

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
        if (_objConfiguration.checar_Jogo_Online === true) {
            $('#btn-checkOnline').removeClass('hide');
        }
        else {
            $('#btn-checkOnline').addClass('hide');
        }

        if (_objConfiguration.enviar_Email_Manualmente === true) {
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
        })
    });
}

function limpaObjetoNovaCofiguracao() {
    _objSaveConfiguration.Id = 0;
    _objSaveConfiguration.valor_campo = 0;
    _objSaveConfiguration.enum_config = 0;
}


$("#minAmountToSentEmail").keydown(function (e) {

    if (e.currentTarget.value.length >= 2 && e.currentTarget.value[0] == 0) {
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

    novo_valor = parseFloat($("#minAmountToSentEmail").val()).toFixed(2);

    $("#minAmountToSentEmail").val(novo_valor);

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

    _objConfiguration.Id = _objConfiguration.Id;
    _objConfiguration.calcular_Dezenas_Sem_Pontuacao = $('#CalcularDezenasSemPontuacao')[0].checked;
    _objConfiguration.checar_Jogo_Online = _objConfiguration.checar_Jogo_Online;
    _objConfiguration.enviar_Email_Automaticamente = _objConfiguration.enviar_Email_Automaticamente;
    _objConfiguration.enviar_Email_Manualmente = _objConfiguration.enviar_Email_Manualmente;
    _objConfiguration.valor_Minimo_Para_Envio_Email = _objConfiguration.valor_Minimo_Para_Envio_Email;

    saveConfig(_objConfiguration);
    carregaPagina();
});

$('#VerificaJogoOnline').click(function () {

    _objConfiguration.Id = _objConfiguration.Id;
    _objConfiguration.calcular_Dezenas_Sem_Pontuacao = _objConfiguration.calcular_Dezenas_Sem_Pontuacao;
    _objConfiguration.checar_Jogo_Online = $('#VerificaJogoOnline')[0].checked;
    _objConfiguration.enviar_Email_Automaticamente = _objConfiguration.enviar_Email_Automaticamente;
    _objConfiguration.enviar_Email_Manualmente = _objConfiguration.enviar_Email_Manualmente;
    _objConfiguration.valor_Minimo_Para_Envio_Email = _objConfiguration.valor_Minimo_Para_Envio_Email;

    saveConfig(_objConfiguration);
});

$('#EmailAutomatico').click(function () {

    _objConfiguration.Id = _objConfiguration.Id;
    _objConfiguration.calcular_Dezenas_Sem_Pontuacao = _objConfiguration.calcular_Dezenas_Sem_Pontuacao;
    _objConfiguration.checar_Jogo_Online = _objConfiguration.checar_Jogo_Online;
    _objConfiguration.enviar_Email_Automaticamente = $('#EmailAutomatico')[0].checked;
    _objConfiguration.enviar_Email_Manualmente = _objConfiguration.enviar_Email_Manualmente;
    _objConfiguration.valor_Minimo_Para_Envio_Email = _objConfiguration.valor_Minimo_Para_Envio_Email;

    saveConfig(_objConfiguration);
});

$('#EmailManual').click(function () {

    _objConfiguration.Id = _objConfiguration.Id;
    _objConfiguration.calcular_Dezenas_Sem_Pontuacao = _objConfiguration.calcular_Dezenas_Sem_Pontuacao;
    _objConfiguration.checar_Jogo_Online = _objConfiguration.checar_Jogo_Online;
    _objConfiguration.enviar_Email_Automaticamente = _objConfiguration.enviar_Email_Automaticamente;
    _objConfiguration.enviar_Email_Manualmente = $('#EmailManual')[0].checked;
    _objConfiguration.valor_Minimo_Para_Envio_Email = _objConfiguration.valor_Minimo_Para_Envio_Email;

    saveConfig(_objConfiguration);
});




