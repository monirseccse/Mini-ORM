using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    public  class Necessary
    {
        private List<Dictionary<string, object>> _lists;
        private List<string> _className;
        private Dictionary<string, object> _dic;
        Dictionary<string,(string parentname,object parentId)> _dic2;
        object _listforeignkeyId = null;
        bool listflag;
        public Necessary()
        {
            _lists = new List<Dictionary<string, object>>();
            _dic2 = new Dictionary<string, (string parentname, object parentId)>();
            _className = new List<string>();
            _listforeignkeyId = null;
            listflag = false;
        }
        public  Type TypeGetting<T>(T obj)
        {
            return obj.GetType();
        }
       

        public  (List<Dictionary<string, object>>,List<string>) ObjectInitialiseForReflection(object entity)
        {
            if (entity == null)
                return (_lists, _className);

            Type type = entity.GetType();
            _className.Add(type.Name);
            
            if(!_lists.Contains(_dic)&&_dic?.Count>0)
            {
                _lists.Add(_dic);
            }
            _dic = new Dictionary<string, object>();bool flag = false;
            PropertyInfo[] propertyInfos = type.GetProperties();

            foreach (var item in propertyInfos)
                {
                   if(item.Name.Equals("Id"))
                  {
                    _listforeignkeyId = item.GetValue(entity);
                  }
                   if(_dic2.ContainsKey(type.Name)&&!flag)
                 {
                    flag = true;
                    _dic.Add(_dic2[type.Name].parentname+"Id", _dic2[type.Name].parentId);
                 }
                  if (CheckDataTypeForQuotation(item.PropertyType))
                   {
                            _dic.Add(item.Name, item.GetValue(entity));
                   }
                   //ForeignKeyValue for Parent class 
                     else if (!item.PropertyType.IsGenericType &&!item.PropertyType.IsArray)
                     {
                                if(item.GetValue(entity)!=null)
                            {
                                object _foreignkey = GetObjForeignKeyvalue(item.GetValue(entity));
                                _dic.Add(item.Name + "Id", _foreignkey);
                            }
                            else
                            {
                                return(null,null);
                            }
                     }
                   else if(item.PropertyType.IsGenericType||item.PropertyType.IsArray)
                {
                    Type type1 = item.PropertyType.GetGenericArguments()[0];
                    _dic2.Add(type1.Name, (type.Name,_listforeignkeyId));
                   }
                    

                }
            foreach (var item in propertyInfos)
            {
                Type type1 = item.PropertyType;
                if (type1.IsGenericType || type1.IsArray)
                {
                  
                    IEnumerable<object> list = (IEnumerable<object>)item.GetValue(entity);
                    
                    foreach (var obj in list)
                    {
                        listflag = true;
                       
                        ObjectInitialiseForReflection(obj);
                     }
                    
                    listflag = false;
                }

               else if (!CheckDataTypeForQuotation(item.PropertyType))
                {
                      if (item.GetValue(entity) != null)
                    {
                        ObjectInitialiseForReflection(item.GetValue(entity));
                        
                    }
                }
            }
            if (!_lists.Contains(_dic))
            {
                _lists.Add(_dic);
            }
            return (_lists,_className);
        }

        private object GetObjForeignKeyvalue(object entity)
        {
            Type type = entity.GetType();
            PropertyInfo[] propertyInfos = type.GetProperties();
           object obj = null;
            foreach (var item in propertyInfos)
            {
                  if (item.Name.Equals("Id"))
                    {
                    obj = item.GetValue(entity);
                    return obj;
                }

            }
            return obj;
        }

        private static bool CheckDataTypeForQuotation(Type propertyType)
        {
            if (
               propertyType==typeof(Guid)|| propertyType == typeof(int) || propertyType == typeof(long) || propertyType == typeof(double)
                || propertyType == typeof(float) || propertyType == typeof(bool)
                || propertyType==typeof(string)||propertyType==typeof(char)||propertyType==typeof(DateTime)
                ||propertyType==typeof(decimal))
                return true;

            return false;
        }

        public HashSet<string> GetClassAndSubclassName(Type type)
        {
            HashSet<string> lists = new HashSet<string>();
            lists.Add(type.Name);
            PropertyInfo[] propertyInfos = type.GetProperties();
            foreach (var item in propertyInfos)
            {
                Type type1 = item.PropertyType;
                if (type1.IsGenericType || type1.IsArray)
                {
                    type1 = type1.GetGenericArguments()[0];
                    lists.Add(type1.Name);
                }

                else if (!CheckDataTypeForQuotation(item.PropertyType))
                {
                    lists.Add(type1.Name);
                }
            }
            return lists;
        }

        public bool NoDuplicate(Dictionary<string, object> cls, string v)
        {
            string sql = "select * from " + v + " where Id=@Id";
            DataUtility dataUtility = new DataUtility();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            object s = cls["Id"];
            dic.Add("Id", cls["Id"]);
            List<Dictionary<string, object>> list = dataUtility.DataRead(sql, dic);

            return list.Count==0;
        }
    }
}
