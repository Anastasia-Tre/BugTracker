 CREATE TABLE [Tasks] (
	Id integer IDENTITY(1,1),
	Name varchar(255) NOT NULL,
	Description varchar(255),
	ProjectId integer NOT NULL,
	AuthorId integer NOT NULL,
	AssignedId integer,
	Status integer NOT NULL,
	Type integer NOT NULL,
	Priority integer NOT NULL,
	Difficulty integer NOT NULL,
	Deadline datetime NOT NULL,
	Created datetime NOT NULL,
  CONSTRAINT [PK_TASK] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Projects] (
	Id integer IDENTITY(1,1),
	Name varchar(255) NOT NULL,
	Description varchar(255),
	AuthorId integer NOT NULL,
	Status integer NOT NULL,
	Deadline datetime NOT NULL,
	Created datetime NOT NULL,
  CONSTRAINT [PK_PROJECT] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Users] (
	Id integer IDENTITY(1,1),
	FirstName varchar(255) NOT NULL,
	LastName varchar(255) NOT NULL,
	Email varchar(255) NOT NULL,
	Phone varchar(255),
	Title varchar(255) NOT NULL,
	Bio varchar(255),
	Created datetime NOT NULL,
  CONSTRAINT [PK_USER] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [UserProject] (
	UserId integer NOT NULL,
	ProjectId integer NOT NULL
)
GO
ALTER TABLE [Tasks] WITH CHECK ADD CONSTRAINT [Task_fk0] FOREIGN KEY ([ProjectId]) REFERENCES [Projects]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [Tasks] CHECK CONSTRAINT [Task_fk0]
GO
ALTER TABLE [Tasks] WITH CHECK ADD CONSTRAINT [Task_fk1] FOREIGN KEY ([AuthorId]) REFERENCES [Users]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [Tasks] CHECK CONSTRAINT [Task_fk1]
GO
ALTER TABLE [Tasks] WITH CHECK ADD CONSTRAINT [Task_fk2] FOREIGN KEY ([AssignedId]) REFERENCES [Users]([Id])
GO
ALTER TABLE [Tasks] CHECK CONSTRAINT [Task_fk2]
GO

ALTER TABLE [Projects] WITH CHECK ADD CONSTRAINT [Project_fk0] FOREIGN KEY ([AuthorId]) REFERENCES [Users]([Id])
GO
ALTER TABLE [Projects] CHECK CONSTRAINT [Project_fk0]
GO

ALTER TABLE [UserProject] WITH CHECK ADD CONSTRAINT [UserProject_fk0] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id])
GO
ALTER TABLE [UserProject] CHECK CONSTRAINT [UserProject_fk0]
GO
ALTER TABLE [UserProject] WITH CHECK ADD CONSTRAINT [UserProject_fk1] FOREIGN KEY ([ProjectId]) REFERENCES [Projects]([Id])
GO
ALTER TABLE [UserProject] CHECK CONSTRAINT [UserProject_fk1]
GO


