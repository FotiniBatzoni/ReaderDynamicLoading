using PersonReader.CSV;
using PersonReader.Interface;
using PersonReader.Service;
using PersonReader.SQL;

namespace PersonReader.Factory
{
    public class ReaderFactory
    {
        public IPersonReader GetReader(string readerType)
        {
            switch (readerType)
            {
                case "Service":
                    return new ServiceReader();
                    break;
                case "CSV":
                    return new CSVReader();
                    break;
                case "SQL":
                    return new SQLReader();
                    break;
                default: throw new ArgumentException($"Invalid Reader type: {readerType}");

            }
        }
    }
}