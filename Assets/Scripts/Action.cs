using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : MonoBehaviour
{
    abstract public void onEnable();
    abstract public void onDisable();
}
