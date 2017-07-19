//<reference path="../Bootstrap/MultiSelect/js/bootstrap-multiselect.js" />
//includeJs("../Bootstrap/MultiSelect/js/bootstrap-multiselect.js");

function MostrarModal() {
    $("#modalPanel").modal('show');
}


function OcultarModal() {
    $("#modalPanel").modal('hide');
}

function RestringirMouse() {
    //$(document).ready(function () {
    //    $(document)[0].oncontextmenu = function () { return false; }
    //});

    $(document).bind("contextmenu", function (e) {
        return false;
    });
}

function ModalPanel() {
    RestringirMouse();
    MostrarModal();
    OcultarModal();
}

function NoModalPanel() {
    RestringirMouse();
    // RestringirMouse();   
}


function ValidaSoloDecimales() {
    alert(event.value.toString());
    if (!isNumeric(event.valueAsString))
        event.returnValue = false;
}

function ValidaSoloNumeros() {
    if ((event.keyCode < 48) || (event.keyCode > 57))
        event.returnValue = false;
}

function SoloNum(e) {
    var key_press = document.all ? key_press = e.keyCode : key_press = e.which;
    return ((key_press > 47 && key_press < 58) || key_press == 46);
    // el  "|| key_press == 46" es para incluir el punto ".", si borramos solo ingresara enteros 
}

function RelocalizarUrlParent() {
    if (parent.frames.length > 0) {
        parent.location.href = self.document.location;
    }
}


function MostrarModal() {
    $("#myModal").modal('show');    
}

function OcultarModal() {
    $("#myModal").modal('hide');
}

function End(sender, args) { }

function BeginRequestHandler(sender, args) {
    $("#myLoading").modal('show');
}
function EndRequestHandler(sender, args) {
    $("#myLoading").modal('hide');
    $(".modal-backdrop").hide();
    CargarEstilosFiltros();
}

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
