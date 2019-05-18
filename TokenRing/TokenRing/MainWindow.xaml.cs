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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TokenRing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Token Tk;
        public MainWindow()
        {
            InitializeComponent();
            
           
        }

        private void clearWindow()
        {
          foreach( WrapPanel wp in mainGrid.Children.OfType<WrapPanel>() )
            {
                wp.Children.OfType<TextBlock>().First().Text = "";
                wp.Children.OfType<TextBox>().First().Text = "";
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HandleNext();

        }

        private void HandleNext()
        {
            int source = Convert.ToInt16(TxtSource.Text.Trim());
            int Destination = Convert.ToInt16(TxtDestination.Text.Trim());
            int Current = Tk.CurrentCalculator;

            if (Tk.IsFree)
            {
                if (source == Current)
                {
                    Tk.Source = source;
                    Tk.Destination = Destination;
                    Tk.IsFree = false;
                    Tk.msg = TxtMsg.Text;
                    Tk.IsAnswer = false;
                    UpdateComputer(1);
                    NextComputer();
                    return;
                }
                UpdateComputer(4);
                NextComputer();
            }
            else
            {
                if (Destination == Current)
                {
                    Tk.response = TxtMsg.Text;
                    Tk.IsAnswer = true;
                    UpdateComputer(2);
                    NextComputer();
                    return;
                }

                if (source == Current)
                {
                    Tk.IsFree = true;
                    UpdateComputer(3);
                    NextComputer();
                    return;

                }
                UpdateComputer(4);
                NextComputer();
                return;



            }
        }

        private void NextComputer()
        {
            Tk.CurrentCalculator++;
            if (Tk.CurrentCalculator > 4)
                Tk.CurrentCalculator = 1;
           
        }

        private void UpdateComputer(int op)
        {
            string name = "WpCalc" + Tk.CurrentCalculator.ToString().Trim();

            
            foreach (WrapPanel wp in mainGrid.Children.OfType<WrapPanel>())
                if(wp.Name==name)
                {
                    TextBlock tbl = wp.Children.OfType<TextBlock>().First();
                    switch (op)
                    {
                        case 1:
                            tbl.Text += "generez mesajul:" + Tk.msg.Trim()+"\n";
                            tbl.Text += "Dest:" + Tk.Destination.ToString().Trim() + "\n";
                            break;
                        case 2:
                            tbl.Text += "primesc mesajul:" + Tk.msg.Trim() + "\n";
                            //tbl.Text += "Dest:" + Tk.Destination.ToString().Trim() + "\n";
                            Tk.response = wp.Children.OfType<TextBox>().First().Text.Trim();
                            tbl.Text += "Generes raspunsul :" + Tk.response.ToString().Trim() + "\n";
                            break;
                        case 3:
                            tbl.Text += "Primesc Raspunsul:" + Tk.response.Trim() + "\n";
                            tbl.Text += "eliberez Tokenul\n";

                            break;
                        case 4:
                            tbl.Text += "Transmit tokenul mai departe:\n";

                            break;
                        default:
                            break;

                    }

                }
        }

        private void MainWindow1_Loaded(object sender, RoutedEventArgs e)
        {
            clearWindow();
            Tk = new Token();
            Tk.CurrentCalculator = 1;
            spTokenRing.DataContext = Tk;
        }

    }
}
