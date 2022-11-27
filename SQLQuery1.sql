use Project

create table Users(

[Id] int Primary Key identity(1,1) Not Null,

[User_Id] int foreign key references (Id) Not Null,

[Name] nvarchar(100) Not Null,

[Surname] nvarchar(100) Not Null,

[Email] nvarchar(100) Unique Not Null,

[Phone] nvarchar(100) Unique Not Null,

[Addres] nvarchar(100) Not Null,

[City] nvarchar(100) Not Null,

[ZipCode] nvarchar(100) Not Null,

[ImagePath] nvarchar(100) Not Null,

[Description] nvarchar(100) Not Null,

Check([Name] != '' AND [Surname] != '')

)


create table Categories(

[Id] int Primary Key identity(1,1) Not Null,

[CategoryName] nvarchar(100) Not Null

Check([CategoryName] != '' )

)




create table Stories(

[Id] int Primary Key identity(1,1) Not Null,

[User_Id] int foreign key references Users(Id) Not Null,

[Story_Photo] nvarchar(100) Not Null,

Check([Story_Photo] != '')

)


create table Friends(

[Id] int Primary Key identity(1,1) Not Null,

[User_Id] int foreign key references Users(Id) Not Null

)




create table Posts(

[Id] int Primary Key identity(1,1) Not Null,

[User_Id] int foreign key references Users(Id) Not Null,

[Category_Id] int foreign key references Categories(Id) Not Null,

[Path] nvarchar(100),

[Post_Content] nvarchar(100),

[Like_Count] int Not Null,

[Comment_Count] int Not Null

)


create table Comments(

[Id] int Primary Key identity(1,1) Not Null,

[User_Id] int foreign key references Users(Id) Not Null,

[Post_Id] int foreign key references Posts(Id) Not Null,

[Path] nvarchar(100),

[Post_Content] nvarchar(100)

)

create table Messagee(

[Id] int Primary Key identity(1,1) Not Null,

[User_Id] int foreign key references Users(Id) Not Null,

[Index] int Not Null,

[The_Message] nvarchar(100)

)
