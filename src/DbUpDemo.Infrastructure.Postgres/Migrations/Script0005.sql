select pg_advisory_xact_lock(1);

UPDATE dbupdemo.interestingthing
SET name = 'Sixth Interesting Thing'
WHERE name = 'Sixtth Interesting Thing';