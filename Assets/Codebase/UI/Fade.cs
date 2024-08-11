using DG.Tweening;
using UnityEngine;

namespace Assets.Codebase.UI
{

    public class Fade : MonoBehaviour
    {
        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

        public void FadeIn(float duration, CanvasGroup canvasGroup, TweenCallback tweenCallback)
        {
            FadeCanvasGroup(1f, duration, canvasGroup,tweenCallback);
        }
        public void FadeOut(float duration, CanvasGroup canvasGroup, TweenCallback tweenCallback)
        {
            FadeCanvasGroup(0f, duration, canvasGroup,tweenCallback);
        }

        private void FadeCanvasGroup(float fadeValue, float duration, CanvasGroup canvasGroup, TweenCallback onEnd)
        {
            canvasGroup.DOFade(fadeValue, duration).OnComplete(onEnd);
        }
    }
}