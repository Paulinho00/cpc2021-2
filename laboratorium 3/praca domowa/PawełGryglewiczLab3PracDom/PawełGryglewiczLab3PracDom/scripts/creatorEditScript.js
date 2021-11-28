
//Tablica przechowująca dane z pól tekstowych
let inputs = [];

//Funkcja startowa strony kreatora
function Start() {
    //Dodanie eventListenra do przycisku cofającego na główną stronę
    document.getElementById("back-to-main-page").addEventListener("click", BackToMainPage);
    //Wywołanie metody blokującej wcześniejsze daty niż aktualna w date-input
    RefreshDateInput();
    //Sprawdzenie czy licznik jest zainicjalizowany
    if (window.sessionStorage.getItem("isCounterInitialized") === null) {
        //Inicjalizajca licznika
        StartCounter();
        window.sessionStorage.setItem("isCounterInitialized", true);
    }
    //Sprawdzenie czy jest włączona opcja tworzenia
    if (window.sessionStorage.getItem("editOrCreate") === "create") {
        //Dodanie eventListnera do przycisku potwierdzeni
        document.getElementById("confirm-values").addEventListener("click", CreateTask);
    }

    //Sprawdzenie czy jest włączona opcja edycji
    if (window.sessionStorage.getItem("editOrCreate") === "edit") {
        //Pobranie indeksu edytowanego zadania
        let index = window.sessionStorage.getItem("chosenIndex");
        //Pobranie danych edytowanego zadania
        let storage = JSON.parse(window.sessionStorage.getItem(index.toString()));
        //Wyświetlenie danych zadania w polach tekstowych
        BaseValues(storage);
        //Dodanie eventListnera do przycisku potwierdzenia
        document.getElementById("confirm-values").addEventListener("click", function () { EditValues(index) });

    }
}

// Funkcja blokująca wybranie wcześniejszej daty niż aktualna w date-input
function RefreshDateInput() {
    //Pobranie aktualnej daty
    let n = new Date();
    let y = n.getFullYear();
    let m = n.getMonth() + 1;
    let d = n.getDate();

    //Utworzenie stringa w formacie daty
    if (m < 10)
        m = '0' + m.toString();
    else if (d < 10)
        d = '0' + d.toString();
    let minDate = y + '-' + m + '-' + d;

    //Ustawienie minimalnej daty w polu date-input
    let dateInput = document.getElementById("date-input");
    dateInput.setAttribute("min", minDate);

}

//Funkcja tworząca nowe zadanie i zapisująca je w pamięci sesji
function CreateTask() {

    //Wywołanie metody zczytującej wartości w polach tekstowych
    if (ReadValues() === -1) { return; }
    
    //Wyczyszczenie pól tesktowych
    document.getElementById("name-input").value = " ";
    document.getElementById("description-input").value = " ";
    document.getElementById("date-input").value = " ";
    document.getElementById("priority").value = " ";
    document.getElementById("duration-input").value = " ";

    //Zapisanie danych w sesji przeglądarki
    let nextIndex = parseInt(window.sessionStorage.getItem("counter")) + 1;
    window.sessionStorage.setItem(nextIndex, JSON.stringify(inputs));
    //Zwiększenie licznika
    window.sessionStorage.setItem("counter", parseInt(window.sessionStorage.getItem("counter")) + 1)
    //Wyświetlenie napisu potwierdzającego dodanie zadania
    DisplayLabel();
    //Usunięcie napisu po 5s
    window.setTimeout(DeleteLabel, 2000);

    
}
//Funkcja edytująca zadanie o danym indeksie
function EditValues(index) {
    //Wywołanie metody zczytującej wartości w polach tekstowych
    if (ReadValues() === -1) { return; }
    //Zapisanie zaaktualizowanych danych w pamięci sesji
    window.sessionStorage.setItem(index, JSON.stringify(inputs));
    //Wyczyszczenie zapisanego indeksu
    window.sessionStorage.setItem("chosenIndex", -1);
    //Wywołanie metody otwierająca główną stronę
    BackToMainPage();
}


//Powrót do głównej strony
function BackToMainPage() {
    window.open("../index.html", "_self");
}

//Licznik id wpisów do pamięci sesji
function StartCounter() {
    window.sessionStorage.setItem("counter", 0);
}

// Funkcja wyświetlająca aktualne dane wybranego zadania w polu tekstowym
function BaseValues(storage) {
    document.getElementById("name-input").value = storage[0];
    document.getElementById("description-input").value = storage[1];
    document.getElementById("date-input").value = storage[2];
    document.getElementById("priority").value = storage[3];
    document.getElementById("duration-input").value = storage[4];
}

//Funkcja odczytująca wartości w polach tekstowych
function ReadValues() {
    //Sprawdzenie czy pole jest puste
    if (document.getElementById("name-input") === null || document.getElementById("name-input").value === "") {
        alert("Wypełnij wszystkie pola!");
        return -1;
    }
    //Odczyt nazwy zadania
    inputs[0] = document.getElementById("name-input").value.trim();

    //Sprawdzenie czy pole jest puste
    if (document.getElementById("description-input") === null || document.getElementById("description-input").value === "") {
        alert("Wypełnij wszystkie pola!");
        return -1;
    }
    //Odczyt opisu zadania
    inputs[1] = document.getElementById("description-input").value;

    //Sprawdzenie czy pole jest puste
    if (document.getElementById("date-input") === null || document.getElementById("date-input").value === "") {
        alert("Wypełnij wszystkie pola!");
        return -1;
    }
    //Odczyt daty wykonania zadania
    inputs[2] = document.getElementById("date-input").value;

    
    //Sprawdzenie czy pole jest puste
    let select = document.getElementById("priority");
    if (select.options[select.selectedIndex].value === "") {
        alert("Wypełnij wszystkie pola!");
        return -1;
    }
    //Odczyt priorytetu zadania
    inputs[3] = document.getElementById("priority").value;

    //Sprawdzenie czy pole jest puste
    if (document.getElementById("duration-input") === null || document.getElementById("duration-input").value === "") {
        alert("Wypełnij wszystkie pola!");
        return -1;
    }
    //Odczyt czasu trwania zadania
    inputs[4] = document.getElementById("duration-input").value;
    return 1;

}

// Funkcja wyświetlająca napis potwierdzający dodanie zadania
function DisplayLabel() {
    //Utworzenie elementu
    let h3 = document.createElement("h3");
    //Dodanie tekstu
    h3.innerHTML = "Pomyślnie dodano";
    //Dodanie id
    h3.setAttribute("id", "confirm-label");
    //Dodanie napisu do kontenera 
    document.getElementById("confirm-label-container").appendChild(h3);
}

// Funkcja usuwająca napis potwierdzający
function DeleteLabel() {
    //Usunięcie napisu
    document.getElementById("confirm-label").remove();
}

