/*
	postgres inserts

	description: 
	child to MaintenanceTemplate. this holds the details specific to which services specifically are being managed
	through the core template.

	notes:
	MaintenanceRequestId is a grouping value for a given request. since templates can be reused, they will need some id
	to group them together in this table, and as a reference to the history table.
*/

create table if not exists Stratosphere.MaintenanceTemplateDetail (
	MaintenanceTemplateId int not null,
	ServiceId int not null,
	EnvironmentId int not null,
	StartOrder int not null,
	StopOrder int not null,
	WaitForQueueClearOnStart boolean not null default false,
	WaitForQueueClearOnStop boolean not null default false,
	CreatedBy varchar(255) not null,
	CreatedDate timestamp not null,
	ModifiedBy varchar(255) null,
	ModifiedDate timestamp null,
	primary key (MaintenanceTemplateId, ServiceId, EnvironmentId),
	foreign key (MaintenanceTemplateId) references Stratosphere.MaintenanceTemplate(MaintenanceTemplateId),
	foreign key (ServiceId) references Stratosphere.Service(ServiceId),
	foreign key (EnvironmentId) references Stratosphere.Environment(EnvironmentId)
);