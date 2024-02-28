/*
	sqlserver inserts

	description: 
	Historical record of maintenance mode requests. These could be for planned maintenance or for emergency maintenance. 
	They could've been copied from a template or create adhoc. This doesn't store what services were in the request, 
	but rather the parent details around the request itself, why it might've been needed, and what the timeframe was.
*/

create table [Stratosphere].[MaintenanceRequest] (
	[CreatedBy] varchar(255) not null,
	[CreatedDate] datetime2(7) not null,
	[ModifiedBy] varchar(255) null,
	[ModifiedDate] datetime2(7) null
);