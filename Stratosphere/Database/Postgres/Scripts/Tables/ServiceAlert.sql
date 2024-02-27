/*
	postgres inserts

	description: 
	relates to the service table and is reponsible for tracking what alerts trigger for a given service
*/

create table if not exists Stratosphere.ServiceAlert (
	ServiceId nvarchar(255) not null,
	AlertProfileId nvarchar(255) not null,
	CreatedBy varchar(255) not null,
	CreatedDate timestamp not null,
	ModifiedBy varchar(255) null,
	ModifiedDate timestamp null,
	primary key (ServiceId, AlertProfileId),
	foreign key (ServiceId) references Stratosphere.Service(ServiceId),
	foreign key (AlertProfileId) references Stratosphere.AlertProfile(AlertProfileId)
);