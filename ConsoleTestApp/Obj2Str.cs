using System.Reflection;

namespace ConsoleTestApp
{
    internal class Class1
    {
        public class SomeTestApiRequest
        {
            public int UserId { get; set; }
            public int? Amount { get; set; }
            public string SomeNotes { get; set; }
        }

        public void Test()
        {
            string test = ReqObj2EncodedUrl(
                new SomeTestApiRequest() { UserId = 123, SomeNotes = "Some notes here..." });

            Console.WriteLine(test);
        }

        private string ReqObj2EncodedUrl(object obj)
        {
            Type type = obj.GetType();

            IEnumerable<string> propertyNames = type.GetMembers().Where(x => x.MemberType == MemberTypes.Property).Select(x => x.Name);

            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

            foreach (string propName in propertyNames)
            {
                object val = type.GetProperty(propName).GetValue(obj, null);

                if (val != null)
                {
                    keyValuePairs.Add(propName, val.ToString());
                }
            }
            return
                string.Join("&", keyValuePairs.Select(x => string.Format("{0}={1}", x.Key.ToLower(), x.Value)).ToArray());
        }
    }
}
