USE [IdentityServer]
GO
/****** Object:  Table [dbo].[IdentityUsers]    Script Date: 14-12-2019 02:38:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentityUsers](
	[SubjectId] [varchar](max) NOT NULL,
	[UserName] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[PasswordHash] [varchar](max) NULL,
	[Role] [varchar](15) NULL,
	[Name] [varchar](25) NULL,
	[UserId] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[IdentityUsers] ([SubjectId], [UserName], [Email], [PasswordHash], [Role], [Name], [UserId]) VALUES (N'sonalkumar', N'sonal', N'sonal@gmail.com', N'AQAAAAEAACcQAAAAEBjNq+W5QleWJ/VJtnuMuJ0MRa4cjdZ9k3XB/BF6JiB10U/HekNm5D7hglnATFrlhA==', N'Admin', N'Sonal', 123)
INSERT [dbo].[IdentityUsers] ([SubjectId], [UserName], [Email], [PasswordHash], [Role], [Name], [UserId]) VALUES (N'f6174302-728a-40a9-948a-7f21ab9bd749', N'sonal@madasolns.com', NULL, N'AQAAAAEAACcQAAAAELnYRj0OF8mBLj1+oRnJ9vKYHgZ77Kqr7j70+Pyrs8ex3iuo7nb0VehWCbyRZTKDPQ==', N'Admin', N'Sonal', 322)
/****** Object:  StoredProcedure [dbo].[spIdentityUsers_GetByUsername]    Script Date: 14-12-2019 02:38:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spIdentityUsers_GetByUsername]
( @UserName varchar(50) )
as
begin
	select SubjectId, UserName, PasswordHash, UserId, Email, Role, Name from IdentityUsers where UserName = @UserName;
end
GO
/****** Object:  StoredProcedure [dbo].[spIdentityUsers_GetUserById]    Script Date: 14-12-2019 02:38:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spIdentityUsers_GetUserById] ( @SubjectId varchar(max) )
  as
  begin 

	select SubjectId, UserName, Email, Role, Name, UserId, PasswordHash from IdentityUsers where SubjectId = @SubjectId;
  end
GO
/****** Object:  StoredProcedure [dbo].[spIdentityUsers_Upsert]    Script Date: 14-12-2019 02:38:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spIdentityUsers_Upsert]
  ( @SubjectId varchar(max), @UserName varchar(50), @Email varchar(50), @PasswordHash varchar(max), @Role varchar(15), @Name varchar(25), @UserId int )
  as begin
	if exists (
	select 1 from IdentityUsers where UserName = @UserName
	)
	begin 
		update IdentityUsers set
			SubjectId = @SubjectId,
			UserName = @UserName,
			Email = @Email,
			Role = @Role,
			Name = @Name,
			UserId = @UserId,
			PasswordHash = @PasswordHash
		where UserName = @UserName
	end
	else
		begin
			insert into IdentityUsers
			(
				SubjectId,
				UserName,
				PasswordHash,
				Role,
				UserId,
				Email,
				Name
			)
			values
			(
				@SubjectId,
				@UserName,
				@PasswordHash,
				@Role,
				@UserId,
				@Email,
				@Name
			)
		end
  end
GO
