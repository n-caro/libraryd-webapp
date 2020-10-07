namespace PSoft.Libraryd.Domain.Commands
{
    public interface ILibroRepository
    {
        bool LibroDiscountStock(string ISBN);
    }
}
