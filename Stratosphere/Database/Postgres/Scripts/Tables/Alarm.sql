/*
	postgres inserts

	description: 
	Local reference for cloudamqp alarm information. Alarms and recipients can change and are generally id based. 
	When editing an alarm on cloudamqp you typically have to push all fields so this is a good place to store the info.
*/

create table if not exists Stratosphere.Alarm (
	AlarmId uuid not null,
	CreatedBy varchar(255) not null,
	CreatedDate timestamp not null,
	ModifiedBy varchar(255) null,
	ModifiedDate timestamp null,
	ReferenceId varchar(255) not null,
	primary key (AlarmId)
);