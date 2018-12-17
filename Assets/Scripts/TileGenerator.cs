using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator {

    int COLUMNHEIGHT = LevelRenderer.COLUMNHEIGHT;

    public static T Choose<T>(T[] possibilities, float[] distribution, int distrSize)
    {
        float number = Random.value;

        float sum = 0;
        for (int i = 0; i < distrSize; i++)
        {
            sum += distribution[i];
            if (sum > number)
            {
                return possibilities[i];
            }
        }

        return possibilities[0];
    }

    //char[] possibilites = new char[] { 'S', 'G', 'B', 'N', 'C' };
    public char[] createFollowingTile(char[] prevTile, char[] possibilites)
    {
        char[] newTile = new char[COLUMNHEIGHT];
        newTile[0] = 'S';
        bool grassPlaced = false;

        for (int i = 1; i < COLUMNHEIGHT; i++)
        {
            switch (prevTile[i])
            {
                case 'S':
                    //previous is soil
                    if (grassPlaced)
                    { 
                        //if grass is placed we can either have a candy or soil

                        //if there is a tile below for the candy to go on
                        if(newTile[i-1] == 'B' | newTile[i - 1] == 'S')
                        {
                            newTile[i] = Choose(possibilites, new float[] { 0.0f, 0.0f, 0, 0.5f, 0.5f }, 5);
                            break;
                        }
                        
                        //otherwise we'll just put nothing here
                        newTile[i] = 'N';
                    }
                    else
                    {
                        newTile[i] = Choose(possibilites, new float[] { 0.7f, 0.3f, 0, 0, 0 }, 5);
                        if (newTile[i] == 'G')
                        {
                            grassPlaced = true;
                        }
                    }
                    break;
                case 'N':

                    if (i == 1 && !grassPlaced)
                    {
                        newTile[i] = Choose(possibilites, new float[] { 0.3f, 0.7f, 0, 0,0 }, 5);
                        if (newTile[i] == 'G')
                        {
                            grassPlaced = true;
                        }
                    }
                    else
                    {
                        if (!grassPlaced)
                        {
                            newTile[i] = 'G';
                            grassPlaced = true;
                            break;
                        }

                        if (i == 2 || i == 3)
                        {
                            newTile[i] = 'N';
                            break;
                        }

                        if (newTile[i - 1] == 'B' || newTile[i - 1] == 'G')
                        {
                            newTile[i] = Choose(possibilites, new float[] { 0, 0, 0.0f, 0.6f, 0.4f }, 5);
                            break;
                        }

                        if (newTile[i - 2] == 'G' || newTile[i - 2] == 'B')
                        {
                            newTile[i] = 'N';
                            break;
                        }

                        newTile[i] = Choose(possibilites, new float[] { 0, 0, 0.05f, 0.95f, 0.00f}, 5);

                        

                    }

                    break;
                case 'G':
                    if (!grassPlaced)
                    {
                        newTile[i] = Choose(possibilites, new float[] { 0.1f, 0.9f, 0, 0, 0}, 5);
                        if (newTile[i] == 'G')
                        {
                            grassPlaced = true;
                        }
                        break;
                    }
                    else
                    {
                        newTile[i] = 'N';
                    }
                    break;
                case 'B':
                    if (newTile[i - 2] == 'B' || newTile[i - 1] == 'B' || newTile[i - 2] == 'G' || newTile[i - 1] == 'G')
                    {
                        newTile[i] = 'N';
                        break;
                    }
                    else
                    {
                        if (!grassPlaced)
                        {
                            newTile[i] = 'G';
                            grassPlaced = true;
                            break;
                        }
                        newTile[i] = Choose(possibilites, new float[] { 0, 0, 0.8f, 0.2f, 0f}, 5);
                    }
                    break;
                case 'C':
                    if (grassPlaced && ( newTile[i - 1] == 'G' || newTile[i - 1] == 'B'))
                    {
                        newTile[i] = Choose(possibilites, new float[] { 0, 0, 0, 0.5f, 0.5f }, 5);
                        break;
                    }

                    if(i == 1 || newTile[i - 2] == 'G' || newTile[i - 2] == 'B')
                    {
                        newTile[i] = 'N';
                        break;
                    }

                    newTile[i] = Choose(possibilites, new float[] { 0, 0, 0.05f, 0.95f, 0.00f }, 5);
                    break;

            }


        }
        return newTile;

    }
}
