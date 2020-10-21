export const alertBoostrap = (message = "", type = "primary") => `
<div class="alert alert-${type}" role="alert">
  ${message}
</div>`;
