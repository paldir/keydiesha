using System.IO;
using System.Text;
using Microsoft.Office.Interop.Excel;

namespace Marże
{
    public class Program
    {
        private static void Main(string[] args)
        {
            args = new[] { Path.GetFullPath("Marże S-1 2016_wrzesień.xlsx"), "S1.txt" };
            Application aplikacja = new Application();
            Workbook zeszyt = aplikacja.Workbooks.Open(args[0]);
            Worksheet arkusz = zeszyt.Worksheets.Item[1] as Worksheet;

            if (arkusz == null)
                return;

            string[] linie = File.ReadAllLines(args[1], Encoding.GetEncoding("Windows-1250"));

            for (int i = 5; i < linie.Length; i++)
            {
                string[] komórki = linie[i].Split('|');
            }

            /*Range komórka = arkusz.Rows.Range["H5", "I6"];
            komórka.Value = new[,] {{1, 2}, {3, 4}};

            string ścieżkaNowegoPliku = Path.Combine(Path.GetDirectoryName(args[0]), string.Concat(Path.GetFileNameWithoutExtension(args[0]), "_nowy", Path.GetExtension(args[0])));

            if (File.Exists(ścieżkaNowegoPliku))
                File.Delete(ścieżkaNowegoPliku);

            aplikacja.ActiveWorkbook.SaveAs(ścieżkaNowegoPliku);
            aplikacja.Application.Quit();
            aplikacja.Quit();
            Process.Start(ścieżkaNowegoPliku);*/
        }
    }
}