using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Player
{
    public class PickupAction : MonoBehaviour
    {
        [SerializeField] private Button pickupBtn;
        [SerializeField] private Slider pickupSlider;
        [SerializeField] private ParticleSystem particle;
        [SerializeField] private TMP_Text bombCount;
        private GameObject _tempHolder;
        private int _pickupCount;
        private void Start()
        {
            pickupBtn.onClick.AddListener(PickupBtnAction);
            pickupSlider.onValueChanged.AddListener(PlayParticle);
        }

        private void PlayParticle(float arg0)
        {
            particle.Play();
            _pickupCount++;
            bombCount.text = $"{arg0}";
            if (_pickupCount >= 5)
            {
                //GameBehaviourManager.Instance.UIManager;
                enabled = false;
            }
        }

        private void PickupBtnAction()
        {
            if (_tempHolder != null)
            {
                Destroy(_tempHolder);
                pickupSlider.value += 1;
            }

            PickupBtn(false, null);
        }

        private void OnEnable()
        {
            ActionHelper.OnPickupAction += PickupBtn;
        }

        private void PickupBtn(bool arg1, GameObject arg2)
        {
            pickupBtn.gameObject.SetActive(arg1);
            _tempHolder = arg1 ? arg2 : null;
        }

        private void OnDisable()
        {
            ActionHelper.OnPickupAction -= PickupBtn;
        }
        
    }
}