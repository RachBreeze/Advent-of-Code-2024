using FileParse.Model;

namespace FileParse
{
    public interface IReadCollectionsFromFile
    {
        List<Row> ReadFileContentsToCollection(string fileName, string separator);
    }
}