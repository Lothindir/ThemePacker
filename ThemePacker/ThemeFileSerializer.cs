using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThemePacker
{
    public class ThemeFileSerializer
    {
        private string _path;

        public JObject JSON { get; set; }
        public dynamic Theme { get; set; }

        public ThemeFileSerializer(string path)
        {
            _path = path;

            JSON = new JObject();
            Theme = new ExpandoObject();
        }

        public dynamic Deserialize()
        {
            var themeDic = new Dictionary<string, Dictionary<string, string>>();

            using (StreamReader sr = new StreamReader(_path))
            {
                string line;
                string parent = "";

                while ((line = sr.ReadLine()) != null)
                {
                    if (!(line.StartsWith(";") || string.IsNullOrEmpty(line)))
                    {
                        if (line.StartsWith("["))
                        {
                            parent = line.TrimStart('[').TrimEnd(']').Replace('\\', '_');
                            themeDic.Add(parent, new Dictionary<string, string>());
                        }
                        else
                        {
                            string[] property = line.Split('=');
                            string key = property[0];
                            string value = property.Length == 1 ? "" : property[1];

                            themeDic[parent].Add(key, value);
                        }
                    }
                }
            }

            JSON = JObject.FromObject(themeDic);

            Theme = new ExpandoObject();

            var expandoDict = Theme as IDictionary<string, object>;

            foreach (var category in themeDic)
            {
                expandoDict.Add(category.Key, new ExpandoObject());

                foreach (var prop in category.Value)
                {
                    (expandoDict[category.Key] as IDictionary<string, object>).Add(prop.Key, prop.Value);
                }
            }

            return Theme;
        }

        public void Serialize(string path = null)
        {
            if (path == null)
                path = _path;

            using (StreamWriter sw = new StreamWriter(path))
            {
                var themeDic = Theme as IDictionary<string, object>;

                foreach (var category in themeDic)
                {
                    sw.WriteLine($"[{category.Key.Replace('_', '\\')}]");

                    foreach (var prop in category.Value as IDictionary<string, object>)
                    {
                        sw.WriteLine($"{prop.Key}={prop.Value}");
                    }

                    sw.WriteLine();
                }

                sw.Close();
            }
        }

        public void JsonSerialize(string path = null)
        {
            if (path == null)
                path = _path;

            var themeDic = JSON.ToObject<Dictionary<string, Dictionary<string, string>>>();

            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (var category in themeDic)
                {
                    sw.WriteLine($"[{category.Key.Replace('_', '\\')}]");

                    foreach (var prop in category.Value)
                    {
                        sw.WriteLine($"{prop.Key}={prop.Value}");
                    }

                    sw.WriteLine();
                }

                sw.Close();
            }
        }
    }
}
