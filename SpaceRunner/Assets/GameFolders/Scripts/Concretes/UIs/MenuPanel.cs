using System.Collections;
using System.Collections.Generic;
using SpaceRunner.Managers;
using UnityEngine;

namespace SpaceRunner.UIs
{
    public class MenuPanel : MonoBehaviour
    {
        public void SelectAndStartButton(int index)
        {
            GameManager.Instance.DifficultyIndex = index;
            GameManager.Instance.LoadScene("GameScene");
        }
        
        public void ExitButton()
        {
            GameManager.Instance.ExitGame();
        }
        
    }
}
