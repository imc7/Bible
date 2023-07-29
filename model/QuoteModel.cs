using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bible.model
{
    public class QuoteModel
    {
        private string book { get; set; }
        private int chapter { get; set; }
        private int verse { get; set; }
        private string text { get; set; }

        // Constructors
        public QuoteModel(string book, int chapter, int verse, string text)
        {
            this.book = book;
            this.chapter = chapter;
            this.verse = verse;
            this.text = text;
        }

        public string Book { get { return book; } set { book = value; } }
        public int Chapter { get { return chapter; } set { chapter = value; } }
        public int Verse { get { return verse; } set { verse = value; } }
        public string Text { get { return text; } set { text = value; } }
    }
}
