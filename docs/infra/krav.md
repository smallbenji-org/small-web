# Defensive Security
---
- [ ] HAK-FK-17-176: Systemet skal have rate-limiting pr. IP/klient og pr. endpoint.
- [ ] HAK-NF-15-164: Blokerede SQLi-forsøg skal fremgå i central log/SIEM inden for 1 minut.
- [ ] HAK-NF-16-174: CSP-violations skal logges og rapporteres i SIEM inden for 1 minut.
- [ ] HAK-NF-17-183: Angrebsindikatorer (spikes i RPS, 429/403) skal alarmeres til drift/SOC inden for 30 sek.
- [ ] HAK-NF-17-184: Systemet skal kunne absorbere mindst 10× normal trafik uden total nedetid via WAF/LB/cache.

# SOC/SIEM
---
- [ ] SOC-13-FK-085: SOC skal kunne iværksætte afværgeforanstaltninger (fx blokering via WAF/firewall).
- [ ] SOC-12-NF-083: Alarmer skal være tilgængelige for SOC senest 30 sekunder efter registrering.
- [ ] SOC-12-NF-084: Alarmer må ikke overses (skal logges centralt og markeres som “behandlet”).
- [ ] SOC-12-FK-081: Systemet skal generere alarmer baseret på definerede sikkerhedsmønstre.
- [ ] SOC-12-FK-082: Alarmer skal kategoriseres efter alvorlighed.
- [ ] SOC-11-FK-076: Systemet skal indsamle logs fra servere, services og applikationen.
- [ ] SOC-11-FK-077: Logs skal sendes til et centralt system.
- [ ] SOC-11-FK-078: Logs skal gemmes i minimum 30 dage.
- [ ] SOC-11-NF-079: Logs skal overføres krypteret.
- [ ] SOC-11-NF-080: Logs skal være søgbare inden for 1 minut efter de er oprettet.

# Documentation
---
- [x] INF-10-FK-068: Infrastruktur skal dokumentere netværksantologi (netværksdiagram).
- [x] INF-10-FK-069: Infrastruktur skal dokumentere komponent- og deployment-diagrammer.
- [ ] INF-10-FK-070: Infrastruktur skal dokumentere driftprocesser (deployment, overvågning, backup).

# Documentation System
---
- [x] DIN-06-FK-050: Dokumentationen skal være tilgængelig for alle aktører i projektet (f.eks. i Git-repo).

# Logging
---
- [x] INF-08-FK-059: Systemet skal overvåge servere og services.
- [x] INF-08-NF-061: Overvågning skal ske med maks. 1 minuts forsinkelse.
- [ ] INF-08-FK-060: Systemet skal generere alarmer ved fejl, nedbrud eller ressourceoverskridelse.
- [ ] INF-08-NF-062: Alarmer skal være tilgængelige for drift/SOC senest 30 sekunder efter fejl registreres.

# Deployment
---
- [x] INF-07-FK-055: Systemet skal understøtte zero downtime deployment.
- [x] INF-07-FK-056: Deployment-processen skal have en rollback-mekanisme.
- [x] INF-07-NF-058: Rollback skal kunne gennemføres på under 2 minutter.

# Statistik
---
- [ ] MAR-04-FK-029: Systemet skal indsamle og gemme data om sidevisninger.
- [ ] MAR-04-FK-030: Systemet skal vise simple rapporter (fx mest besøgte sider, hyppige søgeord).
- [ ] MAR-04-FK-031: Systemet skal give mulighed for at filtrere rapporter efter periode (fx dag/uge/måned).
- [ ] MAR-04-NF-032: Statistik skal være tilgængelig uden at påvirke performance for Visitors.
- [ ] MAR-04-NF-033: Statistikdata skal opdateres mindst én gang i timen.
- [ ] MAR-04-NF-034: Statistikvisningen skal kun være tilgængelig via HTTPS og kræve autentifikation.
- [ ] MAR-04-NF-035: Statistikmodulet skal ikke påvirke hjemmesidens Lighthouse score (100 i alle kategorier).