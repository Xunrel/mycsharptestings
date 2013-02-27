; (function ($) {
    $(document).ready(function () {
        var alertBox = '<div class="alert alert-error">' +
            '<button type="button" class="close" data-dismiss="alert">&times;</button>' +
            'Couldn\'t add or remove persons' +
            '</div>';

        $('.addRemoveBtn').bind('click', function () {
            var $thisBtn = $(this);

            try {
                $thisBtn.preventDefault();
            } catch(e) {

            } 
            var roomId = $thisBtn.prev().prev().val();
            var seatsValue = $thisBtn.prev().val();

            $.ajax({
                url: '/Room/AddRemovePersons',
                type: 'POST',
                data: {
                    id: roomId,
                    count: seatsValue
                },
                success: function() {
                    window.location.href = window.location.href;
                },
                error: function () {
                    var $parentDiv = $thisBtn.parent();
                    $parentDiv.append(alertBox);
                }
            });
        });

        $('.addRemoveInput').each(function() {
            var $thisInput = $(this);
            $thisInput.keyup(function(event) {
                if (event.keyCode == 13) {
                    $thisInput.next().click();
                }
            });
        });
    });
})(jQuery);
