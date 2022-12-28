
$(document).ready(function () {

  const connection = new signalR.HubConnectionBuilder()
    .withUrl("/signalrurl")
    .withAutomaticReconnect([0, 3000, 5000, 10000, 15000, 30000])
    .configureLogging(signalR.LogLevel.Information)
    .build();

  connection.on('GetCryptoData', (newData) => {
    fillTable(newData);
  });

  connection.start().then(function () {

  }).catch(console.error);

  let tryingToReconnect = false;

  connection.onreconnecting((error) => {
    tryingToReconnect = true;
  });

  connection.onreconnected((connectionId) => {
    tryingToReconnect = false;

  });
});

function fillTable(data) {
  let table = document.getElementById("table");
  let tableBody = table.querySelector('tbody');
  let bodyText = "";

  for (let i = 0; i < data.length; i++) {
    let el = data[i];
    bodyText +=
      `<tr><td>${el.name}</td><td>${el.symbol}</td><td>${el.price}</td><td>${el.changeRate}</td></tr>`;
  }

  tableBody.innerHTML = bodyText;
}