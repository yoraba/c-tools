using System;
using Xunit;
using Parser;
using System.Collections.Generic;

namespace Unittests
{
    public class TestParser
    {
        const string DAT_PATH = "./dat";
        List<Dictionary<String, Object>> _dict_list = new List<Dictionary<string, object>>{
            new Dictionary<string, object>{{"string_data", "1"},{ "int_data", 2 } ,{ "float_data", 3.3 } },
            new Dictionary<string, object>{{"string_data", "4"},{ "int_data", 5 } ,{ "float_data", 6.6 } },
            new Dictionary<string, object>{{"string_data", "7"},{ "int_data", 8 } ,{ "float_data", 9.9 } }
        };

        [Fact]
        public void TestDict2CSV()
        {
            var parser = new CSVParser();
            var path = System.IO.Path.Combine(DAT_PATH, "d2c.csv");
            Assert.True(parser.ToFile(path, parser.Dict2Str(_dict_list)));
            Assert.True(System.IO.File.Exists(path));
        }

        [Fact]
        public void TestCSV2Dict()
        {
            var parser = new CSVParser();
            var path = System.IO.Path.Combine(DAT_PATH, "c2d.csv");
            var answer = parser.Str2Dict(parser.FromFile(path));
            Assert.True(answer != null);
            foreach (var row in answer)
            {
                foreach (var col in row)
                {
                    Console.Write($"{col.Key}:{col.Value} ");
                }
                Console.WriteLine();
            }
        }
    }
}
