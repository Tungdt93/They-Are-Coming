    using UnityEngine;

public class AK47 : Weapon
{
    private void OnEnable()
    {
        InitializeModel();
        InitializeVariables();
    }

    private void Update() 
    {
        if (!pickedUp) 
        {
            return;
        }
        Fire();
    }
}
