
namespace NET6ConsoleAPPWithDI
{
    public interface IMyService
    {
        void Welcome();

        Task<int> GetSomethingFromDb();
    }
}
