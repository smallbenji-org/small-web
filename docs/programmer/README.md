*Database opssætning*

User used for ConnectionString

--Delete ApplcationAccess
--DROP ROLE ApplicationAccess

CREATE ROLE ApplicationAccess WITH
    LOGIN
    PASSWORD 'strongpassword';

GRANT CONNECT ON DATABASE smallweb TO ApplicationAccess;

GRANT EXECUTE ON ALL FUNCTIONS IN SCHEMA public TO ApplicationAccess;



