
namespace Bible.model
{
    class BookModel
    {
        private string number;
        private string title;

        // Constructors
        public BookModel(string number, string title)
        {
            this.number = number;
            this.title = title;
        }

        // Getters and setters
        public string Number { get { return number; } set { number = value; } }
        public string Title { get { return title; } set { title = value; } }
    }
}
