using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseConsole : Interactable
{
    public HackerDen den;

    public override void OnInteract()
    {
        base.OnInteract();

        den.UseConsole();
    }
}
