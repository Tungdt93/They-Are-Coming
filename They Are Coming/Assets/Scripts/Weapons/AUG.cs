using UnityEngine;

public class AUG : Weapon
{
    // Start is called before the first frame update
    private void OnEnable()
    {
        InitializeModel();
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
