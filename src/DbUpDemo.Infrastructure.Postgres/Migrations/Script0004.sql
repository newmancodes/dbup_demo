select pg_advisory_xact_lock(1);

INSERT INTO dbupdemo.interestingthing (name) VALUES ('Fourth Interesting Thing');
INSERT INTO dbupdemo.interestingthing (name) VALUES ('Fifth Interesting Thing');
INSERT INTO dbupdemo.interestingthing (name) VALUES ('Sixtth Interesting Thing');