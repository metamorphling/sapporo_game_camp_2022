using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastleController : MonoBehaviour
{
    public CastleParameters Info;
    public Rigidbody RigidBody;
    public Image HealthBar;

    private float _healthMax;

    private void Start()
    {
        Info.Init(1);
        _healthMax = Info.CurrentHealth;
    }

    void Update()
    {
        if (Info == null || Info.IsInitialized == false)
        {
            return;
        }
        HealthBar.fillAmount = Mathf.Clamp(Info.CurrentHealth / _healthMax, 0, 1f);
        if (Info.CurrentHealth <= 0)
        {
            Destroy(this.gameObject);
            return;
        }
    }
}
