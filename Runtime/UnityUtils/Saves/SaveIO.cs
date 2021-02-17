using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace UnityUtils.Saves
{
    public static class SaveIO
    {
        /// <summary>
        /// Write object as JSON string to persistentDataPath/saveFileName location.
        /// </summary>
        public static void WriteObjectAsJsonString<T>(T obj, string saveFileName, object lockable, bool logSave = false) 
            => WriteString(saveFileName, JsonUtility.ToJson(obj), lockable, logSave);

        /// <summary>
        /// Write string to persistentDataPath/saveFileName location.
        /// </summary>
        public static void WriteString(string saveFileName, string str, object lockable, bool logSave = false)
        {
            lock (lockable)
            {
                var file = File.Create(Application.persistentDataPath + "/" + saveFileName);
                if(logSave) Debug.Log($"Writing file: {saveFileName} string: {str}");
                new BinaryFormatter().Serialize(file, str);
                file.Close();
            }
        }

        /// <summary>
        /// Read object  saved as JSON string from persistentDataPath/saveFileName location.
        /// </summary>
        public static T ReadObjectAsJsonString<T>(string saveFileName, object lockable, bool logSave = false)
            => JsonUtility.FromJson<T>(ReadString(saveFileName, lockable, logSave));

        /// <summary>
        /// Read string from persistentDataPath/saveFileName location.
        /// </summary>
        public static string ReadString(string saveFileName, object lockable, bool logSave = false)
        {
            try
            {
                lock (lockable)
                {
                    if (!File.Exists(Application.persistentDataPath + "/" + saveFileName)) return null;

                    var file = File.Open(Application.persistentDataPath + "/" + saveFileName, FileMode.Open);
                    var str = (string) new BinaryFormatter().Deserialize(file);
                    if (logSave) Debug.Log($"Read file: {saveFileName} string: {str}");
                    file.Close();

                    return str;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}