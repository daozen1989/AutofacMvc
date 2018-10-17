using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Web.Interfaces.Utilities
{
    public static class ModelMapper
    {
        private static readonly int _UTC_TO_JST = 9;
        private static readonly string _INSERT_UPDATE_USER = "site_st";

        public static void Mapping(object srcObj, object destObj)
        {
            if (null == srcObj || null == destObj)
            {
                return;
            }
            foreach (var srcProp in srcObj.GetType().GetProperties())
            {
                var dstProp = destObj.GetType().GetProperty(srcProp.Name);
                if (dstProp != null)
                    dstProp.SetValue(destObj, srcProp.GetValue(srcObj));
            }
        }

        public static void MappingCamelLower(object srcObj, object destObj, char separator)
        {
            if (null == srcObj || null == destObj)
            {
                return;
            }
            foreach (var srcProp in srcObj.GetType().GetProperties())
            {
                var srcPropNameParts = srcProp.Name.Split(separator);
                string destPropName = srcPropNameParts[0].ToLower();
                for (int i = 1; i < srcPropNameParts.Length; i++)
                {
                    if (!string.IsNullOrEmpty(srcPropNameParts[i]))
                    {
                        destPropName = destPropName + srcPropNameParts[i].Substring(0, 1).ToUpper() + srcPropNameParts[i].ToLower().Substring(1);
                    }
                }
                var dstProp = destObj.GetType().GetProperty(destPropName);
                if (dstProp != null)
                    dstProp.SetValue(destObj, srcProp.GetValue(srcObj));
            }
        }

        public static void MappingCamelUpper(object srcObj, object destObj, char separator)
        {
            if (null == srcObj || null == destObj)
            {
                return;
            }
            foreach (var srcProp in srcObj.GetType().GetProperties())
            {
                var srcPropNameParts = srcProp.Name.Split(separator);
                string destPropName = string.Empty;
                for (int i = 0; i < srcPropNameParts.Length; i++)
                {
                    if (!string.IsNullOrEmpty(srcPropNameParts[i]))
                    {
                        destPropName = destPropName + srcPropNameParts[i].Substring(0, 1) + srcPropNameParts[i].Substring(1);
                    }
                }
                var dstProp = destObj.GetType().GetProperty(destPropName);
                if (dstProp != null)
                    dstProp.SetValue(destObj, srcProp.GetValue(srcObj));
            }
        }

        public static void MappingFromModelToEntity(object modelObj, object entityObj, char separator)
        {
            if (null == modelObj || null == entityObj)
            {
                return;
            }
            foreach (var entityProp in entityObj.GetType().GetProperties())
            {
                var entityPropNameParts = entityProp.Name.Split(separator);
                string modelPropName = entityPropNameParts[0].Substring(0, 1).ToUpper() + entityPropNameParts[0].ToLower().Substring(1);
                for (int i = 1; i < entityPropNameParts.Length; i++)
                {
                    if (!string.IsNullOrEmpty(entityPropNameParts[i]))
                    {
                        modelPropName = modelPropName + entityPropNameParts[i].Substring(0, 1).ToUpper() + entityPropNameParts[i].ToLower().Substring(1);
                    }
                }
                var modelProp = modelObj.GetType().GetProperty(modelPropName);
                if (modelProp != null)
                    entityProp.SetValue(entityObj, modelProp.GetValue(modelObj));
            }
        }

        public static IList MappingCamelUpperForList(IList srcLst, Type destType, char separator)
        {
            if (null == srcLst || null == destType)
            {
                return null;
            }

            var result = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(destType));

            foreach (var item in srcLst)
            {
                result.Add(Activator.CreateInstance(destType, item, separator));
            }

            return result;
        }


        public static bool SetDefaultColumnsForNew(object entityObj, PropertyInfo prop)
        {
            DateTime currentDateTime = DateTime.UtcNow.AddHours(_UTC_TO_JST);

            switch (prop.Name)
            {
                case "INSERT_USER":
                    prop.SetValue(entityObj, _INSERT_UPDATE_USER);
                    return true;
                case "INSERT_DATETIME":
                    prop.SetValue(entityObj, currentDateTime);
                    return true;
                case "UPDATE_USER":
                    prop.SetValue(entityObj, _INSERT_UPDATE_USER);
                    return true;
                case "UPDATE_DATETIME":
                    prop.SetValue(entityObj, currentDateTime);
                    return true;
                case "DELETED_FLAG":
                    prop.SetValue(entityObj, "0");
                    return true;
                case "VERSION_NO":
                    prop.SetValue(entityObj, 0);
                    return true;
                default:
                    return false;
            }
        }

        public static bool SetDefaultColumnsForNew(object entityObj)
        {
            if (entityObj == null)
            {
                return false;
            }

            foreach (var entityProp in entityObj.GetType().GetProperties())
            {
                SetDefaultColumnsForNew(entityObj, entityProp);
            }

            return true;
        }

        public static bool SetDefaultColumnsForUpdate(object entityObj, PropertyInfo prop)
        {
            DateTime currentDateTime = DateTime.UtcNow.AddHours(_UTC_TO_JST);

            switch (prop.Name)
            {
                case "UPDATE_USER":
                    prop.SetValue(entityObj, _INSERT_UPDATE_USER);
                    return true;
                case "UPDATE_DATETIME":
                    prop.SetValue(entityObj, currentDateTime);
                    return true;
                case "VERSION_NO":
                    int currVersion = (int)prop.GetValue(entityObj);
                    prop.SetValue(entityObj, currVersion + 1);
                    return true;
                default:
                    return false;
            }
        }

        public static bool SetDefaultColumnsForUpdate(object entityObj)
        {
            if (entityObj == null)
            {
                return false;
            }

            foreach (var entityProp in entityObj.GetType().GetProperties())
            {
                SetDefaultColumnsForUpdate(entityObj, entityProp);
            }

            return true;
        }

    }
}
