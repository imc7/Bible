using Bible.model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bible.tools
{
    class JsonTool
    {
        // Get quote
        public static QuoteModel ReadQuote(string title, int chapter, int verse)
        {
            QuoteModel response=null;

            return response;
        }


        // Looking for book title
        public static List<BookModel> lookingFor(string title)
        {
            StreamReader sr = new StreamReader(Constants.jsonPath);
            string json = sr.ReadToEnd();
            List<BookModel> jsonObj = JsonConvert.DeserializeObject<List<BookModel>>(json);
            List<BookModel> response = new List<BookModel>();
            foreach (BookModel i in jsonObj)
            {
                string item = StringTool.replaceAccents(i.getTitle().ToLower());
                title = StringTool.replaceAccents(title.ToLower());
                if (item.Contains(title, StringComparison.OrdinalIgnoreCase))
                    response.Add(i);
            }

            return response;
        }
    }
}
