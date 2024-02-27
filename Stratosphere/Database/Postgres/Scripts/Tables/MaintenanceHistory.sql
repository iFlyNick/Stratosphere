/*
	postgres inserts

	description: 
	Historical record of maintenance mode requests via templates as well as ad-hoc requests. Template requests will
	be using a simple reference to the template table. Ad-hoc requests won't reference a template, but will need to store
	more information. 
*/

create table if not exists Stratosphere.MaintenanceHistory (
	CreatedBy varchar(255) not null,
	CreatedDate timestamp not null,
	ModifiedBy varchar(255) null,
	ModifiedDate timestamp null
);