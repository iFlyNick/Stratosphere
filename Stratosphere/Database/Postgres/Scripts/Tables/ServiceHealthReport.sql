/*
	postgres inserts

	description: 
	parent table for ServiceHealthHistoryReport. this table is responsible for the overall status of a service that
	has been reported. additional detail reported will be stored in the child table. similar to the queuesnapshot table, 
	this table will need to smartly managed to keep footprint low.
*/

create table if not exists Stratosphere.ServiceHealthReport (
	ServiceHealthReportId uuid not null,
	CreatedBy varchar(255) not null,
	CreatedDate timestamp not null,
	ModifiedBy varchar(255) null,
	ModifiedDate timestamp null,
	ServiceId uuid not null,
	EnvironmentId uuid not null,
	AssetId uuid not null,
	HealthStatusTypeId uuid not null,
	primary key (ServiceHealthReportId),
	foreign key (ServiceId) references Stratosphere.Service(ServiceId),
	foreign key (EnvironmentId) references Stratosphere.Environment(EnvironmentId),
	foreign key (AssetId) references Stratosphere.Asset(AssetId),
	foreign key (HealthStatusTypeId) references Stratosphere.HealthStatusType(HealthStatusTypeId)
);