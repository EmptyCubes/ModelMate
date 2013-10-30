namespace UnitTest.Data
{
    public interface IDataProvider
    {
        object GetSource();
        object GetExpected();
    }
}