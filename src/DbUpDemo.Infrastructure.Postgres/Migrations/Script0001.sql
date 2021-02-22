select pg_advisory_xact_lock(1);

create schema dbupdemo;

create table dbupdemo.interestingthing
(
	id			serial		not null	constraint interestingthing_pk	primary key,
	name		text		not null
);

alter table dbupdemo.interestingthing
	owner to dbup_demo_u;