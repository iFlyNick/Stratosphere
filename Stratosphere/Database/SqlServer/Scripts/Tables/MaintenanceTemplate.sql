/*
	sqlserver inserts

	description: 
	parent table to MaintenanceTemplateDetail. this table is a core table for managing groups of services to support
	the maintenance mode functionality. Services tied to the template are stored in the detail table so this table
	will remain high level.
*/

create table [Stratosphere].[MaintenanceTemplate] (
	[CreatedBy] varchar(255) not null,
	[CreatedDate] datetime2(7) not null,
	[ModifiedBy] varchar(255) null,
	[ModifiedDate] datetime2(7) null
);