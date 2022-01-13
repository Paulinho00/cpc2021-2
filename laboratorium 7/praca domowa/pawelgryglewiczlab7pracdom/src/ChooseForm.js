import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Button } from 'reactstrap';

//Funkcją renderująca stronę wyboru formularza dodawania osoby
function ChooseForm(){

    //Stan przechowujący informację o wybranym formularzu
    const [form, setForm] = useState(0);

    return(
    <>
    <div>
        {form == 0 &&
        <>
        <div className='mt-5'>
            <Button style={{backgroundColor:'#111e60'}}>Dodaj studenta</Button>
        </div>
        <div class='mt-2'>
            <Button style={{backgroundColor:'#111e60'}}>Dodaj prowadzącego</Button>
        </div>
        </>
        }       
    </div>
    </>
    );
    
}

export default ChooseForm;