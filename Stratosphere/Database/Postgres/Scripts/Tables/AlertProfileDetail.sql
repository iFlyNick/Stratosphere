/*
	postgres inserts

	description: 
	Child table for AlertProfile. Responsible for storing contact specific details for a given profile.
*/

create table if not exists Stratosphere.AlertProfileDetail (
	AlertProfileId int not null,
	ContactId int not null,
	CreatedBy varchar(255) not null,
	CreatedDate timestamp not null,
	ModifiedBy varchar(255) null,
	ModifiedDate timestamp null,
	primary key (AlertProfileId, ContactId),
	foreign key (AlertProfileId) references Stratosphere.AlertProfile(AlertProfileId),
	foreign key (ContactId) references Stratosphere.Contact(ContactId)
);