
using Microsoft.Win32;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Data.SQLite;

namespace AdvancedRegistrySearch
{
    class SearchEngine
    {
        private SQLiteConnection conn;
        private SQLiteCommand cmd;

        public SearchEngine()
        {
            string cs = "Data Source=:memory:";
            string stm = "SELECT SQLITE_VERSION()";

            conn = new SQLiteConnection(cs);
            conn.Open();

            cmd = new SQLiteCommand(stm, conn);
            string version = cmd.ExecuteScalar().ToString();

            Console.WriteLine($"SQLite version: {version}");

            // --

            cmd = new SQLiteCommand(conn);

            cmd.CommandText = "DROP TABLE IF EXISTS keys";
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"CREATE TABLE keys(id INTEGER PRIMARY KEY, path TEXT, value TEXT)";
            cmd.ExecuteNonQuery();
        }

        public void index()
        {
            var t1 = new Thread(() =>
            {
                // HKEY_CLASSES_ROOT
                recursiveIndex(Registry.ClassesRoot);
            });
            t1.Start();

            var t2 = new Thread(() =>
            {
                // HKEY_LOCAL_MACHINE
                recursiveIndex(Registry.LocalMachine);
            });
            t2.Start();

            var t3 = new Thread(() =>
            {
                // HKEY_CURRENT_USER
                recursiveIndex(Registry.CurrentUser);
            });
            t3.Start();

            var t4 = new Thread(() =>
            {
                // HKEY_USERS
                recursiveIndex(Registry.Users);
            });
            t4.Start();

            var t5 = new Thread(() =>
            {
                // HKEY_CURRENT_CONFIG
                recursiveIndex(Registry.CurrentConfig);
            });
            t5.Start();

            t1.Join();
            t2.Join();
            t3.Join();
            t4.Join();
            t5.Join();
            
            cmd.CommandText = "select count(id) from keys;";
            cmd.CommandType = System.Data.CommandType.Text;
            int RowCount = 0;
            RowCount = Convert.ToInt32(cmd.ExecuteScalar());
            Console.WriteLine("There are {0} keys", RowCount);
        }

        private void recursiveIndex(RegistryKey root)
        {
            foreach (var child in root.GetSubKeyNames())
            {
                try
                {
                    using (var childKey = root.OpenSubKey(child))
                    {
                        recursiveIndex(childKey);
                    }
                } catch (Exception ex)
                {
                    continue;
                }
            }

            var command = new SQLiteCommand();
            command.Connection = conn;
            foreach (var value in root.GetValueNames())
            {
                string k = String.Format("{0}\\{1}", root, value);
                string v = (root.GetValue(value) ?? "").ToString();

                command.CommandText = "INSERT INTO keys(path, value) VALUES('@k','@v')";
                command.Parameters.AddWithValue("k", k);
                command.Parameters.AddWithValue("v", v);
                command.ExecuteNonQuery();
            }
        }
    }
}
