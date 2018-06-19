namespace SpyrosORM.DataAccess
{
    public interface IDataAccess<T> where T : class ,new()
    {
        int Insert(T dataObject);
    }
}