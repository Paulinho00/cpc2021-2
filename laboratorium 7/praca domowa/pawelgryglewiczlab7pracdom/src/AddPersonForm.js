import React, { useEffect } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Form, FormGroup, Label, Input, Col, Button } from 'reactstrap';
import { useState } from 'react/cjs/react.development';

//Komponent z formularzem dodawania osoby
function AddPersonForm(props) {

    //Stany przechowujące wartości wprowadzone przez użytkownika
    const [name, setName] = useState('');
    const [surname, setSurname] = useState('');
    const [subject, setSubject] = useState('');
    const [faculty, setFaculty] = useState('');
    const [email, setEmail] = useState('');
    const [degree, setDegree] = useState('');
    const [researchArea, setResearchArea] = useState('');

    //Funkcje pobierające wartości z pól tekstowych
    const handleInputName = function(event){
        setName(event.target.value);
    }

    const handleInputSurname = function(event){
        setSurname(event.target.value);
    }

    const handleInputSubject = function(event){
        setSubject(event.target.value);
    }

    const handleInputFaculty = function(event){
        setFaculty(event.target.value);
    }

    const handleInputEmail = function(event){
        setEmail(event.target.value);
    }

    const handleInputDegree = function(event){
        setDegree(event.target.value);
    }

    const handleInputResearchArea = function(event){
        setResearchArea(event.target.value);
    }


    //Hook wyświetlający alert o powodzeniu lub niepowowdzeniu dodania osoby
    useEffect(() => {
        return () => {
            alert("Wychodzisz z okna formularzu")
        }
    }, []);

    //Funkcja dodająca studenta do tablicy z wszystkimi studentami studentów
    const addStudent = function () {
        //Sprawdzenie czy pola są wypełnione
        if (name == '' || surname == '' || subject == '' || faculty == '' || email == '') {
            alert("Nie wszyskie pola są wypełnione");
            props.returnToChoosePage(0);
        }
        else {
            let student = { name: name, surname: surname, subject: subject, faculty: faculty, email: email };
            let students = props.students;
            props.setStudents([...students, student]);
            props.returnToChoosePage(0);
        }
    }

    //Funkcja dodająca nauczyciela akademickiego do tablicy z wszystkimi nauczycielami
    const addTeacher = function(){
        //Sprawdzenie czy pola są wypełnione
        if (name == '' || surname == '' || degree == '' || researchArea == '' || email == '') {
            alert("Nie wszyskie pola są wypełnione");
            props.returnToChoosePage(0);
        }
        else {
    
            let teacher = { name: name, surname: surname, degree: degree, researchArea: researchArea, email: email };
            let teachers = props.teachers;
            props.setTeachers([...teachers, teacher]); 
            props.returnToChoosePage(0);
        }
    }


    return (
        <>
        <div>
            <Form className='mt-5' >
                <FormGroup row>
                    <Label for='name' sm={2} style={{color:'white'}}>
                        Imię
                    </Label>
                    <Col sm={2}>
                        <Input
                            id='name'
                            type='text'
                            onInput={handleInputName}
                        />
                    </Col>
                </FormGroup>

                <FormGroup row>
                    <Label for='surname' sm={2} style={{color:'white'}}>
                        Nazwisko
                    </Label>
                    <Col sm={2}>
                    <Input
                        id='surname'
                        type='text'
                        onInput={handleInputSurname}
                    />
                    </Col>
                </FormGroup>

                {props.isStudent
                    ? <>
                        <FormGroup row>
                            <Label for='subject' sm={2} style={{color:'white'}}>
                                Kierunek
                            </Label>
                            <Col sm={2}>
                            <Input
                                id='subject'
                                type='text'
                                onInput={handleInputSubject}
                            />
                            </Col>
                        </FormGroup>

                        <FormGroup row>
                            <Label for='faculty' sm={2} style={{color:'white'}}>
                                Wydział
                            </Label>
                            <Col sm={2}>
                            <Input
                                id='faculty'
                                type='text'
                                onInput={handleInputFaculty}
                            />
                            </Col>
                        </FormGroup>
                    </>
                    : <>
                        <FormGroup row>
                            <Label for='degree' sm={2} style={{color:'white'}}>
                                Stopień
                            </Label>
                            <Col sm={2}>
                            <Input
                                id='degree'
                                type='select'
                                onInput={handleInputDegree}
                            > 
                                <option>Magister</option>
                                <option>Doktor</option>
                                <option>Doktor habilotowany</option>
                                <option>Profesor</option>
                            </Input>
                            </Col>

                        </FormGroup>

                        <FormGroup row>
                            <Label for='researchArea' sm={2} style={{color:'white'}}>
                                Obszar badań naukowych
                            </Label>
                            <Col sm={2}>
                            <Input
                                id='researchArea'
                                type='text'
                                onInput={handleInputResearchArea}
                            />
                            </Col>
                        </FormGroup>
                    </>
                }

                <FormGroup row>
                    <Label for='email' sm={2} style={{color:'white'}}>
                        Adres email
                    </Label>
                    <Col sm={2}>
                    <Input
                        id='email'
                        type='email'
                        onInput={handleInputEmail}
                    />
                    </Col>
                </FormGroup>

            </Form>
            </div>
            <div className='mt-4 w-25'>
                {/* Przycisk cofający do widoku z wyborem formularza */}
                <Button style={{backgroundColor:'#111e60'}} onClick={() =>{props.returnToChoosePage(0)}}>Cofnij</Button>
                {/* Przycisk zatwierdzający dane*/}
                <Button style={{backgroundColor:'#111e60'}} onClick={props.isStudent ? addStudent: addTeacher}>Dodaj</Button>
            </div>
        </>

    )
}

export default AddPersonForm;