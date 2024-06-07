using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SpaceRunner.UIs
{
    public class TimeCounter : MonoBehaviour
    {
        #region Self Variables

        #region Private Variables

        private TMP_Text _text;
        private float _currentTime;

        #endregion

        #endregion
        
        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
        }

        private void Update()
        {
            _currentTime += Time.deltaTime;
            _text.text = _currentTime.ToString("0");
        }
    }
}
