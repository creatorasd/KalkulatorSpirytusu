
using System;
using System.Drawing;
using System.Windows.Forms;

namespace KalkulatorSpirytusu;

public class MainForm : Form
{
    private NumericUpDown objetosc;
    private NumericUpDown procent;
    private NumericUpDown liczba;
    private Label wynik;

    public MainForm()
    {
        Text = "Kalkulator spirytusu";
        Size = new Size(420, 340);
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
BackColor = Color.WhiteSmoke;
        Controls.Add(new Label
        {
            Text = "Objętość naczynia (ml):",
            Location = new Point(20, 25),
            AutoSize = true
        });

        objetosc = new NumericUpDown
        {
            Location = new Point(210, 22),
            Width = 150,
            Minimum = 1,
            Maximum = 100000,
            Value = 50
        };
        Controls.Add(objetosc);

        Controls.Add(new Label
        {
            Text = "Zawartość spirytusu (%):",
            Location = new Point(20, 75),
            AutoSize = true
        });

        procent = new NumericUpDown
        {
            Location = new Point(210, 72),
            Width = 150,
            Maximum = 100,
            Value = 40
        };
        Controls.Add(procent);

        Controls.Add(new Label
        {
            Text = "Liczba naczyń:",
            Location = new Point(20, 125),
            AutoSize = true
        });

        liczba = new NumericUpDown
        {
            Location = new Point(210, 122),
            Width = 150,
            Minimum = 1,
            Maximum = 10000,
            Value = 1
        };
        Controls.Add(liczba);

        Button przycisk = new Button
        {
            Text = "Oblicz",
            Location = new Point(20, 175),
            Size = new Size(340, 35)
        };
        Controls.Add(przycisk);

        wynik = new Label
        {
            Text = "Wynik pojawi się tutaj.",
            Location = new Point(20, 225),
            Size = new Size(360, 60)
        };
        Controls.Add(wynik);

        przycisk.Click += (sender, e) =>
        {
            Kalkulator kalkulator = new Kalkulator();

            Wynik dane = kalkulator.Oblicz(
                objetosc.Value,
                procent.Value,
                (int)liczba.Value
            );

            wynik.Text =
                $"Objętość napoju: {dane.ObjetoscNapojuMl:0.##} ml\n" +
                $"Czysty spirytus: {dane.ObjetoscSpirytusuMl:0.##} ml";
        };
    }
}
