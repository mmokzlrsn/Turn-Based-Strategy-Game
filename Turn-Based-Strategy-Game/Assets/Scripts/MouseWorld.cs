using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWorld : MonoBehaviour
{
    [SerializeField] private LayerMask mouseLayerMask;
     
    private void Update()
    {
        Debug.Log(Input.mousePosition);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
    }
}
