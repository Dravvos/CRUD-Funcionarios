// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function apagarFuncionario(id) {
    new swal({
        showCancelButton: true,
        cancelButtonText: `Não apagar`,
        title: "Você Tem Certeza?",
        text: "Uma vez deletado, você não conseguirá recuperar esse registro!",
        icon: 'warning',
    })
        .then((result) => {
            if (result.isConfirmed) {
                new swal({
                    text: "Deletado com Sucesso",
                    icon: "success",
                }).then(() => location.href = `funcionario/Delete?Id=${id}`);
            }
        });
}