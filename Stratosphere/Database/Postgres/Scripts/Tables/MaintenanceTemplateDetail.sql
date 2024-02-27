/*
	postgres inserts

	description: 
	child to MaintenanceTemplate. this holds the details specific to which services specifically are being managed
	through the core template.
*/

create table if not exists Stratosphere.MaintenanceTemplateDetail (
	CreatedBy varchar(255) not null,
	CreatedDate timestamp not null,
	ModifiedBy varchar(255) null,
	ModifiedDate timestamp null
);