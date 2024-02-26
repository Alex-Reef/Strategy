using UnityEngine;

namespace NavigationSystem
{
    [RequireComponent(typeof(Canvas))]
    public class UiPage : MonoBehaviour
    {
        private Canvas _canvas;

        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
        }

        public virtual void Show()
        {
            _canvas.enabled = true;
        }

        public virtual void Hide()
        {
            _canvas.enabled = false;
        }
    }
}