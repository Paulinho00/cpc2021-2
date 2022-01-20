import { PageHeader, Space, Typography } from 'antd';
import React from 'react';

//Widok strony powitalnej/głównej
function MainPage(){
    const {Title, Link} = Typography
    return(
        <Space direction="vertical" style={{justifyContent: 'center'}} >
        <Title level={1} strong>Witaj na Postbooku!</Title>
        <Title level={4}>Portalu z postami użytkowników.</Title>
        <Title level={4}>Aby wyświetlić posty, dodać post lub znaleźć konkretny post,</Title>
        <Title level={4}>przejdź do zakładki Opcje na pasku nawigacyjny</Title>
        <Title level={5} italic>Portal zasilany API: <Link href="https://jsonplaceholder.typicode.com/">jsonplaceholder.typicode.com</Link></Title>
        </Space>
    )
}

export default MainPage;