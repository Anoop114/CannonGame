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


        public void PickupCompleteAction()
        {
            SetActivePanel(pickupComplete.name);
        }
        
        public void ErrorDisplayCannonMenu()
        {
            SetActivePanel(errorDisplayCannonMenu.name);
        }
        
        public void MainMenuActive()
        {
            GameBehaviourManager.Instance.SwipeController.enabled = false;
            GameBehaviourManager.Instance.CannonMachineController.enabled = false;
            SetActivePanel(menuUI.name);
        }

        public void CollectCannonBallActive()
        {
            GameBehaviourManager.Instance.SwipeController.enabled = true;
            SetActivePanel(collectCannonBall.name);
        }


        public void DragDropCannonBallActive()
        {
            SetActivePanel(dragDropCannonBall.name);
            GameBehaviourManager.Instance.CamScript.UpdateCameraPosToCannon();
            ActionHelper.OnCannonMachineActive?.Invoke();
        }

        public void CannonMachineMenu()
        {
            SetActivePanel(cannonMachineMenu.name);
            GameBehaviourManager.Instance.CannonMachineController.enabled = true;
            Debug.Log("Active cannon controller script");
        }
        
        private void SetActivePanel(string activePanel)
        {
            menuUI.SetActive(activePanel.Equals(menuUI.name));
            collectCannonBall.SetActive(activePanel.Equals(collectCannonBall.name));
            dragDropCannonBall.SetActive(activePanel.Equals(dragDropCannonBall.name));
            cannonMachineMenu.SetActive(activePanel.Equals(cannonMachineMenu.name));
            pickupComplete.SetActive(activePanel.Equals(pickupComplete.name));
            errorDisplayCannonMenu.SetActive(activePanel.Equals(errorDisplayCannonMenu.name));
        }
    }
}