CREATE DATABASE gameData;
USE gameData;

CREATE TABLE Score(
	ID INT PRIMARY KEY IDENTITY(1,1),
	NameOf VARCHAR(45) UNIQUE NOT NULL,
	XP INT NOT NULL CHECK(XP > 0)
);

CREATE TABLE Player(
	ID INT PRIMARY KEY IDENTITY(1,1),
	IsOnline BIT NOT NULL DEFAULT 0,
	ScoreID INT NOT NULL FOREIGN KEY REFERENCES Score(ID),
	Nickname VARCHAR(45) UNIQUE NOT NULL CHECK(LEN(Nickname) >= 5),
	LastLogin DATE NOT NULL DEFAULT (FORMAT (GETDATE(), 'yyyy-MM-dd')),
	FullName VARCHAR(45) NOT NULL CHECK(LEN(FullName) >= 6),
	Email VARCHAR(45) UNIQUE NOT NULL CHECK(Email LIKE '%@%'),
	Registred DATE NOT NULL DEFAULT (FORMAT (GETDATE(), 'yyyy-MM-dd'))
);

CREATE TABLE Game(
	ID INT PRIMARY KEY IDENTITY(1,1),
	TypeOf VARCHAR(45) UNIQUE NOT NULL,
	Duration INT NOT NULL
);

CREATE TABLE Client(
	ID INT PRIMARY KEY IDENTITY(1,1),
	IsOnline BIT NOT NULL DEFAULT 0,
	Region VARCHAR(45) NOT NULL,
	GameID INT NOT NULL FOREIGN KEY REFERENCES Game(ID),
	LastStart DATE DEFAULT (FORMAT (GETDATE(), 'yyyy-MM-dd')),
	CurrentPlayers INT NOT NULL
);

CREATE TABLE Connection(
	ID INT PRIMARY KEY IDENTITY(1,1),
	PlayerID INT FOREIGN KEY REFERENCES Player(ID),
	ClientID INT FOREIGN KEY REFERENCES Client(ID)
);

GO
CREATE TRIGGER onConnectToServer ON Connection
FOR INSERT
AS
UPDATE Client SET CurrentPlayers += 1
FROM Client INNER JOIN Connection ON Client.ID = Connection.ClientID
WHERE Client.ID = Connection.ClientID;

GO
CREATE TRIGGER onDisconnectFromServer ON Connection
FOR DELETE
AS
UPDATE Client SET CurrentPlayers -= 1
FROM Client INNER JOIN Connection ON Client.ID = Connection.ClientID
WHERE Client.ID = Connection.ClientID;