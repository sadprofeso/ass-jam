using System;
using System.Collections;
using UnityEngine;

public class WinLoseScreen : MonoBehaviour
{
    public static WinLoseScreen Instance;
    public GameObject winScreen;
    public GameObject loseScreen;

    public Animator animator;
    
    [HideInInspector] public bool thereIsAWinner = false;
    private void Awake()
    {
        Instance = this;
    }

    public void Win()
    {
        thereIsAWinner = true;
        Pause();
        animator.SetTrigger("Win");
        ACharacter.canMove = false;
    }

    public void Lose()
    {
        thereIsAWinner = true;
        Pause();
        animator.SetTrigger("Lose");
        ACharacter.canMove = false;
    }

    private void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
