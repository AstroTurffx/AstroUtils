using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace AstroTurffx.AstroUtils.SaveLoadSystem
{
    public static class SaveLoadManager
    {
        public static bool SaveFile<T>(string fileName, T data)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/" + fileName;
            FileStream stream = new FileStream(path, FileMode.Create);
            
            try
            {
                formatter.Serialize(stream, data);
                stream.Close();
                return true;
            }
            catch (Exception e)
            {
                Debug.LogError("Unable to save file.\n" + e);
                stream.Close();
                return false;
            }
        }
        
        public static bool LoadFile<T>(string fileName, out T data)
        {
            data = default(T);
            string path = Application.persistentDataPath + "/" + fileName;
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                try
                {
                    data = (T)formatter.Deserialize(stream);
                    stream.Close();
                    return true;
                }
                catch (Exception e)
                {
                    Debug.LogError("Unable to load file.\n" + e);
                    stream.Close();
                    return false;
                }
            }
            else return false;
        }
    }
}