using System.Collections;
using UnityEngine;
using UnityEngine.Video;

namespace UnityUtils.Extensions
{
    public static class VideoPlayerExt
    {
        public static IEnumerator ResetAndPlay(this VideoPlayer vp, GameObject renderer)
        {
            vp.Reset();

            while (!vp.isPrepared)
            {
                yield return null;
            }
            
            vp.Play();
            yield return new WaitForEndOfFrame();
            renderer.SetActive(true);
            while (vp.isPlaying)
            {
                yield return null;
            }

            yield return new WaitForEndOfFrame();
        }

        public static void Reset(this VideoPlayer vp)
        {
            vp.frame = 0;
            vp.Prepare();
        }
    }
}