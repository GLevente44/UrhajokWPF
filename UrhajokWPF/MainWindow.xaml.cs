using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UrhajokWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Urhajo> urhajok = new List<Urhajo>();
        public MainWindow()
        {
            InitializeComponent();
        }

        // Adatok betöltése
        private void Betoltes_Click(object sender, RoutedEventArgs e)
        {
            urhajok.Clear();

            urhajok.Add(new Urhajo("Falcon-9", 7, 550000, 87, "SpaceX", "Sikeres", 2020));
            urhajok.Add(new Urhajo("Orion-X1", 4, 820000, 73, "NASA", "Folyamatban", 2023));
            urhajok.Add(new Urhajo("StarRider", 12, 910000, 66, "Boeing", "Sikeres", 2019));
            urhajok.Add(new Urhajo("SolarWind", 3, 300000, 92, "ESA", "Sikertelen", 2018));
            urhajok.Add(new Urhajo("Galaxy-Cruiser", 18, 1200000, 54, "Blue Origin", "Sikeres", 2022));
            urhajok.Add(new Urhajo("Nova-Prime", 10, 760000, 80, "Roscosmos", "Sikeres", 2017));
            urhajok.Add(new Urhajo("Pioneer-VII", 6, 640000, 70, "NASA", "Folyamatban", 2024));
            urhajok.Add(new Urhajo("Titan-Hawk", 14, 1050000, 48, "SpaceX", "Sikeres", 2021));
            urhajok.Add(new Urhajo("CosmoJet", 5, 430000, 93, "JAXA", "Sikertelen", 2016));
            urhajok.Add(new Urhajo("Nebula-FX", 11, 870000, 60, "ESA", "Sikeres", 2020));

            dgUrhajok.ItemsSource = null;
            dgUrhajok.ItemsSource = urhajok;
        }

        // Hány űrhajó van?
        private void Darab_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Összesen {urhajok.Count} űrhajó van.", "Űrhajók száma");
        }

        // Legnagyobb hatótáv
        private void Legnagyobb_Click(object sender, RoutedEventArgs e)
        {
            if (urhajok.Count == 0)
            {
                MessageBox.Show("Először töltsd be az adatokat!");
                return;
            }

            Urhajo legnagyobb = urhajok.OrderByDescending(u => u.MaxHatotav).First();

            MessageBox.Show(
                $"A legnagyobb hatótávú űrhajó:\n\n" +
                $"Név: {legnagyobb.Nev}\n" +
                $"Gyártó: {legnagyobb.Gyarto}\n" +
                $"Hatótáv: {legnagyobb.MaxHatotav}",
                "Legnagyobb hatótáv"
            );
        }

        // Sikeres küldetésen lévő űrhajók
        private void Sikeres_Click(object sender, RoutedEventArgs e)
        {
            var sikeres = urhajok.Where(u => u.KuldetesStatusz == "Sikeres").ToList();

            dgUrhajok.ItemsSource = sikeres;
        }
        private void Atlag_Click(object sender, RoutedEventArgs e)
        {
            if (urhajok.Count == 0)
            {
                MessageBox.Show("Először töltsd be az adatokat!");
                return;
            }

            double atlag = urhajok.Average(u => u.Legenyseg);

            MessageBox.Show(
                $"Az átlagos legénységszám: {atlag:F1} fő",
                "Átlagos legénységszám"
            );
        }

        private void Csoportositas_Click(object sender, RoutedEventArgs e)
        {
            if (urhajok.Count == 0)
            {
                MessageBox.Show("Először töltsd be az adatokat!");
                return;
            }

            var csoportok = urhajok
                .GroupBy(u => u.Gyarto)
                .OrderBy(g => g.Key);

            string eredmeny = "";

            foreach (var csoport in csoportok)
            {
                eredmeny += csoport.Key + ": "
                    + csoport.Count() + " db\n";
            }

            MessageBox.Show(
                eredmeny,
                "Gyártók szerinti csoportosítás"
            );
        }

        private void Kereses_Click(object sender, RoutedEventArgs e)
        {
            if (urhajok.Count == 0)
            {
                MessageBox.Show("Először töltsd be az adatokat!");
                return;
            }

            string keresett = txtKereses.Text.Trim();

            if (keresett == "")
            {
                MessageBox.Show("Írj be egy nevet!");
                return;
            }

            var talalatok = urhajok.Where(u => u.Nev.Contains(keresett)).ToList();

            dgUrhajok.ItemsSource = talalatok;

            if (talalatok.Count == 0)
            {
                MessageBox.Show("Nincs találat!");
            }
        }

        private void Osszes_Click(object sender, RoutedEventArgs e)
        {
            dgUrhajok.ItemsSource = null;
            dgUrhajok.ItemsSource = urhajok;

            txtKereses.Clear();
        }

    
    }
}