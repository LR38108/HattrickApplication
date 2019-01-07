$(document).ready(function () {
    var total;
    $('.tip').click(function () {
        if ($(this).attr("class") === "tip") {
            var group = "input:submit[name='" + $(this).attr("name") + "']";
            var $row = jQuery(this).closest('tr');
            var rowclass = jQuery(this).attr("name");
            var columnID = jQuery(this).closest('tr').attr("id");
            var columnH = $row.find('#homeCell').html();
            var columnA = $row.find('#awayCell').html();
            var columnT = jQuery(this).attr("id");
            var columnC = jQuery(this).attr("value");
            var table = $('#ticket-data').children('tbody');
            if ($("#ticket-data").find("#" + columnID).length) {
                alert("Already played once!");
            } else {
                table.append('<tr class="ticketitem" id=' + rowclass + '><td id="' + columnID +'"> ' + columnID + '</td > <td>' + columnH + columnA + '</td > <td>' + columnT + '</td > <td class="coeff">' + columnC + '</td></tr > ');
                $(group).attr("class", "tip");
                $(this).attr("class", "tip-selected");
                $(group).css("background", "");
                $(this).css("background", "red");
                $(group).attr("disabled", true);
                $(this).attr("disabled", false);
            }
        } else {
            group = "input:submit[name='" + $(this).attr("name") + "']";
            $(this).prop("class", "tip");
            $(this).css("background", "");
            columnID = jQuery(this).closest('tr').attr("id");
            table = $('#ticket-data').children('tbody');
            $(table).find("#" + columnID).closest("tr").remove();
            $(group).attr("disabled", false);
        }
	});

    $(document).bind('keydown keyup keypress click', function () {
        if ($('#ticket-data >tbody >tr').length > 0) {
            var mgmtfee = $("#bet").val() * 0.95;
            $('#bet-minus-fee').html('5 % management fee: ' + mgmtfee.toFixed(2));
            total = 1;
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
        if ($("#bet").val().length > 0) {
            if ($('#ticket-data #TipsCheckBoxGroupTop').length > 0) {
                var ctr = 0;
                $('#ticket-data td.coeff').each(function () {
                    if ($(this).text() >= 1.1) {
                        ctr += 1;
                    }
                });
                if (ctr < 6) {
                    var needed = 6 - ctr;
                    alert("You must add at least " + needed + " other events with coefficient over 1.1");
                    return false;
                }
            }

            var ticket = new Object();
            var ticketitems = [];
            ticket.bet = $('#bet').val();

            $('.ticketitem').each(function () {
                var titem = new Object();
                titem.EventID = $(this).find("td:eq(0)").text();
                titem.TipType = $(this).find("td:eq(2)").text();
                titem.TipOdd = $(this).find("td:eq(3)").text();
                ticketitems.push(titem);
            });
            ticket.ticketitems = ticketitems;
            ticket.totalOdd = total;
            ticket.pWon = ticket.totalOdd * ticket.bet * 0.95;
            ticket.pWon = ticket.pWon.toFixed(2);


            $.ajax(
                {
                    type: 'POST',
                    data: JSON.stringify(ticket),
                    url: 'Event/CreateTicket',
                    dataType: 'json',
                    contentType: 'application/json; charset=utf-8',
                    success: function (response) {
                        if (response.success) {
                            alert(response.message);
                            location.reload();
                        } else {
                            alert(response.message);
                        }
                    },
                    error: function () {
                        alert(response.message);
                    }
                });


        } else {
            alert("Please input bet ammount");
        }
    });
    
});