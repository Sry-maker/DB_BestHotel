﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;


namespace BackEnd.Models
{
    public class DataAccess
    {
        public static OracleConnection DB;

        //建立数据库连接
        public static void CreateConn()
        {
            string connString = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = orcl.mshome.net))); Persist Security Info=True;User ID=system;Password=Bac66238#tan;";
            DB = new OracleConnection(connString);
            DB.Open();
        }

        //关闭数据库连接
        public static void CloseConn()
        {
            DB.Close();
        }

        //与功能点1：登录与注册相关的操作

        //在USERS表中查询用户、密码是否错误(登录时使用)
        //密码或用户名错误返回false；密码和用户名正确返回true
        public static bool IsUserExist(string user_id, string user_password)
        {
            int Count;
            CreateConn();
            OracleCommand CMD = DB.CreateCommand();
            CMD.CommandText = "select count(*) from USERS where user_id=:user_id and user_password=:user_password";
            CMD.Parameters.Add(new OracleParameter(":user_id", user_id));
            CMD.Parameters.Add(new OracleParameter(":user_password", user_password));
            Count = Convert.ToInt32(CMD.ExecuteScalar());
            CloseConn();
            if (Count == 0)
                return false;
            else
                return true;

        }

        //初步专用测试
        public static List<User> test()
        {

            OracleCommand Search = DB.CreateCommand();
            Search.CommandText = "select * from EMPLOYEE";
            OracleDataReader Ord = Search.ExecuteReader();
            List<User> a = new List<User>();
            while (Ord.Read())
            {
                a.Add(new User { user_id = Ord.GetValue(0).ToString(), user_password = Ord.GetValue(1).ToString() });
            }
            return a;
        }

        

        //向Users表中增加一个新用户(注册)
        //添加成功返回true，添加失败返回“0”
        public static bool AddUser(User req)
        {
            CreateConn();
            OracleCommand Insert = DB.CreateCommand();
            Insert.CommandText = "insert into USERS values(:USER_ID,:USER_PASSWORD,:USER_TYPE,:SECURITY_Q,:S_Q_ANSWER,:USER_NAME)";
            Insert.Parameters.Add(new OracleParameter(":USER_ID", req.user_id));
            Insert.Parameters.Add(new OracleParameter(":USER_PASSWORD", req.user_password));
            Insert.Parameters.Add(new OracleParameter(":USER_TYPE", req.user_type));
            Insert.Parameters.Add(new OracleParameter(":SECURITY_Q", req.security_q));
            Insert.Parameters.Add(new OracleParameter(":S_Q_ANSWER", req.s_q_answer));
            Insert.Parameters.Add(new OracleParameter(":USER_NAME", req.user_name));
            int Result = Insert.ExecuteNonQuery();
            CloseConn();
            if (Result == 1)
            {
                return true;
            }
            else return false;
        }

        //向Client表中增加一个新客户(注册)
        //添加成功返回1，添加失败返回0
        public static bool AddClient(Client req)
