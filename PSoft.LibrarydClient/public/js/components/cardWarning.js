export const cardWarning = (title, message, extraHTMLbody = '') => {
  return `
  <div class="card text-center py-3 align-content-center" id="cardBig">
      <i class="fas fa-exclamation-circle icon text-warning"></i>
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