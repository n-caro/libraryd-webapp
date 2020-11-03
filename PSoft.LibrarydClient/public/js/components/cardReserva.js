import { cardBodyLibro } from './cardBodyLibro.js'
export const cardReserva = (alquiler) => {
  let { id, libro, fechaReserva } = alquiler;
  return `
  <div class="card my-4 text-left">
  <div class="card-header d-flex">
    <span  class="align-middle">
      Orden #<b>${id}</b>
      <span class="badge badge-secondary">Reserva</span>
    </span>
      
    </div>
    <div class="card-body pt-0 pb-2">
    <ul class="list-group list-group-horizontal border-0 align-middle">
      <li class="list-group-item flex-fill border-0">
      <span class="small text-muted d-block">Fecha de reserva</span>
      <i class="far fa-calendar"></i>
      <span class="align-middle">${new Date(fechaReserva).toLocaleDateString()}</span>
    </li>
  </ul>
    ${cardBodyLibro(libro)}
    </div>
  </div>
  `;
}