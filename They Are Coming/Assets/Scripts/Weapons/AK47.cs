    using UnityEngine;

public class AK47 : Weapon
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
