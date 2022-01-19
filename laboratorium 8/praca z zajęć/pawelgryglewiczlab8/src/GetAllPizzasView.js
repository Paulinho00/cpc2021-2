import React, {useEffect, useState} from 'react';
import {Table, Button, Modal, Form, message} from 'antd';
import {fetchAllPizzas, updatePizza, deletePizza} from "./api";
import PizzaForm from "./PizzaForm";

const columns = (onUpdateClick, onDeleteClick) => [{
	title: "Nazwa pizzy",
	dataIndex: "name",
	render: (pizzaName) => <strong>{pizzaName}</strong> 
},{
	title: "Opis",
	dataIndex: "description"
},{
	title: "Cena",
	dataIndex: 'cost',
	align: 'right',
	render: (cost) => cost.toFixed(2) + " zł"
},{
	title: "Akcje",
	align: "center",
	render: (record) => 
	<>
		<Button size="small" type="link" onClick={onUpdateClick(record)}>Edytuj</Button>
		<Button size="small" type="link" danger onClick={onDeleteClick(record)}>Usuń</Button>
	</>
}];

const GetAllPizzaView = () => {

	const [pizzas, setPizzas] = useState([]); 
	const [isUpdateModalVisible, setIsUpdateModalVisible] = useState(false);
	const [selectedPizza, setSelectedPizza] = useState(null);
	const [form] = Form.useForm();


	useEffect(() =>{
		fetchAllPizzas()
		.then((res) =>res.json())
		.then((data) => setPizzas(data));
	}, []);
	

	const openUpdateModal = () => setIsUpdateModalVisible(true);
	const closeUpdateModal = () => setIsUpdateModalVisible(false);

	const handleUpdateClick = (pizza) => () =>{
		openUpdateModal();
		setSelectedPizza(pizza);
	}


	const handleUpdateFinish = () =>{
		form.validateFields().then((values) => {
			updatePizza(values.id, values).then(() => {
			message.success("Pomyślnie zaaktualizowano pizze " + values.name);
			closeUpdateModal();
			fetchAllPizzas()
			.then((res) =>res.json())
			.then((data) => setPizzas(data));
			})
		})
	}

	const handleDeleteClick = (pizza) => () => {
		Modal.confirm({
			title: "Czy chcesz usunąć pizze " +  pizza.name + " ?",
			onOk: () => {
				deletePizza(pizza.id).then(() =>{
					message.success('Pomyślnie usunięto pizze ' + pizza.name);
					closeUpdateModal()
					fetchAllPizzas()
					.then((res) => res.json())
					.then((data) => setPizzas(data));
				})
			}
		})
	}

	return(<div>
		<h1 className='text-center m-5 font-display'>Pizze w naszym menu!</h1>
		<Table rowKey="id" dataSource={pizzas} columns={columns(handleUpdateClick, handleDeleteClick)}/>
		<Modal visible={isUpdateModalVisible} onOk={handleUpdateFinish} onCancel={closeUpdateModal}>
				<PizzaForm form={form} initialValues={selectedPizza} />
		</Modal>
		</div>);

}
export default GetAllPizzaView;
