document.querySelectorAll('.delete-button').forEach(button => {
    button.addEventListener('click', function (event) {
        if (!confirm('Are you sure you want to delete this item?')) {
            event.preventDefault();
        }
    });
});


document.querySelectorAll('a[href^="#"]').forEach(anchor => {
    anchor.addEventListener('click', function (e) {
        e.preventDefault();
        document.querySelector(this.getAttribute('href')).scrollIntoView({
            behavior: 'smooth'
        });
    });
});


$(function () {
    $('.datetime-local').datepicker();
});

$(document).ready(function () {
    $('#CEP').change(function () {
        var cep = $(this).val().replace(/\D/g, '');
        if (cep.length === 8) {
            $.ajax({
                url: 'https://viacep.com.br/ws/' + cep + '/json/',
                dataType: 'json',
                success: function (resposta) {
                    $('#Rua').val(resposta.logradouro);
                    $('#Bairro').val(resposta.bairro);
                    $('#Cidade').val(resposta.localidade);
                    $('#Estado').val(resposta.uf);
                    $('#Numero').focus();
                }
            });
        }
    });
});



