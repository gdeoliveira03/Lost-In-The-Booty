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
        [field: SerializeField, Header("State Machine")] public PlayerSO Data { get; private set; }
        [field: Header("State Machine")] public ScruffyInput MyInputMap { get; private set; }
        private PlayerMovementStateMachine movementStateMachine;
        #endregion

        #region Main Fields
        [field: SerializeField, Header("Main Fields")] public Rigidbody MyRigidbody { get; private set; }
        [field: SerializeField] public GameObject MyCamera { get; private set; }
        #endregion

        #region Animation
        [Header("Animation")]
        [SerializeField] private Animator myAnimator;
        #endregion
        private void Awake()
        {
            MyRigidbody = GetComponent<Rigidbody>();
            MyInputMap = new ScruffyInput();
            MyInputMap.GroundedInputs.Enable();
            movementStateMachine = new PlayerMovementStateMachine(this);
        }
        private void Start()
        {
            movementStateMachine.ChangeState(movementStateMachine.IdleState);
            AudioListener[] ALs = FindObjectsOfType<AudioListener>();
            foreach (var al in ALs)
            {
                Debug.LogWarning(al.gameObject);
            }
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