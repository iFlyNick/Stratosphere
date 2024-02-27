/*
	postgres inserts

	description: 
	Base information around supported service types. ie) Docker, IIS Application, Windows Service, etc.
*/

create table if not exists Stratosphere.ServiceType (
	ServiceTypeId int generated always as identity,
	Name varchar(255) not null,
	CreatedBy varchar(255) not null,
	CreatedDate timestamp not null,
	ModifiedBy varchar(255) null,
	ModifiedDate timestamp null,
	primary key (ServiceTypeId)
);