using System.Runtime.CompilerServices;
using SpaceRunner.Abstracts.Inputs;
using UnityEngine.InputSystem;

namespace SpaceRunner.Inputs
{
    public class InputReader : IInputReader
    {
        #region Self Variables

        #region Private Variables
        
        private PlayerInput _playerInput;

        #endregion

        #region Public Variables

        public float Horizontal { get; private set; }
        public bool IsJump { get; private set; }

        #endregion

        #endregion
        
        public InputReader(PlayerInput playerInput)
        {
            _playerInput = playerInput;

            _playerInput.currentActionMap.actions[0].performed += OnHorizontalMove;
            _playerInput.currentActionMap.actions[1].started += OnJump;
            _playerInput.currentActionMap.actions[1].canceled += OnJump;
        }

        private void OnJump(InputAction.CallbackContext context)
        {
            IsJump = context.ReadValueAsButton();
        }

        private void OnHorizontalMove(InputAction.CallbackContext context)
        {
            Horizontal = context.ReadValue<float>();
        }
    }
}
