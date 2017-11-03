using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ADODB;

namespace MMORPG_SERVER
{
    class Database
    {
        public bool AccountExist(int index,string username)
        {
            var db = Globals.mysql.DB_RS;
            {
                db.Open("SELECT * FROM accounts WHERE Username='"+username+"'", Globals.mysql.DB_CONN, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);
                
                if(db.EOF)
                {
                    Globals.networkSendData.SendAlertMsg(index,"Username does not exists! Please try again.");
                    db.Close();
                    return false;
                }
                else
                {
                    db.Close();
                    return true;
                }
                
            }
        }

        public bool PasswordOK(int index,string username,string password)
        {
            var db = Globals.mysql.DB_RS;
            {
                db.Open("SELECT '"+username+"' FROM accounts WHERE Password='" + password + "'", Globals.mysql.DB_CONN, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);

                if (db.EOF)
                {
                    Globals.networkSendData.SendAlertMsg(index, "Password does not match! Please try again.");
                    db.Close();
                    return false;
                }
                else
                {
                    db.Close();
                    return true;
                }

            }
        }

        public void AddAccount(string username, string password)
        {
            var db = Globals.mysql.DB_RS;
            {
                db.Open("SELECT * FROM accounts WHERE 0=1", Globals.mysql.DB_CONN, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);
                db.AddNew();
                db.Fields["Username"].Value = username;
                db.Fields["Password"].Value = password;
                db.Update();
                db.Close();
            }
        }
    }
}
