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
        public Necessary()
        {
            _lists = new List<Dictionary<string, object>>();
            _className = new List<string>();
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
            _dic = new Dictionary<string, object>();
            PropertyInfo[] propertyInfos = type.GetProperties();

            foreach (var item in propertyInfos)
                {
                  if (CheckDataTypeForQuotation(item.PropertyType))
                     {
                            _dic.Add(item.Name, item.GetValue(entity));
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
                        ObjectInitialiseForReflection(obj);
                    }
                }

               else if (!CheckDataTypeForQuotation(item.PropertyType))
                {
                      if (item.GetValue(entity) != null)
                    {
                        ObjectInitialiseForReflection(entity);
                    }
                }
            }
            if (!_lists.Contains(_dic))
            {
                _lists.Add(_dic);
            }
            return (_lists,_className);
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

            return list.Count>0?true:false;
        }
    }
}
