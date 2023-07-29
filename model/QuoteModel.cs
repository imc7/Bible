
namespace Bible.model
{
    public class QuoteModel
    {
        private string book { get; set; }
        private string chapter { get; set; }
        private string verse { get; set; }
        private string text { get; set; }

        // Constructors
        public QuoteModel(string book, string chapter, string verse, string text)
        {
            this.book = book;
            this.chapter = chapter;
            this.verse = verse;
            this.text = text;
        }

        public string Book { get { return book; } set { book = value; } }
        public string Chapter { get { return chapter; } set { chapter = value; } }
        public string Verse { get { return verse; } set { verse = value; } }
        public string Text { get { return text; } set { text = value; } }
    }
}
