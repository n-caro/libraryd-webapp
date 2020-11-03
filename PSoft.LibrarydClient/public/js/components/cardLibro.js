const libroImageDefault = '/img/libros/libro-no-cover.jpg';
export const cardLibro = (libro) => `
<div class="col p-4">
  <div class="card border-0 shadow-sm">
    <div class="card-header p-0 bg-transparent border-0">
      <img class="card-img-top d-block mx-auto coverlibro" src="${libro.imagen || libroImageDefault}" alt="Portada de ${libro.titulo}">
    </div>
    <div class="card-body py-2 font-weight-light text-center">
      <h6 class="card-title d-block font-weight-bold mb-0">${libro.titulo}</h6>
      <span class="card-subtitle mb-2 text-muted font-weight-light">${libro.autor}</span>
    </div>
    <ul class="list-group list-group-flush">
      <li class="list-group-item text-center">
      ${libro.stock ? '<span class="badge badge-success mb-2">disponible</span>' : '<span class="badge badge-warning mb-2">sin stock</span>'}
      <div class="btn-group btn-group-sm d-flex" role="group">
        <a href="/alquilar?isbn=${libro.isbn}" class="btn btn-outline-secondary ${libro.stock ? '': 'disabled'}">Alquilar</a>
        <a href="/reservar?isbn=${libro.isbn}" class="btn btn-outline-secondary ${libro.stock ? '': 'disabled'}">Reservar</a>
      </div>
      </li>
      <li class="list-group-item">
        <small class="d-block text-muted">Edicion</small> ${libro.edicion}</li>
      <li class="list-group-item"><small class="d-block text-muted">Editorial</small> ${libro.editorial}</li>
      <li class="list-group-item"><small class="d-block text-muted">ISBN</small> <span class="text-monospace">${libro.isbn}</span></li>
    </ul>
  </div>
</div>`;
