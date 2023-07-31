using Bible.model;
using Bible.tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace Bible
{
    public partial class Text : Window
    {
        // Global variables
        public QuoteModel quote;
        public Text()
        {
            InitializeComponent();
        }

        public void initializePlayText()
        {
            lblQuote.Content = $"{quote.Book} {quote.Chapter}:{quote.Verse}";
            tblQuote.Text = quote.Text;
        }

        public void searchNewQuote(int chapterIncrease, int verseIncrease)
        {
            string book = quote.Book;
            string oldChapter = quote.Chapter;
            string oldVerse = quote.Verse;

            string newChapter = Convert.ToString(int.Parse(oldChapter)+ chapterIncrease);
            string newVerse = Convert.ToString(int.Parse(oldVerse)+ verseIncrease);

            QuoteModel newQuote = JsonTool.ReadQuote(book, newChapter, newVerse);

            if (newQuote is null)
            {
                MessageBox.Show("Cita no encontrada", "Alerta", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            this.quote = newQuote;
            initializePlayText();
        }


        // WPF Controls
        private void btnBoBack_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnMinusVerse_Click(object sender, RoutedEventArgs e)
        {
            searchNewQuote(0, -1);
        }

        private void btnPlusChapter_Click(object sender, RoutedEventArgs e)
        {
            searchNewQuote(1, 0);
        }

        private void btnPlusVerse_Click(object sender, RoutedEventArgs e)
        {
            searchNewQuote(0, 1);
        }

        private void btnMinusChapter_Click(object sender, RoutedEventArgs e)
        {
            searchNewQuote(-1, 0);
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                btnMinusVerse_Click(null, null);
            }
            else if (e.Key == Key.Up)
            {
                btnPlusChapter_Click(null,null);
            }
            else if (e.Key == Key.Right)
            {
                btnPlusVerse_Click(null, null);
            }
            else if (e.Key == Key.Down) { 
                btnMinusChapter_Click(null, null);
            }
        }
    }
}
