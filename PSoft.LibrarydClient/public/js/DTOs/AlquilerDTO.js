export class AlquilerDTO {
  constructor(clienteId, isbn, fechaAlquiler) {
    this.cliente = clienteId;
    this.isbn = isbn;
    this.fechaAlquiler = fechaAlquiler;
  }
}

export class ReservaDTO {
  constructor(clienteId, isbn, fechaReserva) {
    this.cliente = clienteId;
    this.isbn = isbn;
    this.fechaReserva = fechaReserva;
  }
}
