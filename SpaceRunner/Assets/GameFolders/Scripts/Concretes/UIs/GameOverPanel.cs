using System.Collections;
using System.Collections.Generic;
using SpaceRunner.Managers;
using UnityEngine;

namespace SpaceRunner.UIs
{
    public class GameOverPanel : MonoBehaviour
    {

        public void RestartButton()
        {
            GameManager.Instance.LoadScene("GameScene");
        }
        

        public void ExitButton()
        {
            GameManager.Instance.LoadScene("MenuScene");
        }
    }
}
