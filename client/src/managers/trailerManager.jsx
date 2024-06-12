const _apiUrl = "/api/trailer";

export const getAllTrailers = () => {
    return fetch(_apiUrl).then((res) => res.json());
}