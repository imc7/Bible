using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bible.model
{
    class BookModel
    {
        private string number { get; set; }
        private string title { get; set; }

        // Constructors
        public BookModel(string number, string title)
        {
            this.number = number;
            this.title = title;
        }

        // Setters and Getters
        public void setNumber(string number)
        {
            this.number = number;
        }
        public void setTitle(string title)
        {
            this.title = title;
        }
        public string getNumber()
        {
            return number;
        }
        public string getTitle()
        {
            return title;
        }
    }
}
