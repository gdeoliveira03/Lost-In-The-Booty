using Assets.Scripts.Player.Data;
using Assets.Scripts.Player.States.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Player
{
    public class PlayerCharacter : MonoBehaviour
    {
        #region StateMachine
        [field: SerializeField] public PlayerSO Data { get; private set; }
        public ScruffyInput MyInputMap { get; private set; }
        private PlayerMovementStateMachine movementStateMachine;
        #endregion

        #region Main Fields
        public Rigidbody myRigidbody { get; private set; }
        [field: SerializeField] public GameObject myCamera { get; private set; }
        #endregion
        private void Awake()
        {
            myRigidbody = GetComponent<Rigidbody>();
            MyInputMap = new ScruffyInput();
            MyInputMap.GroundedInputs.Enable();
            movementStateMachine = new PlayerMovementStateMachine(this);
        }
        private void Start()
        {
            movementStateMachine.ChangeState(movementStateMachine.IdleState);
        }
        private void Update()
        {
            movementStateMachine.HandleInput();
            movementStateMachine.Update();
        }
        private void FixedUpdate()
        {
            movementStateMachine.PhysicsUpdate();
        }
        public void OnAnimationEnterEvent()
        {
            movementStateMachine.OnAnimationEnterEvent();
        }
        public void OnAnimationExitEvent()
        {
            movementStateMachine.OnAnimationExitEvent();
        }
    }
}