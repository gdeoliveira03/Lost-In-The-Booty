using Assets.Scripts.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : Singleton<GameManager>
{
    public ScruffyInventory scruffyInventory;
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
        scruffyInventory = ScriptableObject.CreateInstance<ScruffyInventory>();
        menuInputs = new MenuInputActions();
        menuInputs.Enable();
#if UNITY_EDITOR
        menuInputs.Menu.Pause.started += (InputAction.CallbackContext context) => { Application.Quit(); };
#else
        menuInputs.Menu.Pause.started += OnPauseStarted;
#endif
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        DontDestroyOnLoad(gameObject);
    }

    private void OnPauseStarted(InputAction.CallbackContext context)
    {
        if (currentState == GameState.PLAY)
        {
            ChangeGameState(GameState.PAUSED);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            ChangeGameState(GameState.PLAY);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void ChangeGameState(GameState newState)
    {
        currentState = newState;
        OnGameStateChange?.Invoke(currentState);
    }
}
