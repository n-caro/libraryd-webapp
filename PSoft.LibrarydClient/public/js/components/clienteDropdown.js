export const clienteDropdown = (nombre) => (`
    <div class="btn-group align-middle">
      <button type="button" class="btn btn-white dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
        <svg class="bi" width="1.2em" height="1.2em" fill="currentColor">
        <use xlink:href="/img/icons/bootstrap-icons.svg#person-fill"/>
        </svg> 
        <span class="align-middle">${nombre}</span>
      </button>
      <div class="dropdown-menu dropdown-menu-lg-right">
        <h6 class="dropdown-header">Opciones de usuario</h6>
        <a class="dropdown-item" href="/cliente/dashboard">Dashboard</a>
        <a class="dropdown-item text-danger" href="/logout">Cerrar sesion</a>
      </div>
    </div>`);
