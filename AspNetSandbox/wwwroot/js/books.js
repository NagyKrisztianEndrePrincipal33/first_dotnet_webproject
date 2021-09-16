var connection = new signalR.HubConnectionBuilder()
    .withUrl("/messagehub")
    .build();

// Disable send button until connection is establishes

connection.on("BookCreated", function(book) {
    $("tbody").append(`<tr id=${book.id}>
        <td>
            ${book.title}
        </td>
        <td>
            ${book.author}
        </td>
        <td>
            ${book.language}
        </td>
        <td>
            <a href="/Books/Edit?id=${book.id}">Edit</a> |
            <a href="/Books/Details?id=${book.id}">Details</a> |
            <a href="/Books/Delete?id=${book.id}">Delete</a>
        </td>
    </tr>`);
});

connection.on("BookUpdated", function (book) {
    $(`#${book.id}`)[0].innerHTML = ` <td>
    ${book.title}
</td>
<td>
    ${book.author}
</td>
<td>
    ${book.language}
</td>
<td>
    <a href="/Books/Edit?id=${book.id}">Edit</a> |
    <a href="/Books/Details?id=${book.id}">Details</a> |
    <a href="/Books/Delete?id=${book.id}">Delete</a>
</td>`;
});

connection.on("BookDeleted", function(book) {
    $(`#${book.id}`).remove();
});

connection
    .start()
    .then(function() {
        console.log("Connection estabilished!");
    })
    .catch(function(err) {
        return console.error(err.toString());
    });