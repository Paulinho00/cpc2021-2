import { useState } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Button } from 'reactstrap';
import AddPersonForm from './AddPersonForm';

//Komponent z wyborem formularza dodawania osoby
function ChooseForm(props){

    //Stan przechowujący informację o wybranym formularzu
    const [form, setForm] = useState(0);

    return(
    <>
    <div>  
        {form == 1 &&
        <>
        <AddPersonForm isStudent={true} returnToChoosePage={setForm} students={props.students} teachers={props.teachers} setStudents={props.setStudents} setTeachers={props.setTeachers}/>
        </>
        }
        {form == 2 &&
        <>
        <AddPersonForm isStudent={false} returnToChoosePage={setForm} teachers={props.teachers} students={props.students} setStudents={props.setStudents} setTeachers={props.setTeachers}/>
        </>
        }    
        {form == 0 &&
        <>
        <div className='mt-5'>
            <Button style={{backgroundColor:'#111e60'}} onClick={() => setForm(1)}>Dodaj studenta</Button>
        </div>
        <div class='mt-2'>
            <Button style={{backgroundColor:'#111e60'}} onClick={() => setForm(2)}>Dodaj prowadzącego</Button>
        </div>
        </>
        }
    </div>
    </>
    );
    
}

export default ChooseForm;