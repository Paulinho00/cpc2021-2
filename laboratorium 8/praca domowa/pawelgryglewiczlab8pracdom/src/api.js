


const BASE_URL = "https://jsonplaceholder.typicode.com";

//Pobranie wszystkich postów
export function fetchAllPosts(){
    return fetch(BASE_URL+"/posts", {method:'get'});
}

//Pobranie postu z określonym id
export function fetchPost(id){
    return fetch(BASE_URL+"/posts/"+id, {method:'get'})
}

//Pobranie komentarzy do określonego postu
export function fetchPostComments(id){
    return fetch(BASE_URL+"/posts/"+id+"/comments", {method:'get'})
}

//Dodanie nowego postu
export function addPost(post){
    return fetch(BASE_URL+"/posts", {method:"post", body:JSON.stringify(post), headers:{
        "Content-type": "application/json"
    }});
}