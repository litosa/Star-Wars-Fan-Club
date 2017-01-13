$(function () {

    startChatHub();
});

function startChatHub() {
    var chat = $.connection.chatHub;
    var messageList = [];

    // Hämtar inloggat användarnamn och skriver ut i onlineuser div
    $('#nickname').val($('#nick').val());
    chat.client.differentName = function (name) {
        return false;
        $('#nickname').val($('#nick').val());
        chat.server.notify($('#nickname').val(), $.connection.hub.id);
    };

    chat.client.online = function (name) {
        // Uppdaterar listan av användare anslutna till chatten
        if (name == $('#nickname').val())
            $('#onlineusers').append('<div class="text-warning">Du: ' + name + '</div>');
        else {
            $('#onlineusers').append('<div>' + name + '</div>');
            $("#users").append('<option value="' + name + '">' + name + '</option>');
        }
    };

    //Triggas när användare ansluter till chatten
    chat.client.enters = function (name) {

        var count = $('#chatlog > div > i').length;

        // Kollar om antal meddelanden i chatloggen är mer än 15,
        // Då ska det äldsta meddelandet tas bort för att göra plats för det nyaste
        if (count > 14) {
            $('#chatlog div').last().remove();
        }

        $('#chatlog').prepend('<div class="text-success" style="font-style:italic;"><i>' + name + ' har anslutit till chatten</i></div><br/>');
        $("#users").append('<option value="' + name + '">' + name + '</option>');
        $('#onlineusers').append('<div>' + name + '</div>');
    };

    // Hämtar 15 senaste meddelanden när användare ansluter sig till chatten
    chat.client.getBroadcastMessage = function (filteredListMessagesByName) {

        // Felhantering: Varje gång ny användare ansluter till chatten triggas starthub
        // och hämtas gamla meddelanden. Då hämtar även redan inloggade användare samma meddelanden
        // Denna algoritm motverkar dubletter av meddelanden till redan inloggad användare...
        for (var i = 0; i < filteredListMessagesByName.length; i++) {
            var found = false;
            for (var j = 0; j < messageList.length; j++) {
                if (filteredListMessagesByName[i].messagePosted == messageList[j].messagePosted) found = true;
            }
            if (!found) {
                for (var i = 0; i < filteredListMessagesByName.length; i++) {

                    name = filteredListMessagesByName[i].Name;
                    message = filteredListMessagesByName[i].Message;
                    messagePosted = filteredListMessagesByName[i].MessagePosted;

                    // Ersätter specifika tecken till smileys
                    message = message.replace(":)", "<img src=\"/images/smile.gif\" class=\"smileys\" />");
                    message = message.replace("B)", "<img src=\"/images/cool.gif\" class=\"smileys\" />");
                    message = message.replace("bye!", "<img src=\"/images/bye.gif\" class=\"smileys\" />");
                    message = message.replace("darthmaul", "<img src=\"/images/darthmaul.gif\" class=\"smileys\" />");

                    // Bifogar varje skickat meddelande till chatlog
                    $('#chatlog').append('<div style="color:#7f7f7f"><i>' + messagePosted + '</i><br/><span style="color:black"><strong>' + name + ':</strong></span> ' + message + '</div><br/>');
                }
            }

            messageList = filteredListMessagesByName;
        }
    }

    // Funktion som sänder ut nya meddelanden med tillhörande,
    // användarnamn i hubben på serversidan
    chat.client.broadcastMessage = function (name, message, createdAt) {

        var count = $('#chatlog > div > i').length;

        if (count > 14) {
            $('#chatlog div').last().remove();
        }

        message = message.replace(":)", "<img src=\"/images/smile.gif\" class=\"smileys\" />");
        message = message.replace("B)", "<img src=\"/images/cool.gif\" class=\"smileys\" />");
        message = message.replace("bye!", "<img src=\"/images/bye.gif\" class=\"smileys\" />");
        message = message.replace("darthmaul", "<img src=\"/images/darthmaul.gif\" class=\"smileys\" />");


        $('#chatlog').prepend('<div style="color:#7f7f7f"><i>' + createdAt + '</i><br/><span style="color:black"><strong>' + name + ':</strong></span> ' + message + '</div><br/>');
    };

    // Triggas när användare lämnar chatten och har kontakt med,
    // funktionen OnDisconnected i hubben på serversidan
    chat.client.disconnected = function (name) {

        var count = $('#chatlog > div > i').length;

        if (count > 14) {
            $('#chatlog div').last().remove();
        }

        $('#chatlog').prepend('<div class="text-danger" style="font-style:italic;"><i>' + name + ' har lämnat chatten</i></div><br/>');
        $('#onlineusers div').remove(":contains('" + name + "')");
        $("#users option").remove(":contains('" + name + "')");
    }

    // Startar anslutningen till hubben.
    $.connection.hub.start().done(function () {

        //Hämtar inloggad användare
        chat.server.get($('#nickname').val());

        // Anropar Notify funktionen i hubben på serversidan
        chat.server.notify($('#nickname').val(), $.connection.hub.id);

        $('#btnsend').click(function () {
            if ($("#users").val() == "SendToUser") {
                // Felhantering: Motverkar spam med tomma meddelanden
                if ($('#message').val() != "") {
                    $('#errorlog div').last().remove();
                    // Anropar Send funktionen i hubben på serversidan.
                    chat.server.send($('#nickname').val(), $('#message').val());
                }
                else {
                    $('#errorlog div').last().remove();
                    $('#errorlog').append('<div class="list-group-item text-danger"><span>Felaktig inmatning</span></div>');
                }
            }
            else {
                chat.server.sendToSpecific($('#nickname').val(), $('#message').val(), $("#users").val());
            }
            $('#message').val('').focus();
        });

        //$('#btnget').click(function () {
        //    chat.server.get($('#nickname').val());
        //});

    });
}