import { alertBoostrap } from "../components/alertBoostrap.js";

export const showAlert = (message, type) => {
  document.getElementById("showAlert").innerHTML = alertBoostrap(message, type);
};
