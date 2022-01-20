
import './App.css';
import React from 'react';
import {Menu} from 'antd';
import {CaretDownOutlined} from "@ant-design/icons"
import SubMenu from 'antd/lib/menu/SubMenu';


function App() {
  return (
    <div className="App">
        <Menu  mode="horizontal" theme="dark">
          <Menu.Item key="main page">
            Strona główna
          </Menu.Item>
          <Menu.Item key="SubMenu-Item">
            <SubMenu key="SubMenu" icon={<CaretDownOutlined />} title="Opcje">
              <Menu.Item key="addPost">Dodaj post</Menu.Item>
              <Menu.Item key="findPostById">Szukaj</Menu.Item>
            </SubMenu>
          </Menu.Item>
        </Menu>
    </div>
  );
}

export default App;
