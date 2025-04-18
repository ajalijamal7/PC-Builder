﻿
CREATE TABLE Users (
ID INT,
First_Name NVARCHAR(25),
Last_Name NVARCHAR(25),
Email NVARCHAR(25),
U_Password NVARCHAR(25),
Phone INT,
U_Role NVARCHAR(25),
Salary REAL,
PRIMARY KEY (ID),
)


CREATE TABLE CPU(
CPU_Name NVARCHAR(50),
CPU_Socket NVARCHAR(25),
Max_Memory INT,
CPU_Power INT,
Price REAL,
Quantity INT,
Warranty INT,
PRIMARY KEY(CPU_Name),
)


CREATE TABLE GPU(
GPU_Name NVARCHAR(50),
Lenght INT,
GPU_Power INT,
Price REAL,
Quantity INT,
Warranty INT,
Color NVARCHAR(50),
PRIMARY KEY(GPU_Name),
)



CREATE TABLE Motherboard(
M_Name NVARCHAR(50),
M_Socket NVARCHAR(25),
Memory_Type NVARCHAR(25),
Memory_Slots INT,
HDD_Storage_Slots INT,
SSD_Storage_Slots INT,
Max_Memory INT,
Form_Factor NVARCHAR(50),
Price REAL,
Quantity INT,
Warranty INT,
PRIMARY KEY(M_Name),
)


CREATE TABLE PC_Case(
ID INT IDENTITY(1,1),
PC_Case_Name NVARCHAR(50),
Edition NVARCHAR(50),
Form_Factor NVARCHAR(50),
Max_Gpu_lenght NVARCHAR(50),
Price REAL,
Color NVARCHAR(25),
Quantity INT,
PRIMARY KEY (ID)
)


CREATE TABLE PSU(
ID INT IDENTITY(1,1),
PSU_Name NVARCHAR(50),
Wattage INT,
Rate NVARCHAR (50),
Price REAL,
Quantity INT,
PRIMARY KEY(ID),
)


CREATE TABLE Storage(
ID INT IDENTITY(1,1),
S_Name NVARCHAR(50),
S_Type NVARCHAR(50),
S_Size INT,
Read_Speed REAL,
Write_Speed REAL,
Price REAL,
Quantity INT,
PRIMARY KEY(ID),
)


CREATE TABLE RAM(
ID INT IDENTITY(1,1),
RAM_Name NVARCHAR(50),
RAM_Size INT,
Speed REAL,
RAM_Type NVARCHAR(25),
Price REAL,
Quantity INT,
PRIMARY KEY(ID),
)

CREATE TABLE Custom_PC(
ID INT IDENTITY(1,1),
CPU_Name NVARCHAR(50),
GPU_Name NVARCHAR(50),
M_Name NVARCHAR(50),
PSU_ID INT,
PC_Case_ID INT,
Price REAL,
Quantity INT,
PRIMARY KEY (ID),
)

ALTER TABLE Custom_PC
ADD CONSTRAINT CPU_CUSTOM_PC_NAME
FOREIGN KEY (CPU_Name) REFERENCES CPU (CPU_Name);

ALTER TABLE Custom_PC
ADD CONSTRAINT GPU_PC_NAME 
FOREIGN KEY (GPU_Name) REFERENCES GPU (GPU_Name);

ALTER TABLE Custom_PC
ADD CONSTRAINT Motherboard_PC_NAME 
FOREIGN KEY (M_Name) REFERENCES Motherboard (M_Name);

ALTER TABLE Custom_PC
ADD CONSTRAINT PSU_PC_ID 
FOREIGN KEY (PSU_ID) REFERENCES PSU (ID);

ALTER TABLE Custom_PC
ADD CONSTRAINT PC_Case_PC_ID
FOREIGN KEY (PC_Case_ID) REFERENCES PC_Case (ID);


CREATE TABLE Laptops(
ID INT IDENTITY(1,1),
laptop_Name NVARCHAR(100),
Brand NVARCHAR(50),
Color NVARCHAR(50),
CPU NVARCHAR(100),
GPU NVARCHAR(50),
Motherboard NVARCHAR(100),
RAM INT,
Storage INT,
storage_Type NVARCHAR(50),
Quantity INT,
Warranty INT,
PRIMARY KEY (ID),


)


CREATE TABLE Ticket(
Ticket_ID INT,
T_Date Date,
Users_ID INT,
Custom_PC_ID INT,
PSU_ID INT,
CPU_Name NVARCHAR(50),
GPU_Name NVARCHAR(50),
M_Name NVARCHAR(50),
RAM_ID INT,
Storage_ID INT,
PC_Case_ID INT,
Quantity_CPU INT,
Quantity_GPU INT,
Quantity_Motherboard INT,
Quantity_RAM INT,
Quantity_Storage INT,
Quantity_Cases INT,
Quantity_PSU INT,
Quantity_Custom_PC INT,
laptop_ID INT,
PRIMARY KEY (Ticket_ID, T_Date),
)

ALTER TABLE Ticket
ADD CONSTRAINT Users_Ticket_ID
FOREIGN KEY (Users_ID) REFERENCES Users (ID);

ALTER TABLE Ticket
ADD CONSTRAINT Custom_PC_Ticket_ID
FOREIGN KEY (Custom_PC_ID) REFERENCES Custom_PC (ID);

ALTER TABLE Ticket
ADD CONSTRAINT CPU_Ticket_Nae
FOREIGN KEY (CPU_Name) REFERENCES CPU (CPU_Name);

ALTER TABLE Ticket
ADD CONSTRAINT GPU_Ticket_Name
FOREIGN KEY (GPU_Name) REFERENCES GPU (GPU_Name);

ALTER TABLE Ticket
ADD CONSTRAINT Motherboard_Ticket_Name
FOREIGN KEY (M_Name) REFERENCES Motherboard (M_Name);

ALTER TABLE Ticket
ADD CONSTRAINT RAM_Ticket_ID
FOREIGN KEY (RAM_ID) REFERENCES RAM (ID);

ALTER TABLE Ticket
ADD CONSTRAINT Storage_Ticket_ID
FOREIGN KEY (Storage_ID) REFERENCES Storage (ID);

ALTER TABLE Ticket
ADD CONSTRAINT PC_Case_Ticket_ID
FOREIGN KEY (PC_Case_ID) REFERENCES PC_Case (ID);

ALTER TABLE Ticket
ADD CONSTRAINT PSU_Ticket_ID
FOREIGN KEY (PSU_ID) REFERENCES PSU (ID)

ALTER TABLE Ticket
ADD CONSTRAINT laptops_Ticket_ID
FOREIGN KEY (Laptop_ID) REFERENCES Laptops (ID)


