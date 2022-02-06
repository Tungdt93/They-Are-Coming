using UnityEngine;

public class PowerUpHolder : MonoBehaviour
{
    [SerializeField] private PowerUp powerUp1;
    [SerializeField] private PowerUp powerUp2;

    private void OnEnable()
    {
        powerUp1.OnDeactivate += DeactivateHolder;
        powerUp2.OnDeactivate += DeactivateHolder;
    }

    private void OnDisable()
    {
        powerUp1.OnDeactivate -= DeactivateHolder;
        powerUp2.OnDeactivate -= DeactivateHolder;
    }

    private void DeactivateHolder()
    {
        this.gameObject.SetActive(false);
    }
}
