using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRenderer : MonoBehaviour {

    public GameObject prefabs;

    public GameObject mainCamera;

    Prefabs myPrefabs;

    float enemyProb = 0.01f;

    int frameNum = 0;

    TileGenerator randomTile = new TileGenerator();

    char[] possibilites = new char[] {'S','G','B','N','C'}; 

    Camera myCam;

    public static int COLUMNHEIGHT = 20;

    int cameraWidth = 26;

    public static Dictionary<int, char[]> map;

    /// <summary>
    /// Gets the rendering postition of a certain tile
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static float getPos(int n)
    {
        return n + 0.5f;
    }

    /// <summary>
    /// Gets the tile of certain rendering position
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static int getTile(float n)
    {
        return (int)Mathf.Floor(n);
    }


    GameObject getPrefab(char c)
    {
        switch (c)
        {
            case 'S':
                return myPrefabs.SoilPrefab;
            case 'G':
                return myPrefabs.grassPrefab;
            case 'B':
                return myPrefabs.skyblockPrefab;
            case 'C':
                return myPrefabs.getCandyObject();
        }

        return null;
    }

    void MakeMap()
    {
        map = new Dictionary<int, char[]>();
        map[-13] = (new char[] { 'S', 'G', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N' });
        map[-12] = (new char[] { 'S', 'G', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N' });
        map[-11]= (new char[] { 'S', 'G', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N' });
        map[-10] = (new char[] { 'S', 'G', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N' , 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N' });
        map[-9] = (new char[] { 'S', 'G', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N' , 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N' });
        map[-8] = (new char[] { 'S', 'G', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N' , 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N' });
        map[-7] = (new char[] { 'S', 'G', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N' , 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N' });
        map[-6] = (new char[] { 'S', 'G', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N' , 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N' });
        map[-5] = (new char[] { 'S', 'G', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N' , 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N' });
        map[-4] = (new char[] { 'S', 'G', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N' , 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N' });
        map[-3] = (new char[] { 'S', 'G', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N' ,'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N' });
        map[-2] = (new char[] { 'S', 'G', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N' , 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N' });
        map[-1] = (new char[] { 'S', 'G', 'N', 'B', 'N', 'N', 'N', 'N', 'N', 'N' , 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N' });
        map[0] = (new char[] { 'S', 'G', 'N', 'B', 'N', 'N', 'N', 'N', 'N', 'N' , 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N' });
        map[1] = (new char[] { 'S', 'G', 'N', 'B', 'N', 'N', 'N', 'N', 'N', 'N' , 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N' });

    }

    void RenderColumn(int n)
    {
        char[] column = map[n];
        for(int i = 0; i < COLUMNHEIGHT; i++)
        {
            GameObject prefab = getPrefab(column[i]);
            if(prefab != null)
            {
                Vector2 location = new Vector2(getPos(n), getPos(i));
                Instantiate(prefab, location, Quaternion.identity);

                //also might render an enemy
                if(Random.value < enemyProb)
                {
                    Instantiate(myPrefabs.evilDude, new Vector3(getPos(n), Random.value * (COLUMNHEIGHT), 0), Quaternion.identity);
                }
            }
        }
    }

    void RenderWholeMap()
    {
        for (int i = -13; i < 2; i++)
        {
            RenderColumn(i);
        }
    }


    
  

    

    void FillInMap(int camX)
    {
        //to the left
        for (int i = 0; i < (camX + cameraWidth / 2); i++)
        {
            if (!map.ContainsKey(i))
            {
                map[i] = randomTile.createFollowingTile(map[i - 1], possibilites);
                RenderColumn(i);
            }
        }
    }

    // Use this for initialization
    void Start () {
        myPrefabs = prefabs.GetComponent<Prefabs>();
        myCam = mainCamera.GetComponent<Camera>();
        MakeMap();
        RenderWholeMap();
	}

    
	
	// Update is called once per frame
	void Update () {
        int getCameraXTile = getTile(myCam.transform.position[0]);
        FillInMap(getCameraXTile);

        frameNum++;
        if(frameNum == 10000)
        {
            frameNum = 0;
            enemyProb *= 2;
        }

        
	}
}
