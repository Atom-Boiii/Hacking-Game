using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Email
{
    public string from, to;

    [TextArea]
    public string message;
}
