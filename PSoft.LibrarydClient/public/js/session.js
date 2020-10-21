import { clienteDropdown as menuCliente } from "./components/clienteDropdown.js";
import { alertBoostrap } from "./components/alertBoostrap.js";
import { APIBASEURL } from "./config/constants.js";

const clienteSesion = JSON.parse(localStorage.getItem("cliente"));

const setNavbar = () => {
  let userNavbar = document.getElementById("userNavbar");
  clienteSesion
    ? (userNavbar.innerHTML = menuCliente(clienteSesion.nombre))
    : (userNavbar.innerHTML += menuInvitado());
};

const menuInvitado = () => {
  return `
    <a href="/login" class="btn btn-outline-primary">
        Iniciar sesion
    </a>
    `;
};

const logInForm = document.getElementById("login-form");
if (logInForm) {
  logInForm.onsubmit = function (e) {
    e.preventDefault();
    let dniValue = logInForm.elements.dni.value;
    dniValue
      ? logIn(dniValue)
      : showLoginError("El campo DNI se encuentra vacío.");
  };
}

const showLoginError = (message) => {
  let showAlertDIV = document.getElementById("showAlert");
  showAlertDIV
    ? (showAlertDIV.innerHTML = alertBoostrap(message, "danger"))
    : console.warn("No existe #showAlertDIV");
};

const logIn = (dni) => {
  fetch(`${APIBASEURL}/Clientes?dni=${dni}`)
    .then((res) => res.json())
    .catch((error) => {
      showLoginError("El inicio de sesión no esta disponible.");
      console.warn(error);
    })
    .then((response) => {
      if (response.error) showLoginError("Cliente inexistente.");
      else {
        let cliente = response[0];
        console.log(cliente);
        localStorage.setItem("cliente", JSON.stringify(cliente));
        window.location.assign("/cliente");
      }
    });
};

// logOut
const logOut = () => {
  localStorage.removeItem("cliente");
  window.location.assign("/");
};

let logOutButton = document.getElementById("logOutbtn");
logOutButton ? logOutButton.addEventListener("click", logOut) : "";

export { clienteSesion, setNavbar };
