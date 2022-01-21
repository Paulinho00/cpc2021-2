import React from 'react';
import {Form, Typography, Button, Space} from 'antd';
import CreateEditPostForm from './CreateEditPostForm';

function EditPost({initialValues}){

    const [form] = Form.useForm();

    const {Paragraph} = Typography;

    return (
        <>
        <Paragraph strong level={6} style={{margin: '20px 4px'}}>Tworzenie posta</Paragraph>
        <Space direction="vertical" style={{margin: '45px 4px'}}>
            <CreateEditPostForm form={form} initialValues={initialValues}/>
            <Button size="large" type="primary">Edytuj post</Button>
        </Space>
        </>
    );
}

export default EditPost;