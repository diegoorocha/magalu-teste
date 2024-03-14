//INICIO -> Função para validar se o e-mail já está cadastrado

let emailValido = false;

//function ValidarEmailCadastrado(callback = () => { }) {
//    $("#valid-icon-email").remove();
//    $(".btn-validacao-email").unbind("click");
//    $(".btn-validacao-email").blur();
//    $.ajax({
//        url: '/Cliente/ValidarEmail/',
//        type: 'POST',
//        datatype: 'json',
//        data: {
//            email: $("#email").val(),
//        },
//        success: function (data) {
//            if (data == false) {
//                $("<i id='valid-icon-email'class='fas fa-thumbs-down fa-blink' style='color:red'></i>").appendTo("#label-icon-email")
//                $("#email").val("")
//                emailValido = false;
//            } else {
//                $("<i id='valid-icon-email'class='fas fa-thumbs-up' style='color:green'></i>").appendTo("#label-icon-email")
//                $(".btn-validacao-email").removeClass("fa-blink");
//                emailValido = true;
//            }
//            callback();
//        }
//    })
//}

async function ValidarEmailCadastrado(callback = () => { }) {
    $("#valid-icon-email").remove();
    $(".btn-validacao-email").unbind("click");
    $(".btn-validacao-email").blur();

    return new Promise((resolve, reject) => {
        $.ajax({
            url: '/Cliente/ValidarEmail/',
            type: 'POST',
            datatype: 'json',
            data: {
                email: $("#email").val(),
            },
            success: function (data) {
                if (data == false) {
                    $("<i id='valid-icon-email' class='fas fa-thumbs-down fa-blink' style='color:red'></i>").appendTo("#label-icon-email");
                    $("#email").val("");
                    emailValido = false;
                } else {
                    $("<i id='valid-icon-email' class='fas fa-thumbs-up' style='color:green'></i>").appendTo("#label-icon-email");
                    $(".btn-validacao-email").removeClass("fa-blink");
                    emailValido = true;
                }
                callback();
                resolve();
            },
            error: function (error) {
                reject(error);
            }
        });
    });
}

//FIM -> Função para validar se o e-mail já está cadastrado

//INICIO -> Função para validar se o documento CPF / CNPJ já está cadastrado

let documentoValido = false;

async function ValidarDocumento(callback = () => { }) {
    $("#valid-icon-documento").remove();
    $(".btn-validacao-documento").unbind("click");
    $(".btn-validacao-documento").blur();

    return new Promise((resolve, reject) => {
        $.ajax({
            url: '/Cliente/ValidarDocumentoCpfCnpj/',
            type: 'POST',
            datatype: 'json',
            data: {
                documento: $("#documento").val(),
            },
            success: function (data) {
                if (data == false) {
                    $("<i id='valid-icon-documento' class='fas fa-thumbs-down fa-blink' style='color:red'></i>").appendTo("#label-icon-documento");
                    $("#documento").val("");
                    documentoValido = false;
                } else {
                    $("<i id='valid-icon-documento' class='fas fa-thumbs-up' style='color:green'></i>").appendTo("#label-icon-documento");
                    $(".btn-validacao-documento").removeClass("fa-blink");
                    documentoValido = true;
                }
                callback();
                resolve();
            },
            error: function (error) {
                reject(error);
            }
        });
    });
}


//FIM -> Função para validar se o documento CPF / CNPJ já está cadastrado

//INICIO -> Função para validar se o e-mail já está cadastrado

let inscricaoEstadualValida = false;

async function ValidarInscricaoEstadualCadastrado(callback = () => { }) {
    $("#valid-icon-inscricao").remove();
    $(".btn-validacao-inscricao-estadual").unbind("click");
    $(".btn-validacao-inscricao-estadual").blur();

    return new Promise((resolve, reject) => {
        $.ajax({
            url: '/Cliente/ValidarInscricaoEstadual/',
            type: 'POST',
            datatype: 'json',
            data: {
                inscricaoEstadual: $("#InscricaoEstadual").val(),
            },
            success: function (data) {
                if (data == false) {
                    $("<i id='valid-icon-inscricao' class='fas fa-thumbs-down fa-blink' style='color:red'></i>").appendTo("#label-icon-inscricao-estadual");
                    $("#InscricaoEstadual").val("");
                    inscricaoEstadualValida = false;
                } else {
                    $("<i id='valid-icon-inscricao' class='fas fa-thumbs-up' style='color:green'></i>").appendTo("#label-icon-inscricao-estadual");
                    $(".btn-validacao-inscricao-estadual").removeClass("fa-blink");
                    inscricaoEstadualValida = true;
                }
                callback();
                resolve();
            },
            error: function (error) {
                reject(error);
            }
        });
    });
}

//FIM -> Função para validar se o e-mail já está cadastrado
