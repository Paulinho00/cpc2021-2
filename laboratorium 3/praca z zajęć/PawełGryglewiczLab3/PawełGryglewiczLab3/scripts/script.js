// Ilość prób przed podaniem średniego wyniku
let howManyTrials = 5;

// Zmierzone czasy reakcji
let reactionTimes = [];
// Rozpoczęcie pomiaru czasu
let trialStart = 0;
// Zakończenie pomiaru czasu
let trialEnd = 0;
// Licznik prób
let trialCounter = 0;

// ID procesu mierzenia czasu
let timeoutId = 0;

// Zresetowanie czasów reakcji
function ResetTimes() {
    for (let i = 0; i < howManyTrials; i++) {
        reactionTimes[i] = 0;
    }
}

//Rozpoczęcie oczekiwania na pomiaru 
function StartIdle() {
    document.getElementById("button-timer").src = "images/buttonBlue.png";
    document.getElementById("button-timer").onclick = FalseStart;

    if (trialCounter > howManyTrials - 1) {
        ResetTimes();
        UpdateTable(0);
        trialCounter = 0;
    }

    trialCounter++;
    let randomTimer = Math.round(Math.random() * 1000 + 500);
    timeoutId = setTimeout(StartTimer, randomTimer);
}

// Ukaranie za naciśnięcie przycisku zbyt wcześnie
function FalseStart() {
    clearTimeout(timeoutId);
    trialStart = new Date().getTime() - 1000;
    StopTimer();
}


//Rozpoczęcie pomiaru czasu
function StartTimer() {
    document.getElementById("button-timer").src = "images/buttonGreen.png";
    document.getElementById("button-timer").onclick = StopTimer;
    trialStart = new Date().getTime();
}

//Zakończenie pomiaru czasu reakcji
function StopTimer() {
    trialEnd = new Date().getTime() - trialStart;
    document.getElementById("button-timer").src = "images/buttonRed.png";
    document.getElementById("button-timer").onclick = StartIdle;

    reactionTimes[trialCounter - 1] = trialEnd;

    let average = 0;

    if (trialCounter > howManyTrials - 1) {
        for (let i = 0; i < trialCounter; i++) {
            average += reactionTimes[i];
        }

        average = Math.round(average / howManyTrials);
        alert("Twój średni czas reakcji: " + average + " ms");
    }

    UpdateTable(average);
}

// Funkcja aktualizująca tabelę z wynikami
function UpdateTable(average) {
    document.getElementById('times-table').innerHTML = "";
    document.getElementById('times-table').innerHTML +=
        '<tr>' +
               '<th> Nr próby </th>' +
                '<th> Czas reakcji </th>' +
        '</tr>';

    for (let i = 0; i < howManyTrials; i++) {
        document.getElementById('times-table').innerHTML +=
            '<tr>' +
            '<td> Próba ' + (i + 1) + '</td>' +
            '<td>' + reactionTimes[i]+  ' ms </td > ' +
            '</tr>';
    }

    document.getElementById('times-table').innerHTML +=
        '<tr>' +
        '<td> Average </td>' +
        '<td>' + average + ' ms </td>' +
        '</tr>';
}