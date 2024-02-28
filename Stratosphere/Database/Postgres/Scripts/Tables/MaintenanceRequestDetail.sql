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
	MaintenanceRequestId int not null,
	ServiceId int not null,
	EnvironmentId int not null,
	AssetId int not null,
	StopTime timestamp not null,
	StartTime timestamp not null,
	primary key (MaintenanceRequestId, ServiceId, EnvironmentId, AssetId),
	foreign key (MaintenanceRequestId) references Stratosphere.MaintenanceRequest(MaintenanceRequestId),
	foreign key (ServiceId) references Stratosphere.Service(ServiceId),
	foreign key (EnvironmentId) references Stratosphere.Environment(EnvironmentId),
	foreign key (AssetId) references Stratosphere.Asset(AssetId)
);