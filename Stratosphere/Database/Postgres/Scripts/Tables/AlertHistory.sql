/*
	postgres inserts

	description: 
	Holds historical information related to alerts raised for a long term log. Useful for tracking and reporting.
*/

create table if not exists Stratosphere.AlertHistory (
	AlertHistoryId uuid not null,
	CreatedBy varchar(255) not null,
	CreatedDate timestamp not null,
	ModifiedBy varchar(255) null,
	ModifiedDate timestamp null,
	AlertProfileId uuid not null,
	AlertTime timestamp not null,
	ServiceHealthReportId uuid not null,
	AlertMessage varchar(1000) not null,
	primary key (AlertHistoryId),
	foreign key (AlertProfileId) references Stratosphere.AlertProfile(AlertProfileId),
	foreign key (ServiceHealthReportId) references Stratosphere.ServiceHealthReport(ServiceHealthReportId)
);