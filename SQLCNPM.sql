
use QuanLyQuanCafe
go
create table TABLE_FOOD
(
id int primary key,
name nvarchar(20),
status int, --trống:1, có khách:0
)
go
create table STAFF
(
id int primary key,
name nvarchar(20),
sdt int ,
address nvarchar(20),
sex nvarchar(20),
salary real,
status int, --còn làm:1, nghỉ việc:0
)
go
create table ACCOUNT
(
username nvarchar(20) unique,
password varchar(20),
type int , --admin:1, nhanvien:0
id_staff int,
primary key(username),
FOREIGN KEY(id_staff) REFERENCES staff(id)
)
go
create table BILL 
(
id int primary key ,
dayCheckIn datetime,
dayCheckOut datetime,
discount int ,
id_staff int,--nhanvien xử lí
id_table int,
FOREIGN KEY(id_staff) REFERENCES staff(id),
FOREIGN KEY(id_table) REFERENCES Table_Food(id)
)
go
create table FOOD_CATEGORY
(
id int primary key,
name nvarchar(50)
)
go
create table FOOD 
(
id int primary key,
price int ,
name nvarchar(50),
id_category int,
FOREIGN KEY(id_category) REFERENCES food_category(id)
)
go
create table BILL_INF --tách ra dễ quản lí
(
id int primary key,
id_bill int,
id_food int,
amount int , --số lượng sản phẩm
FOREIGN KEY(id_food) REFERENCES food(id),
FOREIGN KEY(id_bill) REFERENCES bill(id)
)
go
create table PART_TIME 
(
station nvarchar(20),
Time_begin datetime,
Time_end datetime,
id_staff int primary key,
FOREIGN KEY(id_staff) REFERENCES staff(id)
)
go

insert into TABLE_FOOD values 
							(1, N'bàn A', 1),
							(2, N'bàn B', 1),
							(3, N'bàn C', 1),
							(4, N'bàn D', 1),
							(5, N'bàn E', 1);
go
insert into STAFF values (1, N'Huỳnh Thị Hương Ly', 0771111111, N'Quảng Nam', N'nữ', 7000000,1),
						 (2, N'Phan Thành Trung', 0771111112, N'Quảng Bình', N'nữ', 7000000,1),
						 (3, N'Lê Đỗ Trà My', 0771111113, N'Bình Dương', N'nữ', 7000000,1),
						 (4, N'Võ Thị Thanh Ngân', 0771111114, N'Đồng Tháp', N'nữ', 7000000,1),
						 (5, N'Trần Gia Nguyên', 0771111115, N'Gia Lai', N'nữ', 7000000,1),
						 (6,N'Admin',0771111110,N'Tp.HCM',N'Nữ',0,1),
						 (7, N'La Lương Linh', 0771111005, N'Gia Lai', N'nữ', 7000000,0);

insert into ACCOUNT values  (N'admin','a1',1,6),
							(N'lyhth', '123', 0, 1),
							(N'trungpt', '123', 0, 2),
							(N'myldt', '123', 0, 3),
							(N'nganvtt', '123', 0, 4),
							(N'nguyentg', '123', 0, 5),
							(N'linhll', '123', 0, 7);
go
insert into BILL values (1, '12-01-2020', '12-01-2020', 0, 1, 1),
						(2, '12-01-2020', '12-01-2020', 0 ,1, 2),
						(3, '12-02-2020', '12-02-2020', 50000, 2, 1),
						(4, '12-02-2020', '12-02-2020', 0, 2, 2),
						(5, '12-02-2020', '12-02-2020', 0, 2, 3);
go
insert into PART_TIME values    (N'Đã trực', '12-01-2020 9:0:0', '12-01-2020 21:0:0', 1),
								(N'Chưa trực', '12-02-2020 9:0:0', '12-02-2020 21:0:0', 2),
								(N'Chưa trực', '12-03-2020 9:0:0', '12-03-2020 21:0:0', 3),
								(N'Chưa trực', '12-04-2020 9:0:0', '12-04-2020 21:0:0', 4),
								(N'Chưa trực', '12-05-2020 9:0:0', '12-05-2020 21:0:0', 5);
go
insert into FOOD_CATEGORY values (1, N'Cà phê'),
								 (2, N'Trà sữa'),
								 (3, N'Trà'),
								 (4, N'Bánh');
go
insert into FOOD values (1 , 29000, N'Phin sữa đá', 1),
						(2 , 29000, N'Phin đen đá', 1),
						(3 , 29000, N'Bạc Xỉu', 1),
						(4 , 29000, N'Phin sữa nóng', 1),
						(5 , 29000, N'Phin đen nóng', 1),
						(6 , 29000, N'Ca cao đá', 1), 
						--
						(7 , 33000, N'Đường nâu cacao sữa', 2),
						(8 , 33000, N'Đường nâu kem cheese', 2),
						--
						(9 , 30000, N'Trà xanh đậu đỏ', 3),
						(10 , 30000, N'Trà sen vàng', 3),
						--
						(11 , 29000, N'Bánh Tiramisu', 4),
						(12 , 29000, N'Bánh mousse Đào', 4),
						(13 , 29000, N'Bánh phô mai cà phê', 4),
						(14 , 9000, N'Cookies hạt bí', 4);
go

insert into BILL_INF values (1, 1, 11, 1),
							(2, 1, 11, 3),
							(3, 2, 7, 1),
							(4, 3, 12, 1), 
							(5, 3, 6, 2),
							(6, 3, 3, 2),
							(7, 4, 8, 2),
							(8, 5, 9, 1),
							(9, 5, 10, 1);
go
