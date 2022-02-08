using UnityEngine;

public abstract class PlayerUnit : MonoBehaviour
{
    public static PlayerMain playerMain;
    public GameObject visual;
    public Transform weaponHolder;
    public Rigidbody rb;
    public PlayerUnitInfomation unitInfo;

    public void InitializeVariables()
    {
        playerMain = PlayerMain.Instance;
    }
}
