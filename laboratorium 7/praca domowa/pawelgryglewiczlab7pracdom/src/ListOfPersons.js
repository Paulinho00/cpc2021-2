import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Table, Button, ButtonGroup } from 'reactstrap';
import { useState } from 'react/cjs/react.development';

//Komponent z listą wszystkich zapisanych osób
function ListOfPersons(props){

    //Stan przechowujący, które osoby są teraz wyświetlane w tabeli
    const [showStudent, setShowStudent] = useState(false);

    const deleteStudent = function(index){
        const newStudents = props.students.filter((element, i, arr) => {
            return i != index;
        });
        props.setStudents(newStudents);
    }

    const deleteTeacher = function(index){
        const newTeachers = props.teachers.filter((element, i, arr) => {
            return i != index;
        });
        props.setTeachers(newTeachers);
    }


    return (
        <>
        <Table dark>
            <thead>
                <tr>
                    <th scope='row'>
                        Lp.
                    </th>
                    <th>
                        Imię
                    </th>
                    <th>
                        Nazwisko
                    </th>
                    <th>

                    </th>
                    <th>

                    </th>
                </tr>
            </thead>
            <tbody>
                {showStudent 
                ? 
                    props.students.map(function(elementFromTable, index){
                        return(
                        <tr>
                        <th scope='row'>{index+1}</th>
                        <td>{elementFromTable.name}</td>
                        <td>{elementFromTable.surname}</td>
                        <td><Button style={{backgroundColor:'#111e60'}} onClick={() => deleteStudent(index)}>Usuń</Button></td>
                        <td><Button style={{backgroundColor:'#111e60'}}>Szczegóły</Button></td>
                        </tr>
                        )
                    })
                :   props.teachers.map(function(elementFromTable, index){
                    return(
                    <tr>
                    <th scope='row'>{index+1}</th>
                    <td>{elementFromTable.name}</td>
                    <td>{elementFromTable.surname}</td>
                    <td><Button style={{backgroundColor:'#111e60'}} onClick={() => deleteTeacher(index)}>Usuń</Button></td>
                    <td><Button style={{backgroundColor:'#111e60'}}>Szczegóły</Button></td>
                    </tr>
                    )
                })

                }
            </tbody>
        </Table>
        <div>
            <ButtonGroup>
                <Button color='primary' onClick={() => {setShowStudent(true)}}>Prowadzący</Button>
                <Button color='primary' onClick={() => {setShowStudent(false)}}>Studenci</Button>
            </ButtonGroup>
        </div>
        </>   
    )
}


export default ListOfPersons;