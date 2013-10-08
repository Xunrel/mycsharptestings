requirejs.config({
    baseUrl: '/Scripts/libs', // wir nutzen die Libraries als Basis für das Programm
    paths: {
        app: '../app', // mit app/{0} können wir nun auf alle JS Dateien für das Haupt-Programm nutzen
        ko: 'knockout-2.2.0.debug.js',
    },
    shim: {
        jqueryui: {
            deps: ['jquery'],
            exports: '$'
        }
    }
});


require(['jqueryui'], function ($) {
    $(document).ready(function () {
        console.log('worked');
    });
});