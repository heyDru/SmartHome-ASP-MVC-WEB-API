var ConfirmDeleteTV= function (tvid, name) {
    $("#hiddenId").val(tvid);
    $("#ToDeleteTVName").html(name);
    $("#tvModalDelete").modal('show');
}

var DeleteTV = function () {

    var tvId = $("#hiddenId").val();
    $("#loaderDiv").show();

    $.ajax({
        type: "POST",
        url: "/Home/DeleteTV",
        data: {
            tvId: tvId
        },
        success: function (response) {
            $("#loaderDiv").hide();
            $("#tvModalDelete").modal('hide');
            $("#tv_" + tvId).remove();
        }
    })

}

var ConfigTV = function (tvId) {
    var url = "/Home/ConfigTV?tvId=" + tvId;
    $("#hiddenId").val(tvId);
    $("#tvConfigForm").load(url, function () {
        $("#tvModalConfig").modal("show");
    })

}


var TVSwitchClick = function () {
    var turnOn = $("#TurnOn").val();
    if ($("#tvTurnOn").val() === "True") {
        $("#btnSwitchTV").removeClass("btn-success");
        $("#btnSwitchTV").addClass("btn-warning");
        $("#tvTurnOn").val("False");
        $("#tvTurnOn").data().val = false;
        $("#switchTextTV").html("Device is OFF");
    }
    else {
        $("#btnSwitchTV").removeClass("btn-warning");
        $("#btnSwitchTV").addClass("btn-success");
        $("#tvTurnOn").val("True");
        $("#tvTurnOn").data().val = true;
        $("#switchTextTV").html("Device is ON");
    }
}