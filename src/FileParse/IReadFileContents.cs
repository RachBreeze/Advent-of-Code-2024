using FileParse.Model;
using System.Collections.Specialized;

namespace FileParse
{
    public interface IReadFileContents
    {
        List<Row> AsCollections(string fileName, string separator);
        StringCollection AsLines(string fileName);
    }
}