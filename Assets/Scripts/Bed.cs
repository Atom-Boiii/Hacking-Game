using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : Interactable
{
    public override void OnInteract()
    {
        base.OnInteract();

        print("Skipping day...");
    }
}
