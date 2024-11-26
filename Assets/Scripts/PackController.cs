using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackController : MonoBehaviour
{
    private int numPacks;
    private Pack[] packs;
    private Pack selectedPack;

    private void Start()
    {
        packs = new Pack[numPacks];
    }

}
