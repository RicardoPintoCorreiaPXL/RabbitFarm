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

namespace RabbitFarm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int huizenCapaciteit = 0;
        private int veldenCapaciteit = 0;
        private int totaal = 0;
        private double simTotaal = 0;
        public MainWindow()
        {
            InitializeComponent();
            Wipe();
        }

        private void berekenButton_Click(object sender, RoutedEventArgs e)
        {
            simulatieButton.IsEnabled = true;
            int getal1;
            int getal2;
            if (int.TryParse(huizenTextbox.Text, out getal1))
            {
                if (int.TryParse(veldenTextbox.Text, out getal2))
                {
                    huizenCapaciteit = Int32.Parse(huizenTextbox.Text) * 40;
                    veldenCapaciteit = Int32.Parse(veldenTextbox.Text) * 100;
                    totaal = huizenCapaciteit + veldenCapaciteit;
                    outputTextbox.Text = $"De totale capaciteit van je boerderij is {totaal} konijnen";
                }    else
                {
                    MessageBox.Show("Ongeldige ingave van aantal velden of huizen");
                }  
            } else
            {
                MessageBox.Show("Ongeldige ingave van aantal velden of huizen");
            }
            

        }

        private void simulatieButton_Click(object sender, RoutedEventArgs e)
        {
            outputTextbox.Text = "";
            int getal1;
            int getal2;
            int maand = 0;
            ;
            if (int.TryParse(sprongTextbox.Text, out getal1))
            {
                if (int.TryParse(aantalmaandTextbox.Text, out getal2))
                {
                    maand += 1;
                    simTotaal = getal1;
                    for (int i = 0; i < getal2; i++)
                    {
                        

                        if (maand >= 4)
                        {
                            simTotaal += Math.Floor(simTotaal / 2);
                            if (simTotaal > totaal)
                            {
                                ToString(maand, totaal);
                            } else
                            {
                                ToString(maand, simTotaal);
                                
                            }


                        } else
                        {
                            ToString(maand, simTotaal);
                        }
                        maand++;
                    }
                }
                else
                {
                    MessageBox.Show("Ongeldige ingave van aantal velden of huizen of maanden of sprong");
                }
            }
            else
            {
                MessageBox.Show("Ongeldige ingave van aantal velden of huizen of maanden of sprong");
            }
        }

        private void ToString(int maand, double waarde)
        {
            outputTextbox.AppendText($"Maand {maand}: {waarde}");
            outputTextbox.AppendText(Environment.NewLine);
        }

        private void wissenButton_Click(object sender, RoutedEventArgs e)
        {
            Wipe();
        }

        private void Wipe()
        {
            simulatieButton.IsEnabled = false;
            huizenTextbox.Text = "0";
            veldenTextbox.Text = "0";
            sprongTextbox.Text = "0";
            aantalmaandTextbox.Text = "0";
            outputTextbox.Text = "";
            huizenCapaciteit = 0;
            veldenCapaciteit = 0;
            totaal = 0;
            simTotaal = 0;
        }
    }
}
