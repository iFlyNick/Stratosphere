/*
	sqlserver inserts

	description: 
	holds actual contact information for a given profile. core functionality for how to contact someone.
	
	notes:
	contactvalue should hold the actual contact information. this could be an email address, phone number, webhook url, etc.
*/

create table [Stratosphere].[Contact] (
	[CreatedBy] varchar(255) not null,
	[CreatedDate] datetime2(7) not null,
	[ModifiedBy] varchar(255) null,
	[ModifiedDate] datetime2(7) null
);