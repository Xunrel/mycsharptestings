;(function($) {
    $(document).ready(function() {
        var $demoBgBtn = $('#demoBgBtn');
        var $resetBtn = $('#resetBgBtn');
        var $bgElement = $('#bgEvent');
        var $unbindBtn = $('#unbindEventsBtn');
        var $bindBtn = $('#bindEventsBtn');

        $bindBtn.on('click', function() {
            $demoBgBtn.on('click', function () {
                $bgElement
                    .css('background-color', '#3a87ad')
                    .css('color', 'white');
            });

            $resetBtn.on('click', function () {
                $bgElement
                    .css('background-color', '#f5f5f5')
                    .css('color', '#333');
            });
        });

        $unbindBtn.on('click', function() {
            $demoBgBtn.off();
        });

        $bindBtn.trigger('click');
    });
})(jQuery);
