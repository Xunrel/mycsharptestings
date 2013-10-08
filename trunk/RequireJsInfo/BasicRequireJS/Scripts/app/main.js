requirejs.config({
    baseUrl: 'Scripts/libs',
    paths: {
        'app': '../app',
        'utils': '../tools/utils',
        'jquery': 'jquery-1.10.2',
        'ko': 'knockout-2.3.0'
    }
});

require(['jquery'], function($) {
    $(document).ready(function() {
        console.log('ready');
    });
});
