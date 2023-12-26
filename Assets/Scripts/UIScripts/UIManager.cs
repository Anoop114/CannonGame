using UnityEngine;
using Utils;

namespace UIScripts
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject menuUI;
        [SerializeField] private GameObject collectCannonBall;
        [SerializeField] private GameObject dragDropCannonBall;
        [SerializeField] private GameObject cannonMachineMenu;
        [SerializeField] private GameObject pickupComplete;
        [SerializeField] private GameObject errorDisplayCannonMenu;
        [SerializeField] private GameObject winMenu;
        [SerializeField] private GameObject looseMenu;
        [SerializeField] private GameObject localMenu;

        private bool _isCollectCannonBallVisit;
        private bool _isPickupCompleteVisit;
        private bool _isDragDropCannonBallVisit;
        private bool _isCannonMachineMenuVisit;

        
        
        
        
        public void MainMenuActive()
        {
            StaticHelper.IsPlayStart = false;
            GameBehaviourManager.Instance.SwipeController.enabled = false;
            GameBehaviourManager.Instance.CannonMachineController.enabled = false;
            SetActivePanel(menuUI.name);
        }

        public void CollectCannonBallActive()
        {
            StaticHelper.IsPlayStart = true;
            GameBehaviourManager.Instance.SwipeController.enabled = true;
            if (_isCollectCannonBallVisit)
            {
                PickupCompleteAction(true);
            }
            SetActivePanel(collectCannonBall.name);
        }
        public void PickupCompleteAction(bool action)
        {
            _isCollectCannonBallVisit = true;
            if(_isPickupCompleteVisit) return;
            if(action)
                SetActivePanel(pickupComplete.name);
        }
        public void DragDropCannonBallActive()
        {
            StaticHelper.IsUseJoystick = false;
            _isPickupCompleteVisit = true;
            localMenu.SetActive(false);
            GameBehaviourManager.Instance.CamScript.UpdateCameraPosToCannon();
            ActionHelper.OnCannonMachineActive?.Invoke();
            if (_isDragDropCannonBallVisit)
            {
                CannonMachineMenu();
                return;
            }
            SetActivePanel(dragDropCannonBall.name);
        }

        public void CannonMachineMenu()
        {
            _isDragDropCannonBallVisit = true;
            SetActivePanel(cannonMachineMenu.name);
            GameBehaviourManager.Instance.CannonMachineController.enabled = true;
            Debug.Log("Active cannon controller script");
        }

        public void WinMenu()
        {
            SetActivePanel(winMenu.name);
        }

        public void LooseMenu()
        {
            SetActivePanel(looseMenu.name);
            
        }
        
        private void SetActivePanel(string activePanel)
        {
            menuUI.SetActive(activePanel.Equals(menuUI.name));
            if (!StaticHelper.IsUseJoystick || activePanel.Equals(collectCannonBall.name))
            {
                collectCannonBall.SetActive(activePanel.Equals(collectCannonBall.name));
            }
            pickupComplete.SetActive(activePanel.Equals(pickupComplete.name));
            dragDropCannonBall.SetActive(activePanel.Equals(dragDropCannonBall.name));
            cannonMachineMenu.SetActive(activePanel.Equals(cannonMachineMenu.name));
            errorDisplayCannonMenu.SetActive(activePanel.Equals(errorDisplayCannonMenu.name));
            winMenu.SetActive(activePanel.Equals(winMenu.name));
            looseMenu.SetActive(activePanel.Equals(looseMenu.name));
        }
    }
}