var usuarioAtualizadoComSucesso = false;

function siteUsuarioConfiguracoes() {

    toastr.options = {
        "closeButton": false,
        "debug": false,
        "newestOnTop": false,
        "progressBar": true,
        "positionClass": "toast-top-right",
        "preventDuplicates": true,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    };

    toastr.options.onHidden = function () {
        if (usuarioAtualizadoComSucesso === true) {
            window.location = window.location.origin;
        }
    };

    toastr.options.onclick = function () {
        if (usuarioAtualizadoComSucesso === true) {
            window.location = window.location.origin;
        }
    };

    toastr.options.onCloseClick = function () {
        if (usuarioAtualizadoComSucesso === true) {
            window.location = window.location.origin;
        }
    };

    $(document).ready(function () {
        $("input[name='Telefone']")
            .mask('(00) 00000-0000')
            .focusout(function (event) {
                var target, phone, element;
                target = (event.currentTarget) ? event.currentTarget : event.srcElement;
                phone = target.value.replace(/\D/g, '');
                element = $(target);
                element.unmask();
                if (phone.length > 10) {
                    element.mask("(99) 99999-9999");
                } else {
                    element.mask("(99) 9999-99999");
                }
            });
    });
}

function SetUsuarioAtualizadoComSucessoToTrue() {
    usuarioAtualizadoComSucesso = true;
}