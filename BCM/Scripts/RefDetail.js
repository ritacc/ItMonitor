var mStatus;
var mStatusSub;

var lblState;

var mHealth;
var lblLastPollingTime;
var lblNextPollingTime;
var mStatus1;

var deviceID;

$(document).ready(function () {
    mStatus = $("#imgStatus");
    mStatusSub = $("#imgStatusSub");
    mHealth = $("#imgHealth");                      //告警状态,健康状态
    lblLastPollingTime = $("#lblLastPollingTime");
    lblNextPollingTime = $("#lblNextPollingTime");
    mStatus1 = $("#imgStatus1");

    lblState = $("#lblState");
});

function Ref() {
    $.ajax({
        type: "get",
        url: "DeviceRef.aspx?id=" + deviceID + "&index=" + Math.random(),
        success: function (data) {
            if (data != "") {
                var obj = $.tryUnescape(data);
                if (obj) {
                    if (mStatus) {//状态
                        var murl = "../images/Common/stata" + obj.StatusVal + ".gif";
                        mStatus.attr("src", murl);
                        if (mStatusSub) {//第二状态
                            mStatusSub.attr("src", murl);
                        }
                    }
                    if (lblState) {
                        lblState.html(obj.Status);
                    }
                    if (mHealth) {
                        var murl = "../images/Common/health" + obj.StatusVal + ".gif";
                        mHealth.attr("src", murl);
                    }
                    if (lblLastPollingTime) {
                        lblLastPollingTime.html(obj.LastPollingTime);
                    }
                    if (lblNextPollingTime) {
                        lblNextPollingTime.html(obj.LastPollingTime);
                    }
                    if (mStatus1) {
                        var murl = "../images/Common/stata2" + obj.StatusVal + ".gif";
                        mStatus1.attr("src", murl);
                    }
                }
            }
            else {
                alert("获取数据失败！");
            }
        },
        complete: function (XMLHttpRequest, textStatus) { },
        error: function () { alert("获取数据失败！"); },
        cache: false
    });   //end ajax
}

function SetRef(mdeviceID) {
    deviceID = mdeviceID;
    setInterval(Ref, 10 * 1000);
}