

//Funkcja przypisująca EventListenery do przycisków na głównej stronie
function ButtonInit() {
    document.getElementById("open-creator-page").addEventListener("click", OpenCreatorPage);
    document.getElementById("open-edit-page").addEventListener("click", OpenEditPage);
    document.getElementById("open-detailed-view").addEventListener("click", function () { window.open("./pages/detailed-view.html", "_self") });
}

//Funkcja otwierająca stronę 
function OpenCreatorPage() {
    //Otwarcie strony i ustawienie odpowiedniej opcji w pamięci sesji
    window.sessionStorage.setItem("editOrCreate", "create")
    window.open("./pages/new-task-creator-page.html", "_self");
}

// Funkcja usuwająca zadanie o podanym indeksie
function DeleteTask(index) {
    //Usunięcie elementu z pliku html
    document.getElementById("task" + index).remove();
    //Usunięcie danych o zadaniu z pamięci sesji
    window.sessionStorage.removeItem(index);
    //Zresetowanie searchboxa
    ResetSelect();

}

// Funkcja zmieniają styl wyświetlania zadania
function MarkAsDone(index) {
    // Odczyt nagłówka z plik html
    let li = document.getElementById("task" + index);

    //Zmiana stylu
    li.style.backgroundColor = "grey";
    li.getElementsByTagName('span')[0].style.textDecoration = "line-through";

    //Usunięcie przycisku 
    document.getElementById("marks-as-done-task" + index).remove();
    //Usunięcie danych o zadaniu z pamięci sesji
    window.sessionStorage.removeItem(index);
    //Zresetowanie searchboxa
    ResetSelect();

}

// Funkcja aktualizująca wyświetlane dane na głównej stronie
function ReloadTaskList() {
    //Sprawdzenie czy pamięc sesji nie jest pusta
    if (window.sessionStorage.length !== 0) {
        //Wywołanie pętli do odczytu całej pamięci sesji
        for (let i = 1; i <= window.sessionStorage.getItem("counter"); i++) {
            //Sprawdzenie czy dany wpis w pamięci nie jest nullem
            if (window.sessionStorage.getItem(i) !== null) {
                //Odczyt tablicy stringów
                let storage = JSON.parse(window.sessionStorage.getItem(i));
                //Dodanie wartości do datelist searchboxa
                AddElementToSelect(storage);
                //Stworzenie nowego elementu
                let li = document.createElement("li");
                //Ustawienie atrybutów nowego elementu
                li.setAttribute("id", "task" + i);
                li.setAttribute("class", "task");
                //Dodanie odpowiednich nagłówków i wartości do nowego elementu
                li.innerHTML += '<span class="task-text">' + storage[0] + '</span>' +
                    '<button id="marks-as-done-task' + i + '" type="button" class="small-normal button">Wykonane</button>' +
                    '<button id="delete-task' + i + '" type="button" class="delete button">Usuń</button>';

                //Dodanie nowego elementu do pliku html
                document.getElementById("tasks").appendChild(li);

                //Dodanie actionListenerów do przycisków w nowym elemencie
                document.getElementById("marks-as-done-task" + i).addEventListener("click", function () { MarkAsDone(i) });
                document.getElementById("delete-task" + i).addEventListener("click", function () { DeleteTask(i) });
            }
        }
    }
}

// Funkcja aktualizująca searchboxa
function ResetSelect() {
    document.getElementById("searchbox").innerHTML = "";
    //Sprawdzenie czy pamięc sesji nie jest pusta
    if (window.sessionStorage.length !== 0) {
        //Wywołanie pętli do odczytu całej pamięci sesji
        for (let i = 1; i <= window.sessionStorage.getItem("counter"); i++) {
            //Sprawdzenie czy dany wpis w pamięci nie jest nullem
            if (window.sessionStorage.getItem(i) !== null) {
                //Odczyt tablicy stringów
                let storage = JSON.parse(window.sessionStorage.getItem(i));
                //Dodanie wartości do datelist searchboxa
                AddElementToSelect(storage);
            }
        }
    }
}
// Funkcja dodająca zadanie do searchboxa
function AddElementToSelect(inputs) {
    //Utworzenie nowej opcji
    let option = document.createElement("option");
    //Ustawienie wartości nowej opcji
    option.innerHTML += inputs[0];
    //Dodanie opcji do datelist
    document.getElementById("searchbox").appendChild(option);
}

// Funkcja otwierająca stronę edycji zadania
function OpenEditPage() {
    //Pobranie nazwy wybranego zadania
    let taskName = document.getElementById("searchbox").value;
    //Pętla sprawdzająca jaki indeks ma dane zadanie
    for (let i = 0; i <= window.sessionStorage.getItem("counter"); i++) {
        //Sprawdzenie czy nazwa zadani się zgadza i czy dany indeks nie jest nullem
        if (window.sessionStorage.getItem(i) !== null && (JSON.parse(window.sessionStorage.getItem(i)))[0] === taskName) {
            //Zapisanie indeksu wybranego zadania
            window.sessionStorage.setItem("chosenIndex", i);
        }
    }
    //Otwarcie strony i ustawienie odpowiedniej opcji w pamięci sesji
    window.sessionStorage.setItem("editOrCreate", "edit")
    window.open("./pages/new-task-creator-page.html", "_self");
}

