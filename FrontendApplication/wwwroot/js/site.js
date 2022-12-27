
$(document).ready(function () {
  fillTable(newData);
});

function fillTable(data) {
  let table = document.getElementById("table");
  let tableBody = document.getElementById("table").querySelector('tbody');
  let bodyText = "";

  for (let i = 0; i < data.length; i++) {
    let el = data[i];
    bodyText +=
      `<tr><td>${el.name}</td><td>${el.symbol}</td><td>${el.price}</td><td>${el.changeRate}</td></tr>`;
  }

  tableBody.innerHTML = bodyText;
}

var newData = [
  {
    "name": "Name1",
    "symbol": "Symbol1",
    "price": 40,
    "changeRate": 20
  },
  {
    "name": "Name2",
    "symbol": "Symbol2",
    "price": 30,
    "changeRate": 10
  },
  {
    "name": "Name3",
    "symbol": "Symbol3",
    "price": 25,
    "changeRate": 6
  },
  {
    "name": "Name4",
    "symbol": "Symbol4",
    "price": 35,
    "changeRate": 8
  },
  {
    "name": "Name5",
    "symbol": "Symbol5",
    "price": 78,
    "changeRate": 4
  }
];