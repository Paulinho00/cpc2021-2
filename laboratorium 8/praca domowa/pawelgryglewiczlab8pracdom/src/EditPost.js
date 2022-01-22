import React from 'react';
import { Form, Typography, Button, Space, message } from 'antd';
import CreateEditPostForm from './CreateEditPostForm';
import { updatePost } from './api';

//Widok edycji posta
function EditPost({ initialValues, setView }) {

    const [form] = Form.useForm();

    const { Paragraph } = Typography;

    const handleUpdatePost = function () {
        form.validateFields().then((values) => {
            updatePost(values.id, values).then(() => {
                setView(1);
                message.success(
                    "Pomyślnie zedytowano post"
                )
            })
        })
    }

    return (
        <>
            <Paragraph strong level={6} style={{ margin: '20px 4px' }}>Tworzenie posta</Paragraph>
            <Space direction="vertical" style={{ margin: '45px 4px' }}>
                <CreateEditPostForm form={form} initialValues={initialValues} />
                <Space direction="horizontal">
                    <Button size="large" type="primary" onClick={() => setView(1)}>Cofnij</Button>
                    <Button size="large" type="primary" onClick={handleUpdatePost}>Edytuj post</Button>
                </Space>
            </Space>
        </>
    );
}

export default EditPost;