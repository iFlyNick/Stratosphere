/*
	postgres inserts

	description: 
	historical information of an implementation for a maintenance mode request. this tracks actual responses and execution details for a given request.
*/

create table if not exists Stratosphere.MaintenanceRequestDetailHistory (
	MaintenanceRequestDetailHistoryId int generated always as identity,
	MaintenanceRequestDetailId int not null,
	MaintenanceRequestId uuid not null,
	CreatedBy varchar(255) not null,
	CreatedDate timestamp not null,
	ModifiedBy varchar(255) null,
	ModifiedDate timestamp null,
	ServiceId uuid not null,
	EnvironmentId uuid not null,
	AssetId uuid not null,
	ExecutionTime timestamp not null,
	Action varchar(50) not null, --stop/start
	IsSuccess boolean default false,
	StatusMessage varchar(1000) null,
	primary key (MaintenanceRequestDetailHistoryId, MaintenanceRequestDetailId, MaintenanceRequestId),
	foreign key (MaintenanceRequestId) references Stratosphere.MaintenanceRequest(MaintenanceRequestId),
	foreign key (MaintenanceRequestDetailId, MaintenanceRequestId) references Stratosphere.MaintenanceRequestDetail(MaintenanceRequestDetailId, MaintenanceRequestId),
	foreign key (ServiceId) references Stratosphere.Service(ServiceId),
	foreign key (EnvironmentId) references Stratosphere.Environment(EnvironmentId),
	foreign key (AssetId) references Stratosphere.Asset(AssetId)
);