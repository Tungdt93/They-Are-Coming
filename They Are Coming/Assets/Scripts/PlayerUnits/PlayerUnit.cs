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
        if (playerMain.Weapon != null)
        {
            InitializeWeapon();
        }
    }
    public void InitializeWeapon()
    {
        GameObject newWeapon = Instantiate(playerMain.Weapon.gameObject, weaponHolder.transform.position, Quaternion.identity, weaponHolder.transform);
        Weapon weapon = newWeapon.GetComponent<AK47>();
        weapon.PickedUpNewWeapon();
    }
}
