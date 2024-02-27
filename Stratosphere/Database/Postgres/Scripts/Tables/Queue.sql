/*
	postgres inserts

	description: 
	reference table to store queue feeds created by the referenced cloudamqp service. 
*/

create table if not exists Stratosphere.Queue (
	CreatedBy varchar(255) not null,
	CreatedDate timestamp not null,
	ModifiedBy varchar(255) null,
	ModifiedDate timestamp null
);