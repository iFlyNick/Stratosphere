/*
	postgres inserts

	description: 
	child to ServiceHealthReport. this holds the details of the health Report for a given service past the basic report.
	examples of additional detail could be the specifics around errors, or reasons the service was down.
*/

create table if not exists Stratosphere.ServiceHealthReportDetail (
	ServiceHealthReportDetailId int generated always as identity,
	CreatedBy varchar(255) not null,
	CreatedDate timestamp not null,
	ModifiedBy varchar(255) null,
	ModifiedDate timestamp null,
	ServiceHealthReportId uuid not null,
	Message varchar(4000) null,
	primary key (ServiceHealthReportDetailId),
	foreign key (ServiceHealthReportId) references Stratosphere.ServiceHealthReport(ServiceHealthReportId)
);