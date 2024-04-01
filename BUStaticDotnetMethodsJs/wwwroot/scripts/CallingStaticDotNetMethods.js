setTimeout(async function () {
    const settings = await DotNet.invokeMethodAsync("CallingStaticDotNetMethods", "GetSettings");
    alert('API key: ' + settings.someApiKey);
}, 1000);
