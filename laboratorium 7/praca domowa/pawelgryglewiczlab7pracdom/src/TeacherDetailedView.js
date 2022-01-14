import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import {Button} from 'reactstrap';

//Komponent wyświetlający szczegółowe dane nauczyciela
function TeacherDetailedView(props){

    const backToListOfPersons = function(){
        props.setChosenTeacher(-1);
    }


    return(
    <>
    <div className='container-fluid'>
        <div className='row  mt-3 d-flex justify-content-center'>
            <div className='col-sm-2 text-white fw-bold'>Imię:</div>
            <div className='col-sm-2 text-white'>{props.teacher.name}</div>
        </div>
        <div className='row mt-2  mt-3 d-flex justify-content-center'>
            <div className='col-sm-2 text-white fw-bold'>Nazwisko:</div>
            <div className='col-sm-2 text-white'>{props.teacher.surname}</div>
        </div>
        <div className='row mt-2  mt-3 d-flex justify-content-center'>
            <div className='col-sm-2 text-white fw-bold'>Stopień:</div>
            <div className='col-sm-2 text-white'>{props.teacher.degree}</div>
        </div>
        <div className='row mt-2  mt-3 d-flex justify-content-center'>
            <div className='col-sm-2 text-white fw-bold'>Obszar badań:</div>
            <div className='col-sm-2 text-white'>{props.teacher.researchArea}</div>
        </div>
        <div className='row mt-2  mt-3 d-flex justify-content-center'>
            <div className='col-sm-2 text-white fw-bold'>Email:</div>
            <div className='col-sm-2 text-white'>{props.teacher.email}</div>
        </div>
    </div>
    <div className='mt-3 ms-5  mt-3 d-flex justify-content-center'>
    <Button style={{backgroundColor:'#111e60'}} onClick={() => backToListOfPersons()}>Cofnij</Button>
    </div>
    </>
    )
}

export default TeacherDetailedView;
