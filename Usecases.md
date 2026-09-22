# Use cases – Komme/gå-system til HYDAC

## Afgrænsning af systemet

### Uden for systemet (aktører)
* Medarbejdere
* Gæster
* Ejere/ledelse (beredskabsansvarlig)

### Eksterne systemer (uden for scope)
* Outlook mødelokale-booking (ingen integration)

### Inde i systemet (funktioner)
* Registrer medarbejders ankomst
* Registrer medarbejders afgang
* Registrer gæsts ankomst (navn, firma, ansvarlig, sikkerhedsfolder)
* Registrer gæsts afgang
* Vis antal personer til stede
* Vis hvem der er ansvarlig/vært for en gæst
* Opret/rediger medarbejderstamdata
* Gem oplysninger (persistens til fil)

---

## Oversigt over use cases

| ID | Navn | Primær aktør |
|----|------|--------------|
| UC1 | Tjek medarbejder ind | Medarbejder |
| UC2 | Tjek medarbejder ud | Medarbejder |
| UC3 | Se medarbejdere til stede | Medarbejder / Beredskabsansvarlig |
| UC4 | Opret/rediger medarbejder | Administrator |
| UC5 | Registrer gæst ved ankomst | Reception |
| UC6 | Registrer gæstens afgang | Reception |
| UC7 | Marker sikkerhedsfolder udleveret | Reception |
| UC8 | Se aktuel gæsteliste | Reception / Vært |
| UC9 | Generér beredskabsliste | Beredskabsansvarlig |
| UC10 | Søg person og se status | Alle brugere |
| UC11 | Se historik/log | Administrator |

---

## UC1 – Tjek medarbejder ind

**Aktør:** Medarbejder

**Formål:** At registrere at en medarbejder er ankommet, så vedkommende fremgår som "til stede" i systemet (erstatter den fysiske smiley på "Take Care"-tavlen).

**Forudsætninger:**
- Medarbejderen findes i systemet som stamdata (jf. UC4)
- Medarbejderen er ikke allerede tjekket ind

**Trigger:** Medarbejderen ankommer til virksomheden og vælger "tjek ind" i systemet.

**Normalt forløb:**
1. Medarbejderen vælger funktionen "Tjek ind" i menuen
2. Systemet beder om medarbejderens ID/navn
3. Medarbejderen indtaster ID/navn
4. Systemet finder medarbejderen i stamdata
5. Systemet registrerer nuværende tidspunkt som ankomsttid
6. Systemet sætter medarbejderens status til "til stede"
7. Systemet bekræfter registreringen til medarbejderen

**Alternative forløb / undtagelser:**
- 4a. Medarbejderen findes ikke → systemet viser fejlbesked og returnerer til menuen
- 6a. Medarbejderen er allerede tjekket ind → systemet oplyser dette og spørger, om der i stedet skal tjekkes ud (kan evt. håndteres som en genvej til UC2)
- 3a. Ugyldigt input (fx bogstaver hvor der forventes et tal-ID) → systemet fanger fejlen (`int.TryParse` e.l.) og beder om input igen

**Efterbetingelser:** Medarbejderens status er "til stede" med et registreret ankomsttidspunkt.

---

## UC2 – Tjek medarbejder ud

**Aktør:** Medarbejder

**Formål:** At registrere at en medarbejder har forladt virksomheden.

**Forudsætninger:**
- Medarbejderen findes i systemet
- Medarbejderen er aktuelt tjekket ind

**Trigger:** Medarbejderen forlader virksomheden og vælger "tjek ud".

**Normalt forløb:**
1. Medarbejderen vælger funktionen "Tjek ud" i menuen
2. Medarbejderen indtaster ID/navn
3. Systemet finder medarbejderen og verificerer at vedkommende er tjekket ind
4. Systemet registrerer nuværende tidspunkt som afgangstid
5. Systemet sætter medarbejderens status til "ikke til stede"
6. Systemet bekræfter registreringen

**Alternative forløb / undtagelser:**
- 3a. Medarbejderen findes ikke → fejlbesked
- 3b. Medarbejderen er ikke tjekket ind i forvejen → systemet oplyser dette og foretager ingen ændring

**Efterbetingelser:** Medarbejderens status er "ikke til stede" med registreret afgangstidspunkt.

---

## UC3 – Se medarbejdere til stede

**Aktør:** Medarbejder, Beredskabsansvarlig

**Formål:** At give et hurtigt overblik over, hvilke medarbejdere der aktuelt er i huset — svarer til at kigge på "Take Care"-tavlen og se, hvor de grønne smileys hænger.

**Forudsætninger:** Der findes registrerede medarbejdere i systemet.

**Trigger:** Brugeren vælger "Se hvem er til stede" i menuen.

