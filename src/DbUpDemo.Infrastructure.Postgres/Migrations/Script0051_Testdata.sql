select pg_advisory_xact_lock(1);

INSERT INTO dbupdemo.interestingthing (name) VALUES ('First Interesting Test Only Thing');
INSERT INTO dbupdemo.interestingthing (name) VALUES ('Second Interesting Test Only Thing');