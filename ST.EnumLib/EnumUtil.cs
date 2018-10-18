using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Linq;

namespace ST.EnumLib
{
    public static class EnumUtil
    {
        public static string GetName(this Enum em)
        {
            return em.ToString();
        }
        public static string GetName<T>(this int value) where T : struct
        {
            return Enum.GetName(typeof(T), value);
        }
        public static string GetDisplayName(this Enum em)
        {
            string name = em.ToString();
            FieldInfo field = em.GetType().GetField(name);
            if (field == null) return null;
            object[] objs = field.GetCustomAttributes(typeof(DisplayNameAttribute), false);
            if (objs == null || objs.Length == 0)
            {
                objs = field.GetCustomAttributes(typeof(DisplayAttribute), false);
                if (objs == null || objs.Length == 0) { return name; }
                var attr = (DisplayAttribute)objs[0];
                return attr.Name;
            }
            else
            {
                var attr = (DisplayNameAttribute)objs[0];
                return attr.DisplayName;
            }
        }
        public static string GetDisplayName<T>(this int value) where T : struct
        {
            var em = Enum.Parse(typeof(T), GetName<T>(value)) as Enum;
            return GetDisplayName(em);
        }
        public static string GetDisplayName<T>(this string value) where T : struct
        {
            var em = Enum.Parse(typeof(T), value) as Enum;
            return GetDisplayName(em);
        }
        public static string GetDescription(this Enum em)
        {
            string name = em.ToString();
            FieldInfo field = em.GetType().GetField(name);
            if (field == null) return null;
            object[] objs = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (objs == null || objs.Length == 0)
            {
                objs = field.GetCustomAttributes(typeof(DisplayAttribute), false);
                if (objs == null || objs.Length == 0) return name;
                var attr = (DisplayAttribute)objs[0];
                return attr.Description;
            }
            else
            {
                var attr = (DescriptionAttribute)objs[0];
                return attr.Description;
            }
        }
        public static string GetDescription<T>(this int value) where T : struct
        {
            var em = Enum.Parse(typeof(T), GetName<T>(value)) as Enum;
            return GetDescription(em);
        }
        public static string GetDescription<T>(this string value) where T : struct
        {
            var em = Enum.Parse(typeof(T), value) as Enum;
            return GetDescription(em);
        }
        public static string[] GetNames(this Enum em)
        {
            return Enum.GetNames(em.GetType());
        }
        public static Dictionary<int, string> GetNamesDictionary<T>(bool defaultItem = false, int defaultKey = -1, string defaultValue = "") where T : struct
        {
            var dic = new Dictionary<int, string>();
            if (defaultItem) { dic.Add(defaultKey, defaultValue); }
            foreach (var value in Enum.GetValues(typeof(T)))
            {
                dic.Add((int)value, value.ToString());
            }
            return dic;
        }
        public static Dictionary<int, string> GetDisplayNamesDictionary<T>(bool defaultItem = false, int defaultKey = -1, string defaultValue = "") where T : struct
        {
            var dic = new Dictionary<int, string>();
            if (defaultItem) { dic.Add(defaultKey, defaultValue); }
            foreach (var value in Enum.GetValues(typeof(T)))
            {
                dic.Add((int)value, ((Enum)value).GetDisplayName());
            }
            return dic;
        }
        public static Dictionary<int, string> GetDescriptionsDictionary<T>(bool defaultItem = false, int defaultKey = -1, string defaultValue = "") where T : struct
        {
            var dic = new Dictionary<int, string>();
            if (defaultItem) { dic.Add(defaultKey, defaultValue); }
            foreach (var value in Enum.GetValues(typeof(T)))
            {
                dic.Add((int)value, ((Enum)value).GetDescription());
            }
            return dic;
        }

    }
}
