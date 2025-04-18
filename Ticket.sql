CREATE TABLE O_Ticket(
ID INT IDENTITY(1,1),
Item_Name NVARCHAR(100),
Item_ID INT,
Price REAL,
Item_Type NVARCHAR(50),
Quantity INT,
First_Name NVARCHAR(50),
Last_Name NVARCHAR(50),
Order_Taken_BY NVARCHAR(50),
Order_Date DATETIME


PRIMARY KEY (ID)
)