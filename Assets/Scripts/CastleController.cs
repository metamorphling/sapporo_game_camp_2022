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
        _healthMax = Info.Parameters.Health;
    }

    void Update()
    {
        if (Info == null || Info.IsInitialized == false)
        {
            return;
        }
        HealthBar.fillAmount = Mathf.Clamp(Info.Parameters.Health / _healthMax, 0, 1f);
        if (Info.Parameters.Health <= 0)
        {
            Destroy(this.gameObject);
            return;
        }
    }
}
