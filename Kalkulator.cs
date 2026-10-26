
using System;

namespace KalkulatorSpirytusu;

public readonly record struct Wynik(
    decimal ObjetoscNapojuMl,
    decimal ObjetoscSpirytusuMl
);

public sealed class Kalkulator
{
    public Wynik Oblicz(
        decimal objetoscNaczyniaMl,
        decimal procentSpirytusu,
        int liczbaNaczyn)
    {
        if (objetoscNaczyniaMl <= 0)
            throw new ArgumentOutOfRangeException(nameof(objetoscNaczyniaMl));

        if (procentSpirytusu < 0 || procentSpirytusu > 100)
            throw new ArgumentOutOfRangeException(nameof(procentSpirytusu));

        if (liczbaNaczyn <= 0)
            throw new ArgumentOutOfRangeException(nameof(liczbaNaczyn));

        decimal objetoscNapoju = objetoscNaczyniaMl * liczbaNaczyn;
        decimal objetoscSpirytusu = objetoscNapoju * procentSpirytusu / 100m;

        return new Wynik(objetoscNapoju, objetoscSpirytusu);
    }
}
