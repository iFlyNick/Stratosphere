/*
	postgres inserts

	description: 
	Simple table to store what options are supported for how a service operates. mainly server information.
*/

create table if not exists Stratosphere.Environment (
	EnvironmentId int generated always as identity,
	Name varchar(255) not null,
	CreatedBy varchar(255) not null,
	CreatedDate timestamp not null,
	ModifiedBy varchar(255) null,
	ModifiedDate timestamp null,
	primary key (EnvironmentId)
);