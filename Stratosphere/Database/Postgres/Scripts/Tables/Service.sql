/*
	postgres inserts

	description: 
	core functionality to track services. responsible for most of the details of a given service.
*/

create table if not exists Stratosphere.Service (
	CreatedBy varchar(255) not null,
	CreatedDate timestamp not null,
	ModifiedBy varchar(255) null,
	ModifiedDate timestamp null
);