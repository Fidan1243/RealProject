
CREATE TABLE Combos(
Id INT IDENTITY(1,1) PRIMARY KEY,
Name NVARCHAR(MAX) NOT NULL,
Marble_Id  int foreign key references Products(Id) Not Null,
Mirror_Id int foreign key references Products(Id) Not Null,
Sink_Unit_Id  int foreign key references Products(Id) Not Null,
Shower_Id int foreign key references Products(Id) Not Null,
Toilet_Id int foreign key references Products(Id) Not Null,
Marble_Count INT NOT NULL,
Like_Count INT NOT NULL,
Total Float NOT NULL,
)




        
        --public int Id { get; set; }
        --[Required]
        --public string Name { get; set; }
        --[Required]
        --public int Model_Id { get; set; }
        --[Required]
        --public int Material_Id { get; set; }
        --[Required]
        --public double Price { get; set; }
        --[Required]
        --public string ImagePath { get; set; }