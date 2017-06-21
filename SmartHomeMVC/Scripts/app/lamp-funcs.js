var ConfirmDeleteLamp = function (Lampid,name) {
    $("#hiddenId").val(Lampid);
    $("#ToDeleteLampName").html(name);
    $("#lampModalDelete").modal('show'); 
}

var DeleteLamp = function () {

    var lampId = $("#hiddenId").val();
    $("#loaderDiv").show();

    $.ajax({
        type: "POST",
        url: "/Home/DeleteLamp",
        data: {
            lampId: lampId
        },
        success: function (response) {
            $("#loaderDiv").hide();
            $("#lampModalDelete").modal('hide');
            $("#lamp_" + lampId).remove();
        }
    })

}

var ConfigLamp = function (lampId) {
    var url = "/Home/ConfigLamp?lampId=" + lampId;
    $("#hiddenId").val(lampId);
    $("#lampConfigForm").load(url, function () {
        $("#lampModalConfig").modal("show");
    })

}

var SwitchClick = function () {
    var turnOn = $("#TurnOn").val();
    if ($("#TurnOn").val() === "True") {
        $("#btnSwitch").removeClass("btn-success");
        $("#btnSwitch").addClass("btn-warning");
        $("#TurnOn").val("False");
        $("#TurnOn").data().val = false;
        $("#switchText").html("Device is OFF");
        $("#Intensity").prop("disabled", true);
    }
    else {
        $("#btnSwitch").removeClass("btn-warning");
        $("#btnSwitch").addClass("btn-success");
        $("#TurnOn").val("True");
         $("#TurnOn").data().val = true;
        $("#switchText").html("Device is ON");
        $("#Intensity").prop("disabled", false);
    }
}


