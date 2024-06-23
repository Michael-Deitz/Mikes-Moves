const _apiUrl = "/api/reserve";

export const ReserveTrailer = (reservation) => {
    return fetch(_apiUrl, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(reservation)
    })
}

export const getReservedTrailer = (trailerId) => {
    return fetch(`${_apiUrl}/trailer/${trailerId}`).then((res) => res.json())
}

export const deleteReservation = (id) => {
    return fetch(`${_apiUrl}/reservations/${id}`, {
        method: "DELETE"
    })
}