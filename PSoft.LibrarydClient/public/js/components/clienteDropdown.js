export const clienteDropdown = (nombre) => (`
    <div class="btn-group align-middle">
      <button type="button align-middle" class="btn btn-white dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
        <i class="far fa-user"></i>
        <span>${nombre}</span>
      </button>
      <div class="dropdown-menu dropdown-menu-lg-right">
        <h6 class="dropdown-header">Opciones de usuario</h6>
        <a class="dropdown-item" href="/cliente">Dashboard</a>
        <a class="dropdown-item text-danger" href="/logout"><i class="fas fa-sign-out-alt text-danger"></i> Cerrar sesion</a>
      </div>
    </div>`);
