import { alertBoostrap } from "../components/alertBoostrap.js";

export const showAlert = (message, type) => {
  let showAlertDOM = document.getElementById("showAlert");
  if (showAlertDOM) showAlertDOM.innerHTML = alertBoostrap(message, type);
};

export const showAlertRemove = () => {
  let showAlertDOM = document.getElementById("showAlert");
  if (showAlertDOM) showAlertDOM.innerHTML = '';
}