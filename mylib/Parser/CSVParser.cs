using System.Collections.Generic;
using System.Linq;
using Parser;

namespace Parser
{
    public class CSVParser : Parser.IParser
    {
        public List<string> Dict2Str(List<Dictionary<string, object>> dict, char sep = ',')
        {
            var result = new List<string>();
            if (dict == null || dict.Count < 1) { return result; }
            var header = "";
            var keys = new List<string>(dict[0].Keys);
            foreach (var (v, i) in keys.Select((v, i) => (v, i)))
            {
                header += v;
                if (i < keys.Count - 1) { header += sep; }
            }
            result.Add(header);
            for (int row = 0; row < dict.Count; row++)
            {
                var str_row = "";
                foreach (var (v, i) in keys.Select((v, i) => (dict[row][v], i)))
                {
                    str_row += v;
                    if (i < keys.Count - 1) { str_row += sep; }
                }
                result.Add(str_row);
            }
            return result;
        }

        public List<Dictionary<string, object>> Str2Dict(List<string> text, char sep = ',')
        {
            var result = new List<Dictionary<string, object>>();
            if (text == null || text.Count < 1) { return result; }
            var header = text[0].Split(sep).ToList();
            foreach (var (v, i) in text.Select((v, i) => (v, i)))
            {
                if (i == 0) { continue; }
                var cols = v.Split(sep);
                var dict = new Dictionary<string, object>();
                foreach (var (cv, ci) in cols.Select((cv, ci) => (cv, ci)))
                {
                    dict.Add(header[ci], cv);
                }
                result.Add(dict);
            }
            return result;
        }
    }
}