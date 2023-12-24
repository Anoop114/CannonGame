using UnityEngine;
using Utils;

namespace UIScripts
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject menuUI;
        [SerializeField] private GameObject collectCannonBall;


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


        private void SetActivePanel(string activePanel)
        {
            menuUI.SetActive(activePanel.Equals(menuUI.name));
            collectCannonBall.SetActive(activePanel.Equals(collectCannonBall.name));
        }
    }
}