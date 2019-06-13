namespace WebApplicationWithInterfaceSegregation.Services
{
    public interface IReader
    {
        string[] GetValues();
    }

    public interface IWriter
    {
        string[] WriteValues(string[] values);
    }

    public class Service : IReader, IWriter
    {
        public string[] GetValues()
        {
            return new string[] { "value1", "value2" };
        }

        public string[] WriteValues(string[] values)
        {
            return values;
        }
    }
}