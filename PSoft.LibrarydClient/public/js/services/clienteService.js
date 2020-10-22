import { API_URL_CLIENTE } from "../config/constants.js";

const getClienteByDNI = (dni) => {
  return fetch(`${API_URL_CLIENTE}?dni=${dni}`)
    .then((response) => response.json())
    .catch((err) => console.log("ERROR: " + err));
};

export { getClienteByDNI };