CREATE TABLE [dbo].[Walk](
	id int IDENTITY(1,1) PRIMARY KEY,
	IMEI varchar(50),
	start_time datetime,
	end_time datetime,
	longitude decimal (12, 9),
	latitude decimal (12, 9),
	distance decimal(18, 9)
)

CREATE TABLE [dbo].[BotUser](
	id int PRIMARY KEY,
	IMEI varchar(50)
)