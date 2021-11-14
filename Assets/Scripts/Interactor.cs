using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    public Transform origin;
    public float range;
    public LayerMask interactWith;
    public GameObject indicator;

    private void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(origin.position, origin.forward, out hit, range, interactWith))
        {
            if (hit.transform.GetComponent<Interactable>())
            {
                indicator.SetActive(true);

                if (Input.GetKeyDown(KeyCode.F))
                {
                    hit.transform.GetComponent<Interactable>().OnInteract();
                }
            }
            else
            {
                indicator.SetActive(false);
            }
        }
    }
}
