import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';

//Funkcja renderująca stronę główną/powitalną
function MainPage(){
    return(
        <>
        <div className='p-5 text-center text-light'>
            <h1 className='mb-3'>Witaj na stronie z ewidencją studentów i nauczycieli akademickich.</h1>
            <h4 className='mb-3'>Aby zobaczyć studentów i nauczycieli w bazie, przejdź do zakładki lista.</h4>
            <h4 className='mb-3'>Jeśli chcesz dodać studenta lub nowego prowadzącego, przejdź do zakładki dodaj osobę </h4>
        </div>
        </>
    )
}

export default MainPage;