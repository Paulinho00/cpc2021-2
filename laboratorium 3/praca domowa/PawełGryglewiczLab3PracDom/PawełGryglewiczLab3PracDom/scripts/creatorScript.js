
//Tablica przechowująca dane wpisane przez użytkownika
let inputs =[];

//Funkcja startowa skryptu
function Start() {
    //Dodanie eventListenera
    document.getElementById("confirm-values").addEventListener("click", ReadValues);
}

//Funkcja odczytująca wartości w polach tekstowych i zapisująca je 
function ReadValues() {

    //Sprawdzenie czy pole jest puste
    if (document.getElementById("name-input") === null || document.getElementById("name-input").value === "") {
        alert("Wypełnij wszystkie pola!");
        return;
    }
    //Odczyt nazwy zadania
    inputs[0] = document.getElementById("name-input");

    //Sprawdzenie czy pole jest puste
    if (document.getElementById("description-input") === null || document.getElementById("description-input").value === "") {
        alert("Wypełnij wszystkie pola!");
        return;
    }
    //Odczyt opisu zadania
    inputs[1] = document.getElementById("description-input");

    //Sprawdzenie czy pole jest puste
    if (document.getElementById("date-input") === null || document.getElementById("date-input").value === "") {
        alert("Wypełnij wszystkie pola!");
        return;
    }
    //Odczyt daty wykonania zadania
    inputs[2] = document.getElementById("date-input");

    //Sprawdzenie czy pole jest puste
    if (document.getElementById("priority-input") === null || document.getElementById("priority-input").value === "") {
        alert("Wypełnij wszystkie pola!");
        return;
    }
    //Odczyt priorytetu zadania
    inputs[3] = document.getElementById("priority-input");

    //Sprawdzenie czy pole jest puste
    if (document.getElementById("duration-input") === null || document.getElementById("duration-input").value === "") {
        alert("Wypełnij wszystkie pola!");
        return;
    }
    //Odczyt czasu trwania zadania
    inputs[4] = document.getElementById("duration-input");

    //Wyczyszczenie pól tesktowych
    document.getElementById("name-input").value = " ";
    document.getElementById("description-input").value = " ";
    document.getElementById("date-input").value = " ";
    document.getElementById("priority-input").value = " ";
    document.getElementById("duration-input").value = " ";

    //Zapisanie danych w sesji przeglądarki
    window.sessionStorage.setItem(inputs[0], inputs);
}

