using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Manager<GameManager>
{
    [SerializeField] private GameObject bulletStorgage;

    public GameObject BulletStorgage { get => bulletStorgage; set => bulletStorgage = value; }

    public override void InitializeSingleton()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public override void InitializeVariables()
    {
        
    }

    private void Awake() 
    {
        InitializeSingleton();
    }
}
