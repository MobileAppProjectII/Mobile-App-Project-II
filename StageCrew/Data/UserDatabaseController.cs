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

        //***************** SONG STUFF


        public SongInfo GetSong()
        {
            lock (locker)
            {
                if (database.Table<SongInfo>().Count() == 0)
                {
                    return null;
                }

                else
                {
                    return database.Table<SongInfo>().First();
                }
            }
        }

        public int SaveSong(SongInfo song)
        {
            lock (locker)
            {
                if (song.id != 0)
                {
                    database.Update(song);
                    return song.id;
                }
                else
                {
                    return database.Insert(song);
                }
            }
        }

        public int DeleteSong(int id)
        {
            lock (locker)
            {
                return database.Delete<SongInfo>(id);
            }
        }


        //******* STANZA STUFF

        public StanzaInfo GetStanza()
        {
            lock (locker)
            {
                if (database.Table<StanzaInfo>().Count() == 0)
                {
                    return null;
                }

                else
                {
                    return database.Table<StanzaInfo>().First();
                }
            }
        }

        public int SaveStanza(StanzaInfo stanza)
        {
            lock (locker)
            {
                if (stanza.id != 0)
                {
                    database.Update(stanza);
                    return stanza.id;
                }
                else
                {
                    return database.Insert(stanza);
                }
            }
        }

        public int DeleteStanza(int id)
        {
            lock (locker)
            {
                return database.Delete<StanzaInfo>(id);
            }
        }
    }
}
