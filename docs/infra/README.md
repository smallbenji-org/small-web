# Infra docs

## IP overview
| Device/service     | Hostname     | IP             |
|--------------------|--------------|----------------|
| PF sense           | voldemort    | 192.168.69.1   |
| Switch             | sw0          | 192.168.69.2   |
| Benjamin           | <CLIENT>     | 192.168.69.3   |
| Simon              | <CLIENT>     | 192.168.69.4   |
| Silas              | <CLIENT>     | 192.168.69.5   |
| Thomas             | <CLIENT>     | 192.168.69.6   |
| Emil               | <CLIENT>     | 192.168.69.7   |
| Harry (Proxmox)    | harry        | 192.168.69.10  |
| Hermione (Proxmox) | hermione     | 192.168.69.11  |
| Ron (Proxmox)      | ron          | 192.168.69.12  |
| Harry (BMC)        | harry-bmc    | 192.168.69.20  |
| Hermione (BMC)     | hermione-bmc | 192.168.69.21  |
| Ron (BMC)          | ron-bmc      | 192.168.69.22  |
| NTP Server         | ntp          | 192.168.69.30  |
| Logs               | logs         | 192.168.69.31  |
| GoAccess           |              | 192.168.69.32  |
| HAProxy            |              | 192.168.69.33  |
| Keycloak           |              | 192.168.69.40  |
| Web0               | web0         | 192.168.69.100 |
| Web1               | web1         | 192.168.69.101 |
| Web2               | web2         | 192.168.69.102 |
| Web3               | web3         | 192.168.69.103 |
| Web4               | web4         | 192.168.69.104 |
| Web5               | web5         | 192.168.69.105 |
| Web6               | web6         | 192.168.69.106 |
| Web7               | web7         | 192.168.69.107 |
| Web8               | web8         | 192.168.69.108 |
| db0                | db0          | 192.168.69.110 |
| db1                | db1          | 192.168.69.111 |
| db2                | db2          | 192.168.69.112 |
| minio0             | minio0       | 192.168.69.120 |
| minio1             | minio1       | 192.168.69.121 |
| minio2             | minio2       | 192.168.69.122 |
| Safeline (WAF)     | safeline     | 192.168.69.130 |
| Tailscale          | tailscale    | 192.168.69.131 |
| PostgreSQL (TEST)  | db-test      | 192.168.69.150 |
| Minio (TEST)       | minio-test   | 192.168.69.151 |

DHCP range 192.168.69.200-255/24

Gateway ip: 192.168.69.1

DNS server: 192.168.69.1

## Server roles
__WEB0-8__
* Run kubernetes
* 0, 3, 6 is the control-panels and masters
__DB0-2__
* Runs Postgresql and MSSQL
