var BlazorUniversity = BlazorUniversity || {};
BlazorUniversity.startRandomGenerator = function (dotNetObject) {
    return setInterval(function () {
        let text = Math.random() * 1000;
        console.log("JS: Generated " + text);
        dotNetObject.invokeMethodAsync('AddText', text.toString());
    }, 1000);
};
BlazorUniversity.stopRandomGenerator = function (handle) {
    clearInterval(handle)
};
