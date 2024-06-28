/*
	postgres inserts

	description: 
	core functionality to track services. responsible for most of the details of a given service.
*/

create table if not exists Stratosphere.Service (
	ServiceId uuid not null,
	CreatedBy varchar(255) not null,
	CreatedDate timestamp not null,
	ModifiedBy varchar(255) null,
	ModifiedDate timestamp null,
	ServiceName varchar(255) null,
	ServiceDescription varchar(4000) null,
	ServiceTypeId uuid not null,
	primary key (ServiceId),
	foreign key (ServiceTypeId) references Stratosphere.ServiceType(ServiceTypeId)
);