## Opgave: Byg dit eget interaktive hundredetal!

### Beskrivelse:
Du skal programmere et spil, hvor du skal udfylde et hundredetal. Et tal vil blive valgt tilfældigt, og brugeren/kunden skal så finde de tal, der er 10 mere, 10 mindre, 1 mere og 1 mindre.


<div align="center">
  <img src="images/HundresCart_MoreThan_LessThan.png" style=" width: 500px;  margin: 0 auto;">
</div>

### Krav:
* **Spilmotor:** C# Winforms, eller efter aftale (specifikke spilmotor eller programmeringssprog, f.eks. Unity, Winforms eller blazor. C# eller javascript)
* **Funktionalitet:**
  * Tilfældig talgenerering
  * Brugerinput
  * Svarafstemning / feedback på om svar korrekt forkert
  * Grafisk brugerinterface
* **Ekstra (valgfrit):**
  * Timer
  * Highscore
  * Forskellige sværhedsgrader
  * Tematisk design
  * Lydeffekter

### Leverance:
* **Kode:** Indlever din kode i et git-repository (f.eks. på GitHub).
* **Dokumentation:** Lav en kort dokumentation, der forklarer din kode og designvalg.
* **Præsentation:** Vær klar til at præsentere dit projekt for klassen.

### Evaluering:
* **Funktionalitet:** Fungerer spillet som forventet?
* **Design:** Er spillet brugervenligt og visuelt tiltalende?
* **Kodekvalitet:** Er koden velstruktureret og let at forstå?
* **Kreativitet:** Har du tilføjet egne kreative elementer?

### Hjælpemidler:
* * **Generelt:**
  * W3Schools: https://www.w3schools.com/
  * MDN Web Docs: https://developer.mozilla.org/en-US/
  * Stack Overflow: https://stackoverflow.com/   

* **C# og .NET:**
  * Microsoft Docs: https://docs.microsoft.com/en-us/dotnet/
  * Unity Manual: https://docs.unity3d.com/Manual/index.html
* **Version kontrol:**
  * GitHub Guides: https://guides.github.com/
* **Værktøjer:**
  * Visual Studio Code: https://code.visualstudio.com/
  * GitHub Desktop: https://desktop.github.com/

### Tips:
* Start med at lave en simpel version af spillet, og udbyg det gradvist.
* Test din kode grundigt for at finde og rette fejl.
* Spørg din lærer eller medstuderende om hjælp, hvis du sidder fast.

### Eksempel på WorkFlow
```mermaid
graph LR
    subgraph Initialisering
        A(Start) --> B{Initialiser komponenter}
        B --> C{Initialiser timer-event}
        C --> D{Initialiser tastatur-events}
        D --> E{Nulstil spil-timer}
        E --> F{Ny Spil}
    end

    subgraph Spil-loop
         F --> G{Timer1 Spiltid?}
        classDef tooltip fill:#ffcccc,stroke:#000FF000,stroke-width:2px;
        class G tooltip
        G -- Ja --> H{Reduktion af tid}
        H --> I{Tid udløbet?}
        I -- Ja --> J{Stop timer}
        I -- Nej --> G
        J --> K{Sæt alle tekstbokse til ReadOnly}
        K --> L{Vis besked: Tid udløbet timer2}
        L --> M{Spil igen?}
        M -- Ja --> F
        M -- Nej --> N{Afslut program}
        G --> O{Check for svar?}
        O -- Ja --> P{Tjek svar}
        P --> Q{Vis feedback}
        Q --> R{Nulstil spil}
        R --> F
    end

   subgraph Brugerinput
        F --> S{Bruger indtaster svar}
        S --> T{Valider input karakter}
        T -- Gyldigt (tal & backspace)--> O
        T -- Ugyldigt (ikke tal)--> S
    end
```
**Eksempel på kode (C#):**
```csharp
using System;
using System.Windows.Forms;

namespace Hundredtal
{
    public partial class Form1 : Form
    {
        private Random random = new Random();
        private int midtal;

        public Form1()
        {
            InitializeComponent();
            NyOpgave();
        }

        private void NyOpgave()
        {
            // Generer et tilfældigt tal mellem 1 og 99
            midtal = random.Next(1, 100);
            labelMidtal.Text = midtal.ToString();

            // Nulstil tekstfelter til brugerinput
            textBox10Mere.Text = "";
            textBox10Mindre.Text = "";
            textBox1Mere.Text = "";
            textBox1Mindre.Text = "";
        }

        // ... resten af koden fx event eller som herunder en knap?
        private void buttonTjekSvar_Click(object sender, EventArgs e)
        {
            // Tjek om brugerens svar er korrekte
            // ... (Implementer logikken her)
            // Vis en besked til brugeren om, hvor mange svar der var korrekte
        }
    }
}
```

# Dag 2
|  1 |  2 |  3 |  4 |  5 |  6 |  7 |  8 |  9 | 10 |
|---|---|---|---|---|---|---|---|---|---|
| 11 | 12 | 13 | 14 | 15 | 16 | 17 | 18 | 19 | 20 |
| 21 | 22 | 23 | 24 | 25 | 26 | 27 | 28 | 29 | 30 |
| 31 | 32 | _33_| 34 | 35 | 36 | 37 | 38 | 39 | 40 |
| 41 | _42_ | ___43___ | _44_ | 45 | 46 | 47 | 48 | 49 | 50 |
| 51 | 52 | _53_ | 54 | 55 | 56 | 57 | 58 | 59 | 60 |
| 61 | 62 | 63 | 64 | 65 | 66 | 67 | 68 | 69 | 70 |
| 71 | 72 | 73 | 74 | 75 | 76 | 77 | 78 | 79 | 80 |
| 81 | 82 | 83 | 84 | 85 | 86 | 87 | 88 | 89 | 90 |
| 91 | 92 | 93 | 94 | 95 | 96 | 97 | 98 | 99 | 100 |
