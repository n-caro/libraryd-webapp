import { API_URL_LIBROSTOCK } from "../config/constants.js";

const getStock = () => {
  return fetch(API_URL_LIBROSTOCK)
    .then((response) => response.json())
    .catch((err) => console.log("ERROR: " + err));
};

export { getStock };
