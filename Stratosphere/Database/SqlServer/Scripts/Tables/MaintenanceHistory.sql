/*
	sqlserver inserts

	description: 
	Historical record of maintenance mode requests via templates as well as ad-hoc requests. Template requests will
	be using a simple reference to the template table. Ad-hoc requests won't reference a template, but will need to store
	more information. 
*/

create table [Stratosphere].[MaintenanceHistory] (
	[CreatedBy] varchar(255) not null,
	[CreatedDate] datetime2(7) not null,
	[ModifiedBy] varchar(255) null,
	[ModifiedDate] datetime2(7) null
);