import { API_URL_CLIENTE } from "../config/constants.js";

const getClienteByDNI = (dni) => {
  return fetch(`${API_URL_CLIENTE}?dni=${dni}`)
    .then((response) => response.json())
    .catch((err) => console.log("ERROR: " + err));
};

const postCliente = (cliente) => {
  return fetch(API_URL_CLIENTE, {
    method: "POST",
    body: JSON.stringify(cliente),
    headers: {
      "Content-Type": "application/json",
    },
  })
    .then((response) => response.json())
    .catch((err) => console.log("ERROR: " + err));
};

export { getClienteByDNI, postCliente };
