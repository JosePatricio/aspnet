

function CargarEstilosFiltros() {

    $(document).ready(function () {
        $('[id*=TipoContenedorListBox]').multiselect({
            includeSelectAllOption: true,
            enableFiltering: true,
            maxHeight: 250,
            enableCaseInsensitiveFiltering: true,
            buttonWidth: '100%',

        });
    });

    $(document).ready(function () {
        $('[id*=ddlDeposito]').multiselect({
            enableFiltering: true,
            maxHeight: 250,
            enableCaseInsensitiveFiltering: true,
            buttonWidth: '100%',
        });
    });

    $(document).ready(function () {
        $('[id*=ddlLinea]').multiselect({
            enableFiltering: true,
            maxHeight: 250,
            enableCaseInsensitiveFiltering: true,
            buttonWidth: '100%',
        });
    });

    $(document).ready(function () {
        $('[id*=ddlEstado]').multiselect({
            enableFiltering: true,
            maxHeight: 250,
            enableCaseInsensitiveFiltering: true,
            buttonWidth: '100%',
        });
    });

    $(document).ready(function () {
        $('[id*=ddlFabricante]').multiselect({
            enableFiltering: true,
            maxHeight: 250,
            enableCaseInsensitiveFiltering: true,
            buttonWidth: '100%',
        });
    });
}


