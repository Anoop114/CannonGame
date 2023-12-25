using UnityEngine;
using UnityEngine.EventSystems;

namespace UIScripts
{
    public class DragDrop : MonoBehaviour,IEndDragHandler,IDragHandler
    {

        [SerializeField] private Canvas mCanvas;
        private RectTransform _mTransform;
        private bool _isDragSuccess;
        private Vector2 _originPos;
        private void Start()
        {
            _mTransform = GetComponent<RectTransform>();
            _originPos = _mTransform.anchoredPosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if(_isDragSuccess)return;
            _mTransform.anchoredPosition = _originPos;
        }

        public void IsDragSuccess()
        {
            _isDragSuccess = true;
            enabled = false;
            gameObject.SetActive(false);
        }
        public void OnDrag(PointerEventData eventData)
        {
            _mTransform.anchoredPosition += eventData.delta / mCanvas.scaleFactor;
        }
    }
}