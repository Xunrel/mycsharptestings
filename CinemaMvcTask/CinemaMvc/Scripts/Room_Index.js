; (function ($) {
    $(document).ready(function () {
        var alertBox = '<div class="alert alert-error">' +
            '<button type="button" class="close" data-dismiss="alert">&times;</button>' +
            'Couldn\'t add or remove persons' +
            '</div>';

        //$('.addRemoveBtn').bind('click', function () {
        //    var $thisBtn = $(this);

        //    try {
        //        $thisBtn.preventDefault();
        //    } catch(e) {

        //    } 
        //    var roomId = $thisBtn.prevAll('input#item_RoomId').val();
        //    var seatsValue = $thisBtn.prevAll('input.addRemoveInput').val();

        //    $.ajax({
        //        url: '/Room/AddRemovePersons',
        //        type: 'POST',
        //        data: {
        //            id: roomId,
        //            count: seatsValue
        //        },
        //        success: function() {
        //            window.location.href = window.location.href;
        //        },
        //        error: function () {
        //            var $parentDiv = $thisBtn.parent();
        //            $parentDiv.append(alertBox);
        //        }
        //    });
        //});

        $('.addBtn').bind('click', function () {
            var $thisBtn = $(this);

            try {
                $thisBtn.preventDefault();
            } catch(e) {

            }

            var roomId = $thisBtn.prevAll('input#item_RoomId').val();
            var seatsValue = $thisBtn.prevAll('input.addRemoveInput').val();

            makeAjaxCall($thisBtn, '/Room/AddPersons', roomId, seatsValue);
        });

        $('.removeBtn').bind('click', function () {
            var $thisBtn = $(this);

            try {
                $thisBtn.preventDefault();
            } catch (e) {

            }

            var roomId = $thisBtn.prevAll('input#item_RoomId').val();
            var seatsValue = $thisBtn.prevAll('input.addRemoveInput').val();

            makeAjaxCall($thisBtn, '/Room/RemovePersons', roomId, seatsValue);
        });

        var makeAjaxCall = function (sender, url, id, count) {
            $.ajax({
                url: url,
                type: 'POST',
                data: {
                    id: id,
                    count: count
                },
                success: function() {
                    window.location.href = window.location.href;
                },
                error: function () {
                    var $parentDiv = sender.parent();
                    $parentDiv.append(alertBox);
                }
            });
        };

//        $('.addRemoveInput').each(function() {
//            var $thisInput = $(this);
//            $thisInput.keyup(function(event) {
//                if (event.keyCode == 13) {
//                    $thisInput.next().click();
//                }
//            });
//        });
    });
})(jQuery);
