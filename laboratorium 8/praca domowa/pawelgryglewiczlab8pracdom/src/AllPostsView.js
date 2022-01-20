import React, { useEffect } from 'react';
import {Table} from 'antd'
import { fetchAllPosts } from './api';
import { useState } from 'react/cjs/react.development';

const columns = [
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
    }
]

//Wyświetlenie wszystkich postów
function AllPostsView(){

    const [posts, setPosts] = useState([]);

    useEffect(() =>{
        fetchAllPosts()
        .then((res) => res.json())
        .then((data) => setPosts(data));
    });


    return(
        <Table rowKey="id" dataSource={posts} columns={columns}/>
    )
}

export default AllPostsView;