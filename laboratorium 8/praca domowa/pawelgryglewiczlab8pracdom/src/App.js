
import './App.css';
import React, { useState } from 'react';
import {Menu} from 'antd';
import {CaretDownOutlined} from "@ant-design/icons"
import SubMenu from 'antd/lib/menu/SubMenu';
import MainPage from './MainPage';


function App() {

  //State przechowujący, który widok jest wyświetlany
  const [view, setView] = useState(0);

  //Ustawienie odpowiedniego widoku w zależności od wyboru z menu
  const handleMenuClick = function(e){
    switch(e){
      case "main-page": setView(0); break;
      case "addPost": break;
      case "findPostById": break;
      case "allPosts": break;
    }
  }

  return (
    <div className="App">
      <div>
        <Menu onClick={handleMenuClick}  mode="horizontal" theme="dark">
          <Menu.Item key="main-page">
            Strona główna
          </Menu.Item>
          <Menu.Item key="SubMenu-Item">
            <SubMenu key="SubMenu" icon={<CaretDownOutlined />} title="Opcje">
              <Menu.Item key="addPost">Dodaj post</Menu.Item>
              <Menu.Item key="findPostById">Szukaj</Menu.Item>
              <Menu.Item key="allPosts">Wyświetl posty</Menu.Item>
            </SubMenu>
          </Menu.Item>
        </Menu>
      </div>
      {
        {
          0: <MainPage/>
        }[view]
      }

      <div>

      </div>
    </div>
  );
}

export default App;
