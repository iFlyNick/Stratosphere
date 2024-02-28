/*
	postgres inserts

	description: 
	parent table to MaintenanceTemplateDetail. this table is a core table for managing groups of services to support
	the maintenance mode functionality. Services tied to the template are stored in the detail table so this table
	will remain high level.
*/

create table if not exists Stratosphere.MaintenanceTemplate (
	MaintenanceTemplateId int generated always as identity,
	Name varchar(255) not null,
	Description varchar(1500) not null,
	CreatedBy varchar(255) not null,
	CreatedDate timestamp not null,
	ModifiedBy varchar(255) null,
	ModifiedDate timestamp null,
	primary key (MaintenanceTemplateId)
);