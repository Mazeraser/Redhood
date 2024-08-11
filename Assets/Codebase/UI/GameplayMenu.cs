using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Assets.Codebase.UI
{
    public class GameplayMenu : MonoBehaviour
    {
        [SerializeField]
        private float _fadeDuration;
        [SerializeField]
        private GameObject _activateButton;

        private Fade _fade;

        [Inject]
        private void Construct(Fade fade)
        {
            _fade = fade;
        }

        public virtual void Start()
        {
            Deactivate();
        }

        public void Activate()
        {
            Cursor.visible = true;
            _fade.FadeIn(_fadeDuration, GetComponent<CanvasGroup>(), () =>
            {
                Time.timeScale = 0f;
            });
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            _activateButton?.SetActive(false);
        }
        public void Deactivate()
        {
            Cursor.visible = false;
            Time.timeScale = 1f;
            _fade.FadeOut(_fadeDuration, GetComponent<CanvasGroup>(), () =>
            {
                Time.timeScale = 1f;
            });
            GetComponent<CanvasGroup>().blocksRaycasts = false;
            _activateButton?.SetActive(true);
        }
        public void Reset()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        public void Exit(int menu_index)
        {
            SceneManager.LoadScene(menu_index);
        }
    }
}

