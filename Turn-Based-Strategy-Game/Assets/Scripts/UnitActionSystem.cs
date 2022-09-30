using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{
    [SerializeField] private Unit selectedUnit;

    [SerializeField] private LayerMask unitLayerMask;



    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(1)) // 0 is left mouse button , 1 is right
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
                selectedUnit = unit;
                return true;
            }
        }
        return false;
    }
}
