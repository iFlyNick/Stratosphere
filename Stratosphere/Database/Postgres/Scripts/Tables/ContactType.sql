/*
	postgres inserts

	description: 
	Simple table to store what options are available for a given contact definition.
*/

create table if not exists Stratosphere.ContactType (
	ContactTypeId uuid not null,
	CreatedBy varchar(255) not null,
	CreatedDate timestamp not null,
	ModifiedBy varchar(255) null,
	ModifiedDate timestamp null,
	Name varchar(255) not null,
	Description varchar(255) not null,
	primary key (ContactTypeId)
);