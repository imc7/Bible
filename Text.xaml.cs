﻿using Bible.model;
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
    }
}