<<<<<<< Updated upstream
        {
            CreateConn();
            OracleCommand Insert = DB.CreateCommand();
            Insert.CommandText = "insert into CLIENT values(:CLIENT_ID,:CLIENT_NAME,:CLIENT_SEX,to_date(:CLIENT_BIRTHDAY,'YYYY-MM-DD'),:CLIENT_TELEPHONENUMBER,:CLIENT_IDENTITY_CARD_NUMBER)";
            Insert.Parameters.Add(new OracleParameter(":CLIENT_ID", req.client_id));
            Insert.Parameters.Add(new OracleParameter(":CLIENT_NAME", req.client_name));
            Insert.Parameters.Add(new OracleParameter(":CLIENT_SEX", req.client_sex));
            Insert.Parameters.Add(new OracleParameter(":CLIENT_BIRTHDAY", req.client_birthday));
            Insert.Parameters.Add(new OracleParameter(":CLIENT_TELEPHONENUMBER", req.client_mobile));
            Insert.Parameters.Add(new OracleParameter(":CLIENT_IDENTITY_CARD_NUMBER", req.client_idCard));
=======
        {
            CreateConn();
            OracleCommand Insert = DB.CreateCommand();
            Insert.CommandText = "insert into CLIENT values(:CLIENT_ID,:CLIENT_NAME,:CLIENT_SEX,to_date(:CLIENT_BIRTHDAY,'YYYY-MM-DD'),:CLIENT_TELEPHONENUMBER,:CLIENT_IDENTITY_CARD_NUMBER)";
            Insert.Parameters.Add(new OracleParameter(":CLIENT_ID", req.client_id));
            Insert.Parameters.Add(new OracleParameter(":CLIENT_NAME", req.client_name));
            Insert.Parameters.Add(new OracleParameter(":CLIENT_SEX", req.client_sex));
            Insert.Parameters.Add(new OracleParameter(":CLIENT_BIRTHDAY", req.client_birthday));
            Insert.Parameters.Add(new OracleParameter(":CLIENT_TELEPHONENUMBER", req.client_mobile));
            Insert.Parameters.Add(new OracleParameter(":CLIENT_IDENTITY_CARD_NUMBER", req.client_idCard));
            int Result = Insert.ExecuteNonQuery();
            CloseConn();
            if (Result == 1)
            {
                return true;
            }
            else return false;
        }

        //向Staff表中增加一个新客户(注册)
        //添加成功返回true，添加失败返回false
        public static bool AddStaff(Staff req)
        {
            CreateConn();
            OracleCommand Insert = DB.CreateCommand();
            Insert.CommandText = "insert into STAFF values(	:STAFF_ID,:STAFF_NAME,:STAFF_SEX,:STAFF_AGE	,:STAFF_IDENTITY_CARD_NUMBER,:STAFF_ADDRESS	,:STAFF_DEPARTMENT,:STAFF_POSITION,to_date(:STAFF_ENTRY_DATE,'YYYY-MM-DD'),:STAFF_SALARY)";
            Insert.Parameters.Add(new OracleParameter("	:STAFF_ID	", req.staff_id));
            Insert.Parameters.Add(new OracleParameter("	:STAFF_NAME	", req.staff_name));
            Insert.Parameters.Add(new OracleParameter("	:STAFF_SEX	", req.staff_sex));
            Insert.Parameters.Add(new OracleParameter("	:STAFF_AGE	", req.staff_age));
            Insert.Parameters.Add(new OracleParameter("	:STAFF_IDENTITY_CARD_NUMBER	", req.staff_identity_card_number));
            Insert.Parameters.Add(new OracleParameter("	:STAFF_ADDRESS	", req.staff_address));
            Insert.Parameters.Add(new OracleParameter("	:STAFF_DEPARTMENT	", req.staff_department));
            Insert.Parameters.Add(new OracleParameter("	:STAFF_POSITION	", req.staff_position));
            Insert.Parameters.Add(new OracleParameter("	:STAFF_ENTRY_DATE	", req.staff_entry_date));
            Insert.Parameters.Add(new OracleParameter("	:STAFF_SALARY	", req.staff_salary));
>>>>>>> Stashed changes
            int Result = Insert.ExecuteNonQuery();
            CloseConn();
            if (Result == 1)
            {
                return true;
            }
            else return false;
<<<<<<< Updated upstream
        }

        //向Staff表中增加一个新客户(注册)
        //添加成功返回true，添加失败返回false
        public static bool AddStaff(Staff req)
        {
            CreateConn();
            OracleCommand Insert = DB.CreateCommand();
            Insert.CommandText = "insert into STAFF values(	:STAFF_ID,:STAFF_NAME,:STAFF_SEX,:STAFF_AGE	,:STAFF_IDENTITY_CARD_NUMBER,:STAFF_ADDRESS	,:STAFF_DEPARTMENT,:STAFF_POSITION,to_date(:STAFF_ENTRY_DATE,'YYYY-MM-DD'),:STAFF_SALARY)";
            Insert.Parameters.Add(new OracleParameter("	:STAFF_ID	", req.staff_id));
            Insert.Parameters.Add(new OracleParameter("	:STAFF_NAME	", req.staff_name));
            Insert.Parameters.Add(new OracleParameter("	:STAFF_SEX	", req.staff_sex));
            Insert.Parameters.Add(new OracleParameter("	:STAFF_AGE	", req.staff_age));
            Insert.Parameters.Add(new OracleParameter("	:STAFF_IDENTITY_CARD_NUMBER	", req.staff_identity_card_number));
            Insert.Parameters.Add(new OracleParameter("	:STAFF_ADDRESS	", req.staff_address));
            Insert.Parameters.Add(new OracleParameter("	:STAFF_DEPARTMENT	", req.staff_department));
            Insert.Parameters.Add(new OracleParameter("	:STAFF_POSITION	", req.staff_position));
            Insert.Parameters.Add(new OracleParameter("	:STAFF_ENTRY_DATE	", req.staff_entry_date));
            Insert.Parameters.Add(new OracleParameter("	:STAFF_SALARY	", req.staff_salary));
            int Result = Insert.ExecuteNonQuery();
            CloseConn();
            if (Result == 1)
            {
                return true;
            }
            else return false;
=======
>>>>>>> Stashed changes
        }

        //查找个人信息
        public static User FindUserInfo(string user_id)
        {
            CreateConn();
            OracleCommand Search = DB.CreateCommand();
            Search.CommandText = "select * from USERS where user_id=:user_id";
            Search.Parameters.Add(new OracleParameter(":user_id", user_id));
            OracleDataReader Ord = Search.ExecuteReader();
            User a = new User ();
            while (Ord.Read())
            {
                a.user_id = Ord.GetValue(0).ToString();
                a.user_name = Ord.GetValue(5).ToString();
                a.user_password = Ord.GetValue(1).ToString();
                a.user_type = (Ord.GetValue(2).ToString() == "1" ? "client":"staff");
                a.security_q = Ord.GetValue(3).ToString();
                a.s_q_answer = Ord.GetValue(4).ToString();
            }
            CloseConn();
            return a;
        }
<<<<<<< Updated upstream
        //查找客户信息
        public static List<Client> FindClientInfo()
        {
            CreateConn();
            OracleCommand Search = DB.CreateCommand();
            Search.CommandText = "select * from CLIENT";
            OracleDataReader Ord = Search.ExecuteReader();
            List<Client> a = new List<Client>();
            while (Ord.Read())
            {
                a.Add(new Client
                {
                    client_id = Ord.GetValue(0).ToString() ,  client_name = Ord.GetValue(1).ToString() ,  client_sex = Ord.GetValue(2).ToString() ,  client_birthday = Ord.GetValue(3).ToString() ,  client_mobile = Ord.GetValue(4).ToString()  , client_idCard = Ord.GetValue(5).ToString()
                });
            }
            return a;
        }
        public static Client FindClientInfo(string client_id)
        {
            CreateConn();
            OracleCommand Search = DB.CreateCommand();
            Search.CommandText = "select * from CLIENT where CLIENT_ID=:client_id";
            Search.Parameters.Add(new OracleParameter(":client_id", client_id));
            OracleDataReader Ord = Search.ExecuteReader();
            Client a = new Client();
            while (Ord.Read())
            {
                a.client_id = Ord.GetValue(0).ToString();
                a.client_name = Ord.GetValue(1).ToString();
                a.client_sex = Ord.GetValue(2).ToString();
                a.client_birthday = Ord.GetValue(3).ToString();
                a.client_mobile = Ord.GetValue(4).ToString();
                a.client_idCard = Ord.GetValue(5).ToString();
            }
            return a;
        }
        public static bool AlterUserPassword(string id, string password)
        {
            CreateConn();
            OracleCommand CMD = DB.CreateCommand();
            CMD.CommandText = "update USERS set USER_PASSWORD=:password where USER_ID=:id";
            CMD.Parameters.Add(new OracleParameter(":password", password));
            CMD.Parameters.Add(new OracleParameter(":id", id));
            int Result = CMD.ExecuteNonQuery();
            CloseConn();
            if (Result != 1)
                return false;
            else
                return true;
        }
        public static bool AlterClient(string id,string phone)
        {
            CreateConn();
            OracleCommand CMD = DB.CreateCommand();
            CMD.CommandText = "update CLIENT set CLIENT_TELEPHONENUMBER=:phone where CLIENT_ID=:id";
            CMD.Parameters.Add(new OracleParameter(":phone", phone));
            CMD.Parameters.Add(new OracleParameter(":id", id));
            int Result = CMD.ExecuteNonQuery();
            CloseConn();
            if (Result != 1)
                return false;
            else
                return true;

        }

        //查询数据库中所有订单信息
        public static ListInfo DisplayOrderListInfo(string query = "*")
=======
        //查找所有客户信息
        public static List<Client> FindClientInfo()
>>>>>>> Stashed changes
        {
            CreateConn();
            OracleCommand Search = DB.CreateCommand();
<<<<<<< Updated upstream
            string Strsql;
            if (query == "*")
                Strsql = "select " + query + " from room_order";
            else
            {
                Strsql = "select * from room_order where order_id like %" + query + "% or client_id like %" + query + "% or order_date like %" + query + "% or amount like %" + query + "% or state like %" + query + "% of room_id like %" + query + "%";
            }
            Search.CommandText = Strsql;
=======
            Search.CommandText = "select * from CLIENT";
>>>>>>> Stashed changes
            OracleDataReader Ord = Search.ExecuteReader();
            List<Client> a = new List<Client>();
            while (Ord.Read())
            {
                a.Add(new Client
                {
                    client_id = Ord.GetValue(0).ToString() ,  client_name = Ord.GetValue(1).ToString() ,  client_sex = Ord.GetValue(2).ToString() ,  client_birthday = Ord.GetValue(3).ToString() ,  client_mobile = Ord.GetValue(4).ToString()  , client_idCard = Ord.GetValue(5).ToString()
                });
            }
<<<<<<< Updated upstream
            int total = orders.Count();
            ListInfo list = new ListInfo { total = total, list = orders };
            return list;
        }

        //修改订单信息
        public static int ModifyOrderInfo(string order_id)
        {
            OracleCommand Update = DB.CreateCommand();
            Update.CommandText = "update room_order set state=3 where order_id=:order_id";
            Update.Parameters.Add(new OracleParameter(":order_id", order_id));
            int Result = Update.ExecuteNonQuery();
            return Result;
=======
            return a;
>>>>>>> Stashed changes
        }

        //查客户信息
        public static Client FindClientInfo(string client_id)
        {
            CreateConn();
            OracleCommand Search = DB.CreateCommand();
            Search.CommandText = "select * from CLIENT where CLIENT_ID=:client_id";
            Search.Parameters.Add(new OracleParameter(":client_id", client_id));
            OracleDataReader Ord = Search.ExecuteReader();
            Client a = new Client();
            while (Ord.Read())
            {
<<<<<<< Updated upstream
                order.order_id = Ord.GetValue(0).ToString();
                order.client_id = Ord.GetValue(1).ToString();
                order.order_date = Ord.GetValue(3).ToString();
                order.amount = (decimal)Ord.GetValue(4);
                order.state = (Int16)Ord.GetValue(5);

=======
                a.client_id = Ord.GetValue(0).ToString();
                a.client_name = Ord.GetValue(1).ToString();
                a.client_sex = Ord.GetValue(2).ToString();
                a.client_birthday = Ord.GetValue(3).ToString();
                a.client_mobile = Ord.GetValue(4).ToString();
                a.client_idCard = Ord.GetValue(5).ToString();
>>>>>>> Stashed changes
            }
            return a;
        }

<<<<<<< Updated upstream

        public static int AddRoomOrder(string client_id, string order_date, string room_type, int stay_time = 1, string client_telephonenumber = null)
        {
            if (client_telephonenumber != null)
=======
        //修改用户密码
        public static bool AlterUserPassword(string id, string password)
        {
            CreateConn();
            OracleCommand CMD = DB.CreateCommand();
            CMD.CommandText = "update USERS set USER_PASSWORD=:password where USER_ID=:id";
            CMD.Parameters.Add(new OracleParameter(":password", password));
            CMD.Parameters.Add(new OracleParameter(":id", id));
            int Result = CMD.ExecuteNonQuery();
            CloseConn();
            if (Result != 1)
                return false;
            else
                return true;
        }
        //修改客户信息
        public static bool AlterClient(string id,string phone)
        {
            CreateConn();
            OracleCommand CMD = DB.CreateCommand();
            CMD.CommandText = "update CLIENT set CLIENT_TELEPHONENUMBER=:phone where CLIENT_ID=:id";
            CMD.Parameters.Add(new OracleParameter(":phone", phone));
            CMD.Parameters.Add(new OracleParameter(":id", id));
            int Result = CMD.ExecuteNonQuery();
            CloseConn();
            if (Result != 1)
                return false;
            else
                return true;
        }
        public static string FindFacilityState(string facilty_id, string room_id)
        {
            CreateConn();
            OracleCommand Search = DB.CreateCommand();
            Search.CommandText = "select FACILITY_CONDITION from ROOM_FACILITY_CONDITION where FACILITY_ID=:facilty_id and ROOM_ID=:room_id";
            Search.Parameters.Add(new OracleParameter(":facilty_id", facilty_id));
            Search.Parameters.Add(new OracleParameter(":room_id", room_id));
            OracleDataReader Ord = Search.ExecuteReader();
            string a="";
            while (Ord.Read())
>>>>>>> Stashed changes
            {
                a = Ord.GetValue(0).ToString();
            }
            return a;
        }
<<<<<<< Updated upstream


        public static int AddDishOrder(string client_id, string dish_name, int number = 1)
        {

            OracleCommand Search = DB.CreateCommand();
            Search.CommandText = "select dish_id from dish where  dish_name=:dish_name";
            Search.Parameters.Add(new OracleParameter(":dish_name", dish_name));
            int dish_id = (int)Search.ExecuteScalar();
            Search.CommandText = "select dish_price from dish where  dish_name=:dish_name";
            Int64 dish_price = (Int64)Search.ExecuteScalar();
            OracleCommand Insert = DB.CreateCommand();
            Insert.CommandText = "insert into dish_order values(sys_guid(),:client_id,:dish_id,to_date(:dish_date,'YYYY-MM-DD'),:amount,'0',:number)";
            Insert.Parameters.Add(new OracleParameter(":client_id", client_id));
            Insert.Parameters.Add(new OracleParameter(":dish_id", dish_id));
            Insert.Parameters.Add(new OracleParameter(":dish_date", DateTime.Now.ToString()));
            Insert.Parameters.Add(new OracleParameter(":amount", number * dish_price));
            Insert.Parameters.Add(new OracleParameter(":number", number));
            int Result = Insert.ExecuteNonQuery();
            return Result;
=======
        public static List<FaciltyStaffResponse> FindFacilityStaff(string facility_id)
        {
            CreateConn();
            OracleCommand Search = DB.CreateCommand();
            Search.CommandText = "select staff_id from repair where facility_id=:facility_id";
            Search.Parameters.Add(new OracleParameter(":facilty_id", facility_id));
            OracleDataReader Ord = Search.ExecuteReader();
            List<FaciltyStaffResponse> a = new List<FaciltyStaffResponse>();
            while (Ord.Read())
            {
                a.Add(new FaciltyStaffResponse { staff_id = Ord.GetValue(0).ToString()});
            }
            return a;
>>>>>>> Stashed changes
        }
        public static List<StaffFaciltyResponse> FindStaffFacility(string staff_id)
        {
            CreateConn();
            OracleCommand Search = DB.CreateCommand();
            Search.CommandText = "select facility_id from repair where staff_id=:staff_id";
            Search.Parameters.Add(new OracleParameter(":staff_id", staff_id));
            OracleDataReader Ord = Search.ExecuteReader();
            List<StaffFaciltyResponse> a = new List<StaffFaciltyResponse>();
            while (Ord.Read())
            {
<<<<<<< Updated upstream
                rooms.Add(new Room { room_id = Ord.GetValue(0).ToString(), room_price = (decimal)Ord.GetValue(1), room_type = Ord.GetValue(2).ToString(), room_condition = Ord.GetValue(3).ToString(), name = Ord.GetValue(4).ToString(), phone = Ord.GetValue(5).ToString(), time = Ord.GetValue(6).ToString(), staff_id = Ord.GetValue(7).ToString() });
=======
                a.Add(new StaffFaciltyResponse { facility_id = Ord.GetValue(0).ToString() });
>>>>>>> Stashed changes
            }
            return a;
        }
<<<<<<< Updated upstream


        public static int ModifyRoomInfo(string room_id, int room_price, string room_type, string room_condition, string staff_id)
=======
        //查所有监控信息
        public static List<MonitorRequest> FindMonitorInfo()
>>>>>>> Stashed changes
        {
            CreateConn();
            OracleCommand Search = DB.CreateCommand();
            Search.CommandText = "select CAMERA_ID,ROOM_ID from monitoring_facilities_room group by CAMERA_ID,ROOM_ID";
            OracleDataReader Ord = Search.ExecuteReader();
            List<MonitorRequest> a = new List<MonitorRequest>();
            while (Ord.Read())
            {
                int count = a.Count();
                if ((count != 0) && (Ord.GetValue(0).ToString() == a[count - 1].monitor_id))
                {
                    a[count - 1].rooms.Add(new MonitorRoom { room_id = Ord.GetValue(1).ToString() });
                }
                else
                {
                    List<MonitorRoom> b = new List<MonitorRoom>();
                    for (int i = 1; i < Ord.FieldCount; i++)
                        b.Add(new MonitorRoom { room_id = Ord.GetValue(i).ToString() });
                    a.Add(new MonitorRequest { monitor_id = Ord.GetValue(0).ToString(), rooms = b });
                }
            }
            return a;
        }

        //修改监控信息
        public static bool DelMonitor(MonitorRequest value)
        {
            CreateConn();
            OracleCommand CMD = DB.CreateCommand();
            CMD.CommandText = "delete from monitoring_facilities_room where CAMERA_ID=:camera_id";
            CMD.Parameters.Add(new OracleParameter(":camera_id", value.monitor_id));
            OracleDataReader Ord = CMD.ExecuteReader();
            int Result = CMD.ExecuteNonQuery();
            CloseConn();
            if (Result <0)
                return false;
            else
                return true;
        }
<<<<<<< Updated upstream

        public static int AddRoomInfo(string room_condition, decimal room_price, string room_type)
        {
            OracleCommand Insert = DB.CreateCommand();
            Insert.CommandText = "insert into room output inserted.room_id values(sys_guid(),:room_price,:room_type,:room_condition)";
            Insert.Parameters.Add(new OracleParameter(":room_price", room_price));
            Insert.Parameters.Add(new OracleParameter(":room_type", room_type));
            Insert.Parameters.Add(new OracleParameter(":room_condition", room_condition));
            int Result = Insert.ExecuteNonQuery();
            return Result;
=======
        public static bool AddMonitor(MonitorRequest value)
        {
            CreateConn();
            int Result = 0;
            int Count = value.rooms.Count();
            for (int i = 0; i < Count; i++)
            {
                OracleCommand CMD = DB.CreateCommand();
                CMD.CommandText = "insert into monitoring_facilities_room values(:room_id,:camera_id)";
                CMD.Parameters.Add(new OracleParameter(":room_id", value.rooms[i].room_id));
                CMD.Parameters.Add(new OracleParameter(":camera_id", value.monitor_id));
                OracleDataReader Ord = CMD.ExecuteReader();
                Result += CMD.ExecuteNonQuery();
            }
            CloseConn();
            if (Result <= 0)
                return false;
            else
                return true;
>>>>>>> Stashed changes
        }
        public static List<ParkingMsg> ShowParkingInfo()
        {
            CreateConn();
            OracleCommand Search = DB.CreateCommand();
            Search.CommandText = "select * from Parking";
            OracleDataReader Ord = Search.ExecuteReader();
            List<ParkingMsg> a = new List<ParkingMsg>();
            while (Ord.Read())
            {
                a.Add(new ParkingMsg { parking_lot_id = Ord.GetValue(0).ToString(), user_id = Ord.GetValue(1).ToString(), car_number = Ord.GetValue(2).ToString() });
            }
            CloseConn();
            return a;
        }
        public static bool AlertParking(ParkingMsg value)
        {
            CreateConn();
            OracleCommand Update = DB.CreateCommand();
            Update.CommandText = "update PARKING set user_id=:user_id,car_number=:car_number where parking_lot_id=:parking_lot_id";
            Update.Parameters.Add(new OracleParameter(":user_id", value.user_id));
            Update.Parameters.Add(new OracleParameter(":car_number", value.car_number));
            Update.Parameters.Add(new OracleParameter(":parking_lot_id", value.parking_lot_id));
            int Result = Update.ExecuteNonQuery();
            CloseConn();
            if (Result < 0)
                return false;
            else
                return true;

        }
        public static ParkingMsg FindParkingInfo(string park_id)
        {
            CreateConn();
            OracleCommand Search = DB.CreateCommand();
            Search.CommandText = "select * from Parking where PARKING_LOT_ID=:park_id";
            Search.Parameters.Add(new OracleParameter(":park_id", park_id));
            OracleDataReader Ord = Search.ExecuteReader();
            ParkingMsg a = new ParkingMsg();
            while (Ord.Read())
            {
                a.parking_lot_id = Ord.GetValue(0).ToString();
                a.user_id = Ord.GetValue(1).ToString();
                a.car_number = Ord.GetValue(0).ToString();
            }
            CloseConn();
            return a;
        }
    }

    
}

