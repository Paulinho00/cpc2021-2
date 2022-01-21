
import './App.css';
import React, { useState } from 'react';
import {Menu} from 'antd';
import {CaretDownOutlined} from "@ant-design/icons"
import SubMenu from 'antd/lib/menu/SubMenu';
import MainPage from './MainPage';
import AllPostsView from './AllPostsView'
import PostDetailsView from './PostDetailsView';


function App() {

  //State przechowujący, który widok jest wyświetlany
  const [view, setView] = useState(0);

  //State przechowujący id aktualnie wybranego postu
  const[selectedPostId, setSelectedPostId] = useState();

  return (
    <div className="App">
      <div>
        <Menu mode="horizontal" theme="dark">
          <Menu.Item key="main-page" onClick={()=>setView(0)}>
            Strona główna
          </Menu.Item>
          <Menu.Item key="SubMenu-Item">
            <SubMenu key="SubMenu" icon={<CaretDownOutlined />} title="Opcje">
              <Menu.Item key="addPost">Dodaj post</Menu.Item>
              <Menu.Item key="findPostById">Szukaj</Menu.Item>
              <Menu.Item key="allPosts" onClick={() =>setView(1)} >Wyświetl posty</Menu.Item>
            </SubMenu>
          </Menu.Item>
        </Menu>
      </div>
      {
        {
          0: <MainPage/>,
          1: <AllPostsView setView={setView} setSelectedPost={setSelectedPostId}/>,
          2: <PostDetailsView id ={selectedPostId}/>,
        }[view]
      }

      <div>

      </div>
    </div>
  );
}

export default App;
