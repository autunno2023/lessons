namespace PowerfulConsole
{
    public interface IReportGeneratorFactory
    {
        IReportGenerator CreateGenerator(string type);
    }

}
