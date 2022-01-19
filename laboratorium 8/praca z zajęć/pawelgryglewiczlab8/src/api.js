import Modal from "antd/lib/modal/Modal";

const BASE_URL = 'https://localhost:44335';

export function fetchAllPizzas() {
    return fetch(BASE_URL+'/api/Pizza',{method:'get'});
}

export function addPizza(body) {
    return fetch(BASE_URL+'/api/Pizza',{method:'post', body:JSON.stringify(body), headers:{
        'Content-type': 'application/json'
    }});
}


export function updatePizza(id, body) {
    return fetch(BASE_URL+'/api/Pizza/' + id,{method:'put', body:JSON.stringify(body), headers:{
        'Content-type': 'application/json'
    }});
}

    export function  deletePizza(id) {
        return fetch(BASE_URL+'/api/Pizza/' + id,{method:'delete'})}

