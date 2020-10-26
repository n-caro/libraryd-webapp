import { cardBodyLibro } from './cardBodyLibro.js'
export const cardAlquiler = (alquiler) => {
  let { id, cliente, estadoId, libro, fechaAlquiler, fechaReserva, fechaDevolucion } = alquiler;
  let fecha = '-', estadoString = '-';
  switch(estadoId){
    case 1:
      estadoString = 'Reserva'
      fecha = `${new Date(fechaReserva).toLocaleDateString()}`;
      break;
    case 2:
      estadoString = 'Alquiler'
      fecha = new Date(fechaAlquiler).toLocaleDateString();
      break;
  }
  return `
  <div class="card">
  <div class="card-header d-flex">
    <span  class="align-middle">
      Orden #<b>${id}</b>
      <span class="badge badge-secondary">${estadoString}</span>
    </span>
      <span class="d-block ml-auto">
        <svg class="align-middle" class="bi" width="1em" height="1em" fill="currentColor">
          <use xlink:href="/img/icons/bootstrap-icons.svg#file-person"/>
          </svg>
        <span class="align-middle">DNI: ${cliente.dni}</span>
      </span>
    </div>
    <div class="card-body pt-0 pb-2">
    <ul class="list-group list-group-horizontal border-0">
      <li class="list-group-item flex-fill border-0">
      <span class="small text-muted d-block">${estadoString}</span>
      <svg class="align-middle" class="bi" width="1em" height="1em" fill="currentColor">
      <use xlink:href="/img/icons/bootstrap-icons.svg#calendar"/>
      </svg>
      <span class="align-middle">${fecha}</span>
    </li>
    ${estadoId == 2
      ? `<li class="list-group-item flex-fill border-0">
          <span class="small text-muted d-block">Devolución</span>
          <svg class="align-middle" class="bi" width="1em" height="1em" fill="currentColor">
          <use xlink:href="/img/icons/bootstrap-icons.svg#calendar-week"/>
          </svg> <span class="align-middle">${new Date(fechaDevolucion).toLocaleDateString()}</span>
        </li>`
      : ''}
  </ul>
    ${cardBodyLibro(libro)}
    </div>
  </div>
  `;
}