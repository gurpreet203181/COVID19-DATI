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
using System.Xml.Linq;
using System.Xml.XPath;
using System.Diagnostics;


namespace COVID19_DATI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            carica();
           
        }

       //Metodo per caricare dati da file xaml
       public void carica()
        {


            string path = @"DATI.xml";
            XDocument Xmldoc = XDocument.Load(path);
            XElement xmlStudenti = Xmldoc.Element("root");
            var xmlStudente = xmlStudenti.Elements("row");

            
            foreach (var item in xmlStudente)
            {
              

                   Lbl_Cases.Content = item.Element("totale_positivi").Value;
                lbl_deaths.Content = item.Element("deceduti").Value;
                lbl_Recovered.Content = item.Element("dimessi_guariti").Value;
                inl_NewCase.Text = item.Element("nuovi_positivi").Value;
              inl_Insulated.Text = item.Element("isolamento_domiciliare").Value;





            }


        }

        private void lst_exit_Selected(object sender, RoutedEventArgs e)
        {
            
            System.Windows.Application.Current.Shutdown();
        }

       

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://github.com/pcm-dpc/COVID-19/tree/master/dati-andamento-nazionale");

        }

       
    }
}