**Normalt forløb:**
1. Brugeren vælger funktionen
2. Systemet henter alle medarbejdere med status "til stede"
3. Systemet viser listen (navn + ankomsttidspunkt)

**Alternative forløb / undtagelser:**
- 2a. Ingen medarbejdere er til stede → systemet viser en tom liste med tydelig besked
- *Antagelse:* Listen kan evt. filtreres pr. afdeling, hvis I vælger at modellere afdelinger (jf. tavlens gruppering i Montage, Lager, Service, R&D m.fl.)

**Efterbetingelser:** Ingen ændring af data — ren visning.

---

## UC4 – Opret/rediger medarbejder

**Aktør:** Administrator (fx reception/HR)

**Formål:** At vedligeholde stamdata på medarbejdere, så de kan tjekkes ind/ud (svarer til at hænge et nyt foto op på tavlen).

**Forudsætninger:** Brugeren har adgang til administrationsdelen af systemet.

**Trigger:** En ny medarbejder skal oprettes, eller eksisterende data skal rettes.

**Normalt forløb:**
1. Administratoren vælger "Administrer medarbejdere"
2. Administratoren vælger "Opret ny" eller "Rediger eksisterende"
3. Systemet beder om nødvendige data (navn, evt. afdeling, medarbejder-ID)
4. Administratoren indtaster data
5. Systemet validerer input
6. Systemet gemmer medarbejderen

**Alternative forløb / undtagelser:**
- 5a. Ugyldigt input → systemet beder om korrektion
- 2a. Ved redigering: medarbejderen findes ikke → fejlbesked

**Efterbetingelser:** Medarbejderdata er oprettet/opdateret og persisteret.

---

## UC5 – Registrer gæst ved ankomst

**Aktør:** Reception (evt. gæsten selv, hvis I antager selvbetjening)

**Formål:** At registrere en gæsts ankomst — digital erstatning for den fysiske gæstebog ("Registrering af gæster i huset").

**Forudsætninger:** Ingen — gæster oprettes ikke som stamdata på forhånd.

**Trigger:** En gæst ankommer til receptionen.

**Normalt forløb:**
1. Receptionisten vælger "Registrer gæst"
2. Systemet beder om: gæstens navn, firma, ansvarlig medarbejder (vært), ankomsttidspunkt
3. Receptionisten indtaster oplysningerne
4. Systemet gemmer gæsten med status "til stede"
5. Systemet bekræfter registreringen

**Alternative forløb / undtagelser:**
- 3a. Værten findes ikke i medarbejderlisten → systemet advarer, men tillader evt. registrering alligevel (*antagelse — bør besluttes af teamet*)
- 3b. Et felt springes over (fx firma er ukendt) → *antagelse:* firma kan være valgfrit, øvrige felter er påkrævet

**Efterbetingelser:** Gæsten er registreret med ankomsttidspunkt og status "til stede".

---

## UC6 – Registrer gæstens afgang

**Aktør:** Reception

**Formål:** At registrere hvornår en gæst forlader virksomheden igen.

**Forudsætninger:** Gæsten er registreret som "til stede" (jf. UC5).

**Trigger:** Gæsten tjekker ud i receptionen.

**Normalt forløb:**
1. Receptionisten vælger "Tjek gæst ud"
2. Receptionisten vælger/søger gæsten på navn
3. Systemet registrerer nuværende tidspunkt som afgangstid
4. Systemet sætter gæstens status til "ikke til stede"

**Alternative forløb / undtagelser:**
- 2a. Flere gæster med samme navn (fx to gæster fra samme firma) → systemet viser en liste, så receptionisten kan vælge den rette (ses faktisk i det udleverede gæstebogseksempel)
- 2b. Gæsten findes ikke/er allerede tjekket ud → fejlbesked

**Efterbetingelser:** Gæstens afgangstidspunkt er registreret.

---

## UC7 – Marker sikkerhedsfolder udleveret

**Aktør:** Reception

**Formål:** At registrere om gæsten har fået udleveret sikkerhedsfolderen (påkrævet felt i den fysiske gæstebog, formentlig af HSE-hensyn — jf. sikkerhedstavlen).

**Forudsætninger:** Gæsten er registreret (UC5).

**Trigger:** Sikkerhedsfolderen udleveres til gæsten, evt. i forbindelse med ankomstregistrering.

**Normalt forløb:**
1. Receptionisten markerer feltet "Sikkerhedsfolder udleveret" for gæsten — enten som en del af UC5, eller separat bagefter
2. Systemet gemmer ændringen

**Alternative forløb / undtagelser:**
- 1a. Gæsten findes ikke → fejlbesked

**Efterbetingelser:** Gæstens registrering viser, at sikkerhedsfolder er udleveret.

