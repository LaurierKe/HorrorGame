using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Humanoid : MonoBehaviour
{
    protected int    health_points = 10;

    protected string human_name = "Limbo";

    protected float  walk_speed =  5f;

    protected bool   can_be_killed = true;

    protected virtual void Move() { return; }

}