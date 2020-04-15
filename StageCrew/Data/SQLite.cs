using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace StageCrew.Data
{
     public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
