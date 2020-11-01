import { cardBodyLibro } from './cardBodyLibro.js'
export const cardAlquiler = (alquiler) => {
  let { id, libro, fechaAlquiler, fechaDevolucion } = alquiler;
  return `
  <div class="card my-4">
  <div class="card-header d-flex">
    <span  class="align-middle">
      Orden #<b>${id}</b>
      <span class="badge badge-secondary">Alquiler</span>
    </span>
      
    </div>
    <div class="card-body pt-0 pb-2">
    <ul class="list-group list-group-horizontal border-0 align-middle">
      <li class="list-group-item flex-fill border-0">
      <span class="small text-muted d-block">Fecha Alquiler</span>
      <i class="far fa-calendar"></i>
      <span class="align-middle">${new Date(fechaAlquiler).toLocaleDateString()}</span>
    </li>
    <li class="list-group-item flex-fill border-0 align-middle">
          <span class="small text-muted d-block">Fecha Devolución</span>
          <i class="far fa-calendar-alt"></i>
          <span>${new Date(fechaDevolucion).toLocaleDateString()}</span>
    </li>
  </ul>
    ${cardBodyLibro(libro)}
    </div>
  </div>
  `;
}