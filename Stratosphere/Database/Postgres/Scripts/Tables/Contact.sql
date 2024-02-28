/*
	postgres inserts

	description: 
	holds actual contact information for a given profile. core functionality for how to contact someone.

	notes:
	contactvalue should hold the actual contact information. this could be an email address, phone number, webhook url, etc.
*/

create table if not exists Stratosphere.Contact (
	ContactId int generated always as identity,
	Name varchar(255) not null,
	ContactTypeId int not null,
	ContactValue varchar(1000) not null,
	CreatedBy varchar(255) not null,
	CreatedDate timestamp not null,
	ModifiedBy varchar(255) null,
	ModifiedDate timestamp null,
	primary key (ContactId),
	foreign key (ContactTypeId) references Stratosphere.ContactType(ContactTypeId)
);