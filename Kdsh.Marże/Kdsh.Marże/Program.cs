using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using Microsoft.Office.Interop.Excel;

namespace Kdsh.Marże
{
    public class Program
    {
        private static void Main(string[] args)
        {
            args = new[] {Path.GetFullPath("Marże S-9 2016_październik.xls"), "S9.txt"};
            Application aplikacja = new Application();
            aplikacja.Visible = true;
            Workbook zeszyt = aplikacja.Workbooks.Open(args[0]);
            Worksheet arkusz = zeszyt.Worksheets.Item[1] as Worksheet;

            if (arkusz == null)
                throw new Exception("Nie udało się załadować arkusza. - PZ");

            char kolumna1;
            int wiersz1;
            char kolumna2;
            int wiersz2;
            char separator;

            PobierzDaneOdUżytkownika(out kolumna1, out wiersz1, out kolumna2, out wiersz2, out separator);

            int liczbaWierszy = wiersz2 - wiersz1;
            Range wiersze = arkusz.Rows;
            string[] linie = File.ReadAllLines(args[1], Encoding.GetEncoding("Windows-1250"));
            CultureInfo kultura = (CultureInfo) CultureInfo.CurrentCulture.Clone();
            kultura.NumberFormat.NumberDecimalSeparator = separator.ToString();

            for (int i = 0; i < liczbaWierszy; i++)
            {
                string[] wartości = linie[i + 5].Split('|');
                Range komórka1 = wiersze.Range[$"{kolumna1}{wiersz1 + i}"];
                Range komórka2 = wiersze.Range[$"{kolumna1 + 1}{wiersz1 + i}"];
                double a = double.Parse(wartości[7], kultura);
                double b = double.Parse(wartości[8], kultura);
                object wartośćKomórki1 = komórka1.Value;

                if (wartośćKomórki1 is string && Equals(wartośćKomórki1, "DH"))
                {
                }
                else
                {
                    komórka1.Value = a;
                    komórka2.Value = b;
                }
            }

            string folder = Path.GetDirectoryName(args[0]);

            if (folder == null)
                throw new Exception("Brak dostępu do folderu przechowującego plik. - PZ");

            string ścieżkaNowegoPliku = Path.Combine(folder, string.Concat(Path.GetFileNameWithoutExtension(args[0]), "_nowy", Path.GetExtension(args[0])));

            if (File.Exists(ścieżkaNowegoPliku))
                File.Delete(ścieżkaNowegoPliku);

            aplikacja.ActiveWorkbook.SaveAs(ścieżkaNowegoPliku);
            aplikacja.Application.Quit();
            aplikacja.Quit();
            Process.Start(ścieżkaNowegoPliku);
        }

        private static void PobierzDaneOdUżytkownika(out char kolumna1, out int wiersz1, out char kolumna2, out int wiersz2, out char separator)
        {
            Console.Write("Lewa górna komórka: ");

            string pierwszaKomórka = Console.ReadLine();

            if (string.IsNullOrEmpty(pierwszaKomórka))
                throw new Exception("Nie podano współrzędnych komórki. - PZ");

            kolumna1 = pierwszaKomórka[0];
            wiersz1 = Convert.ToInt32(pierwszaKomórka[1]);

            Console.Write("Prawa dolna komórka: ");

            string ostatniaKomórka = Console.ReadLine();

            if (string.IsNullOrEmpty(ostatniaKomórka))
                throw new Exception("Nie podano współrzędnych komórki. - PZ");

            kolumna2 = ostatniaKomórka[0];
            wiersz2 = Convert.ToInt32(ostatniaKomórka[1]);

            Console.Write("Separator dziesiętny: ");

            separator = Console.ReadKey().KeyChar;
        }
    }
}