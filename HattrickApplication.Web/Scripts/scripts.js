$(document).ready(function () {
    var total;
    var cachedItems;
    if ($("#sesionDiv").val()) {
        cachedItems = $("#sesionDiv").attr("value");
        $("#ticket-data").children('tbody').append(cachedItems);
        $(".ticketitem").each(function() {
            var eventId = $(this).find("td:eq(0)").text();
            var tip = $(this).find("td:eq(2)").text();
            var row = $("#accordion").find("tr#" + eventId);
            row.find("input#" + tip).attr("class", "tip-selected");
        });
    }
    $('.tip, .tip-selected').click(function () {
        if ($(this).attr("class") === "tip") {
            var group = "input:submit[name='" + $(this).attr("name") + "']";
            var $row = jQuery(this).closest('tr');
            var rowclass = jQuery(this).attr("name");
            var columnId = jQuery(this).closest('tr').attr("id");
            var columnHome = $row.find('#homeCell').html();
            var columnAway = $row.find('#awayCell').html();
            var columnTip = jQuery(this).attr("id");
            var columnCoeff = jQuery(this).attr("value");
            var table = $('#ticket-data').children('tbody');
            if ($("#ticket-data").find("#" + columnId).length) {
                addToTicket(rowclass, columnId, columnTip, columnCoeff);
                var row = $("#ticket-data").find("#" + columnId).closest("tr");
                row.find("td:eq(0)").text(columnId);
                row.find("td:eq(1)").text(columnHome + columnAway);
                row.find("td:eq(2)").text(columnTip);
                row.find("td:eq(3)").text(columnCoeff);
                $(group).attr("class", "tip");
                $(this).attr("class", "tip-selected");
            } else if (rowclass === "TipsCheckBoxGroupTop" && $("#ticket-data").find("#TipsCheckBoxGroupTop").length) {
               addToTicket(rowclass, columnId, columnTip, columnCoeff);
               var toprow = $("#ticket-data").find("#TipsCheckBoxGroupTop").closest("tr");
               toprow.find("td:eq(0)").text(columnId);
               toprow.find("td:eq(1)").text(columnHome + columnAway);
               toprow.find("td:eq(2)").text(columnTip);
               toprow.find("td:eq(3)").text(columnCoeff);
               $(group).attr("class", "tip");
               $(this).attr("class", "tip-selected");
            } else {
                addToTicket(rowclass, columnId, columnTip, columnCoeff);
                table.append('<tr class="ticketitem" id=' + rowclass + '><td id="' + columnId + '"> ' + columnId + '</td > <td>' + columnHome +"-"+ columnAway + '</td > <td>' + columnTip + '</td > <td class="coeff">' + columnCoeff + '</td><td><button class="removeEvent" type="button">X</button></td></tr > ');
                $(group).attr("class", "tip");
                $(this).attr("class", "tip-selected");
            }     
        } else {
            group = "input:submit[name='" + $(this).attr("name") + "']";
            $(this).prop("class", "tip");
            columnId = jQuery(this).closest('tr').attr("id");
            table = $('#ticket-data').children('tbody');
            deleteFromTicket(columnId);
            $(table).find("#" + columnId).closest("tr").remove();
        }
    });

    function addToTicket(rowClass, id, tip, coefficient) {
        $.ajax(
            {
                type: 'POST',
                data: JSON.stringify({ rowClass: rowClass, id: id, tip: tip, coefficient: coefficient }),
                url: '/Event/AddToSession',
                dataType: 'json',
                contentType: 'application/json; charset=utf-8'
            });
    }
    function deleteFromTicket(eventId) {
        $.ajax(
            {
                type: 'POST',
                data: JSON.stringify({ eventId: eventId }),
                url: '/Event/DeleteSession',
                dataType: 'json',
                contentType: 'application/json; charset=utf-8'

            });
    }


    $('#ticket-data').on("click", ".removeEvent", function () {
        var row = jQuery(this).closest("tr");
        var id = row.find("td:eq(0)").text().replace(" ", "");
        var acordionRow = $("#content").find('tr#'+id);
        var nov = acordionRow.find("input:submit.tip-selected");
        nov.attr("class", "tip");
        deleteFromTicket(id);
        jQuery(this).closest("tr").remove();
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
            ticket.User = new Object();
            ticket.User.Id = 1;
            $('.ticketitem').each(function () {
                var titem = new Object();
                titem.Event = new Object();
                titem.Event.Id = $(this).find("td:eq(0)").text();
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
                    url: '/Event/CreateTicket',
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
    $("#credit-balance").unbind('click').click(function() {

        var credit = $('#credit-amount').val();
        if (credit < 10 || credit > 10000) {
            alert("Invalid amount");
        } else {
            $.ajax(
                {
                    type: 'POST',
                    async: false,
                    data: JSON.stringify({ id: 1, balance: credit }),
                    url: '/User/CreditBalance',
                    dataType: 'json',
                    contentType: 'application/json; charset=utf-8',
                    success: function(response) {
                        if (response.success) {
                            alert(response.message);
                            location.reload();
                        } else {
                            alert(response.message);
                        }
                        
                    },
                    error: function() {
                        alert(response.message);
                    }
                });
        }
    });
    $(".datePicker").datetimepicker({
            dateFormat: "dd/mm/yy",
            timeFormat: 'HH:mm:ss'
        }
    );
});