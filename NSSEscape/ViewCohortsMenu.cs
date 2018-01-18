using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace NSSEscape
{
    public class ViewCohortsMenu
    {
        private DatabaseInterface db;
        private List<Cohort> _cohorts = new List<Cohort>();
        public ViewCohortsMenu(DatabaseInterface DB)
        {
            db = DB;
        }

        public void Show()
        {
            db.Query("select * from cohort",
                (SqliteDataReader reader) =>
                {
                    _cohorts.Clear();
                    while (reader.Read())
                    {
                        _cohorts.Add(new Cohort()
                        {
                            cohort_id = reader.GetInt32(0),
                            cohort_number = reader.GetInt32(1),
                            server_tech = reader.ToString()
                        });
                    }
                }
            );
        }
    }
}