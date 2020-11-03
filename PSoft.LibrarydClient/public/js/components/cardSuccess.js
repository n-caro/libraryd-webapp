export const cardSuccess = (title, message, extraHTMLbody = '') => {
  return `
  <div class="card text-center py-3 align-content-center" id="cardSuccess">
      <i class="fas fa-check-circle icon text-success"></i>
      <div class="card-body">
        <h6 class="title font-weight-normal">${title}</h6>
        <p class="message lead text-muted py-2">${message}</p>
        <div class="extraBody">
          ${extraHTMLbody}
        </div>
      </div>
  </div>
  `
}