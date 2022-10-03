using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UnitActionSystem : MonoBehaviour
{
    public static UnitActionSystem Instance { get; private set; }

    [SerializeField] private Unit selectedUnit;

    [SerializeField] private LayerMask unitLayerMask;

    public event EventHandler OnSelectedUnitChanged;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("There is moree than one Unit Action System" + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(1) || Input.GetMouseButton(1)) // 0 is left mouse button , 1 is right
        {
            if (TryHandleUnitSelection()) return;   
            selectedUnit.Move(MouseWorld.GetPosition());
        }
         
    }

    private bool TryHandleUnitSelection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, unitLayerMask))
        {
            if(raycastHit.transform.TryGetComponent<Unit>(out Unit unit))
            {
                SetSelectedUnit(unit);
                return true;
            }
        }
        return false;
    }

    private void SetSelectedUnit(Unit unit)
    {
        selectedUnit = unit;
        OnSelectedUnitChanged?.Invoke(this, EventArgs.Empty);
    }

    public Unit GetSelectedUnit()
    {
        return selectedUnit;
    }
}
