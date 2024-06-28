/*
	postgres inserts

	description: 
	Historical record of what individual services were part of a maintenance request. These should not be tied
	to templates as users can create a maintenance request from scratch. Templates are provided for convenience.

	This table will be key in knowing what services to re-activate when a request has been completed. long term 
	history of this data should be kept in a separate table as details related to these services could be modified
	over time.

*/

create table if not exists Stratosphere.MaintenanceRequestDetail (
	MaintenanceRequestDetailId int generated always as identity,
	MaintenanceRequestId uuid not null,
	CreatedBy varchar(255) not null,
	CreatedDate timestamp not null,
	ModifiedBy varchar(255) null,
	ModifiedDate timestamp null,
	ServiceId uuid not null,
	EnvironmentId uuid not null,
	StartOrder int not null,
	StopOrder int not null,
	WaitForQueueClearOnStart boolean not null default false,
	WaitForQueueClearOnStop boolean not null default false,
	primary key (MaintenanceRequestDetailId, MaintenanceRequestId),
	foreign key (MaintenanceRequestId) references Stratosphere.MaintenanceRequest(MaintenanceRequestId),
	foreign key (ServiceId) references Stratosphere.Service(ServiceId),
	foreign key (EnvironmentId) references Stratosphere.Environment(EnvironmentId)
);