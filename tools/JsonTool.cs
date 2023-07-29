using Bible.model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Bible.tools
{
    class JsonTool
    {
        // Get quote
        public static QuoteModel ReadQuote(string title, string chapter, string verse)
        {
            string path = $"{Constants.bookPath}{title}.json";
            Uri uri = new Uri(path);
            if (File.Exists(uri.LocalPath))
            {
                StreamReader sr = new StreamReader(path);
                string json = sr.ReadToEnd();
                List<QuoteModel> jsonObj = JsonConvert.DeserializeObject<List<QuoteModel>>(json);
                foreach (QuoteModel i in jsonObj)
                {
                    if (
                        i.Book.Equals(title, StringComparison.Ordinal) &&
                        i.Chapter.Equals(chapter, StringComparison.Ordinal) &&
                        i.Verse.Equals(verse, StringComparison.Ordinal)
                        )
                        return i;
                }
            }
            return null;
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
