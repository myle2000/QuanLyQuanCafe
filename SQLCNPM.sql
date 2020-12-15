USE [QuanLyQuanCafe]
GO
/****** Object:  Table [dbo].[ACCOUNT]    Script Date: 15-Dec-20 2:45:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ACCOUNT](
	[username] [nvarchar](20) NOT NULL,
	[DisplayName] [nvarchar](20) NULL,
	[password] [varchar](20) NULL,
	[type] [int] NULL,
	[id_staff] [int] NULL,
 CONSTRAINT [PK__ACCOUNT__F3DBC573BEC20F24] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BILL]    Script Date: 15-Dec-20 2:45:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BILL](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[dayCheckIn] [datetime] NULL,
	[dayCheckOut] [datetime] NULL,
	[discount] [int] NULL,
	[id_staff] [int] NULL,
	[id_table] [int] NULL,
	[status] [int] NULL,
	[totalPrice] [int] NULL,
 CONSTRAINT [PK__BILL__3213E83F172F5E61] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BILL_INF]    Script Date: 15-Dec-20 2:45:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BILL_INF](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_bill] [int] NULL,
	[id_food] [int] NULL,
	[amount] [int] NULL,
 CONSTRAINT [PK__BILL_INF__3213E83F91E7D32C] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FOOD]    Script Date: 15-Dec-20 2:45:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FOOD](
	[id] [int] NOT NULL,
	[price] [int] NULL,
	[name] [nvarchar](50) NULL,
	[id_category] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FOOD_CATEGORY]    Script Date: 15-Dec-20 2:45:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FOOD_CATEGORY](
	[id] [int] NOT NULL,
	[name] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PART_TIME]    Script Date: 15-Dec-20 2:45:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PART_TIME](
	[station] [nvarchar](20) NULL,
	[Time_begin] [datetime] NULL,
	[Time_end] [datetime] NULL,
	[id_staff] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_staff] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[STAFF]    Script Date: 15-Dec-20 2:45:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[STAFF](
	[id] [int] NOT NULL,
	[name] [nvarchar](20) NULL,
	[sdt] [varchar](15) NULL,
	[address] [nvarchar](20) NULL,
	[sex] [nvarchar](20) NULL,
	[salary] [int] NULL,
	[status] [int] NULL,
 CONSTRAINT [PK__STAFF__3213E83F0CCA053F] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TABLE_FOOD]    Script Date: 15-Dec-20 2:45:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TABLE_FOOD](
	[id] [int] NOT NULL,
	[name] [nvarchar](20) NULL,
	[status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ACCOUNT] ([username], [DisplayName], [password], [type], [id_staff]) VALUES (N'admin', N'admin', N'a1', 1, 6)
INSERT [dbo].[ACCOUNT] ([username], [DisplayName], [password], [type], [id_staff]) VALUES (N'linhll', N'linhll', N'123', 0, 2)
INSERT [dbo].[ACCOUNT] ([username], [DisplayName], [password], [type], [id_staff]) VALUES (N'myldt', NULL, N'123', 0, 3)
INSERT [dbo].[ACCOUNT] ([username], [DisplayName], [password], [type], [id_staff]) VALUES (N'nganvtt', NULL, N'123', 0, 4)
INSERT [dbo].[ACCOUNT] ([username], [DisplayName], [password], [type], [id_staff]) VALUES (N'nguyentg', NULL, N'123', 0, 5)
INSERT [dbo].[ACCOUNT] ([username], [DisplayName], [password], [type], [id_staff]) VALUES (N'nv1', N'dfce', N'1', 0, 3)
GO
SET IDENTITY_INSERT [dbo].[BILL] ON 

INSERT [dbo].[BILL] ([id], [dayCheckIn], [dayCheckOut], [discount], [id_staff], [id_table], [status], [totalPrice]) VALUES (8, CAST(N'2020-12-15T14:30:24.253' AS DateTime), NULL, 0, 6, 4, 0, NULL)
INSERT [dbo].[BILL] ([id], [dayCheckIn], [dayCheckOut], [discount], [id_staff], [id_table], [status], [totalPrice]) VALUES (9, CAST(N'2020-12-15T14:30:28.163' AS DateTime), NULL, 0, 6, 4, 0, NULL)
SET IDENTITY_INSERT [dbo].[BILL] OFF
GO
SET IDENTITY_INSERT [dbo].[BILL_INF] ON 

INSERT [dbo].[BILL_INF] ([id], [id_bill], [id_food], [amount]) VALUES (15, 8, 1, 1)
INSERT [dbo].[BILL_INF] ([id], [id_bill], [id_food], [amount]) VALUES (16, 9, 3, 1)
SET IDENTITY_INSERT [dbo].[BILL_INF] OFF
GO
INSERT [dbo].[FOOD] ([id], [price], [name], [id_category]) VALUES (1, 29000, N'Phin sữa đá', 1)
INSERT [dbo].[FOOD] ([id], [price], [name], [id_category]) VALUES (2, 29000, N'Phin đen đá', 1)
INSERT [dbo].[FOOD] ([id], [price], [name], [id_category]) VALUES (3, 29000, N'Bạc Xỉu', 1)
INSERT [dbo].[FOOD] ([id], [price], [name], [id_category]) VALUES (4, 29000, N'Phin sữa nóng', 1)
INSERT [dbo].[FOOD] ([id], [price], [name], [id_category]) VALUES (5, 29000, N'Phin đen nóng', 1)
INSERT [dbo].[FOOD] ([id], [price], [name], [id_category]) VALUES (6, 29000, N'Ca cao đá', 1)
INSERT [dbo].[FOOD] ([id], [price], [name], [id_category]) VALUES (7, 33000, N'Đường nâu cacao sữa', 2)
INSERT [dbo].[FOOD] ([id], [price], [name], [id_category]) VALUES (8, 33000, N'Đường nâu kem cheese', 2)
INSERT [dbo].[FOOD] ([id], [price], [name], [id_category]) VALUES (9, 30000, N'Trà xanh đậu đỏ', 3)
INSERT [dbo].[FOOD] ([id], [price], [name], [id_category]) VALUES (10, 30000, N'Trà sen vàng', 3)
INSERT [dbo].[FOOD] ([id], [price], [name], [id_category]) VALUES (11, 29000, N'Bánh Tiramisu', 4)
INSERT [dbo].[FOOD] ([id], [price], [name], [id_category]) VALUES (12, 29000, N'Bánh mousse Đào', 4)
INSERT [dbo].[FOOD] ([id], [price], [name], [id_category]) VALUES (13, 29000, N'Bánh phô mai cà phê', 4)
INSERT [dbo].[FOOD] ([id], [price], [name], [id_category]) VALUES (14, 9000, N'Cookies hạt bí', 4)
GO
INSERT [dbo].[FOOD_CATEGORY] ([id], [name]) VALUES (1, N'Cà phê')
INSERT [dbo].[FOOD_CATEGORY] ([id], [name]) VALUES (2, N'Trà sữa')
INSERT [dbo].[FOOD_CATEGORY] ([id], [name]) VALUES (3, N'Trà')
INSERT [dbo].[FOOD_CATEGORY] ([id], [name]) VALUES (4, N'Bánh')
GO
INSERT [dbo].[PART_TIME] ([station], [Time_begin], [Time_end], [id_staff]) VALUES (N'Đã trực', CAST(N'2020-12-01T09:00:00.000' AS DateTime), CAST(N'2020-12-01T21:00:00.000' AS DateTime), 1)
INSERT [dbo].[PART_TIME] ([station], [Time_begin], [Time_end], [id_staff]) VALUES (N'Chưa trực', CAST(N'2020-12-02T09:00:00.000' AS DateTime), CAST(N'2020-12-02T21:00:00.000' AS DateTime), 2)
INSERT [dbo].[PART_TIME] ([station], [Time_begin], [Time_end], [id_staff]) VALUES (N'Chưa trực', CAST(N'2020-12-03T09:00:00.000' AS DateTime), CAST(N'2020-12-03T21:00:00.000' AS DateTime), 3)
INSERT [dbo].[PART_TIME] ([station], [Time_begin], [Time_end], [id_staff]) VALUES (N'Chưa trực', CAST(N'2020-12-04T09:00:00.000' AS DateTime), CAST(N'2020-12-04T21:00:00.000' AS DateTime), 4)
INSERT [dbo].[PART_TIME] ([station], [Time_begin], [Time_end], [id_staff]) VALUES (N'Chưa trực', CAST(N'2020-12-05T09:00:00.000' AS DateTime), CAST(N'2020-12-05T21:00:00.000' AS DateTime), 5)
GO
INSERT [dbo].[STAFF] ([id], [name], [sdt], [address], [sex], [salary], [status]) VALUES (1, N'Huỳnh Thị Hương Ly', N'771111111', N'Quảng Nam', N'nữ', 7000000, 1)
INSERT [dbo].[STAFF] ([id], [name], [sdt], [address], [sex], [salary], [status]) VALUES (2, N'Phan Thành Trung', N'771111112', N'Quảng Bình', N'nữ', 7000000, 1)
INSERT [dbo].[STAFF] ([id], [name], [sdt], [address], [sex], [salary], [status]) VALUES (3, N'Lê Đỗ Trà My', N'771111113', N'Bình Dương', N'nữ', 7000000, 1)
INSERT [dbo].[STAFF] ([id], [name], [sdt], [address], [sex], [salary], [status]) VALUES (4, N'Võ Thị Thanh Ngân', N'771111114', N'Đồng Tháp', N'nữ', 7000000, 1)
INSERT [dbo].[STAFF] ([id], [name], [sdt], [address], [sex], [salary], [status]) VALUES (5, N'Trần Gia Nguyên', N'771111115', N'Gia Lai', N'nữ', 7000000, 1)
INSERT [dbo].[STAFF] ([id], [name], [sdt], [address], [sex], [salary], [status]) VALUES (6, N'Admin', N'771111110', N'Tp.HCM', N'Nữ', 0, 1)
INSERT [dbo].[STAFF] ([id], [name], [sdt], [address], [sex], [salary], [status]) VALUES (7, N'La Lương Linh', N'771111005', N'Gia Lai', N'nữ', 7000000, 0)
GO
INSERT [dbo].[TABLE_FOOD] ([id], [name], [status]) VALUES (1, N'bàn 1', 0)
INSERT [dbo].[TABLE_FOOD] ([id], [name], [status]) VALUES (2, N'bàn 2', 0)
INSERT [dbo].[TABLE_FOOD] ([id], [name], [status]) VALUES (3, N'bàn 3', 0)
INSERT [dbo].[TABLE_FOOD] ([id], [name], [status]) VALUES (4, N'bàn 4', 1)
INSERT [dbo].[TABLE_FOOD] ([id], [name], [status]) VALUES (5, N'bàn 5', 0)
INSERT [dbo].[TABLE_FOOD] ([id], [name], [status]) VALUES (6, N'bàn 6', 0)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__ACCOUNT__F3DBC572F3991DC9]    Script Date: 15-Dec-20 2:45:51 PM ******/
ALTER TABLE [dbo].[ACCOUNT] ADD  CONSTRAINT [UQ__ACCOUNT__F3DBC572F3991DC9] UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BILL]  WITH CHECK ADD  CONSTRAINT [FK__BILL__id_staff__2C3393D0] FOREIGN KEY([id_staff])
REFERENCES [dbo].[STAFF] ([id])
GO
ALTER TABLE [dbo].[BILL] CHECK CONSTRAINT [FK__BILL__id_staff__2C3393D0]
GO
ALTER TABLE [dbo].[BILL]  WITH CHECK ADD  CONSTRAINT [FK__BILL__id_table__2D27B809] FOREIGN KEY([id_table])
REFERENCES [dbo].[TABLE_FOOD] ([id])
GO
ALTER TABLE [dbo].[BILL] CHECK CONSTRAINT [FK__BILL__id_table__2D27B809]
GO
ALTER TABLE [dbo].[BILL_INF]  WITH CHECK ADD  CONSTRAINT [FK__BILL_INF__id_bil__35BCFE0A] FOREIGN KEY([id_bill])
REFERENCES [dbo].[BILL] ([id])
GO
ALTER TABLE [dbo].[BILL_INF] CHECK CONSTRAINT [FK__BILL_INF__id_bil__35BCFE0A]
GO
ALTER TABLE [dbo].[BILL_INF]  WITH CHECK ADD  CONSTRAINT [FK__BILL_INF__id_foo__34C8D9D1] FOREIGN KEY([id_food])
REFERENCES [dbo].[FOOD] ([id])
GO
ALTER TABLE [dbo].[BILL_INF] CHECK CONSTRAINT [FK__BILL_INF__id_foo__34C8D9D1]
GO
ALTER TABLE [dbo].[FOOD]  WITH CHECK ADD FOREIGN KEY([id_category])
REFERENCES [dbo].[FOOD_CATEGORY] ([id])
GO
ALTER TABLE [dbo].[PART_TIME]  WITH CHECK ADD  CONSTRAINT [FK__PART_TIME__id_st__38996AB5] FOREIGN KEY([id_staff])
REFERENCES [dbo].[STAFF] ([id])
GO
ALTER TABLE [dbo].[PART_TIME] CHECK CONSTRAINT [FK__PART_TIME__id_st__38996AB5]
GO
/****** Object:  StoredProcedure [dbo].[USP_GetListBillByDate]    Script Date: 15-Dec-20 2:45:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetListBillByDate]
@checkIn date, @checkOut date
AS 
BEGIN
	SELECT t.name AS [Tên bàn], b.totalPrice AS [Tổng tiền], 
		dayCheckIn AS [Ngày vào], dayCheckOut AS [Ngày ra], discount AS [Giảm giá]
	FROM dbo.Bill AS b,dbo.TABLE_FOOD AS t
	WHERE dayCheckIn >= @checkIn AND dayCheckOut <= @checkOut AND b.status = 1
	AND t.id = b.id_table
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetTableList]    Script Date: 15-Dec-20 2:45:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetTableList]
AS SELECT * FROM dbo.Table_Food
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertBill]    Script Date: 15-Dec-20 2:45:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create PROC [dbo].[USP_InsertBill]
@idTable INT, @id_staff int
AS
BEGIN
	INSERT dbo.Bill 
	        ( 
				dayCheckIn ,
	          DayCheckOut ,
			  discount,
			  id_staff,
	          id_Table ,
	          status	          
	        )
	VALUES  ( 
			GETDATE() , -- DateCheckIn - date
	          NULL , -- DateCheckOut - date
			  0,
			  @id_staff,
	          @idTable , -- idTable - int
	          0  -- chưa tính tiền	          
	        )
END
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertBillInfo]    Script Date: 15-Dec-20 2:45:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create PROC [dbo].[USP_InsertBillInfo]
@idBill INT, @idFood INT, @count INT
AS
BEGIN

	DECLARE @isExitsBillInfo INT
	DECLARE @foodCount INT = 1

	SELECT @isExitsBillInfo = id, @foodCount = b.amount
	FROM Bill_Inf AS b 
	WHERE id_Bill = @idBill AND id_Food = @idFood

	IF (@isExitsBillInfo > 0)-- nếu món đã có trong bill thì cộng dồn
	BEGIN
		DECLARE @newCount INT = @foodCount + @count
		IF (@newCount > 0)
			UPDATE dbo.Bill_Inf	
			SET amount = @foodCount + @count 
			WHERE id_Food = @idFood
		ELSE
			DELETE dbo.Bill_Inf WHERE id_Bill = @idBill AND id_Food = @idFood
	END
	ELSE
	BEGIN
		INSERT	dbo.Bill_Inf( id_Bill, id_Food, amount )
		VALUES  (@idBill,  @idFood, @count  )
	END
END
GO
/****** Object:  StoredProcedure [dbo].[USP_Login]    Script Date: 15-Dec-20 2:45:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_Login]
@userName nvarchar(100), @passWord nvarchar(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @userName AND PassWord = @passWord
END
GO
/****** Object:  StoredProcedure [dbo].[USP_SwitchTabelEmpty]    Script Date: 15-Dec-20 2:45:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_SwitchTabelEmpty]
@idTable1 INT, @idTable2 int AS 
BEGIN
	update bill
	set id_table=@idTable2
	where status=0 and id_table=@idTable1
	update TABLE_FOOD
	set status=0
	where id=@idTable1
END
GO
/****** Object:  StoredProcedure [dbo].[USP_SwitchTabelNotEmpty]    Script Date: 15-Dec-20 2:45:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[USP_SwitchTabelNotEmpty]
@idTable1 INT, @idTable2 int AS 
BEGIN
	declare @id1 int
	declare @id2 int
	--lấy id bill bàn bị chuyển
	select @id1=id
	from BILL 
	where id_table=@idTable1 and status=0--0:chưa tính tiền
	--lấy id bill bàn sắp chuyển
	select @id2=id
	from BILL 
	where id_table=@idTable2 and status=0
	--lấy food bàn cũ vào bảng tạm
	SELECT id_bill,id_food,amount
	INTO #lstFoodOldTable --- temporary table
	FROM BILL_INF
	WHERE id_bill=@id1

	update #lstFoodOldTable
	set id_bill=@id2
	--them ds food từ bàn cũ sang mới
	INSERT INTO bill_inf(id_bill,id_food,amount)
	SELECT * FROM #lstFoodOldTable	 
	--thay đổi status bàn bị chuyển
	update table_food
	set status=0 
	where id=@idTable1
	--xóa ds food bàn cũ
	delete BILL_INF where id_bill=@id1
	--xóa bill bàn bị chuyển
	delete bill where id_table=@idTable1 and status=0
END
GO
/****** Object:  StoredProcedure [dbo].[USP_UpdateAccount]    Script Date: 15-Dec-20 2:45:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_UpdateAccount]
@userName NVARCHAR(20), @displayName NVARCHAR(20), @password VARCHAR(20), @type int, @id_staff int
AS
BEGIN
	UPDATE dbo.Account 
	SET displayName = @displayName , id_staff=@id_staff , Account.password=@password  , type=@type
	WHERE UserName = @userName
END
GO
