const _apiUrl = "/api/item";

export const getAllItems = () => {
    return fetch(_apiUrl).then((res) => res.json());
}

export const getItemsById = (id) => {
    return fetch(`${_apiUrl}/${id}`).then((res) => res.json());
}

export const getAllItemsWithUserDetails = () => {
    return fetch(_apiUrl + "/withusers").then((res) => res.json())
}

export const getAllItemsWithUserDetailsById = (id) => {
    return fetch(`${_apiUrl}/withusers/${id}`).then((res) => res.json())
}

export const createItem = (item) => {
    return fetch(`${_apiUrl}/create`, {
        method: "POST",
        headers: {
            'Content-Type' : 'application/json'
        },
        body: JSON.stringify(item)
    });
}

export const updateItem = (id, item) => {
    return fetch(`${_apiUrl}/${id}/edit`, {
        method: 'PUT',
        headers: {
            'Content-Type' : 'application/json'
        },
        body: JSON.stringify(item)
    });
}

export const deleteItem = (id) => {
    return fetch(`${_apiUrl}/${id}`, {
        method: 'DELETE',
        headers: {
            'Content-Type' : 'application/json'
        },
        body: JSON.stringify(id)
    });
}