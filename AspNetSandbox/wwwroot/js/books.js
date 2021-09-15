"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/messagehub").build();

// Disable send button until connection is establishes

connection.on("BookCreated", function (book) {
    console.log("Book created: "+book.toString());
});

connection.start().then(function () {
    console.log("Connection estabilished!");
}).catch(function (err) {
    return console.error(err.toString());
});
