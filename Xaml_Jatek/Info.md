# Egyszerű játék fejlesztése XAML alapokon.

## Áttekintés

A játék egy ***desktop*** alkalmazás (fontos döntés) ami a reakció idönket méri.
A játék lényege, hogy kártyákat mutatunk egymás után és minden alkalommal el kell dönteni, hogy az adott kártya egyforma-e az előzővel.

##Szereplők
Tudom Ányos
A szellemi képességeinek növekedését kívánja nyomon követni. Mivel a reakcióidők és a játékidő hosszának mérése fontos, a pontos méréshez számítógép szükséges.


## Forgatókönyvek

### Játék a felhasználó szemszögéből
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

### Feladatok (1)
- Megnézni a Stack panel viselkedését, különböző esetekben.
- Ikonok beillesztése a rendszerbe, hogy lehet véletlenszerűen váltogatni őket?
- Hogyan lehet az egyes elemek tulajdonságát megváltoztatni?
- Összefoglaló készítése 

### Feladatok (2)
 - Hogyan lehetne a pontszámokat elkészíteni?

### A játék menete részletesen (a programozó szemszögéből)

Elindul a játék
- A kezdő képernyőn nincs semmilyen felfordított kártya
- Megmutatjuk az első kártyát
  
    Fontos, hogy egymás után következhessen egyforma kártya. Ez csak akkor lehetséges, ha van egyforma kártya a pakliban. Vagy minden húzás után visszatesszük a kártyát és újra megkeverjük. Vagy a pakliban eleve több egyforma kártya van.
    A programozáshoz válasszuk azt, hogy minden alkalommal megkverjük az egész paklit.
    Már csak azt kell eldönteni, hogy mekkor legyen a kártyapakli. Minél nagyobb a kártyapakli, annál valószínűtleneb, hogy egymás után nem jön két egyforma. 
    Értelmes kártyapakli méret - legyen pl. 6 kártya. (a játék élvezetét ez meg
    
    - Majd véletlenszerűen választunk a pakliból egy kártyát, (programozni ezt a legegyszerűbb)
    - Ha keverünk és a tetejéről húzunk, az lényegében ugyanaz.

- **ilyenkor még nem várunk visszajelzést**
  
- Megmutatjuk a következő kártyát

   Ugyanúgy, mint az első kártyánál.  

  - várunk a felhasználó visszajelzésére
    - első lépésben a gombokon keresztül
    - második lépésben a billentyűzetről

  - vagy lejár az idő
  - Ha a felhasználó reagált akkor értékeljük a visszajelzést
  - Értékeljük a visszajelzést
    - jó/nem jó 
    - mennyi volt a reakcióidő
  - Az értékelést megjelenítjük
    - jó/nem jó
    - pontszám frissítése (hogy számoljuk a pontokat?)
- Ezt ismételjük amíg le nem jár az idő 
  - a hátralévő időt folyamatosan kijelezzük (mennyi a játékidő)

## Javítások/ módosítások

- legyen az ablaknak egy minimális mérete.
- fogadjunk el a billentyűzetről is visszajelzést.
- adjunk segítséget a képernyőn, hogy milyen billentyűvel lehet a játékot játszani.
- visszajelző ábra méretét és a színét javítsuk.
- a billentyűk csak akkor éljenek, ha már a játék elindult.

- a kód tisztítása
- a játék érzetének javítása (két egyforma kártya esetén ezt valahogy jelezni kellene)
- visszaszámlálás
- ponszámok számítása
 





