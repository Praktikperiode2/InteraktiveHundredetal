## Opgave: Byg dit eget interaktive hundredetal!

### Beskrivelse:

Du skal programmere et spil, hvor du skal udfylde et hundredetal. Et tal vil blive valgt tilfældigt, og du skal så finde de tal, der er 10 mere, 10 mindre, 1 mere og 1 mindre.

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
