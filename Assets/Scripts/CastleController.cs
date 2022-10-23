using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CastleController : MonoBehaviour
{
    public CastleParameters Info;
    public Rigidbody RigidBody;
    public Image HealthBar;
    public Button GradeUpButton;

    private int _currentLevel = 1;
    private float _healthMax;
    private const int MAX_GRADE = 4;

    public void UpdateUpgradeView()
    {
        if (GradeUpButton == null)
        {
            return;
        }
        var needStone = (int)Info.Parameters.CostStone;
        var needWood = (int)Info.Parameters.CostWood;

        var haveStone = GameManager.Instance.ResourceStone;
        var haveWood = GameManager.Instance.ResourceTree;

        GradeUpButton.interactable = haveStone >= needStone && haveWood >= needStone;
    }

    public void GradeUp()
    {
        if (_currentLevel > MAX_GRADE)
        {
            return;
        }
        _currentLevel++;
        _currentLevel = Math.Clamp(_currentLevel, 1, MAX_GRADE);
        GameManager.Instance.RemoveStone((int)Info.Parameters.CostStone);
        GameManager.Instance.RemoveTree((int)Info.Parameters.CostWood);
        Info.Init(_currentLevel);
        UpdateUpgradeView();
    }

    private void Awake()
    {
    }

    private void Start()
    {
        Info.Init(1);
        _healthMax = Info.CurrentHealth;
#if DEBUG
        //GameManager.Instance.AddStone(2);
        //GameManager.Instance.AddTree(2);
#endif
        UpdateUpgradeView();
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
