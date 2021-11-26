
// Funkcja dodając eventListenery do przycisku
function Start() {
    document.getElementById("back-to-main-page").addEventListener("click", function () { window.open("../index.html", "_self");});
}

// Funkcja wczytująca dane z sesji do tabeli
function LoadIntoTable() {
    //Sprawdzenie czy pamięc sesji nie jest pusta
    if (window.sessionStorage.length !== 0) {
        //Pętla wczytująca wszystkie możliwe indeksy z zadaniami
        for (let i = 1; i <= window.sessionStorage.getItem("counter"); i++) {
            //Sprawdzenie czy dany indeks nie jest pusty
            if (window.sessionStorage.getItem(i) !== null) {
                //Utworzenie nowego rzędu
                let tr = document.createElement("tr");
                //Odczyt zadania z pamięci sesji
                let storage = JSON.parse(window.sessionStorage.getItem(i));
                //Dodanie danych zadania do rzędu tabeli
                tr.innerHTML += '<td>' + storage[0] + '</td>' +
                    '<td>' + storage[1] + '</td>' +
                    '<td>' + storage[2] + '</td>' +
                    '<td>' + storage[3] + '</td>' +
                    '<td>' + storage[4] + '</td>';
                //Dobranie odpowiednie koloru rzędu, w zależności od priorytetu
                switch (storage[3]) {
                    case "Wysoki": tr.setAttribute("class", "high-priority"); break;
                    case "Normalny": tr.setAttribute("class", "normal-priority"); break;
                    case "Niski": tr.setAttribute("class", "low-priority"); break;
                }
                //Dodanie rzędu do tabeli na stronie
                document.getElementById("table-content").appendChild(tr);
            }
        }
    }
}