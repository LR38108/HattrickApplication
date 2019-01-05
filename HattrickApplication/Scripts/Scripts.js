$(document).ready(function () {
    $('.tip').click(function () {
        if ($(this).attr("class") === "tip") {
            var group = "input:submit[name='" + $(this).attr("name") + "']";
            var $row = jQuery(this).closest('tr');
            var rowclass = $(this).attr("name");
            var columnH = $row.find('#homeCell').html();
            var columnA = $row.find('#awayCell').html();
            var columnT = jQuery(this).attr("id");
            var columnC = jQuery(this).attr("value");
            var table = $('#ticket-data').children('tbody');
            table.append('<tr id=' + rowclass + '><td>' + columnH + columnA + '</td ><td>' + columnT + '</td ><td class="coeff">' + columnC + '</td></tr > ');
            $(group).attr("class", "tip");
            $(this).attr("class", "tip-selected");
            $(group).css("background", "");
            $(this).css("background", "red");
            $(group).attr("disabled", true);
            $(this).attr("disabled", false);
        } else {
            group = "input:submit[name='" + $(this).attr("name") + "']";
            $(this).prop("class", "tip");
            $(this).css("background", "");
            rowclass = $(this).attr("name");
            table = $('#ticket-data').children('tbody');
            $('#' + rowclass).remove();
            $(group).attr("disabled", false);
        }
    });

    $('#bet').bind('keydown keyup keypress', function () {
        if ($('#ticket-data >tbody >tr').length > 0) {
            var mgmtfee = this.value * 0.95;
            $('#bet-minus-fee').html('5 % management fee: ' + mgmtfee.toFixed(2));
            var total = 1;
            $('#ticket-data td.coeff').each(function () {
                total *= $(this).text();

            });
            total = total.toFixed(2);
            $('#total-coeff').html("Total coefficient: " + total);
            $('#winnings').html("Potential Winnings: " + (mgmtfee * total).toFixed(2));
        } else {
            $('#total-coeff').html("");
            $('#winnings').html("");
        }
    });

    $('#submit-ticket').click(function () {
        if ($('#ticket-data #TipsCheckBoxGroupTop').length > 0) {
            var ctr = 0;
            $('#ticket-data td.coeff').each(function () {
                if ($(this).text() > 1.1) {
                    ctr += 1;
                }
            });
            if (ctr < 6) {
                var needed = 6 - ctr;
                alert("You must add at least " + needed + " other events with coefficient over 1.1");
            }
        }

    });
});