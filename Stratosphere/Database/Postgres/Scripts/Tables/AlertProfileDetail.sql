/*
	postgres inserts

	description: 
	Child table for AlertProfile. Responsible for storing contact specific details for a given profile.
*/

create table if not exists Stratosphere.AlertProfileDetail (
	CreatedBy varchar(255) not null,
	CreatedDate timestamp not null,
	ModifiedBy varchar(255) null,
	ModifiedDate timestamp null
);