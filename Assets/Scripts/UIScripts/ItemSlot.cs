using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Utils;

namespace UIScripts
{
    public class ItemSlot : MonoBehaviour,IDropHandler
    {
        [SerializeField] private ParticleSystem dropParticle;
        [SerializeField] private GameObject[] balls;
        [SerializeField] private GameObject fireStart;
        [SerializeField] private Button goToFireCannon;
        private int _ballCount;

        private ItemSlot _mScript;

        private void Start()
        {
            _mScript = this;
            goToFireCannon.onClick.AddListener(FireCannonBtnAction);
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag == null) return;
            
            eventData.pointerDrag.GetComponent<DragDrop>().IsDragSuccess();
            balls[_ballCount].SetActive(true);
            dropParticle.Play();
            GameBehaviourManager.Instance.SoundController.PlayPickupAudio();
            _ballCount++;
            if (_ballCount < 5) return;
            
            fireStart.SetActive(true);
        }

        private void FireCannonBtnAction()
        {
            GameBehaviourManager.Instance.UIManager.CannonMachineMenu();
            Destroy(_mScript);
        }
    }
}