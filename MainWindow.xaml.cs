using Bible.model;
using Bible.tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bible
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        // Permite mover ventana
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        // On closing window
        void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtTitle_previewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void txtTitle_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtChapter.Focus();
            }
            else
            {
                string title = txtTitle.Text.Trim();
                txtChapter.Clear(); // after delete
                txtVerse.Clear();
                lbxBooks.Items.Clear();
                if (!string.IsNullOrEmpty(title) && !string.IsNullOrWhiteSpace(title))
                {
                    List<BookModel> books = JsonTool.lookingFor(title);
                    lbxBooks.Items.Clear();
                    if (books.Count > 0)
                    {
                        books.ForEach(book =>
                        {
                            string t = book.getTitle();
                            StackPanel panel = new StackPanel();
                            panel.Orientation = Orientation.Horizontal;
                            panel.HorizontalAlignment = HorizontalAlignment.Left;

                            //First, add book title
                            while (StringTool.replaceAccents(t).Contains(StringTool.replaceAccents(title), StringComparison.OrdinalIgnoreCase))
                            {
                                int Start = StringTool.replaceAccents(t).IndexOf(StringTool.replaceAccents(title), StringComparison.OrdinalIgnoreCase);
                                string sub0 = t.Substring(0, Start);
                                string sub = t.Substring(Start, title.Length);
                                t = t.Remove(0, Start + title.Length);

                                Label label1 = new Label();
                                label1.Foreground = new SolidColorBrush(Colors.White);
                                label1.Margin = new Thickness(0);
                                label1.Padding = new Thickness(0);
                                label1.VerticalAlignment = VerticalAlignment.Center;
                                label1.Content = sub0;
                                panel.Children.Add(label1);

                                Label label2 = new Label();
                                label2.Background = new SolidColorBrush(Colors.Yellow);
                                label2.Foreground = new SolidColorBrush(Colors.Black);
                                label2.Margin = new Thickness(0);
                                label2.Padding = new Thickness(0);
                                label2.VerticalAlignment = VerticalAlignment.Center;
                                label2.Content = sub;
                                panel.Children.Add(label2);
                            }
                            if (t.Length > 0)
                            {
                                Label label3 = new Label();
                                label3.Foreground = new SolidColorBrush(Colors.White);
                                label3.Margin = new Thickness(0);
                                label3.Padding = new Thickness(0);
                                label3.VerticalAlignment = VerticalAlignment.Center;
                                label3.Content = t;
                                panel.Children.Add(label3);
                            }
                            lbxBooks.Items.Add(panel);

                        });


                    }
                }

            }
        }

        private void txtTitle_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtChapter_previewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void txtChapter_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtChapter_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txtVerse_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txtVerse_previewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void txtVerse_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void lbxBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!lbxBooks.Items.IsEmpty)
            {
                StackPanel panel = lbxBooks.SelectedItem as StackPanel;
                string title = "";
                foreach (object child in panel.Children)
                {
                    if (child is Label)
                    {
                        Label label = (Label)child;
                        title += label.Content.ToString();

                    }
                }
                txtTitle.Text = title.Trim();
            }
        }

        private void lbxBooks_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            txtChapter.Focus();
            lbxBooks.Items.Clear();
        }

        
    }
}
