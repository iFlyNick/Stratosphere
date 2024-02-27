/*
	postgres inserts

	description: 
	core functionality to track services. responsible for most of the details of a given service.
*/

create table if not exists Stratosphere.Service (
	ServiceId nvarchar(255) not null,
	ServiceName nvarchar(255) null,
	ServiceDescription nvarchar(4000) null,
	ServiceTypeId int not null,
	CreatedBy varchar(255) not null,
	CreatedDate timestamp not null,
	ModifiedBy varchar(255) null,
	ModifiedDate timestamp null,
	primary key (ServiceId, ServiceTypeId),
	foreign key (ServiceTypeId) references Stratosphere.ServiceType(ServiceTypeId)
);