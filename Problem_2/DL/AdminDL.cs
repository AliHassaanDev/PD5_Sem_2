using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Problem_2.BL;
using Problem_2.UI;

namespace Problem_2.DL
{
    internal class AdminDL
    {
        public static List<Admin> store = new List<Admin>();
        public static void addAdmin(Admin user)
        {
            store.Add(user);
        }
        public List<Admin> getAll()
        {
            return store;
        }
        public static Admin ValidateAdmin(string username, string password)
        {
            return store.Find(a => a.UserName == username && a.Password == password);
        }

        public static void addToFile(string path, Admin a)
        {
            List<string> lines = new List<string>();
            foreach (Admin admin in store)
            {
                lines.Add($"{admin.UserName},{admin.Password},{admin.Role}");
            }
            File.WriteAllLines(path, lines);
        }

    
    public static void readFromFile(string path)
        {
            if (File.Exists(path))
            {
                foreach (string line in File.ReadAllLines(path))
                {
                    string[] data = line.Split(',');
                    store.Add(new Admin(data[0], data[1], data[2]));
                }
            }
        }
            
        }
    }

