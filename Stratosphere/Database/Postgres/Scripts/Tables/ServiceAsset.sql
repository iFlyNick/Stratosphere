/*
	postgres inserts

	description: 
	relates to the service table and is reponsible for tracking what assets a given service operates on
*/

create table if not exists Stratosphere.ServiceAsset (
	ServiceId nvarchar(255) not null,
	AssetId nvarchar(255) not null,
	CreatedBy varchar(255) not null,
	CreatedDate timestamp not null,
	ModifiedBy varchar(255) null,
	ModifiedDate timestamp null,
	primary key (ServiceId, AssetId),
	foreign key (ServiceId) references Stratosphere.Service(ServiceId),
	foreign key (AssetId) references Stratosphere.Asset(AssetId),
);