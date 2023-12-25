using UnityEngine;
using Utils;

namespace UIScripts
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject menuUI;
        [SerializeField] private GameObject collectCannonBall;
        [SerializeField] private GameObject dragDropCannonBall;


        public void MainMenuActive()
        {
            GameBehaviourManager.Instance.SwipeController.enabled = false;
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
            Debug.Log("Active cannon controller script");
        }
        
        private void SetActivePanel(string activePanel)
        {
            menuUI.SetActive(activePanel.Equals(menuUI.name));
            collectCannonBall.SetActive(activePanel.Equals(collectCannonBall.name));
            dragDropCannonBall.SetActive(activePanel.Equals(dragDropCannonBall.name));
        }
    }
}