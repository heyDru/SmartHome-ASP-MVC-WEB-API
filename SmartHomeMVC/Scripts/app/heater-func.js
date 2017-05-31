var ConfirmDeleteHeater = function (Heaterid, name) {
    $("#hiddenId").val(Heaterid);
    $("#ToDeleteHeaterName").html(name);
    debugger;
    $("#heaterModalDelete").modal('show');
}

var DeleteHeater = function () {

    var heaterId = $("#hiddenId").val();
    $("#loaderDiv").show();

    $.ajax({
        type: "POST",
        url: "/Home/DeleteHeater",
        data: {
            heaterId: heaterId
        },
        success: function (response) {
            $("#loaderDiv").hide();
            $("#heaterModalDelete").modal('hide');
            $("#heater_" + heaterId).remove();
        }
    })

}
//field-validation-valid

var ConfigHeater = function (heaterId) {
    var url = "/Home/ConfigHeater?heaterId=" + heaterId;
    $("#hiddenId").val(heaterId);
    $("#heaterConfigForm").load(url, function () {
        $("#heaterModalConfig").modal("show");
    })

}

var HeaterSwitchClick = function () {
    if ($("#heaterTurnOn").val() === "True") {
        $("#btnSwitchHeater").removeClass("btn-success");
        $("#btnSwitchHeater").addClass("btn-warning");
        $("#heaterTurnOn").val("False");
        $("#heaterTurnOn").data().val = false;
        $("#switchTextHeater").html("Device is OFF");
        $("#Temperature").prop("disabled", true);
    }
    else {
        $("#btnSwitchHeater").removeClass("btn-warning");
        $("#btnSwitchHeater").addClass("btn-success");
        $("#heaterTurnOn").val("True");
        $("#heaterTurnOn").data().val = true;
        $("#switchTextHeater").html("Device is ON");
        $("#Temperature").prop("disabled", false);
    }
}