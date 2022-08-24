
namespace NET6ConsoleAPPWithDI
{
    public interface IMyRepository
    {
        Task<int> GetSomethingFromDb();
    }
}
