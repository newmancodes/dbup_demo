select pg_advisory_xact_lock(1);

INSERT INTO dbupdemo.interestingthing (name) VALUES ('First Interesting Thing');
INSERT INTO dbupdemo.interestingthing (name) VALUES ('Second Interesting Thing');
INSERT INTO dbupdemo.interestingthing (name) VALUES ('Third Interesting Thing');