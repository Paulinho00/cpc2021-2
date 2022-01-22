import React, { useEffect } from 'react';
import {Button, Table, Modal, message} from 'antd'
import { deletePost, fetchAllPosts } from './api';
import { useState } from 'react/cjs/react.development';

const columns = (openDetailedView, openEditForm, deletePost) => [
    {
        title:"Id postu",
        dataIndex:"id",
        sorter: (a,b) => a.id - b.id,
    },
    {
        title:"Id autora postu",
        dataIndex:"userId",
        sorter: (a,b) => a.userId - b.userId,
    },
    {
        title:"Tytuł posta",
        dataIndex:"title",
        sorter: (a,b) =>  a.title.localeCompare(b.title),
    },{
        title:"Akcje",
        render: (record) =>
        <>
         <Button size="small" type="link" onClick={() => openDetailedView(record)}>Szczegóły</Button>
         <Button size="small" type="link" onClick={() => openEditForm(record)}>Edytuj</Button>
         <Button size="small" type="link" danger onClick={() => deletePost(record)}>Usuń</Button>
        </>    
        
    }
]

//Widok wyświetlający wszystkie posty
function AllPostsView({setView, setSelectedPost}){

    const [posts, setPosts] = useState([]);

    const openDetailedView = function(post){
        setSelectedPost(post);
        setView(2);
    };

    const openEditForm = function(post){
        setSelectedPost(post);
        setView(4);
    }

    const handleDeletePost = function(post){
        Modal.confirm({
            title:"Czy chcesz usunąć post nr " +post.id +"?",
            onOk: () => {deletePost(post.id).then(() =>{
                    fetchAllPosts()
                    .then((res) => res.json())
                    .then((data) => setPosts(data));
                    message.success("Usunięto post");
                    })}

        })
    }

    useEffect(() =>{
        fetchAllPosts()
        .then((res) => res.json())
        .then((data) => setPosts(data));
    }, []);


    return(
        <Table rowKey="id" dataSource={posts} columns={columns(openDetailedView, openEditForm, handleDeletePost)}/>
    )
}

export default AllPostsView;