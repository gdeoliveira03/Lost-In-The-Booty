using System;
using Assets.Scripts.Player;
using Assets.Scripts.Utils;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts
{
    public class GameManager : Singleton<GameManager>
    {
        public ScruffyInventory scruffyInventory { get; private set; }
        private MenuInputActions menuInputs { get; set; }

        public enum GameState
        {
            PLAY,
            PAUSED
        };

        public GameState currentState { get; private set; } = GameState.PLAY;
        public event Action<GameState> OnGameStateChange;

        protected override void Awake()
        {
            base.Awake();
            menuInputs = new MenuInputActions();
            menuInputs.Enable();
            menuInputs.Menu.Pause.started += OnPauseStarted;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            DontDestroyOnLoad(gameObject);
        }

        public void Start()
        {
            scruffyInventory = GameObject
                .Find("scruffyMain")
                .GetComponent<PlayerCharacter>()
                .MyInventory;
        }

        private void OnPauseStarted(InputAction.CallbackContext context)
        {
            switch (currentState)
            {
                case GameState.PLAY:
                    ChangeGameState(GameState.PAUSED);
                    break;
                case GameState.PAUSED:
                    ChangeGameState(GameState.PLAY);
                    break;
            }
        }

        public void ChangeGameState(GameState newState)
        {
            currentState = newState;
            switch (currentState)
            {
                case GameState.PLAY:
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                    break;
                case GameState.PAUSED:
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    break;
                default:
                    Debug.LogError("[GameManager] Logic for passed in state has not been defined");
                    break;
            }
            OnGameStateChange?.Invoke(currentState);
        }
    }
}
