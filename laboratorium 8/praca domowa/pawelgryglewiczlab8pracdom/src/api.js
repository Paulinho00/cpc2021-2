

const BASE_URL = "https://jsonplaceholder.typicode.com";

//Pobranie wszystkich postów
export function fetchAllPosts(){
    return fetch(BASE_URL+"/posts", {method:'get'});
}