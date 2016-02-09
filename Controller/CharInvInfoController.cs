using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace WebToolz.Controller
{
    public  class CharInvInfoController
    {
        public void ReadItemList()
        {
            Dictionary<string, string> list = new Dictionary<string, string>();
          
            using(var streamRead = new StreamReader("ItemList.txt"))
            {
                while(!streamRead.EndOfStream)
                {
                    string split = streamRead.ReadLine();
                    string[] spliter = split.Split(new char[] { ';' });

                    if (spliter.Length < 2)
                        continue;
                    else if (spliter.Length >= 2)
                        list.Add(spliter[0].Trim(), spliter[1].Trim());
                    else
                        throw new Exception("ERROR DURING ADDING ITEM TO LIST");
                }
            }
        }
    }
}