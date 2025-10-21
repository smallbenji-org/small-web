# Defensive Security
---
- [ ] HAK-FK-17-176: Systemet skal have rate-limiting pr. IP/klient og pr. endpoint.
- [ ] HAK-FK-17-177: WAF/LB skal have volumetriske regler (burst, connections/sec) samt geo/ASN-blokering.
- [ ] HAK-FK-17-181: IP- eller token-baseret “quarantine” skal kunne aktiveres midlertidigt.
- [ ] HAK-FK-15-162: WAF/LB skal blokere kendte SQLi-mønstre (fx UNION SELECT, comments, tautologier).
- [ ] HAK-NF-15-164: Blokerede SQLi-forsøg skal fremgå i central log/SIEM inden for 1 minut.
- [ ] HAK-NF-16-174: CSP-violations skal logges og rapporteres i SIEM inden for 1 minut.
- [ ] HAK-NF-17-183: Angrebsindikatorer (spikes i RPS, 429/403) skal alarmeres til drift/SOC inden for 30 sek.
- [ ] HAK-NF-17-184: Systemet skal kunne absorbere mindst 10× normal trafik uden total nedetid via WAF/LB/cache.

# SOC/SIEM
---
- [ ] SOC-13-FK-085: SOC skal kunne iværksætte afværgeforanstaltninger (fx blokering via WAF/firewall). (dækker: SOC-13-UC01)
- [ ] SOC-12-NF-083: Alarmer skal være tilgængelige for SOC senest 30 sekunder efter registrering. (dækker: SOC-12-UC01)
- [ ] SOC-12-NF-084: Alarmer må ikke overses (skal logges centralt og markeres som “behandlet”). (dækker: SOC-12-UC01)
- [ ] SOC-12-FK-081: Systemet skal generere alarmer baseret på definerede sikkerhedsmønstre. (dækker: SOC-12-UC01)
- [ ] SOC-12-FK-082: Alarmer skal kategoriseres efter alvorlighed. (dækker: SOC-12-UC01)
- [ ] SOC-11-FK-076: Systemet skal indsamle logs fra servere, services og applikationen. (dækker: SOC-11-UC01)
- [ ] SOC-11-FK-077: Logs skal sendes til et centralt system. (dækker: SOC-11-UC01)
- [ ] SOC-11-FK-078: Logs skal gemmes i minimum 30 dage. (dækker: SOC-11-UC01)
- [ ] SOC-11-NF-079: Logs skal overføres krypteret. (dækker: SOC-11-UC01)
- [ ] SOC-11-NF-080: Logs skal være søgbare inden for 1 minut efter de er oprettet. (dækker: SOC-11-UC01)

# Documentation
---
- [ ] INF-10-FK-068: Infrastruktur skal dokumentere netværksantologi (netværksdiagram). (dækker: INF-10-UC01)
- [ ] INF-10-FK-069: Infrastruktur skal dokumentere komponent- og deployment-diagrammer. (dækker: INF-10-UC02)
- [ ] INF-10-FK-070: Infrastruktur skal dokumentere driftprocesser (deployment, overvågning, backup). (dækker: INF-10-UC02, INF-10-UC03)
- [ ] INF-10-FK-071: Infrastruktur skal bruge et Kanban board til planlægning af tasks. (dækker: INF-10-UC04)
- [ ] INF-10-FK-072: Alle infrastruktur-tasks på Kanban boardet skal kunne henføres til et eller flere krav i kravspecifikationen. (dækker: INF-10-UC04)
- [ ] INF-10-FK-068: Infrastruktur skal dokumentere netværksantologi (netværksdiagram). (dækker: INF-10-UC01)
- [ ] INF-10-FK-069: Infrastruktur skal dokumentere komponent- og deployment-diagrammer. (dækker: INF-10-UC02)
- [ ] INF-10-FK-070: Infrastruktur skal dokumentere driftprocesser (deployment, overvågning, backup). (dækker: INF-10-UC02, INF-10-UC03)
- [ ] INF-10-FK-071: Infrastruktur skal bruge et Kanban board til planlægning af tasks. (dækker: INF-10-UC04)
- [ ] INF-10-FK-072: Alle infrastruktur-tasks på Kanban boardet skal kunne henføres til et eller flere krav i kravspecifikationen. (dækker: INF-10-UC04)

