import React from 'react';
import {Form, Button, message} from "antd";
import {addPizza} from './api';
import PizzaForm from './PizzaForm';

const CreatePizzaView = () => {

	const [form] = Form.useForm();
	const handleCreatePizzaFormFinish = (values) =>{

		form.validateFields().then((values)=>{
			addPizza(values).then(() => {
				message.success(
					"Pomyślnie dodano pizze " + values.name
				)
			})
		})
	} 
	return (<>
		<h1>CreatePizzaView</h1>
		<div style={{margin:"auto", maxWidth:"400px"}}>
				<PizzaForm form={form}/>
		</div>
		<div className='text-center'>
			<Button size="large" type="primary" onClick={handleCreatePizzaFormFinish}>
				Utwórz pizze!
			</Button>
		</div>
	</>);
};

export default CreatePizzaView;
