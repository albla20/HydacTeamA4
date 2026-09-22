# Use cases – Komme/gå-system til HYDAC

## Afgrænsning af systemet

### Uden for systemet (aktører)
* Medarbejdere
* Gæster
* Adminstrator

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

---

## Oversigt over use cases

| ID | Navn | Primær aktør |
|----|------|--------------|
| UC1 | Tjek medarbejder ind | Medarbejder |
| UC2 | Tjek medarbejder ud | Medarbejder |
| UC3 | Se personer "til stede" | Alle brugere 
| UC4 | Opret/rediger medarbejder | Administrator |
| UC5 | Registrer gæst ved ankomst | Medarbejder |
| UC6 | Registrer gæstens afgang | Medarbejder |
| UC7 | Marker sikkerhedsfolder udleveret | Medarbejder |
| UC8 | Søg person og se status | Alle brugere |



---

## UC1 – Tjek medarbejder ind

**Aktør:** Medarbejder

**Mål:** At registrere at en medarbejder er ankommet, så vedkommende fremgår som "til stede" i systemet.

**Forudsætninger:**
- Medarbejderen er logget ind.
- Medarbejderen findes i systemet som stamdata.
- Medarbejderen er ikke allerede tjekket ind.

**Hovedscenarie:**
1. Medarbejderen vælger funktionen "Tjek ind" i menuen
2. Systemet beder om medarbejderens ID/navn
3. Medarbejderen indtaster ID/navn
4. Systemet finder medarbejderen i stamdata
5. Systemet registrerer nuværende tidspunkt som ankomsttid
6. Systemet sætter medarbejderens status til "til stede"
7. Systemet bekræfter registreringen til medarbejderen

---

## UC2 – Tjek medarbejder ud

**Aktør:** Medarbejder

**Mål:** At registrere at en medarbejder har forladt virksomheden.

**Forudsætninger:**
- Medarbejderen er logget ind.
- Medarbejderen findes i systemet
- Medarbejderen er aktuelt tjekket ind

**Hovedscenarie:**
1. Medarbejderen vælger funktionen "Tjek ud" i menuen
2. Medarbejderen indtaster ID/navn
3. Systemet finder medarbejderen og verificerer at vedkommende er tjekket ind
4. Systemet registrerer nuværende tidspunkt som afgangstid
5. Systemet sætter medarbejderens status til "ikke til stede"
6. Systemet bekræfter registreringen

---

## UC3 – Se personer "til stede"

**Aktør:** Alle brugere

**Mål:** At give et hurtigt overblik over, hvilke medarbejdere/gæster der aktuelt er i huset.

**Forudsætninger:**
- Ingen

**Hovedscenarie:**
1. Brugeren vælger funktionen "Se hvem er til stede"
2. Systemet henter alle medarbejdere/gæster med status "til stede"
3. Systemet viser listen (navn + ankomsttidspunkt)

---

## UC4 – Opret/rediger medarbejder

**Aktør:** Administrator

**Mål:** At vedligeholde stamdata på medarbejdere, så de kan tjekkes ind/ud.

**Forudsætninger:**
- Brugeren har adgang til administrationsdelen af systemet

**Hovedscenarie:**
1. Administratoren vælger "Administrer medarbejdere"
2. Administratoren vælger "Opret ny" eller "Rediger eksisterende"
3. Systemet beder om nødvendige data (navn, evt. afdeling, medarbejder-ID)
4. Administratoren indtaster data
5. Systemet validerer input
6. Systemet gemmer medarbejderen

---

## UC5 – Registrer gæst ved ankomst

**Aktør:** Medarbejder

**Mål:** At registrere en gæsts ankomst.

**Forudsætninger:**
- Medarbejderen er logget ind.
- Medarbejderen findes i systemet
- Medarbejderen er aktuelt tjekket ind

**Hovedscenarie:**
1. Medarbejder vælger "Registrer gæst"
2. Systemet beder om: gæstens navn, firma,ankomsttidspunkt
3. Medarbejder indtaster oplysningerne
4. Systemet gemmer gæsten med status "til stede"
5. Systemet bekræfter registreringen

---

## UC6 – Registrer gæstens afgang

**Aktør:** Medarbejder

**Mål:** At registrere hvornår en gæst forlader virksomheden igen.

**Forudsætninger:**
- Medarbejderen er logget ind.
- Medarbejderen findes i systemet
- Medarbejderen er aktuelt tjekket ind
- Gæsten er registreret som "til stede"

**Hovedscenarie:**
1. Medarbejder vælger "Tjek gæst ud"
2. Systemet víser "gæster du har ansvaret for"
3. Medarbejder vælger "Gæst på navn"
4. Medarbejder vælger "Tjek gæst ud"
5. Systemet registrerer nuværende tidspunkt som afgangstid
6. Systemet sætter gæstens status til "ikke til stede"

---

## UC7 – Marker sikkerhedsfolder udleveret

**Aktør:** Medarbejder

**Mål:** At registrere om gæsten har fået udleveret sikkerhedsfolderen.

**Forudsætninger:**
- Medarbejderen er logget ind.
- Medarbejderen findes i systemet
- Medarbejderen er aktuelt tjekket ind
- Gæsten er registreret.

**Hovedscenarie:**
1. Medarbejder søger efter gæsten i systemet.
2. Systemet viser gæsten på listen.
2. Medarbejder markerer feltet "Sikkerhedsfolder udleveret" for gæsten.
3. Systemet gemmer ændringen

---


## UC8 – Søg person og se status

**Aktør:** Alle brugere

**Mål:** At kunne slå en bestemt person op (medarbejder eller gæst) og se, om vedkommende er til stede.

**Forudsætninger:**
- Personen findes i systemet.

**Hovedscenarie:**
1. Brugeren vælger "Søg person"
2. Brugeren indtaster navn
3. Systemet søger blandt både medarbejdere og gæster
4. Systemet viser personens status (til stede/ikke til stede) og evt. ankomsttidspunkt

---
