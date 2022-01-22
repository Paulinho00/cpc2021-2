
import './App.css';
import React, { useState } from 'react';
import {Menu, Modal, Form, InputNumber} from 'antd';
import {CaretDownOutlined} from "@ant-design/icons"
import SubMenu from 'antd/lib/menu/SubMenu';
import MainPage from './MainPage';
import AllPostsView from './AllPostsView'
import PostDetailsView from './PostDetailsView';
import CreatePost from './CreatePost';
import EditPost from './EditPost';


function App() {

  //State przechowujący, który widok jest wyświetlany
  const [view, setView] = useState(0);

  //State przechowujący id aktualnie wybranego postu
  const[selectedPost, setSelectedPost] = useState([]);

  //State zmieniający widoczność modala
  const[isSearchModalVisible, setIsSearchModalVisible] = useState(false);

  //State przechowujący aktualną wartość z InputNumber w Modalu
  const[inputNumberValue, setInputNumberValue] = useState(1);


  const handleInputNumber = function(value){
    setInputNumberValue(value);
  }

  const handleOkClickInModal = function(){
    setSelectedPost({id:inputNumberValue});
    setView(2);
    setIsSearchModalVisible(false);
  }

  return (
    <div className="App">
      <div>
        <Menu mode="horizontal" theme="dark">
          <Menu.Item key="main-page" onClick={()=>setView(0)}>
            Strona główna
          </Menu.Item>
          <Menu.Item key="SubMenu-Item">
            <SubMenu key="SubMenu" icon={<CaretDownOutlined />} title="Opcje">
              <Menu.Item key="addPost" onClick={() => setView(3)}>Dodaj post</Menu.Item>
              <Menu.Item key="findPostById" onClick={() => setIsSearchModalVisible(true)}>Szukaj</Menu.Item>
              <Menu.Item key="allPosts" onClick={() =>setView(1)} >Wyświetl posty</Menu.Item>
            </SubMenu>
          </Menu.Item>
        </Menu>
      </div>
      <Modal visible={isSearchModalVisible} onCancel={() =>setIsSearchModalVisible(false)} onOk={handleOkClickInModal}>
        Wybierz id postu, który chcesz wyświetlić
        <Form>
          <Form.Item>
            <InputNumber max={100} min={1} defaultValue={1} onChange={handleInputNumber}/>
          </Form.Item>
        </Form>
      </Modal>
      {
        {
          0: <MainPage/>,
          1: <AllPostsView setView={setView} setSelectedPost={setSelectedPost}/>,
          2: <PostDetailsView id ={selectedPost.id}/>,
          3: <CreatePost setView={setView}/>,
          4: <EditPost initialValues={selectedPost}/>,
        }[view]
      }

      <div>

      </div>
    </div>
  );
}

export default App;
