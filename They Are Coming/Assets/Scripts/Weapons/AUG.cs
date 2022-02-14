using UnityEngine;

public class AUG : Weapon
{
    private void Start()
    {
        InitializeModel();
        InitializeVariables();
    }

    private void Update() 
    {
        CheckGameState();
        AllowToShoot();
    }
}
