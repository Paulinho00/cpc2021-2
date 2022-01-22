import { Card, Typography, Comment, Space, List, Button } from 'antd';
import React, { useEffect } from 'react';
import { useState } from 'react/cjs/react.development';
import {fetchPost, fetchPostComments } from './api';

//Widok wyświetlący szczegóły postu z danym id
function PostDetailsView({id, setView}){

    //State z pobranym postem
    const [post, setPost] =useState([]);
    //State z komentarzami do pobranego posta
    const [comments, setComments] = useState([]);

    useEffect(() =>{
        fetchPost(id)
        .then((res) => res.json())
        .then((data) => setPost(data));

        fetchPostComments(id)
        .then((res) => res.json())
        .then((data) => setComments(data));
    }, [id]);

    const {Text, Paragraph} = Typography;

    
        return (
            <Space direction="vertical" style={{justifyContent: 'center'}} >
        <Card title={post.title} style={{ width:600 }}>
            <Text level={4}>
               <Paragraph><Text strong>Id postu: </Text> {post.id}</Paragraph> 
               <Paragraph><Text strong>Id autora: </Text> {post.userId}</Paragraph>
            </Text>
            <Text level={3} strong>Treść: </Text>
            <Text level={2}>{post.body}</Text>
            <Space direction="vertical" style={{margin: '45px 4px'}}>
                <Text level={2} strong>Komentarze:</Text>
                <List
                className="comment-list"
                itemLayout="horizontal"
                dataSource={comments}
                renderItem={item =>(
                    <li>
                        <Comment
                            author={<><Text strong level={2}>{item.name}</Text><Text italic level={1}> {item.email}</Text> </>}
                            content={<Text level={1}>{item.body}</Text>}
                            />
                    </li>
                )}
                />
            </Space>
            <Button size="large" type="primary" onClick={() => setView(1)}>Cofnij</Button>
        </Card>
        </Space>);
}

export default PostDetailsView;