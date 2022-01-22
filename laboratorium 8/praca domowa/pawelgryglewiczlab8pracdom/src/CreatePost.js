import React from 'react';
import {Form, Typography, Button, Space, message} from 'antd';
import CreateEditPostForm from './CreateEditPostForm';
import { addPost } from './api';

function CreatePost({setView}){

    const [form] = Form.useForm();

    const {Paragraph} = Typography;

    const handleCreatePostFinish = function(values){
        form.validateFields().then((values) =>{
            addPost(values).then(() => {
                setView(1);
                message.success(
                    "Dodano nowy post"
                )
            })
        })
    };

    return (
        <>
        <Paragraph strong level={6} style={{margin: '20px 4px'}}>Edytowanie posta</Paragraph>
        <Space direction="vertical" style={{margin: '45px 4px'}}>
            <CreateEditPostForm form={form}/>
            <Button size="large" type="primary" onClick={handleCreatePostFinish}>Utwórz post</Button>
        </Space>
        </>
    );
}

export default CreatePost;