// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var HttpClient = function() {
    this.get = function(aUrl, aCallback) {
        var anHttpRequest = new XMLHttpRequest();
        anHttpRequest.onreadystatechange = function() { 
            if (anHttpRequest.readyState == 4 && anHttpRequest.status == 200)
                aCallback(anHttpRequest.responseText);
        }

        anHttpRequest.open( "GET", aUrl, true );            
        anHttpRequest.send( null );
    }
}

var client = new HttpClient();
client.get('http://localhost:5000/api/GetList', function(response) {
    const customers = JSON.parse(response);
    var entry = "";

    customers.forEach(row => {
        entry += `<tr class="link-item">`;
        entry += `<td>${row["Name"]}</td>`;
        entry += `<td>${row["Email"]}</td>`;
        entry += `<td>${row["Gender"]}</td>`;
        entry += `<td>${row["DateRegistered"]}</td>`;
        entry += `<td>${row["DaysAttending"]}</td>`;
        entry += `<td>${row["Request"]}</td>`;
        entry += `</tr>`;
    });

    document.getElementById("showData").innerHTML = entry;
});