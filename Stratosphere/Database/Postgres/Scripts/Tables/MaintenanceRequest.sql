/*
	postgres inserts

	description: 
	Historical record of maintenance mode requests. These could be for planned maintenance or for emergency maintenance. 
	They could've been copied from a template or create adhoc. This doesn't store what services were in the request, 
	but rather the parent details around the request itself, why it might've been needed, and what the timeframe was.
*/

create table if not exists Stratosphere.MaintenanceRequest (
	MaintenanceRequestId int generated always as identity,
	Description varchar(1000) null,
	CompletionNote varchar(1000) null,
	StartTime timestamp not null,
	EndTime timestamp not null,
	CreatedBy varchar(255) not null,
	CreatedDate timestamp not null,
	ModifiedBy varchar(255) null,
	ModifiedDate timestamp null,
	primary key (MaintenanceRequestId)
);