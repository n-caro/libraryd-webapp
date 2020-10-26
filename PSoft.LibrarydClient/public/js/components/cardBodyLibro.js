const libroImageDefault = 'https://placekitten.com/300/500';
export const cardBodyLibro = (libro) => `
  <div class="row">
    <div class="col-md-auto align-self-center">
      <img class="alquiler-libro-img d-block m-auto" src="${libro.imagen || libroImageDefault }">
    </div>
    <div class="col align-self-center">
    <h5 class="card-title d-block font-weight-bold">${libro.titulo}</h5>
    <h6 class="card-subtitle text-muted font-weight-light">${libro.autor}</h6>
    <span class="small text-muted d-block my-1">Edición</span>
    <span>${libro.edicion}</span>
    <span class="small text-muted d-block my-1">ISBN</span>
    <span class="text-monospace">${libro.isbn}</span>
    </div>
  </div>
`