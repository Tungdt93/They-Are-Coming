using UnityEngine;

public class AUG : Weapon
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
