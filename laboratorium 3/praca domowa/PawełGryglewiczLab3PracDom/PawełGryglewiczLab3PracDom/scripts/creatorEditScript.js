
//Tablica przechowująca dane z pól tekstowych
let inputs =[];

//Funkcja startowa strony kreatora
function Start() {
    //Dodanie eventListenra do przycisku cofającego na główną stronę
    document.getElementById("back-to-main-page").addEventListener("click", BackToMainPage);
    //Sprawdzenie czy jest włączona opcja tworzenia
    if (window.sessionStorage.getItem("editOrCreate") === "create") {
        //Dodanie eventListnera do przycisku potwierdzeni
        document.getElementById("confirm-values").addEventListener("click", CreateTask);
    }

    //Sprawdzenie czy jest włączona opcja edycji
    if (window.sessionStorage.getItem("editOrCreate") === "edit") {

        //Pobranie indeksu edytowanego zadania
        let index = window.sessionStorage.getItem("chosenIndex")
        //Pobranie danych edytowanego zadania
        let storage = JSON.parse(window.sessionStorage.getItem(index));
        //Wyświetlenie danych zadania w polach tekstowych
        BaseValues(storage);
        //Dodanie eventListnera do przycisku potwierdzenia
        document.getElementById("confirm-values").addEventListener("click", function () { EditValues(index) });

    }
}

//Funkcja tworząca nowe zadanie i zapisująca je w pamięci sesji
function CreateTask() {

    //Wywołanie metody zczytującej wartości w polach tekstowych
    ReadValues();
    
    //Wyczyszczenie pól tesktowych
    document.getElementById("name-input").value = " ";
    document.getElementById("description-input").value = " ";
    document.getElementById("date-input").value = " ";
    document.getElementById("priority").value = " ";
    document.getElementById("duration-input").value = " ";

    //Zapisanie danych w sesji przeglądarki
    window.sessionStorage.setItem(window.sessionStorage.getItem("counter") + 1, JSON.stringify(inputs));
    //Zwiększenie licznika
    window.sessionStorage.setItem("counter", window.sessionStorage.getItem("counter") + 1)
    
}
//Funkcja edytująca zadanie o danym indeksie
function EditValues(index) {
    //Wywołanie metody zczytującej wartości w polach tekstowych
    ReadValues();
    //Zapisanie zaaktualizowanych danych w pamięci sesji
    window.sessionStorage.setItem(index, JSON.stringify(inputs));
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
        return;
    }
    //Odczyt nazwy zadania
    inputs[0] = document.getElementById("name-input").value;

    //Sprawdzenie czy pole jest puste
    if (document.getElementById("description-input") === null || document.getElementById("description-input").value === "") {
        alert("Wypełnij wszystkie pola!");
        return;
    }
    //Odczyt opisu zadania
    inputs[1] = document.getElementById("description-input").value;

    //Sprawdzenie czy pole jest puste
    if (document.getElementById("date-input") === null || document.getElementById("date-input").value === "") {
        alert("Wypełnij wszystkie pola!");
        return;
    }
    //Odczyt daty wykonania zadania
    inputs[2] = document.getElementById("date-input").value;

    
    //Sprawdzenie czy pole jest puste
    let select = document.getElementById("priority");
    if (select.options[select.selectedIndex].value === "") {
        alert("Wypełnij wszystkie pola!");
        return;
    }
    //Odczyt priorytetu zadania
    inputs[3] = document.getElementById("priority").value;

    //Sprawdzenie czy pole jest puste
    if (document.getElementById("duration-input") === null || document.getElementById("duration-input").value === "") {
        alert("Wypełnij wszystkie pola!");
        return;
    }
    //Odczyt czasu trwania zadania
    inputs[4] = document.getElementById("duration-input").value;

}

