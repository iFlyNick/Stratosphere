/*
	postgres inserts

	description: 
	Parent table for AlertProfileDetail. This holds high level information around the purpose of an alert but not
	the specifics of the alert parties themselves.
*/

create table if not exists Stratosphere.AlertProfile (
	AlertProfileId uuid not null,
	CreatedBy varchar(255) not null,
	CreatedDate timestamp not null,
	ModifiedBy varchar(255) null,
	ModifiedDate timestamp null,
	Name varchar(255) not null,
	Description varchar(255) not null,
	primary key (AlertProfileId)
);