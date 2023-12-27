using Assets.Scripts.Player.Data;
using Assets.Scripts.Player.States.Movement;
using Assets.Scripts.Weapon.Weapons;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerCharacter : MonoBehaviour
    {
        #region StateMachine
        [field: SerializeField, Header("State Machine")]
        public PlayerSO Data { get; private set; }

        public ScruffyInput MyInputMap { get; private set; }
        private PlayerMovementStateMachine movementStateMachine;
        #endregion

        #region Main Fields
        [field: SerializeField, Header("Main Fields")]
        public Rigidbody MyRigidbody { get; private set; }

        [field: SerializeField]
        public GameObject MyCamera { get; private set; }
        #endregion

        #region Animation
        [field: Header("Animation")]
        [field: SerializeField]
        public Animator MyAnimator { get; private set; }
        #endregion

        #region Inventory
        public ScruffyInventory MyInventory { get; private set; }

        [SerializeField]
        private Sword mySword;

        [SerializeField]
        private Spear mySpear;

        [SerializeField]
        private Hammer myHammer;
        #endregion

        private void Awake()
        {
            MyRigidbody = GetComponent<Rigidbody>();
            MyInputMap = new ScruffyInput();
            MyInputMap.GroundedInputs.Enable();
            movementStateMachine = new PlayerMovementStateMachine(this);
            MyAnimator = GetComponent<Animator>();

            //For now we create a new inventory but saving and loading feature should be expanded
            MyInventory = ScriptableObject.CreateInstance<ScruffyInventory>();
            MyInventory.InitializeWeapons(mySword, mySpear, myHammer);
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
