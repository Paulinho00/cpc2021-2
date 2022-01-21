import React, { useEffect } from 'react';
import {Button, Table} from 'antd'
import { fetchAllPosts } from './api';
import { useState } from 'react/cjs/react.development';

const columns = (openDetailedView) => [
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
         <Button size="small" type="link" onClick={() => openDetailedView(record.id)}>Szczegóły</Button>
        </>    
        
    }
]

//Widok wyświetlający wszystkie posty
function AllPostsView({setView, setSelectedPost: setSelectedPostId}){

    const [posts, setPosts] = useState([]);

    const openDetailedView = function(id){
        setSelectedPostId(id);
        setView(2);
    }

    useEffect(() =>{
        fetchAllPosts()
        .then((res) => res.json())
        .then((data) => setPosts(data));
    }, []);


    return(
        <Table rowKey="id" dataSource={posts} columns={columns(openDetailedView)}/>
    )
}

export default AllPostsView;