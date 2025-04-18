
INSERT INTO CPU VALUES 
('Intel Core i5-12600K','LGA 1700',128,125,289,10,1),
('Intel Core i7-12700K','LGA 1700',128,125,409,10,1),
('Intel Core i9-12900K','LGA 1700',128,125,589,10,1),
('Intel Core i5-13600K','LGA 1700',128,125,319,10,1),
('Intel Core i7-13700K','LGA 1700',128,125,409,10,1),
('Intel Core i9-13900K','LGA 1700',128,125,589,10,1),
('Intel Core i5-14600K','LGA 1700',128,125,329,10,1),
('Intel Core i7-14700K','LGA 1700',128,125,419,10,1),
('Intel Core i9-14900K','LGA 1700',128,125,599,10,1)


INSERT INTO GPU VALUES
('RTX 3060',242,170,329,10,1,'Black'),
('RTX 3060 Ti',242,200,399,10,1,'Black'),
('RTX 3070',242,220,499,10,1,'Black'),
('RTX 3070 Ti',267,290,599,10,1,'Black'),
('RTX 3090',313,350,1499,10,1,'Black'),
('RTX 3090 Ti',336,450,1999,10,1,'Black'),
('RTX 4090',336,450,1599,10,1,'Black'),
('RTX 5070', 242,225,549,10,1,'Black'),
('RTX 5090',336,575,1999,10,1,'Black')


INSERT INTO Motherboard VALUES
('MSI MAG Z790 Tomahawk Max','LGA 1700','DDR5',4,6,4,128,'ATX',299.99,10,1),
('ASUS PRIME Z790-A WIFI','LGA 1700','DDR5',4,4,4,128,'ATX',249.99,10,1),
('GIGABYTE Z790 AORUS ELITE AX','LGA 1700','DDR5',4,6,4,192,'ATX',269.99,10,1),
('ASUS ROG MAXIMUS Z790 HERO','LGA 1700','DDR5',4,6,5,128,'ATX',629.99,10,1),
('ASRock Z790 PG Lightning','LGA 1700','DDR5',4,4,3,128,'ATX',189.99,10,1)


INSERT INTO PC_Case VALUES
('Corsair 4000D Airflow','Standard','Mid-Tower ATX',360,109.99,	'Black',10),
('NZXT H5 Flow','Standard','Mid-Tower ATX',365,79.99,'Matte Black',10),
('Lian Li O11 Vision','Premium','Mid-Tower ATX',420,129.99,	'Black',10),
('Fractal Design North','Wood','Mid-Tower ATX',355,139.99,'Chalk White',10),
('Hyte Y60','Special','Mid-Tower ATX',375,199.99,'Red',10),
('Thermaltake View 270 TG ARGB','ARGB','Mid-Tower ATX',410,179.00,'Black',10),
('NZXT H9 Flow','Elite','Mid-Tower ATX',435,159.99,'Black',10),
('Fractal Design Torrent','RGB','Mid-Tower ATX',330,189.99,'Gray',10)


INSERT INTO PSU VALUES
('Corsair RM750x',750,'80 Plus  Gold',119.99,10),
('EVGA SuperNOVA 650 G5',650,'80 Plus Gold',89.99,10),
('Seasonic FOCUS GX-750',750,'80 Plus Gold',129.99,10),
('Cooler Master MWE Gold', 850,'80 Plus Gold',99.99,10),
('Corsair HX1000i',1000,'80 Plus Platinum',199.99,10),
('Thermaltake Toughpower GF1',850,'80 Plus Gold',109.99,10),
('Be Quiet! Straight Power 11',750,'80 Plus Gold',109.99,10),
('Gigabyte P850GM',850,'80 Plus Gold',99.99,10),
('XFX ProSeries',850,'80 Plus Gold',109.99,10),
('SilverStone Strider Platinum',850,'80 Plus Platinum',129.99,10)


INSERT INTO RAM VALUES
('Corsair Vengeance LPX',16,3200,'DDR4',69.99,10),
('G.SKILL Ripjaws V',16,3600,'DDR4',74.99,10),
('Kingston Fury Beast', 16,3600,'DDR4',79.99,10),
('Corsair Vengeance RGB Pro',16,3200,'DDR4',89.99,10),
('Crucial Ballistix',16,3000,'DDR4',64.99,10),
('G.SKILL Trident Z RGB', 32,3600,'DDR4',159.99,10),
('Corsair Vengeance LPX',32,3200,'DDR4',129.99,10),
('Kingston HyperX Predator',16,4000,'DDR4',129.99,10),
('Crucial Ballistix',32,3200,'DDR4',139.99,10),
('Corsair Dominator Platinum RGB',32,3600,'DDR4',229.99,10)


INSERT INTO Storage VALUES 
('Samsung 980 Pro', 'NVMe SSD',	1,	7000,5000,129.99,10),
('Western Digital Black SN850',	'NVMe SSD',	1,7000, 5300,119.9,10),
('Crucial P5 Plus',	'NVMe SSD',1,6600,5000,99.99,10),
('Seagate FireCuda 530','NVMe SSD',1,7300,6900,169.99,10),
('Kingston NV2','NVMe SSD',	1,3500,2800,59.99,10),
('Samsung 870 QVO','SATA SSD',1,560,530,89.99,10),
('Western Digital Blue 3D NAND','SATA SSD',1,560,530,89.99,10),
('Crucial MX500','SATA SSD',1,560,510,99.99,10),
('Seagate Barracuda','HDD',2,160,160,54.99,10),
('Western Digital Black','HDD',6,190,190,169.99,10)

INSERT INTO Laptops Values
('ROG Zephyrus G14', 'Asus','Gray','AMD Ryzen 9','NVIDIA GeForce RTX 4070','ASUS ROG Zephyrus G14 Custom',16,1,'SSD',10,1),
('Titan GT77 HX 13V','MSI',	'Black','Intel Core i9-13980HX','NVIDIA GeForce RTX 4090','MSI Titan GT77 Custom',64,2,'SSD',10,1),
('Legion Slim 7i','Lenovo','Black','Intel Core i7-13700H','NVIDIA GeForce RTX 3060','Lenovo Legion Slim 7i Custom',	16,512,'SSD',10,1),
('Slim 7','Lenovo','Gray','Intel Core Ultra 7 155H','Intel Arc Integrated','Lenovo Slim 7 Custom',32,1,'SSD',10,1),
('OmniBook Ultra Flip 14','HP','Silver','Intel Core i7-1265U','Intel Iris Xe Integrated','HP OmniBook Custom',16,512,'SSD',10,1),
('MacBook Air', 'Apple','Silver','Apple M4','Integrated 10-core GPU','Apple Custom Logic Board',8,256,'SSD',10,1)