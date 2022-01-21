import React, { useEffect } from 'react';
import {Button, Table} from 'antd'
import { fetchAllPosts } from './api';
import { useState } from 'react/cjs/react.development';

const columns = (openDetailedView, openEditForm) => [
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

    useEffect(() =>{
        fetchAllPosts()
        .then((res) => res.json())
        .then((data) => setPosts(data));
    }, []);


    return(
        <Table rowKey="id" dataSource={posts} columns={columns(openDetailedView, openEditForm)}/>
    )
}

export default AllPostsView;