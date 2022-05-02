using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace UnityUtils.IO
{
    public static class SpriteLoader 
    {
        public static void Load(MonoBehaviour context, string path, Action<Sprite> spriteCallback)
        {
            context.StartCoroutine(LoadCoroutine(path, spriteCallback));
        }

        private static IEnumerator LoadCoroutine(string path, Action<Sprite> spriteCallback)
        {
            Sprite sprite = null;
            if (string.IsNullOrWhiteSpace(path))
            {
                spriteCallback.Invoke(sprite);
                yield break;
            }
            var loader = UnityWebRequestTexture.GetTexture(path);
            yield return loader.SendWebRequest();
            if (loader.result == UnityWebRequest.Result.Success)
            {
                var texture = DownloadHandlerTexture.GetContent(loader);
                sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            }
            spriteCallback.Invoke(sprite);
        }
    }
}