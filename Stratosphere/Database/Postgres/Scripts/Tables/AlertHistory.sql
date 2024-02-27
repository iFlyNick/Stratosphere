/*
	postgres inserts

	description: 
	Holds historical information related to alerts raised for a long term log. Useful for tracking and reporting.
*/

create table if not exists Stratosphere.AlertHistory (
	CreatedBy varchar(255) not null,
	CreatedDate timestamp not null,
	ModifiedBy varchar(255) null,
	ModifiedDate timestamp null
);