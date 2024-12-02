using System.Collections.Specialized;

namespace FileParse.Model
{
    public class Row
    {
        public Row()
        {
            Values = new StringCollection();
        }
        public StringCollection Values { get; set; }
        public int Index { get; set; }
    }
}
