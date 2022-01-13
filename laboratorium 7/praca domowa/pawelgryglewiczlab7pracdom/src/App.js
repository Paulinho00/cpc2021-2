
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Nav, NavLink, NavItem } from 'reactstrap';
import { useState } from 'react';
import MainPage from './MainPage';
import ChooseForm from './ChooseForm';



function App() {

  //Stan przechowujący informację którą stronę wygenerować
  const [page, setPage] = useState(0);

  //Zmienna przechowująca wszystkich studentów
  const [students, setStudents] = useState([]);

  //Zmienna przechowująca wszystkich nauczycieli akademickich
  const [teachers, setTeachers] = useState([]);

  //Funkcja zmieniają wyświetlanie zakładki
  const changePage = function(page){
    setPage(page);
  }

  return (
    <div className='App'>
      <Nav style={{backgroundColor: '#494949'}} tabs>
        <NavItem>
          <NavLink style={{color: 'white'}} onClick={() =>changePage(0)}>Strona główna</NavLink>
        </NavItem>
        <NavItem>
          <NavLink style={{color: 'white'}} onClick={() =>changePage(1)}>Dodaj osobę</NavLink>
        </NavItem>
        <NavItem>
          <NavLink style={{color: 'white'}} onClick={() =>changePage(2)}>Lista osób</NavLink>
        </NavItem>
      </Nav>
      <div>
        {page == 0 &&
       <MainPage/>
        }
        {page == 1 &&
        <ChooseForm students={students} setStudents={setStudents} teachers={teachers} setTeachers={setTeachers}/>
        }

      </div>
    </div>
    
  );
}

export default App;
