using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBar : HealthBar
{
    private PlayerStatManager statManager;

    private void OnEnable()
    {
        statManager.hpChangedEvent += UpdateHpBar;
    }

    private void OnDisable()
    {
        statManager.hpChangedEvent -= UpdateHpBar;
    }

    private void Awake()
    {
        statManager = GetComponent<PlayerStatManager>();
    }

    protected override void UpdateHpBar(float currentHp, float maxHp)
    {
        base.UpdateHpBar(currentHp, maxHp); 
    }
}
