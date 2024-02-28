/*
	postgres inserts

	description: 
	Simple table to store what options are supported for how a service operates. mainly server information.

	notes:
	avoid assigning environmentid to an asset as that boxes the asset into one environment, limiting its definition.
	purposefully avoiding password storage here. this can hold the user, but alternate methods should be used for password storage.
*/

create table if not exists Stratosphere.Asset (
	AssetId int generated always as identity,
	AssetTypeId int not null,
	Description varchar(255) not null,
	ConnectionString varchar(255) not null,
	RequireCredentials boolean not null default false,
	ConnectionUser varchar(255) null,
	CreatedBy varchar(255) not null,
	CreatedDate timestamp not null,
	ModifiedBy varchar(255) null,
	ModifiedDate timestamp null,
	primary key (AssetId),
	foreign key (AssetTypeId) references Stratosphere.AssetType(AssetTypeId)
);