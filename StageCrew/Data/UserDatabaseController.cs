using SQLite;
using StageCrew.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace StageCrew.Data
{
    public class UserDatabaseController
    {
        static object locker = new object();

        SQLiteConnection database;

        public UserDatabaseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<User>();
            database.CreateTable<SetInfo>();
        }

        public User GetUser()
        {
            lock (locker)
            {
                if(database.Table<User>().Count() == 0)
                {
                    return null;
                }

                else
                {
                    return database.Table<User>().First();
                }
            }
        }

        public int SaveUser(User user)
        {
            lock (locker)
            {
                if (user.id !=0)
                {
                    database.Update(user);
                    return user.id;
                }
                else
                {
                    return database.Insert(user);
                }
            }
        }

        public int DeleteUser(int id)
        {
            lock (locker)
            {
                return database.Delete<User>(id);
            }
        }




        //set stuff *************

        public SetInfo GetSet()
        {
            lock (locker)
            {
                if (database.Table<SetInfo>().Count() == 0)
                {
                    return null;
                }

                else
                {
                    return database.Table<SetInfo>().First();
                }
            }
        }

        public int SaveSet(SetInfo set)
        {
            lock (locker)
            {
                if (set.id != 0)
                {
                    database.Update(set);
                    return set.id;
                }
                else
                {
                    return database.Insert(set);
                }
            }
        }

        public int DeleteSet(int id)
        {
            lock (locker)
            {
                return database.Delete<SetInfo>(id);
            }
        }
    }
}
