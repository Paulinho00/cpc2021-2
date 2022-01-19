import React, {useEffect} from 'react';
import {Form, Input, InputNumber} from 'antd'

const PizzaForm = function({initialValues, form}){

    useEffect( () => {
        form.setFieldsValue(initialValues);
    }, [form, initialValues]);

    return (
    <Form form={form} initialValue={initialValues} layout='horizontal'>
        <Form.Item name='id' hidden>
            <Input/>
        </Form.Item>
        <Form.Item label="Nazwa pizzy" name="name">
            <Input/>
        </Form.Item>
        <Form.Item label="Opis" name='description'>
            <Input/>
        </Form.Item>
        <Form.Item label="Cena" name='cost'>
            <InputNumber min={1}/>
        </Form.Item>
    </Form>
    );
}

export default PizzaForm;