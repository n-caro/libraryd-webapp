import { clienteDropdown } from "./components/clienteDropdown.js";
import { getClienteByDNI } from "./services/clienteService.js";
import { showAlert } from "./utilsDOM/showAlert.js";
import { cardWarning } from "./components/cardWarning.js";

const clienteSesion = localStorage.getItem("cliente")
  ? JSON.parse(localStorage.getItem("cliente"))
  : null;

const setNavbar = () => {
  let userNavbar = document.getElementById("userNavbar");
  clienteSesion
    ? (userNavbar.innerHTML = menuCliente(clienteSesion.nombre))
    : (userNavbar.innerHTML += menuInvitado());
};

const loginRequired = () => {
  if (!clienteSesion) {
    let clienteRequiredDOM = document.getElementById("clienteRequired");
    clienteRequiredDOM.innerHTML = cardWarning(
      "Acceso no permitido",
      "Debes iniciar sesión para continuar",
      `<a href="/login" class="btn btn-primary btn-lg">Iniciar sesión</a>`
    );
  }
};

const menuInvitado = () => {
  return `
    <a href="/login" class="btn btn-outline-primary">
      <i class="fas fa-sign-in-alt"></i> Ingresar
    </a>
    `;
};

const menuCliente = (clienteNombre) => clienteDropdown(clienteNombre);

const logInForm = document.getElementById("login-form");
if (logInForm) {
  logInForm.onsubmit = function (e) {
    e.preventDefault();
    let dniValue = logInForm.elements.dni.value;
    dniValue
      ? logInCliente(dniValue)
      : showLoginError("El campo DNI se encuentra vacío.");
  };
}

const logInCliente = async (dni) => {
  const response = await getClienteByDNI(dni);
  response
    ? manageResponseCliente(response)
    : showAlert("Inicio de sesión no disponible.", "warning");
};

const manageResponseCliente = (responseCliente) => {
  responseCliente.error
    ? showAlert("DNI inválido.", "danger")
    : saveSessionRedirect(responseCliente[0]);
};

const saveSessionRedirect = (cliente) => {
  localStorage.setItem("cliente", JSON.stringify(cliente));
  window.location.assign("/cliente");
};

// logOut
const logOut = () => {
  localStorage.removeItem("cliente");
  window.location.assign("/");
};

let logOutButton = document.getElementById("logOutbtn");
logOutButton ? logOutButton.addEventListener("click", logOut) : "";

export { clienteSesion, setNavbar, loginRequired };
