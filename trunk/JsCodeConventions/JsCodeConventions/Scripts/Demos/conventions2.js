;(function($) {
    $(document).ready(function() {
        var $demoBgBtn = $('#demoBgBtn');
        var $bgElement = $('#bgEvent');
        var $unbindBtn = $('#unbindEventsBtn');
        var $bindBtn = $('#bindEventsBtn');

        $bindBtn.on('click', function() {
            $demoBgBtn.on('click', function () {
                if ($bgElement.css('background-color') === 'rgb(245, 245, 245)') {
                    $bgElement
                        .css('background-color', 'rgb(58, 135, 173)')
                        .css('color', 'white');
                } else {
                    $bgElement
                        .css('background-color', 'rgb(245, 245, 245)')
                        .css('color', '#333');
                }
            });
        });

        $unbindBtn.on('click', function() {
            $demoBgBtn.off();
        });

        $bindBtn.trigger('click');
    });
})(jQuery);
