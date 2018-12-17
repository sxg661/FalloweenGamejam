using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefabs : MonoBehaviour {


    public GameObject SoilPrefab;
    public GameObject grassPrefab;
    public GameObject skyblockPrefab;

    public GameObject friendlyProjectile;
    
    public GameObject mrsPumpkinPatch;
    public GameObject evilDude;


    public GameObject candy1;
    public GameObject candy2;
    public GameObject candy3;
    public GameObject candy4;
    public GameObject candy5;
    public GameObject candy6;
    public GameObject candy7;

    public GameObject getCandyObject()
    {
        return TileGenerator.Choose(
            new GameObject[] { candy1, candy2, candy3, candy4, candy5, candy6, candy7 },
            new float[] { 0.145f, 0.145f, 0.145f, 0.145f, 0.145f, 0.145f, 0.13f },
            7);
    }

}
