using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridData : MonoBehaviour
{
    public int f;
    public static bool operator <(GridData g1, GridData g2)
    {
        return (g1.f < g2.f);
    }

    public static bool operator >(GridData g1, GridData g2)
    {
        return (g1.f > g2.f);
    }

    public static bool operator <=(GridData g1, GridData g2)
    {
        return (g1.f <= g2.f);
    }

    public static bool operator >=(GridData g1, GridData g2)
    {
        return (g1.f >= g2.f);
    }

    public static bool operator ==(GridData g1, GridData g2)
    {
        return (g1.f == g2.f);
    }

    public static bool operator !=(GridData g1, GridData g2)
    {
        return (g1.f != g2.f);
    }
}