*Bemærkning: I kan vælge at slå UC5 og UC7 sammen til ét use case, da de i praksis sker samtidigt — men de er holdt adskilt her, fordi det fremgår som en selvstændig kolonne i den fysiske gæstebog, og fordi det ikke altid sker på samme tidspunkt (jf. eksemplerne i bogen, hvor feltet nogle gange er tomt).*

---

## UC8 – Se aktuel gæsteliste

**Aktør:** Reception, Vært

**Formål:** At se hvilke gæster der aktuelt er i huset, og hvem de besøger.

**Forudsætninger:** Der er registreret mindst én gæst.

**Trigger:** Brugeren vælger "Se gæster i huset".

**Normalt forløb:**
1. Brugeren vælger funktionen
2. Systemet henter alle gæster med status "til stede"
3. Systemet viser navn, firma, vært og ankomsttidspunkt for hver

**Alternative forløb / undtagelser:**
- 2a. Ingen gæster til stede → tom liste vises

**Efterbetingelser:** Ingen ændring — ren visning.

---

## UC9 – Generér beredskabsliste

**Aktør:** Beredskabsansvarlig / AMO

**Formål:** At give et samlet overblik over ALLE personer (medarbejdere + gæster) der aktuelt er i bygningen — kritisk i en nødsituation (jf. beredskabsplanen og evakueringsplanen på sikkerhedstavlen).

**Forudsætninger:** Ingen særlige.

**Trigger:** Beredskabsansvarlig har brug for en samlet oversigt, fx ved en øvelse eller en reel hændelse.

**Normalt forløb:**
1. Brugeren vælger "Generér beredskabsliste"
2. Systemet henter alle medarbejdere med status "til stede"
3. Systemet henter alle gæster med status "til stede"
4. Systemet samler de to lister i én samlet oversigt
5. Systemet viser/udskriver listen

**Alternative forløb / undtagelser:**
- 4a. Ingen personer til stede → systemet viser en tydelig "0 personer i huset"-besked (vigtigt at dette ikke fejler i en nødsituation)

**Efterbetingelser:** Ingen ændring af data — ren visning/udtræk. *Antagelse: Da dette er en konsolapplikation, forstås "udskriv" som visning i konsolvinduet, medmindre andet aftales.*

---

## UC10 – Søg person og se status

**Aktør:** Alle brugere

**Formål:** At kunne slå en bestemt person op (medarbejder eller gæst) og se, om vedkommende er til stede.

**Forudsætninger:** Personen findes i systemet (som medarbejder-stamdata eller som en registreret gæst).

**Trigger:** Brugeren ønsker at vide, om en bestemt person er i huset.

**Normalt forløb:**
1. Brugeren vælger "Søg person"
2. Brugeren indtaster navn
3. Systemet søger blandt både medarbejdere og gæster
4. Systemet viser personens status (til stede/ikke til stede) og evt. ankomsttidspunkt

**Alternative forløb / undtagelser:**
- 3a. Personen findes ikke → systemet oplyser dette
- 3b. Flere match på samme navn → systemet viser alle match til brugeren

**Efterbetingelser:** Ingen ændring — ren visning.

---

## UC11 – Se historik/log

**Aktør:** Administrator

**Formål:** At kunne se tidligere ind-/udtjekninger, fx til statistik over besøgsmønstre eller antal gæster fra et bestemt firma.

**Forudsætninger:** Der findes historiske data (persisteret i tekstfil).

**Trigger:** Administratoren ønsker et historisk overblik.

**Normalt forløb:**
1. Administratoren vælger "Se historik"
2. Systemet indlæser tidligere registreringer fra persistenslaget
3. Systemet viser listen, evt. med mulighed for at filtrere på dato eller person

**Alternative forløb / undtagelser:**
- 2a. Ingen historik findes endnu → tom liste vises

**Efterbetingelser:** Ingen ændring — ren visning.

*Antagelse: Dette use case er placeret sidst i jeres arbejde, da persistens ifølge opgavebeskrivelsen først skal implementeres "henimod slutningen af 6-ugersperioden".*

---

## Noter til det videre arbejde
- Overvej om UC5 og UC7 skal slås sammen
- Overvej om der skal være en fælles "Person"-superklasse for Medarbejder og Gæst i jeres objektmodel, da flere use cases (UC9, UC10) arbejder på tværs af begge
- I bør selv vurdere, om afdelingsopdeling (jf. "Take Care"-tavlen) skal med i domænemodellen, eller om det er for meget scope til de 6 uger
- Alle steder markeret "*Antagelse*" skal I tage stilling til og skrive ind i jeres systemdokumentation, jf. opgavebeskrivelsens krav om at dokumentere egne antagelser
