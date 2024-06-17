#dokumentacija

# Tema Projekta

Projekt API-ja za Rent a Car System pruža rešenje za upravljanje svim aspektima rentiranja vozila. API omogućava administratorima i zaposlenima u rent a car kompaniji da lako vode evidenciju i upravljaju operacijama.

Administratorski deo API-ja pruža sveobuhvatan set funkcionalnosti za upravljanje rezervacijama, evidencijom vozila, zakazanim terminima i servisiranjem vozila.

Klijentski deo API-ja omogućava korisnicima da pristupe informacijama o dostupnim vozilima, izvrše rezervaciju prema svojim potrebama i ostave povratne informacije nakon korišćenja vozila. Ovo omogućava korisnicima da imaju kontrolu i doprinesu unapređenju usluga kroz svoje iskustvo.

# Kredencijali

- Email: admin@example.com 
  Password: StrongP@ssw0rd
- Email: user@example.com 
  Password: StrongP@ssw0rd

# Use Cases

Sve komande u sistemu su podvrgnute validacionoj proveri. Ključni aspekti uključuju proveru pri kreiranju bookinga, gde se automobil ne može rezervisati ako je već zauzet u datom vremenskom opsegu - bilo da je rezervisan od strane drugog korisnika ili je na servisu. Takođe, korisnik koji ima aktivan booking ne može zakazati novi sve dok trenutni nije završen ili otkazan. Slična provera se vrši i prilikom servisiranja vozila, gde se prilikom vraćanja vozila proverava kilometraža da nije ista ili manja od prethodne, a zatim se ažurira kilometraža vozila.

## Admin

- **Audit Log**: Administrator ima uvid u sve aktivnosti, sa mogućnošću filtriranja i pretrage na osnovu identiteta i opsega datuma.
- **Booking**: Administrator ima uvid u sve termine, bilo kog statusa. Kada klijent dođe po auto, administrator menja status bookinga u "In Progress". Prilikom vraćanja automobila, unosi se nova kilometraža koja nije ista ili manja od kilometraže pri rezervaciji. Administrator može da obriše, pregleda detalje ili otkaže booking.
- **Brand**: Marka vozila. Administrator može da dodaje, briše, izmeni marke vozila i da pregleda koliko automobila ima za datu marku.
- **Model**: Oznaka automobila. Administrator može da manipuliše modelima automobila kao i brendovima.
- **Automobili**: Administrator može da dodaje, briše, menja cene automobila, sa uvidom u sve automobile sa ocenama i specifikacijama.
- **Services**: Administrator može da dodaje, briše i menja servise. Takođe, ima uvid u evidenciju kada je koji automobil na servisu.
- **Users**: Administrator ima evidenciju svih korisnika sistema i može da ih briše.

## Korisnik

- **Car**: Korisnik ima uvid u sve automobile sa svim detaljima, ocenama i specifikacijama. Nakon termina, može da ostavi ocenu i komentar za korišćeno vozilo.
- **Booking**: Korisnik može da zakazuje i otkazuje booking, uz mogućnost dodavanja dodatne opreme uz koju se obračunava dodatna cena. Takođe, ima uvid u svoje bookinge.
- **User**: Korisnik može da obriše svoj profil i izvrši update.

## Neautorizovani

- **Car**: Pregled svih automobila.
- **Brand**: Pregled svih marki vozila.
- **Model**: Pregled svih modela vozila.
- **Profile**: Kreiranje profila.
- **Auth**: Mogućnost ulogovanja.



