/*
	sqlserver inserts

	description: 
	Local reference for cloudamqp alarm information. Alarms and recipients can change and are generally id based. 
	When editing an alarm on cloudamqp you typically have to push all fields so this is a good place to store the info.
*/

create table [Stratosphere].[Alarm] (
	[CreatedBy] varchar(255) not null,
	[CreatedDate] datetime2(7) not null,
	[ModifiedBy] varchar(255) null,
	[ModifiedDate] datetime2(7) null
);