/*
	postgres inserts

	description: 
	Simple table to store what options are supported for how a service operates. mainly server information.
*/

create table if not exists Stratosphere.Asset (
	CreatedBy varchar(255) not null,
	CreatedDate timestamp not null,
	ModifiedBy varchar(255) null,
	ModifiedDate timestamp null
);