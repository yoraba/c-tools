using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Parser{
    public class JSONParser : IParser
    {

        public string Dict2Str(Dictionary<string, object> dict, char sep = ',')
        {
            var token = JToken.FromObject(dict);
            var text = token.ToString();
            return text;
        }
        public List<string> Dict2Str(List<Dictionary<string, object>> dict, char sep = ',')
        {
            var result = new List<string>{};
            foreach(var item in dict){
                result.Add(Dict2Str(item, sep));
            }
            return result;
        }

        public Dictionary<string, object> Str2Dict(string text, char sep = ',')
        {
            var result = JsonConvert.DeserializeObject<Dictionary<string, object>>(text);
            return result;
        }

        public List<Dictionary<string, object>> Str2Dict(List<string> text, char sep = ',')
        {
            var result = new List<Dictionary<string, object>>{};
            foreach(var item in text){
                result.Add(Str2Dict(item));
            }
            return result;

        }
    }
}