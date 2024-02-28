/*
	postgres inserts

	description: 
	Historical record of what individual services were part of a maintenance request. These should not be tied
	to templates as users can create a maintenance request from scratch. Templates are provided for convenience.

	This table will be key in knowing what services to re-activate when a request has been completed. long term 
	history of this data should be kept in a separate table as details related to these services could be modified
	over time.
*/

create table [Stratosphere].[MaintenanceRequestDetail] (
	[CreatedBy] varchar(255) not null,
	[CreatedDate] datetime2(7) not null,
	[ModifiedBy] varchar(255) null,
	[ModifiedDate] datetime2(7) null
);