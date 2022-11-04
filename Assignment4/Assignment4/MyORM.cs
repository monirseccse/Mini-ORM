using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    public class MyORM<TKey, TEntity> : IMyORM<TKey, TEntity>
        where TEntity : class, IEntity<TKey, TEntity>
    {
        TEntity _obj;
        (List<Dictionary<string, object>>, List<string>) diclist;
        int ck;

        public MyORM()
        {
            _obj = (TEntity)Activator.CreateInstance(typeof(TEntity), new object[] {});
            _obj= _obj.Instantiate();
            diclist = new Necessary().ObjectInitialiseForReflection(_obj);
            ck = 0;
        }

        

        public void Delete(TEntity entity)
        {
            if (entity == null)
                return;
            int ck = 0;
            foreach (var cls in diclist.Item1)
            {
               
                if (!new Necessary().NoDuplicate(cls, diclist.Item2[ck]))
                {
                    string sql = "Delete from " + diclist.Item2[ck++] + " where Id=@Id";
                    DataUtility dataUtility = new DataUtility();
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    object s = cls["Id"];
                    dic.Add("Id", cls["Id"]);
                    dataUtility.ExecuteCommand(sql, dic);
                }
                else
                {
                    Console.WriteLine("This object does not exist");
                    return;
                }

            }
        }

        public void Delete(TKey key)
        {
            Delete(_obj);
        }

        public void GetAll()
        {
            Dictionary<string, string> s = new Dictionary<string, string>();
            foreach (var cls in diclist.Item1)
            {
                string sql = "select * from " + diclist.Item2[ck++];
                DataUtility dataUtility = new DataUtility();
               
               if(!s.ContainsKey(diclist.Item2[ck - 1]))
                {
                    List<Dictionary<string, object>> list = dataUtility.DataRead(sql, null);
                    Console.WriteLine($"Table name :{diclist.Item2[ck - 1]}");

                    foreach (var item in list)
                    {
                        foreach (var v in item)
                        {
                            Console.WriteLine($"{v.Key}={v.Value}");
                        }
                    }
                    s.Add(diclist.Item2[ck - 1], diclist.Item2[ck - 1]);
                }

            }
            Console.WriteLine();
        }

        public void GetById(TKey id)
        {
            foreach (var cls in diclist.Item1)
            {
                if (!new Necessary().NoDuplicate(cls, diclist.Item2[ck]))
                {
                    string sql = "select * from " + diclist.Item2[ck++] + " where Id=@Id";
                    DataUtility dataUtility = new DataUtility();
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    object s = cls["Id"];
                    dic.Add("Id", cls["Id"]);
                    List<Dictionary<string, object>> list = dataUtility.DataRead(sql, dic);
                    Console.WriteLine($"Table name :{diclist.Item2[ck - 1]}");
                    foreach (var item in list)
                    {
                        foreach (var v in item)
                        {
                            Console.WriteLine($"{v.Key}={v.Value}");
                        }
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("This object does not exist");
                    return;
                }

            }
         
        }

        public void Insert(TEntity entity)
        {
            if (entity == null)
                return;
            if(diclist.Item1==null && diclist.Item1 == null)
            {
                Console.WriteLine("Please Check Foreign Key Constraints or Others Properties");
                return;
            }
          
            int ck = 0;
            foreach (var cls in diclist.Item1)
            {
                if(new Necessary().NoDuplicate(cls,diclist.Item2[ck]))
                {
                    string s1 = "", s2 = ""; bool flag = false;
                    foreach (var item in cls)
                    {

                        if (!flag) flag = true;
                        else { s1 += ","; s2 += ","; }
                        s1 += item.Key;
                        s2 += "@" + item.Key;
                    }

                    string sql = "Insert into " + diclist.Item2[ck++] + " (" + s1 + ") Values (" + s2 + ");";
                    DataUtility dataUtility = new DataUtility();
                    dataUtility.ExecuteCommand(sql, cls);
                }
                else
                {
                    ck++;
                    Console.WriteLine("This Id already exists");
                }
               
            }


        }

        public void Update(TEntity entity)
        {

            if (entity == null)
                return;
          
          
            foreach (var cls in diclist.Item1)
            {
                if (!new Necessary().NoDuplicate(cls, diclist.Item2[ck]))
                {
                    string s1 = " set "; bool flag = false;
                    foreach (var item in cls)
                    {

                        if (!flag) flag = true;
                        else { s1 += ","; }
                        s1 += item.Key + "=@" + item.Key;

                    }
                    string sql = "Update " + diclist.Item2[ck++] + s1;
                    DataUtility dataUtility = new DataUtility();
                    dataUtility.ExecuteCommand(sql, cls);
                }
                else
                {
                    Console.WriteLine("This object does not exist");
                    return;
                }
                
            }
        }
    }
}
