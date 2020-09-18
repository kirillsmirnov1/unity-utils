﻿using UnityEngine;

namespace UnityUtils
{
    public static class GameObjectExtensions
    {
        /// <summary>
        /// Checks if gameObject in question is edited in prefab scene
        /// <para>If you rename prefab file, you need to fix it's m_Name param for that call to work</para>
        /// <para>Can be used in pair with CheckNullFields to not check prefabs while editing them</para>
        /// </summary>
        public static bool InPrefabScene(this GameObject gameObject) 
            => gameObject.scene.name == null || gameObject.scene.name == gameObject.name;
    }
}