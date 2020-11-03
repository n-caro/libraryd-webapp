export const clienteDropdown = (nombre) => (`
    <div class="btn-group align-middle">
      <button type="button align-middle" class="btn btn-white dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
        <i class="far fa-user"></i>
        <span class="d-none d-md-inline-block">${nombre}</span>
      </button>
      <div class="dropdown-menu dropdown-menu-right">
        <a class="dropdown-item" href="/cliente"><i class="fas fa-th-large"></i> Mi cuenta</a>
        <div class="dropdown-divider"></div>
        <a class="dropdown-item" href="/alquilar"><i class="fas fa-plus"></i> Alquilar libro</a>
        <a class="dropdown-item" href="/reservar"><i class="fas fa-calendar-plus"></i> Reservar libro</a>
        <div class="dropdown-divider"></div>
        <a class="dropdown-item" href="/cliente/historial"><i class="fas fa-history"></i> Alquileres y Reservas</a>
        <div class="dropdown-divider"></div>
        <a class="dropdown-item text-danger" href="/logout"><i class="fas fa-sign-out-alt text-danger"></i> Cerrar sesion</a>
      </div>
    </div>`);
