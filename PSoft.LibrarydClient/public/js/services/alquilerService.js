import { APIRUL_ALQUILER, APIRUL_ALQUILERCLIENTEID } from "../config/constants.js";

export const postAlquiler = (data) => {
  return fetch(APIRUL_ALQUILER, {
    method: 'POST',
    body: JSON.stringify(data),
    headers:{
      'Content-Type': 'application/json'
      }
    })
    .then((response) => response.json())
    .catch((err) => console.log("ERROR: " + err));
}

export const getAlquileresCliente = (id) => {
  return fetch(`${APIRUL_ALQUILERCLIENTEID}/${id}`)
    .then((response) => response.json())
    .catch((err) => console.log("ERROR: " + err));
}