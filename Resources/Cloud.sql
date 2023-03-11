CREATE DATABASE cloud;
USE cloud;

CREATE TABLE Account(
	ID INT PRIMARY KEY IDENTITY(1,1),
	FirstName VARCHAR(25) NOT NULL CHECK(LEN(FirstName) >= 3),
	LastName VARCHAR(25) NOT NULL CHECK(LEN(LastName) >= 3),
	Email VARCHAR(35) UNIQUE NOT NULL CHECK(Email LIKE '%@%'),
	HashedPassword VARCHAR(64) NOT NULL,
	Registered DATE NOT NULL DEFAULT (FORMAT (GETDATE(), 'yyyy-MM-dd'))
);

CREATE TABLE FolderColor(
	ID INT PRIMARY KEY IDENTITY(1,1),
	ColorName VARCHAR(15) UNIQUE NOT NULL
);

CREATE TABLE Folder(
	ID INT PRIMARY KEY IDENTITY(1,1),
	FolderName VARCHAR(45) NOT NULL CHECK(LEN(FolderName) > 0),
	ColorID INT NOT NULL DEFAULT 1 FOREIGN KEY REFERENCES FolderColor(ID),
	IsShared BIT NOT NULL DEFAULT 0,
	CreatedAt DATE NOT NULL DEFAULT (FORMAT (GETDATE(), 'yyyy-MM-dd'))
);

CREATE TABLE Access(
	ID INT PRIMARY KEY IDENTITY(1,1),
	AccountID INT NOT NULL FOREIGN KEY REFERENCES Account(ID),
	FolderID INT NOT NULL FOREIGN KEY REFERENCES Folder(ID)
);

CREATE TABLE AttachmentType(
	ID INT PRIMARY KEY IDENTITY(1,1),
	TypeName VARCHAR(45) UNIQUE NOT NULL,
);

CREATE TABLE Attachment(
	ID INT PRIMARY KEY IDENTITY(1,1),
	FolderID INT NOT NULL FOREIGN KEY REFERENCES Folder(ID),
	TypeID INT FOREIGN KEY REFERENCES AttachmentType(ID),
	AttachmentName VARCHAR(20) NOT NULL CHECK(LEN(AttachmentName) > 0),
	SizeMB FLOAT NOT NULL,
	CreatedAt DATE NOT NULL DEFAULT (FORMAT (GETDATE(), 'yyyy-MM-dd')),
	UpdatedAt DATE NOT NULL DEFAULT (FORMAT (GETDATE(), 'yyyy-MM-dd')),
);

INSERT INTO Account (FirstName, LastName, Email, HashedPassword, Registered)
	VALUES
		('Raoul', 'Bocke', 'rbocke0@boston.com', '0c132e75f9ea97874595677ac00b2406f1beaaaaaa6bd7bfb7aace168834459a', '2015-04-01'),
		('Kippy', 'M''Quharge', 'kmquharge1@google.co.uk', '84c0c008958ad0c1886c4a02cb3478402d89025644577aa8fe0267303356aa93', '2021-12-16'),
		('Tommie', 'Henrion', 'thenrion2@sciencedaily.com', '92461de6b35ab8a409ba50854004135b4e4506130139d6db6b800f7a2c4cfefe', '2016-02-08'),
		('Mariann', 'Blest', 'mblest3@liveinternet.ru', '194b34899d975f1915257c326a005d81ce9b2b75ac9e55db4f8130fedb01837f', '2018-08-07'),
		('Itch', 'Dewes', 'idewes4@tmall.com', '1685e39feaaf54924e2d690725af3941495fb22839ebba7c2afe42934fff3374', '2021-03-06'),
		('Gareth', 'Morrel', 'gmorrel5@bigcartel.com', '8200e906c761d21cc63ab012e91acebedc85b524669bd1d3701b5bd25db86e56', '2016-04-07');

INSERT INTO FolderColor (ColorName)
	VALUES
		('Violet'),
		('Red'),
		('Puce'),
		('Aquamarine'),
		('Fuscia');


INSERT INTO Folder (FolderName, ColorID, IsShared, CreatedAt)
	VALUES
		('Financial Statements', 1, 1, '2016-01-05'),
		('Project Plans', 3, 1, '2018-03-21'),
		('Client Contracts', 2, 0, '2020-05-13');

INSERT INTO Access (AccountID, FolderID)
	VALUES
		(1, 1),
		(2, 1),
		(3, 2),
		(5, 1),
		(4, 3),
		(4, 1),
		(5, 1);

INSERT INTO AttachmentType (TypeName)
	VALUES
		('Text Document'),
		('Microsoft Edge HTML Document'),
		('PNG Fi1e'),
		('Microsoft SQL Server Query File'),
		('C# Source File'),
		('Microsoft Edge PDF Document');

INSERT INTO Attachment (FolderID, TypeID, AttachmentName, SizeMB, CreatedAt, UpdatedAt)
	VALUES
		(1, 1, 'github', 2.5, '2012-03-03', '2012-03-03'),
		(1, 2, 'web', 1.2, '2018-03-03', '2018-03-03'),
		(2, 3, 'votes', 3.7, '2014-03-03', '2014-03-03'),
		(2, 4, 'cloud', 5.1, '2013-03-03', '2013-03-03'),
		(3, 5, 'PlayerController', 0.3, '2018-03-03', '2018-03-03'),
		(3, 6, 'game', 2.8, '2020-03-03', '2020-03-03'),
		(1, 1, 'node', 1.5, '2021-03-03', '2021-03-03');