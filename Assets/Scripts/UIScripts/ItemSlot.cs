using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UIScripts
{
    public class ItemSlot : MonoBehaviour,IDropHandler
    {
        [SerializeField] private ParticleSystem dropParticle;
        [SerializeField] private GameObject[] balls;
        [SerializeField] private GameObject fireStart;
        private int _ballCount;

        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag == null) return;
            
            eventData.pointerDrag.GetComponent<DragDrop>().IsDragSuccess();
            balls[_ballCount].SetActive(true);
            dropParticle.Play();
            _ballCount++;
            if (_ballCount >= 5)
            {
                fireStart.SetActive(true);
            }
        }
    }
}