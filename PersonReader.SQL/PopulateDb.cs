using Microsoft.Data.Sqlite;
using PersonReader.Interface;
using System.Diagnostics;


namespace PersonReader.SQL
{
    public static class PopulateDb
    {
        public static void PopulateDatabase()
        {
      
            var persons = new List<Person>()
            {
                new Person() { Id=1, GivenName="John", FamilyName="Koenig",
                    StartDate = new DateTime(1975, 10, 17), Rating=6 },
                new Person() { Id=2, GivenName="Dylan", FamilyName="Hunt",
                    StartDate = new DateTime(2000, 10, 2), Rating=8 },
                new Person() { Id=3, GivenName="Leela", FamilyName="Turanga",
                    StartDate = new DateTime(1999, 3, 28), Rating=8,
                    FormatString = "{1} {0}" },
                new Person() { Id=4, GivenName="John", FamilyName="Crichton",
                    StartDate = new DateTime(1999, 3, 19), Rating=7 },
                new Person() { Id=5, GivenName="Dave", FamilyName="Lister",
                    StartDate = new DateTime(1988, 2, 15), Rating=9 },
                new Person() { Id=6, GivenName="Laura", FamilyName="Roslin",
                    StartDate = new DateTime(2003, 12, 8), Rating=6},
                new Person() { Id=7, GivenName="John", FamilyName="Sheridan",
                    StartDate = new DateTime(1994, 1, 26), Rating=6 },
                new Person() { Id=8, GivenName="Dante", FamilyName="Montana",
                    StartDate = new DateTime(2000, 11, 1), Rating=5 },
                new Person() { Id=9, GivenName="Isaac", FamilyName="Gampu",
                    StartDate = new DateTime(1977, 9, 10), Rating=4 },
            };

            try
            {
                using var conn = new SqliteConnection("Data Source=D:\\PROGRAMMING\\C#Projects\\C#-MyProjects\\Reader\\Readers\\PersonReader.SQL\\People.db;");
                conn.Open();

                string createCmd =
                    "CREATE TABLE People (Id INTEGER NOT NULL, GivenName VARCHAR (100), FamilyName VARCHAR (100), StartDate DATE, Rating INTEGER, FormatString VARCHAR (50), PRIMARY KEY (Id)) WITHOUT ROWID";
                using (var cmd = new SqliteCommand(createCmd, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                string insertCmd =
                    "INSERT INTO People (Id,GivenName, FamilyName, StartDate, Rating, FormatString) VALUES(?,?,?,?,?,?)";
                foreach (Person person in persons)
                {
                    using (var cmd = new SqliteCommand(insertCmd, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", person.Id);
                        cmd.Parameters.AddWithValue("@GivenName", person.GivenName);
                        cmd.Parameters.AddWithValue("@FamilyName", person.FamilyName);
                        cmd.Parameters.AddWithValue("@StartDate", person.StartDate);
                        cmd.Parameters.AddWithValue("@Rating", person.Rating);
                        cmd.Parameters.AddWithValue("@FormatDtring", person.FormatString);
                        cmd.ExecuteNonQuery();
                    }
                }
                conn.Close();
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.Message);
                Debug.WriteLine(exc.StackTrace);
            }

        }
    }
}