# Documentation System
---
- [ ] DIN-06-FK-048: Teamet skal føre en oversigt over, hvilke krav der er opfyldt af systemet. (dækker: DIN-06-UC02)
- [ ] DIN-06-FK-049: Dokumentationen skal løbende opdateres, når systemet ændres. (dækker: DIN-06-UC01, DIN-06-UC02)
- [ ] DIN-06-FK-050: Dokumentationen skal være tilgængelig for alle aktører i projektet (f.eks. i Git-repo). (dækker: DIN-06-UC01, DIN-06-UC02)
- [ ] DIN-06-NF-051: Dokumentationen skal være enkel, kortfattet og konsistent i struktur (max ½ side per beslutning). (dækker: DIN-06-UC01, DIN-06-UC02)
- [ ] DIN-06-NF-052: Oversigten over krav skal opdateres mindst én gang per iteration/sprint. (dækker: DIN-06-UC02)
- [ ] DIN-06-NF-053: Dokumentationen skal være versionsstyret (gemmes i Git). (dækker: DIN-06-UC01, DIN-06-UC02)
- [ ] DIN-06-NF-054: Processen for dokumentation må ikke forsinke udvikling/udrulning væsentligt (maks. 10 min. pr. arkitekturvalg). (dækker: DIN-06-UC01)

# Backup
---
- [ ] INF-09-NF-066: Backup skal tages mindst én gang i døgnet. (dækker: INF-09-UC01)
- [ ] INF-09-NF-067: Backup skal testes mindst én gang om ugen. (dækker: INF-09-UC01)
- [ ] INF-09-FK-063: Systemet skal tage regelmæssige backups af kode og data. (dækker: INF-09-UC01)
- [ ] INF-09-FK-064: Systemet skal understøtte restore/gendannelse fra backup. (dækker: INF-09-UC01, INF-09-UC02)
- [ ] INF-09-FK-065: Backup-processen skal testes regelmæssigt. (dækker: INF-09-UC01)

# Logging
---
- [ ] INF-08-FK-059: Systemet skal overvåge servere og services. (dækker: INF-08-UC01)
- [ ] INF-08-FK-060: Systemet skal generere alarmer ved fejl, nedbrud eller ressourceoverskridelse. (dækker: INF-08-UC02)
- [ ] INF-08-NF-061: Overvågning skal ske med maks. 1 minuts forsinkelse. (dækker: INF-08-UC01)
- [ ] INF-08-NF-062: Alarmer skal være tilgængelige for drift/SOC senest 30 sekunder efter fejl registreres. (dækker: INF-08-UC02)

# Deployment
---
- [ ] INF-07-FK-055: Systemet skal understøtte zero downtime deployment. (dækker: INF-07-UC01)
- [ ] INF-07-FK-056: Deployment-processen skal have en rollback-mekanisme. (dækker: INF-07-UC01, INF-07-UC02)
- [ ] INF-07-NF-057: Deployment skal kunne gennemføres på under 5 minutter. (dækker: INF-07-UC01)
- [ ] INF-07-NF-058: Rollback skal kunne gennemføres på under 2 minutter. (dækker: INF-07-UC02)

# Statistik
---
- [ ] MAR-04-FK-029: Systemet skal indsamle og gemme data om sidevisninger. (dækker: MAR-04-UC01)
- [ ] MAR-04-FK-030: Systemet skal vise simple rapporter (fx mest besøgte sider, hyppige søgeord). (dækker: MAR-04-UC01)
- [ ] MAR-04-FK-031: Systemet skal give mulighed for at filtrere rapporter efter periode (fx dag/uge/måned). (dækker: MAR-04-UC01, MAR-04-UC02)
- [ ] MAR-04-NF-032: Statistik skal være tilgængelig uden at påvirke performance for Visitors. (dækker: MAR-04-UC01)
- [ ] MAR-04-NF-033: Statistikdata skal opdateres mindst én gang i timen. (dækker: MAR-04-UC01)
- [ ] MAR-04-NF-034: Statistikvisningen skal kun være tilgængelig via HTTPS og kræve autentifikation. (dækker: MAR-04-UC01)
- [ ] MAR-04-NF-035: Statistikmodulet skal ikke påvirke hjemmesidens Lighthouse score (100 i alle kategorier). (dækker: MAR-04-UC01)