using System;
using UnityEditor;

namespace UnityUtils.Scenes
{
    [Serializable]
    public struct SceneNameReference
    {
        public string sceneName;
#if UNITY_EDITOR
        public SceneAsset sceneAsset;
        /// <summary>
        /// Should be called in OnValidate() 
        /// </summary>
        public void SerializeName()
        {
            try
            {
                sceneName = sceneAsset.name;
            }
            catch (NullReferenceException) { }
        }
#endif
    }
}