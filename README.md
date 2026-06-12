# DOKUMENTACE PROJEKTU – EVIDENCE HER (C# KONZOLOVÁ APLIKACE)

## 1. Zadání projektu

Cílem projektu je vytvořit konzolovou aplikaci pro správu seznamu her.

Aplikace umožňuje:

- načítání dat ze souboru
- výpis her
- přidávání her
- vyhledávání podle názvu
- filtrování podle žánru
- úpravu údajů
- mazání her
- řazení podle hodnocení
- statistiky
- ukládání do souboru

---

## 2. Model tříd

### Třída `Hry`

| Atribut | Datový typ |
|----------|-----------|
| ID | int |
| Nazev | string |
| Zanr | string |
| StavHry | string |
| Hodnoceni | int |
| Cena | int |

### Vazba

Hlavní datová struktura programu:

```csharp
List<Hry>
```

---

## 3. Struktura aplikace

### Main()

Metoda:

- načte soubor `hry.txt`
- naplní `List<Hry>`
- spustí menu pomocí `while` cyklu
- volá jednotlivé funkce programu

### Použité metody

- `Menu()`
- `VypisHer()`
- `PridavaniHry()`
- `NajitPodleNazvy()`
- `FiltrovaniSouboru()`
- `UpravaUdaju()`
- `SmazaniHry()`
- `SerazeniPodleHodnoceni()`
- `Statistika()`
- `Konec()`

---

## 4. Práce se soubory

### Načítání dat

```csharp
File.ReadAllLines("hry.txt");
```

### Ukládání dat

```csharp
StreamWriter
```

Výstupní soubor:

```text
hry_upraveno.txt
```

### Formát dat

```text
ID;Nazev;Zanr;StavHry;Hodnoceni;Cena
```

---

## 5. Ovládání programu

### Menu

| Volba | Funkce |
|--------|---------|
| 1 | Výpis her |
| 2 | Přidání hry |
| 3 | Vyhledání hry |
| 4 | Filtrování |
| 5 | Úprava |
| 6 | Smazání |
| 7 | Řazení |
| 8 | Statistiky |
| 9 | Konec |

### Ovládání

- uživatel zadává čísla **1–9**
- klávesa **ENTER** vrací do menu
- aplikace kontroluje správnost vstupů

---
