const _apiUrl = "/api/trailer";

export const getAllTrailers = () => {
    return fetch(_apiUrl).then((res) => res.json());
}

export const getTrailersById = (id) => {
    return fetch(`${_apiUrl}/${id}`).then((res) => res.json());
}

export const getAllTrailersWithUserDetails = () => {
    return fetch(_apiUrl + "/withusers").then((res) => res.json())
}

export const getAllTrailersWithUserDetailsById = (id) => {
    return fetch(`${_apiUrl}/withusers/${id}`).then((res) => res.json())
}

export const createTrailer = (trailerCreate) => {
    return fetch(`${_apiUrl}/create`, {
        method: "POST",
        headers: {
            'Content-Type' : 'application/json'
        },
        body: JSON.stringify(trailerCreate)
    });
}

export const updateTrailer = (id, trailer) => {
    return fetch(`${_apiUrl}/${id}/edit`, {
        method: 'PUT',
        headers: {
            'Content-Type' : 'application/json'
        },
        body: JSON.stringify(trailer)
    });
}

export const deleteTrailer = (id) => {
    return fetch(`${_apiUrl}/${id}`, {
        method: 'DELETE',
        headers: {
            'Content-Type' : 'application/json'
        },
        body: JSON.stringify(id)
    });
}
