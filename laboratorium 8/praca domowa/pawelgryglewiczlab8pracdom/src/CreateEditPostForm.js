import React from 'react';
import { Form, InputNumber, Input } from 'antd';

//Formularz edycji/tworzenia postu
function CreateEditPostForm({ initialValues, form }) {

    return (
        <Form form={form} layout='horizontal' initialValues={initialValues}>
            <Form.Item name='id' hidden >
                <Input />
            </Form.Item>
            <Form.Item label="Id autora postu: " name="userId"
                rules={[
                    {
                        required: true,
                        message: "Wprowadź id autora postu"
                    }
                ]}
            >
                <InputNumber size="300" min={1} max={10} />
            </Form.Item>
            <Form.Item label="Tytuł: " name="title"
                rules={[
                    {
                        required: true,
                        message: "Wprowadź tytuł postu"
                    }
                ]}
            >
                <Input />
            </Form.Item>
            <Form.Item label="Treść: " name="body"
                rules={[
                    {
                        required: true,
                        message: "Wprowadź treść postu"
                    }
                ]}
            >
                <Input />
            </Form.Item>
        </Form>
    );
}

export default CreateEditPostForm;