/*
	sqlserver inserts

	description: 
	child to MaintenanceTemplate. this holds the details specific to which services specifically are being managed
	through the core template.
*/

create table [Stratosphere].[MaintenanceTemplateDetail] (
	[CreatedBy] varchar(255) not null,
	[CreatedDate] datetime2(7) not null,
	[ModifiedBy] varchar(255) null,
	[ModifiedDate] datetime2(7) null
);