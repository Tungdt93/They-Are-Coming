using UnityEngine;

public class AK47 : Weapon
{
    private void OnEnable()
    {
        InstantiateModel();
    }

    private void Update() 
    {
        Fire();
    }
}
