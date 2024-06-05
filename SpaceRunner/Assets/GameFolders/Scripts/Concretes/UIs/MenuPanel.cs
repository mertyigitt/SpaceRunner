using System.Collections;
using System.Collections.Generic;
using SpaceRunner.Managers;
using UnityEngine;

namespace SpaceRunner.UIs
{
    public class MenuPanel : MonoBehaviour
    {
        public void StartButton()
        {
            GameManager.Instance.LoadScene();
        }
        
        public void ExitButton()
        {
            GameManager.Instance.ExitGame();
        }
        
    }
}
