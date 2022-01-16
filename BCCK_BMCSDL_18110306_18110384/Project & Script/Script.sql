--Create Table 
--Tạo Database--
  CREATE TABLE "TRUONG"."PASSPORTDATA" 
   (	"ID" NUMBER(5,0) GENERATED ALWAYS AS IDENTITY MINVALUE 1 MAXVALUE 999 INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE  NOKEEP  NOSCALE , 
	"HOTEN" NVARCHAR2(20), 
	"DIACHI" NVARCHAR2(200), 
	"PHAI" NVARCHAR2(20), 
	"CMND" VARCHAR2(20 BYTE), 
	"DIENTHOAI" VARCHAR2(20 BYTE), 
	"EMAIL" VARCHAR2(30 BYTE), 
	"TTXACTHUC" NVARCHAR2(20), 
	"TTXETDUYET" NVARCHAR2(20), 
	"GHICHU" NVARCHAR2(20), 
	"IDUSERXT" NVARCHAR2(20), 
	"IDUSERXD" NVARCHAR2(20), 
	"TTTHONGBAO" NVARCHAR2(200), 
	"IDUSERTT" NVARCHAR2(20), 
	"NGAYSINH" DATE, 
	"NGAYCAPCMND" DATE
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--CREATE SCHEMA DATABASE RESIDENT--
--Tạo Database--
REATE TABLE "TRUONG"."RESIDENT" 
   (	"CMND" NVARCHAR2(20), 
	"HOTEN" NVARCHAR2(20), 
	"NGAYSINH" DATE, 
	"GIOITINH" NVARCHAR2(20), 
	"QUOCTICH" NVARCHAR2(20), 
	"DIACHI" NVARCHAR2(50), 
	"PHUONG" NVARCHAR2(30), 
	"QUANHUYEN" NVARCHAR2(50), 
	"TINH" NVARCHAR2(50), 
	"NGAYCAP" DATE
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
  GRANT SELECT ON "TRUONG"."RESIDENT" TO "HOTRUONG";

-- create policy
create or replace function bao_mat_nhan_vien_luu_tru (p_schema varchar2, p_obj varchar2)
return varchar2 as 
    lv_user varchar2(100);
    roleUser number;
    lv_predicate varchar2(1000);
begin
    select user into lv_user from dual;
    select role into roleUser from truong.taikhoan where UPPER(taikhoan.taikhoan)= (select user from dual);
    if roleUser='2' then
        lv_predicate:='1=2';
    else
        lv_predicate:='1=1';
    end if;
return lv_predicate;
end bao_mat_nhan_vien_luu_tru;

-- b? ph?n l?u tr? ch? xem tt id, tình tr?ng xác th?c và xét duy?t


BEGIN 
    DBMS_RLS.add_policy (
    object_schema     => 'truong',
    object_name        => 'PASSPORTDATA',
    policy_name        => 'Bao_Mat_Luu_Tru',
    function_schema    => 'truong',
    policy_function    => 'bao_mat_nhan_vien_luu_tru',
    statement_types    => 'SELECT',
    sec_relevant_cols        => 'HOTEN,DIACHI,PHAI,CMND,DIENTHOAI,EMAIL,GHICHU,IDUSERXT,IDUSERXD,TTTHONGBAO,IDUSERTT',
    sec_relevant_cols_opt        => dbms_rls.ALL_ROWS
    ); 
END; 


BEGIN 
DBMS_RLS.drop_policy   
(object_schema     => 'truong', object_name        => 'PASSPORTDATA', policy_name        => 'bao_mat_nhan_vien_luu_tru'); 
END; 



-- b? ph?n xét duy?t
create or replace function bao_mat_nhan_vien_xet_duyet (p_schema varchar2, p_obj varchar2)
return varchar2 as 
    lv_user varchar2(100);
    roleUser number;
    lv_predicate varchar2(1000);
begin
    select user into lv_user from dual;
    select role into roleUser from truong.taikhoan where UPPER(taikhoan.taikhoan)= (select user from dual);
    if roleUser='1' then
        lv_predicate:='1=2';
    else
        lv_predicate:='1=1';
    end if;
return lv_predicate;
end bao_mat_nhan_vien_xet_duyet;


BEGIN 
    DBMS_RLS.add_policy (
    object_schema     => 'truong',
    object_name        => 'RESIDENT',
    policy_name        => 'Bao_Mat_Xet_Duyet_RESIDENT',
    function_schema    => 'truong',
    policy_function    => 'bao_mat_nhan_vien_xet_duyet',
    statement_types    => 'SELECT'
    ); 
END; 

BEGIN 
DBMS_RLS.drop_policy   
(object_schema     => 'truong', object_name        => 'PASSPORTDATA', policy_name        => 'Bao_Mat_Xet_Duyet'); 
END;


-- b? ph?t xác th?c
create or replace function bao_mat_nhan_vien_xac_thuc (p_schema varchar2, p_obj varchar2)
return varchar2 as 
    lv_user varchar2(100);
    roleUser number;
    lv_predicate varchar2(1000);
begin
    select user into lv_user from dual;
   select role into roleUser from truong.taikhoan where UPPER(taikhoan.taikhoan)= (select user from dual);
    if roleUser='0' then
        lv_predicate:='1=2';
    else
        lv_predicate:='1=1';
    end if;
return lv_predicate;
end bao_mat_nhan_vien_xac_thuc;

BEGIN 
    DBMS_RLS.add_policy (
    object_schema     => 'truong',
    object_name        => 'PASSPORTDATA',
    policy_name        => 'Bao_Mat_Xac_Thuc',
    function_schema    => 'truong',
    policy_function    => 'bao_mat_nhan_vien_xac_thuc',
    statement_types    => 'SELECT',
    sec_relevant_cols        => 'ID,TTXETDUYET,TTXACTHUC,TTTHONGBAO,IDUSERXT,IDUSERXD,IDUSERTT',
    sec_relevant_cols_opt        => dbms_rls.ALL_ROWS
    ); 
END; 


BEGIN 
DBMS_RLS.drop_policy   
(object_schema     => 'truong', object_name        => 'PASSPORTDATA', policy_name        => 'Bao_Mat_Xac_Thuc'); 
END;


Insert into TRUONG.RESIDENT (CMND,HOTEN,NGAYSINH,GIOITINH,QUOCTICH,DIACHI,PHUONG,QUANHUYEN,TINH,NGAYCAP) values ('1811','Hồ Văn Trường',to_date('15-MAY-00','DD-MON-RR'),'Nam','Việt Nam','Thôn Vĩnh Hy','Phước Lộc','Tuy Phước','Bình Định',to_date('12-JAN-15','DD-MON-RR'));
Insert into TRUONG.RESIDENT (CMND,HOTEN,NGAYSINH,GIOITINH,QUOCTICH,DIACHI,PHUONG,QUANHUYEN,TINH,NGAYCAP) values ('1800','Hồ Vĩnh Long',to_date('23-MAY-00','DD-MON-RR'),'Nam','Việt Nam','Thôn Hòa Lộc','Phước Long','Long Phước','Ninh Thuận',to_date('12-JAN-15','DD-MON-RR'));
Insert into TRUONG.RESIDENT (CMND,HOTEN,NGAYSINH,GIOITINH,QUOCTICH,DIACHI,PHUONG,QUANHUYEN,TINH,NGAYCAP) values ('1912','Mai Đăng Khoa',to_date('04-FEB-00','DD-MON-RR'),'Nam','Việt Nam','Thôn 10','Eabar','Buôn Đôn','Đăk Lăk',to_date('12-JAN-15','DD-MON-RR'));
Insert into TRUONG.RESIDENT (CMND,HOTEN,NGAYSINH,GIOITINH,QUOCTICH,DIACHI,PHUONG,QUANHUYEN,TINH,NGAYCAP) values ('1905','Mai Thị Hải Yến',to_date('23-SEP-02','DD-MON-RR'),'Nữ','Việt Nam','Thôn 2','Khánh Hội','Yên Khánh','Ninh Bình',to_date('12-JAN-15','DD-MON-RR'));

Insert into PASSPORTDATA (ID,HOTEN,DIACHI,PHAI,CMND,DIENTHOAI,EMAIL,TTXACTHUC,TTXETDUYET,GHICHU,IDUSERXT,IDUSERXD,TTTHONGBAO,IDUSERTT,NGAYSINH,NGAYCAPCMND) values (61,'Mai Đăng Khoa','Thành phố Hồ Chí Minh','Nam','32221312','0365845845','mail@gmail.com','Chưa xác thực','Chưa duyệt',null,null,null,'Chưa thông báo',null,to_date('12-JAN-22','DD-MON-RR'),to_date('12-JAN-22','DD-MON-RR'));
Insert into PASSPORTDATA (ID,HOTEN,DIACHI,PHAI,CMND,DIENTHOAI,EMAIL,TTXACTHUC,TTXETDUYET,GHICHU,IDUSERXT,IDUSERXD,TTTHONGBAO,IDUSERTT,NGAYSINH,NGAYCAPCMND) values (42,'Hồ Văn Trường','Quy Nhơn, Bình Định','Nam','327821312','0436771212','truonhg@gmail.com','Đã xác thực','Chưa duyệt',null,'1','2',null,null,null,null);
Insert into PASSPORTDATA (ID,HOTEN,DIACHI,PHAI,CMND,DIENTHOAI,EMAIL,TTXACTHUC,TTXETDUYET,GHICHU,IDUSERXT,IDUSERXD,TTTHONGBAO,IDUSERTT,NGAYSINH,NGAYCAPCMND) values (12,'Nguyễn Văn Long','Quy Nhơn, Bình Định','Nam','327821312','021005212','long@gmail.com','Đã xác thực','Đã xét duyệt',null,'1','2',null,null,null,null);
Insert into PASSPORTDATA (ID,HOTEN,DIACHI,PHAI,CMND,DIENTHOAI,EMAIL,TTXACTHUC,TTXETDUYET,GHICHU,IDUSERXT,IDUSERXD,TTTHONGBAO,IDUSERTT,NGAYSINH,NGAYCAPCMND) values (15,'Mai Văn Khoán','Đăk Lăk','Nam','001245821','0365845845','khoan@gmail.com','Chưa xác thực','Chưa duyệt',null,null,null,'Chưa thông báo',null,to_date('12-JAN-22','DD-MON-RR'),to_date('12-JAN-22','DD-MON-RR'));
Insert into PASSPORTDATA (ID,HOTEN,DIACHI,PHAI,CMND,DIENTHOAI,EMAIL,TTXACTHUC,TTXETDUYET,GHICHU,IDUSERXT,IDUSERXD,TTTHONGBAO,IDUSERTT,NGAYSINH,NGAYCAPCMND) values (19,'Trần Nguyên Quang','Quy Nhơn, Bình Định','Nam','991528528','0436532212','@quanggmail.com','Đã xác thực','Chưa duyệt',null,'1','2',null,null,null,null);
Insert into PASSPORTDATA (ID,HOTEN,DIACHI,PHAI,CMND,DIENTHOAI,EMAIL,TTXACTHUC,TTXETDUYET,GHICHU,IDUSERXT,IDUSERXD,TTTHONGBAO,IDUSERTT,NGAYSINH,NGAYCAPCMND) values (21,'Lê Minh Hai','Quy Nhơn, Bình Định','Nam','124921420','044564345','hai@gmail.com','Đã xác thực','Đã xét duyệt',null,'1','2',null,null,null,null);
Insert into PASSPORTDATA (ID,HOTEN,DIACHI,PHAI,CMND,DIENTHOAI,EMAIL,TTXACTHUC,TTXETDUYET,GHICHU,IDUSERXT,IDUSERXD,TTTHONGBAO,IDUSERTT,NGAYSINH,NGAYCAPCMND) values (32,'Bùi Công Minh','Thành phố Hồ Chí Minh','Nam','0138829423','0365845845','minh@gmail.com','Chưa xác thực','Chưa duyệt',null,null,null,'Chưa thông báo',null,to_date('12-JAN-22','DD-MON-RR'),to_date('12-JAN-22','DD-MON-RR'));
Insert into PASSPORTDATA (ID,HOTEN,DIACHI,PHAI,CMND,DIENTHOAI,EMAIL,TTXACTHUC,TTXETDUYET,GHICHU,IDUSERXT,IDUSERXD,TTTHONGBAO,IDUSERTT,NGAYSINH,NGAYCAPCMND) values (45,'Trần Ngọc Hòa Hoàng','Quy Nhơn, Bình Định','Nam','124295243','099124912','hoang@gmail.com','Đã xác thực','Chưa duyệt',null,'1','2',null,null,null,null);
Insert into PASSPORTDATA (ID,HOTEN,DIACHI,PHAI,CMND,DIENTHOAI,EMAIL,TTXACTHUC,TTXETDUYET,GHICHU,IDUSERXT,IDUSERXD,TTTHONGBAO,IDUSERTT,NGAYSINH,NGAYCAPCMND) values (90,'Nguyễn Hải Trân','Quy Nhơn, Bình Định','Nam','260204325','03249329592','tran@gmail.com','Đã xác thực','Đã xét duyệt',null,'1','2',null,null,null,null);


----- BƯỚC 1: Login vào user SYS_ORCLPDB -----

-- Tạo main_role và gán quyền connect --
create role main_role;
GRANT connect TO main_role; 

-- Tạo và gán main_role cho user xacthuc (Xác Thực) 
CREATE USER xacthuc IDENTIFIED BY xacthuc; 
GRANT main_role TO xacthuc; 
 
-- Tạo và gán main_role cho user xetduyet (Xét Duyệt) 
CREATE USER xetduyet IDENTIFIED BY xetduyet; 
GRANT main_role TO xetduyet; 
 
-- Tạo và gán main_role cho user luutru (Lưu Trữ) 
CREATE USER luutru IDENTIFIED BY luutru; 
GRANT main_role TO luutru; 
 
-- Tạo và gán main_role cho user giamsat (Giám Sát) 
CREATE USER giamsat IDENTIFIED BY giamsat; 
GRANT main_role TO giamsat;

----- BƯỚC 2: Login DANGKHOA_MANAGER ------

-- Tạo table Passportdata --
CREATE TABLE PASSPORTDATA
   (ID NUMBER(10), 
	HOTEN NVARCHAR2(20), 
	DIACHI NVARCHAR2(200), 
	PHAI NVARCHAR2(20), 
	CMND VARCHAR2(20), 
	DIENTHOAI VARCHAR2(20), 
	EMAIL VARCHAR2(30), 
	TTXACTHUC NVARCHAR2(20), 
	TTXETDUYET NVARCHAR2(20), 
	GHICHU NVARCHAR2(20), 
	IDUSERXT NVARCHAR2(20), 
	IDUSERXD NVARCHAR2(20), 
	TTTHONGBAO NVARCHAR2(200), 
	IDUSERTT NVARCHAR2(20), 
	NGAYSINH DATE, 
	NGAYCAPCMND DATE,
    PRIMARY KEY (ID)
) ;

-- Insert dữ liệu --
Insert into PASSPORTDATA (ID,HOTEN,DIACHI,PHAI,CMND,DIENTHOAI,EMAIL,TTXACTHUC,TTXETDUYET,GHICHU,IDUSERXT,IDUSERXD,TTTHONGBAO,IDUSERTT,NGAYSINH,NGAYCAPCMND) values (61,'Mai Đăng Khoa','Thành phố Hồ Chí Minh','Nam','32221312','0365845845','mail@gmail.com','Chưa xác thực','Chưa duyệt',null,null,null,'Chưa thông báo',null,to_date('12-JAN-22','DD-MON-RR'),to_date('12-JAN-22','DD-MON-RR'));
Insert into PASSPORTDATA (ID,HOTEN,DIACHI,PHAI,CMND,DIENTHOAI,EMAIL,TTXACTHUC,TTXETDUYET,GHICHU,IDUSERXT,IDUSERXD,TTTHONGBAO,IDUSERTT,NGAYSINH,NGAYCAPCMND) values (42,'Hồ Văn Trường','Quy Nhơn, Bình Định','Nam','327821312','0436771212','truonhg@gmail.com','Đã xác thực','Chưa duyệt',null,'1','2',null,null,null,null);
Insert into PASSPORTDATA (ID,HOTEN,DIACHI,PHAI,CMND,DIENTHOAI,EMAIL,TTXACTHUC,TTXETDUYET,GHICHU,IDUSERXT,IDUSERXD,TTTHONGBAO,IDUSERTT,NGAYSINH,NGAYCAPCMND) values (12,'Nguyễn Văn Long','Quy Nhơn, Bình Định','Nam','327821312','021005212','long@gmail.com','Đã xác thực','Đã xét duyệt',null,'1','2',null,null,null,null);
Insert into PASSPORTDATA (ID,HOTEN,DIACHI,PHAI,CMND,DIENTHOAI,EMAIL,TTXACTHUC,TTXETDUYET,GHICHU,IDUSERXT,IDUSERXD,TTTHONGBAO,IDUSERTT,NGAYSINH,NGAYCAPCMND) values (15,'Mai Văn Khoán','Đăk Lăk','Nam','001245821','0365845845','khoan@gmail.com','Chưa xác thực','Chưa duyệt',null,null,null,'Chưa thông báo',null,to_date('12-JAN-22','DD-MON-RR'),to_date('12-JAN-22','DD-MON-RR'));
Insert into PASSPORTDATA (ID,HOTEN,DIACHI,PHAI,CMND,DIENTHOAI,EMAIL,TTXACTHUC,TTXETDUYET,GHICHU,IDUSERXT,IDUSERXD,TTTHONGBAO,IDUSERTT,NGAYSINH,NGAYCAPCMND) values (19,'Trần Nguyên Quang','Quy Nhơn, Bình Định','Nam','991528528','0436532212','@quanggmail.com','Đã xác thực','Chưa duyệt',null,'1','2',null,null,null,null);
Insert into PASSPORTDATA (ID,HOTEN,DIACHI,PHAI,CMND,DIENTHOAI,EMAIL,TTXACTHUC,TTXETDUYET,GHICHU,IDUSERXT,IDUSERXD,TTTHONGBAO,IDUSERTT,NGAYSINH,NGAYCAPCMND) values (21,'Lê Minh Hai','Quy Nhơn, Bình Định','Nam','124921420','044564345','hai@gmail.com','Đã xác thực','Đã xét duyệt',null,'1','2',null,null,null,null);
Insert into PASSPORTDATA (ID,HOTEN,DIACHI,PHAI,CMND,DIENTHOAI,EMAIL,TTXACTHUC,TTXETDUYET,GHICHU,IDUSERXT,IDUSERXD,TTTHONGBAO,IDUSERTT,NGAYSINH,NGAYCAPCMND) values (32,'Bùi Công Minh','Thành phố Hồ Chí Minh','Nam','0138829423','0365845845','minh@gmail.com','Chưa xác thực','Chưa duyệt',null,null,null,'Chưa thông báo',null,to_date('12-JAN-22','DD-MON-RR'),to_date('12-JAN-22','DD-MON-RR'));
Insert into PASSPORTDATA (ID,HOTEN,DIACHI,PHAI,CMND,DIENTHOAI,EMAIL,TTXACTHUC,TTXETDUYET,GHICHU,IDUSERXT,IDUSERXD,TTTHONGBAO,IDUSERTT,NGAYSINH,NGAYCAPCMND) values (45,'Trần Ngọc Hòa Hoàng','Quy Nhơn, Bình Định','Nam','124295243','099124912','hoang@gmail.com','Đã xác thực','Chưa duyệt',null,'1','2',null,null,null,null);
Insert into PASSPORTDATA (ID,HOTEN,DIACHI,PHAI,CMND,DIENTHOAI,EMAIL,TTXACTHUC,TTXETDUYET,GHICHU,IDUSERXT,IDUSERXD,TTTHONGBAO,IDUSERTT,NGAYSINH,NGAYCAPCMND) values (90,'Nguyễn Hải Trân','Quy Nhơn, Bình Định','Nam','260204325','03249329592','tran@gmail.com','Đã xác thực','Đã xét duyệt',null,'1','2',null,null,null,null);

--- Gán quyền cho các user ---
GRANT select, insert, update ON PASSPORTDATA TO lbacsys;

GRANT select, insert, update ON PASSPORTDATA TO xacthuc;
GRANT select, insert, update ON PASSPORTDATA TO xetduyet;
GRANT select, insert, update ON PASSPORTDATA TO luutru;


----- BƯỚC 3: Login LBACSYS -----

-- Dùng procedure SA_SYSDBA.CREATE_POLICY để tạo ra chính sách mới 
BEGIN 
	SA_SYSDBA.CREATE_POLICY ( 
	policy_name => 'ACCESS_PASSPORTDATA', 
	column_name => 'OLS_COLUMN'); 
END;

-- Quy định chính sách ACCESS_PASSPORTDATA có 3 level (xacthuc, xetduyet, luutru) --
BEGIN sa_components.create_level 
	(policy_name 	=> 'ACCESS_PASSPORTDATA', 
    long_name  	=> 'XETDUYET', 
    short_name  	=> 'XD', 
    level_num  	=> 300); 
END; 

-- Thực thi thủ tục --
EXECUTE sa_components.create_level ('ACCESS_PASSPORTDATA',200,'XT','XACTHUC'); 
EXECUTE sa_components.create_level ('ACCESS_PASSPORTDATA',400,'LT','LUUTRU'); 

-- Gán level cho người dùng -- 
BEGIN 
     sa_user_admin.set_levels 
    (policy_name  => 'ACCESS_PASSPORTDATA', 
     user_name    => 'xacthuc', 
     max_level    => 'XT', 
     min_level    => 'XT',
     def_level    => 'XT', 
     row_level    => 'XT');  
END; 

BEGIN 
     sa_user_admin.set_levels 
    (policy_name  => 'ACCESS_PASSPORTDATA', 
     user_name    => 'xetduyet', 
     max_level    => 'XD', 
     min_level    => 'XD',
     def_level    => 'XD', 
     row_level    => 'XD');  
END; 

BEGIN 
     sa_user_admin.set_levels 
    (policy_name  => 'ACCESS_PASSPORTDATA', 
     user_name    => 'luutru', 
     max_level    => 'LT', 
     min_level    => 'LT',
     def_level    => 'LT', 
     row_level    => 'LT');  
END;

-- Để gán chính sách cho các bảng ta dùng thủ tục SA_POLICY_ADMIN.APPLY_TABLE_POLICY --
BEGIN 
    sa_policy_admin.apply_table_policy (
    policy_name      => 'ACCESS_PASSPORTDATA', 
    schema_name      => 'DANGKHOA_MANAGER', 
    table_name       => 'PASSPORTDATA', 
    table_options    => 'NO_CONTROL'); 
END; 

-- Thực hiện gán nhãn cho các dòng dữ liệu --
UPDATE DANGKHOA_MANAGER.PASSPORTDATA SET ols_column = char_to_label ('ACCESS_PASSPORTDATA', 'XT'); 

UPDATE DANGKHOA_MANAGER.PASSPORTDATA SET ols_column = char_to_label ('ACCESS_PASSPORTDATA', 'XT') WHERE ttxacthuc = 'Chưa xác thực' and ttxetduyet = 'Chưa duyệt';
UPDATE DANGKHOA_MANAGER.PASSPORTDATA SET ols_column = char_to_label ('ACCESS_PASSPORTDATA', 'XD') WHERE ttxacthuc = 'Đã xác thực' and ttxetduyet = 'Chưa duyệt'; 
UPDATE DANGKHOA_MANAGER.PASSPORTDATA SET ols_column = char_to_label ('ACCESS_PASSPORTDATA', 'LT') WHERE ttxacthuc = 'Đã xác thực' and ttxetduyet != 'Chưa duyệt'; 
COMMIT;

-- Do ở trên đã thiết lập tùy chọn NO_CONTROL cho việc áp dụng chính sách nên phải remove chính sách khỏi bảng 
-- rồi áp dụng lại chính sách với tùy chọn mới để chính sách có thể được kích hoạt bảo vệ cho bảng
BEGIN 
    sa_policy_admin.remove_table_policy (
    policy_name     => 'ACCESS_PASSPORTDATA', 
    schema_name     => 'DANGKHOA_MANAGER', 
    table_name      => 'PASSPORTDATA'); 
    sa_policy_admin.apply_table_policy (
    policy_name     => 'ACCESS_PASSPORTDATA', 
    schema_name     => 'DANGKHOA_MANAGER', 
    table_name      => 'PASSPORTDATA', 
    table_options   =>  'READ_CONTROL,WRITE_CONTROL,CHECK_CONTROL'); 
END; 

----- BƯỚC 4: CONNECT và kiểm tra USER -----

-- Connect vào user xacthuc và thực thi lệnh:
SELECT  label_to_char (ols_column) as label, passportdata.* 
FROM dangkhoa_manager.passportdata WHERE ttxacthuc = 'Chưa xác thực' and ttxetduyet = 'Chưa duyệt'; 

-- Connect vào user luutru và thực thi lệnh:
SELECT  label_to_char (ols_column) as label, passportdata.* 
FROM dangkhoa_manager.passportdata WHERE ttxacthuc = 'Đã xác thực' and ttxetduyet != 'Chưa duyệt'; 

-- Connect vào user luutru và thực thi lệnh:
SELECT  label_to_char (ols_column) as label, passportdata.* 
FROM dangkhoa_manager.passportdata WHERE ttxacthuc = 'Đã xác thực' and ttxetduyet = 'Chưa duyệt'; 



