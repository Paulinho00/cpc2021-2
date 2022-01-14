import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import {Button} from 'reactstrap';

//Komponent wyświetlający szczegółowe dane studenta
function StudentDetailedView(props){

    const backToListOfPersons = function(){
        props.setChosenStudent(-1);
    }


    return(
    <>
    <div className='container-fluid mt-3'>
        <div className='row d-flex justify-content-center'>
            <div className='col-sm-2 text-white fw-bold'>Imię:</div>
            <div className='col-sm-2 text-white'>{props.student.name}</div>
        </div>
        <div className='row mt-2 d-flex justify-content-center'>
            <div className='col-sm-2 text-white fw-bold'>Nazwisko:</div>
            <div className='col-sm-2 text-white'>{props.student.surname}</div>
        </div>
        <div className='row mt-2 d-flex justify-content-center'>
            <div className='col-sm-2 text-white fw-bold'>Kierunek:</div>
            <div className='col-sm-2 text-white'>{props.student.subject}</div>
        </div>
        <div className='row mt-2 d-flex justify-content-center'>
            <div className='col-sm-2 text-white fw-bold'>Wydział:</div>
            <div className='col-sm-2 text-white'>{props.student.faculty}</div>
        </div>
        <div className='row mt-2 d-flex justify-content-center'>
            <div className='col-sm-2 text-white fw-bold'>Email:</div>
            <div className='col-sm-2 text-white'>{props.student.email}</div>
        </div>
    </div>
    <div className='mt-3 ms-5  mt-3 d-flex justify-content-center'>
    <Button style={{backgroundColor:'#111e60'}} onClick={() => backToListOfPersons()}>Cofnij</Button>
    </div>
    </>
    )
}

export default StudentDetailedView;

