# Egyszerű játék fejlesztése XAML alapokon.

## Áttekintés

A játék egy ***desktop*** alkalmazás (fontos döntés) ami a reakció idönket méri.
A játék lényege, hogy kártyákat mutatunk egymás után és minden alkalommal el kell dönteni, hogy az adott kártya egyforma-e az előzővel.

##Szereplők
Tudom Ányos
A szellemi képességeinek növekedését kívánja nyomon követni. Mivel a reakcióidők és a játékidő hosszának mérése fontos, a pontos méréshez számítógép szükséges.


## Forgatókönyvek

### Játék
Ányos elindítja az alkalmazást (fontos döntés), majd ha felkészült elindítja a játékot, ha végzett a játék kiírja az eredményt.
Mivel rövid időket mérünk, az alkalmazás elindításának mérésére nem használhatjuk a játékot. Nem tudjuk a program betöltési idejét. Ezért az alkalmazás indítása és a játék elkezdése között különbséget kell tenni.

### Hány képernyő legyen?
Egy és három között valahol:
alkalmazás induló képernyője  (mindkét kártya lefordítva legyen lásd később az ábránál)
Játék képernyője
Végeredmény képernyő (mindkét kártya lefordítva, mert az eredményt folyamatosan jelezzük.)

Kezdetben elindulhatunk úgy, hogy az induló képernyő a játék kezdő képernyője, a végeredmény egyben a játék záró képernyője lesz.

Célszerű a képernyőket előre megrajzolni, mert könnyebb egy ilyen elemből törölni, mintha ezt az alkalmazásomból kellene megtenni.

[képernyő rajzoláshoz mockflow]
Használjuk a [morkflow](https://mockflow.com) felületet, amelyben 3 képernyőt ingyenesen tervezhetünk.

### Feladatok
- Megnézni a Stack panel viselkedését, különböző esetekben.
- Ikonok beillesztése a rendszerbe, hogy lehet véletlenszerűen váltogatni őket?
- Hogyan lehet az egyes elemek tulajdonságát megváltoztatni?
- Összefoglaló készítése 


