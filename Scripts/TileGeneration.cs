using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGeneration : Photon.MonoBehaviour
{
    public GameObject tile;
    public GameObject grass;
    public GameObject sand;
    public GameObject rocks;
    public GameObject sandHills;
    public GameObject snow;
    public GameObject snowRocks;
    public GameObject badlands;
    public GameObject mesa;
    public GameObject jungle;
    public GameObject savanna;
    public GameObject swamp;
    public GameObject plains;

    public GameObject grass1;
    public GameObject oakTree;
    public GameObject birchTree;
    public GameObject mapleTree;
    public GameObject swampTree1;
    public GameObject swampTree2;
    public GameObject swampTree3;
    public GameObject swampTree4;
    public GameObject savannaTree1;
    public GameObject savannaTree2;
    public GameObject savannaTree3;
    public GameObject savannaTree4;
    public GameObject savannaTree5;
    public GameObject snowTree1;
    public GameObject snowTree2;
    public GameObject snowTree3;
    public GameObject snowTree4;
    public GameObject snowTree5;
    public GameObject deadTree;
    public GameObject jungleTree1;
    public GameObject jungleTree2;
    public GameObject jungleTree3;
    public GameObject jungleTree4;
    public GameObject jungleTree5;
    public GameObject jungleTree6;
    public GameObject jungleTree7;
    public GameObject cactus1;
    public GameObject cactus2;
    public GameObject cactus3;
    public GameObject deadBush1;
    public GameObject deadBush2;
    public GameObject deadBush3;
    public GameObject mesaRock1;
    public GameObject mesaRock2;
    public GameObject mesaRock3;
    public GameObject mesaRock4;
    public GameObject mesaRock5;
    public GameObject mesaRock6;
    public GameObject mesaRock7;
    public GameObject desertRock1;
    public GameObject desertRock2;
    public GameObject desertRock3;
    public GameObject desertRock4;
    public GameObject desertRock5;
    public GameObject desertRock6;
    public GameObject rock1;
    public GameObject rock2;
    public GameObject rock3;
    public GameObject rock4;
    public GameObject rock5;
    public GameObject rock6;
    public GameObject rock7;
    public GameObject rock8;
    public GameObject snowRock1;
    public GameObject snowRock2;
    public GameObject snowRock3;
    public GameObject snowRock4;
    public GameObject pumpkins1;
    public GameObject pumpkins2;
    public GameObject savannaTallGrass;
    public GameObject fallenTree;
    public GameObject badlandsPlant1;
    public GameObject badlandsPlant2;
    public GameObject badlandsPlant3;
    public GameObject savannaGrass1;
    public GameObject savannaGrass2;
    public GameObject savannaGrass3;
    public GameObject savannaRedFlower;
    public GameObject tundraPlant1;
    public GameObject tundraPlant2;
    public GameObject tundraPlant3;
    public GameObject tundraPlant4;
    public GameObject tundraPlant5;
    public GameObject tundraPlant6;
    public GameObject stick;
    public GameObject tundraFlowers;
    public GameObject sunflower1;
    public GameObject sunflower2;
    public GameObject plainsGrass;
    public GameObject forestGrass1;
    public GameObject forestGrass2;
    public GameObject forestPlant;
    public GameObject forestFlower;
    public GameObject brownMushroom1;
    public GameObject brownMushroom2;
    public GameObject redMushroom;
    public GameObject log1;
    public GameObject log2;
    public GameObject junglePlant1;
    public GameObject junglePlant2;
    public GameObject junglePlant3;
    public GameObject junglePlant4;
    public GameObject junglePlant5;
    public GameObject junglePlant6;
    public GameObject junglePlant7;
    public GameObject swampPlant1;
    public GameObject swampPlant2;
    public GameObject swampPlant3;
    public GameObject swampPlant4;
    public GameObject swampGrass1;
    public GameObject swampGrass2;
    public GameObject swampGrass3;
    public GameObject swampLog;

    public GameObject resourceHolder;

    public int[,] tileArray = new int[36,36];
    public int[,] heightArray = new int[36, 36];
    public byte[,,] treeArray = new byte[36, 36, 144];
    public byte[,,] plantArray = new byte[36, 36, 64];
    public ArrayList checkList = new ArrayList();
    public ArrayList resources = new ArrayList();

    void Start()
    {
        if (PhotonNetwork.isMasterClient)
        {
            Debug.Log("I'm the master client");
            for (int i = 0; i < 36; i++)
            {
                for (int k = 0; k < 36; k++)
                {
                    tileArray[i, k] = 12;
                    heightArray[i, k] = 1000;
                }
            }

            /*
            for (int i = 0; i < 500; i++)
            {
                int r1 = Random.Range(0, 149);
                int r2 = Random.Range(0, 149);
                tileArray[r1, r2] = 0;
            }

            for (int i = 0; i < 500; i++)
            {
                int r1 = Random.Range(0, 149);
                int r2 = Random.Range(0, 149);
                tileArray[r1, r2] = 1;
            }

            for (int i = 0; i < 500; i++)
            {
                int r1 = Random.Range(0, 149);
                int r2 = Random.Range(0, 149);
                tileArray[r1, r2] = 2;
            }

            */

            for (int i = 0; i < 36; i++)
            {
                /*
                int i = 0;
                while (checkList.Contains(i) == true && checkList.Count != 150 && checkList.Count != 149)
                {
                    i = Random.Range(0, 149);
                }
                checkList.Add(i);
                */
                for (int l = 0; l < 1000; l++)
                {
                    int k = Random.Range(0, 35);

                    ArrayList biomeOptions = new ArrayList();
                    biomeOptions.Add(0);
                    biomeOptions.Add(0);
                    biomeOptions.Add(1);
                    biomeOptions.Add(2);
                    biomeOptions.Add(3);
                    biomeOptions.Add(4);
                    biomeOptions.Add(4);
                    biomeOptions.Add(5);
                    biomeOptions.Add(6);
                    biomeOptions.Add(7);
                    biomeOptions.Add(8);
                    biomeOptions.Add(9);
                    biomeOptions.Add(10);
                    biomeOptions.Add(11);
                    biomeOptions.Add(11);

                    int hnextTop = 1000;
                    int hnextBottom = 1000;
                    int hnextRight = 1000;
                    int hnextLeft = 1000;

                    int tempHeight = 0;
                    int avgBy = 0;
                    int averageHeight = 0;

                    int nextTop = 12;
                    int nextBottom = 12;
                    int nextRight = 12;
                    int nextLeft = 12;
                    if (i > 0)
                    {
                        nextLeft = tileArray[i - 1, k];
                        hnextLeft = heightArray[i - 1, k];
                    }
                    if (k > 0)
                    {
                        nextTop = tileArray[i, k - 1];
                        hnextTop = heightArray[i, k - 1];
                    }
                    if (i < 35)
                    {
                        nextRight = tileArray[i + 1, k];
                        hnextRight = heightArray[i + 1, k];
                    }
                    if (k < 35)
                    {
                        nextBottom = tileArray[i, k + 1];
                        hnextBottom = heightArray[i, k + 1];
                    }

                    if (nextTop != 12)
                    {
                        for (int n = 0; n < 256; n++)
                        {
                            biomeOptions.Add(nextTop);
                        }
                    }
                    if (nextBottom != 12)
                    {
                        for (int n = 0; n < 256; n++)
                        {
                            biomeOptions.Add(nextBottom);
                        }
                    }
                    if (nextRight != 12)
                    {
                        for (int n = 0; n < 128; n++)
                        {
                            biomeOptions.Add(nextRight);
                        }
                    }
                    if (nextLeft != 12)
                    {
                        for (int n = 0; n < 128; n++)
                        {
                            biomeOptions.Add(nextLeft);
                        }
                    }

                    if (hnextTop != 1000)
                    {
                        tempHeight += hnextTop;
                        avgBy++;
                    }
                    if (hnextBottom != 1000)
                    {
                        tempHeight += hnextBottom;
                        avgBy++;
                    }
                    if (hnextLeft != 1000)
                    {
                        tempHeight += hnextLeft;
                        avgBy++;
                    }
                    if (hnextRight != 1000)
                    {
                        tempHeight += hnextRight;
                        avgBy++;
                    }

                    if (avgBy != 0)
                    {
                        averageHeight = tempHeight / avgBy;
                    }

                    int randomizedTile = Random.Range(0, (biomeOptions.Count - 1));
                    int tileBiome = (int)biomeOptions[randomizedTile];

                    tileArray[i, k] = tileBiome;

                    int randomHeight = 0;
                    if (tileBiome == 0)
                    {
                        int min = averageHeight - 2;
                        if (min < -30)
                        {
                            min = -30;
                        }
                        int max = averageHeight + 5;
                        if (max > 5)
                        {
                            max = 5;
                        }
                        randomHeight = Random.Range(min, max);
                    }
                    if (tileBiome == 1)
                    {
                        int min = averageHeight - 2;
                        if (min < -50)
                        {
                            min = -50;
                        }
                        int max = averageHeight + 1;
                        if (max > 0)
                        {
                            max = 0;
                        }
                        randomHeight = Random.Range(min, max);
                    }
                    if (tileBiome == 2)
                    {
                        int min = averageHeight - 5;
                        if (min < 20)
                        {
                            min = 20;
                        }
                        int max = averageHeight + 10;
                        if (max > 70)
                        {
                            max = 70;
                        }
                        randomHeight = Random.Range(min, max);
                    }
                    if (tileBiome == 3)
                    {
                        int min = averageHeight - 4;
                        if (min < 10)
                        {
                            min = 10;
                        }
                        int max = averageHeight + 8;
                        if (max > 50)
                        {
                            max = 50;
                        }
                        randomHeight = Random.Range(min, max);
                    }
                    if (tileBiome == 4)
                    {
                        int min = averageHeight - 2;
                        if (min < -30)
                        {
                            min = -30;
                        }
                        int max = averageHeight + 4;
                        if (max > 10)
                        {
                            max = 10;
                        }
                        randomHeight = Random.Range(min, max);
                    }
                    if (tileBiome == 5)
                    {
                        int min = averageHeight - 5;
                        if (min < 20)
                        {
                            min = 20;
                        }
                        int max = averageHeight + 10;
                        if (max > 70)
                        {
                            max = 70;
                        }
                        randomHeight = Random.Range(min, max);
                    }
                    if (tileBiome == 6)
                    {
                        int min = averageHeight - 2;
                        if (min < -40)
                        {
                            min = 40;
                        }
                        int max = averageHeight + 1;
                        if (max > 0)
                        {
                            max = 0;
                        }
                        randomHeight = Random.Range(min, max);
                    }
                    if (tileBiome == 7)
                    {
                        int min = averageHeight - 2;
                        if (min < 20)
                        {
                            min = 20;
                        }
                        int max = averageHeight + 10;
                        if (max > 50)
                        {
                            max = 50;
                        }
                        randomHeight = Random.Range(min, max);
                    }
                    if (tileBiome == 8)
                    {
                        int min = averageHeight - 2;
                        if (min < -40)
                        {
                            min = -40;
                        }
                        int max = averageHeight + 3;
                        if (max > 0)
                        {
                            max = 0;
                        }
                        randomHeight = Random.Range(min, max);
                    }
                    if (tileBiome == 9)
                    {
                        int min = averageHeight - 3;
                        if (min < -40)
                        {
                            min = -40;
                        }
                        int max = averageHeight + 2;
                        if (max > 0)
                        {
                            max = 0;
                        }
                        randomHeight = Random.Range(min, max);
                    }
                    if (tileBiome == 10)
                    {
                        int min = averageHeight - 1;
                        if (min < -27)
                        {
                            min = -27;
                        }
                        int max = averageHeight + 1;
                        if (max > -22)
                        {
                            max = -22;
                        }
                        randomHeight = Random.Range(min, max);
                    }
                    if (tileBiome == 11)
                    {
                        int min = averageHeight - 3;
                        if (min < -30)
                        {
                            min = -30;
                        }
                        int max = averageHeight + 2;
                        if (max > 0)
                        {
                            max = 0;
                        }
                        randomHeight = Random.Range(min, max);
                    }
                    heightArray[i, k] = randomHeight;
                }
            }


            for (int i = 0; i < 36; i++)
            {
                for (int k = 0; k < 36; k++)
                {
                    if (tileArray[i, k] == 12)
                    {
                        ArrayList biomeOptions = new ArrayList();
                        biomeOptions.Add(0);
                        biomeOptions.Add(0);
                        biomeOptions.Add(1);
                        biomeOptions.Add(1);
                        biomeOptions.Add(2);
                        biomeOptions.Add(3);
                        biomeOptions.Add(4);
                        biomeOptions.Add(4);
                        biomeOptions.Add(5);
                        biomeOptions.Add(6);
                        biomeOptions.Add(7);
                        biomeOptions.Add(8);
                        biomeOptions.Add(9);
                        biomeOptions.Add(10);
                        biomeOptions.Add(11);
                        biomeOptions.Add(11);
                        int randomizedTile = Random.Range(0, (biomeOptions.Count - 1));
                        int tileBiome = (int)biomeOptions[randomizedTile];

                        tileArray[i, k] = tileBiome;
                    }
                    if (heightArray[i, k] == 1000)
                    {
                        int randomHeight = Random.Range(-5, 5);
                        heightArray[i, k] = randomHeight;
                    }
                }
            }


            for (int i = 0; i < 36; i++)
            {
                for (int k = 0; k < 36; k++)
                {

                    int nextTop = 12;
                    int nextBottom = 12;
                    int nextRight = 12;
                    int nextLeft = 12;
                    int nextTLC = 12;
                    int nextTRC = 12;
                    int nextBLC = 12;
                    int nextBRC = 12;

                    int grassCount = 0;
                    int sandCount = 0;
                    int rocksCount = 0;
                    int sHillsCount = 0;
                    int snowCount = 0;
                    int snowRocksCount = 0;
                    int badlandsCount = 0;
                    int mesaCount = 0;
                    int jungleCount = 0;
                    int savannaCount = 0;
                    int swampCount = 0;
                    int plainsCount = 0;
                    if (i > 0)
                    {
                        nextLeft = tileArray[i - 1, k];
                        if (k > 0)
                        {
                            nextTLC = tileArray[i - 1, k - 1];
                        }
                        if (k < 35)
                        {
                            nextBLC = tileArray[i - 1, k + 1];
                        }
                    }
                    if (k > 0)
                    {
                        nextTop = tileArray[i, k - 1];
                    }
                    if (i < 35)
                    {
                        nextRight = tileArray[i + 1, k];
                        if (k > 0)
                        {
                            nextTRC = tileArray[i + 1, k - 1];
                        }
                        if (k < 35)
                        {
                            nextBRC = tileArray[i + 1, k + 1];
                        }
                    }
                    if (k < 35)
                    {
                        nextBottom = tileArray[i, k + 1];
                    }


                    if (nextTop != 12)
                    {
                        if (nextTop == 0)
                        {
                            grassCount++;
                        }
                        if (nextTop == 1)
                        {
                            sandCount++;
                        }
                        if (nextTop == 2)
                        {
                            rocksCount++;
                        }
                        if (nextTop == 3)
                        {
                            sHillsCount++;
                        }
                        if (nextTop == 4)
                        {
                            snowCount++;
                        }
                        if (nextTop == 5)
                        {
                            snowRocksCount++;
                        }
                        if (nextTop == 6)
                        {
                            badlandsCount++;
                        }
                        if (nextTop == 7)
                        {
                            mesaCount++;
                        }
                        if (nextTop == 8)
                        {
                            jungleCount++;
                        }
                        if (nextTop == 9)
                        {
                            savannaCount++;
                        }
                        if (nextTop == 10)
                        {
                            swampCount++;
                        }
                        if (nextTop == 11)
                        {
                            plainsCount++;
                        }
                    }
                    if (nextBottom != 12)
                    {
                        if (nextBottom == 0)
                        {
                            grassCount++;
                        }
                        if (nextBottom == 1)
                        {
                            sandCount++;
                        }
                        if (nextBottom == 2)
                        {
                            rocksCount++;
                        }
                        if (nextBottom == 3)
                        {
                            sHillsCount++;
                        }
                        if (nextBottom == 4)
                        {
                            snowCount++;
                        }
                        if (nextBottom == 5)
                        {
                            snowRocksCount++;
                        }
                        if (nextBottom == 6)
                        {
                            badlandsCount++;
                        }
                        if (nextBottom == 7)
                        {
                            mesaCount++;
                        }
                        if (nextBottom == 8)
                        {
                            jungleCount++;
                        }
                        if (nextBottom == 9)
                        {
                            savannaCount++;
                        }
                        if (nextBottom == 10)
                        {
                            swampCount++;
                        }
                        if (nextBottom == 11)
                        {
                            plainsCount++;
                        }
                    }
                    if (nextRight != 12)
                    {
                        if (nextRight == 0)
                        {
                            grassCount++;
                        }
                        if (nextRight == 1)
                        {
                            sandCount++;
                        }
                        if (nextRight == 2)
                        {
                            rocksCount++;
                        }
                        if (nextRight == 3)
                        {
                            sHillsCount++;
                        }
                        if (nextRight == 4)
                        {
                            snowCount++;
                        }
                        if (nextRight == 5)
                        {
                            snowRocksCount++;
                        }
                        if (nextRight == 6)
                        {
                            badlandsCount++;
                        }
                        if (nextRight == 7)
                        {
                            mesaCount++;
                        }
                        if (nextRight == 8)
                        {
                            jungleCount++;
                        }
                        if (nextRight == 9)
                        {
                            savannaCount++;
                        }
                        if (nextRight == 10)
                        {
                            swampCount++;
                        }
                        if (nextRight == 11)
                        {
                            plainsCount++;
                        }
                    }
                    if (nextLeft != 12)
                    {
                        if (nextLeft == 0)
                        {
                            grassCount++;
                        }
                        if (nextLeft == 1)
                        {
                            sandCount++;
                        }
                        if (nextLeft == 2)
                        {
                            rocksCount++;
                        }
                        if (nextLeft == 3)
                        {
                            sHillsCount++;
                        }
                        if (nextLeft == 4)
                        {
                            snowCount++;
                        }
                        if (nextLeft == 5)
                        {
                            snowRocksCount++;
                        }
                        if (nextLeft == 6)
                        {
                            badlandsCount++;
                        }
                        if (nextLeft == 7)
                        {
                            mesaCount++;
                        }
                        if (nextLeft == 8)
                        {
                            jungleCount++;
                        }
                        if (nextLeft == 9)
                        {
                            savannaCount++;
                        }
                        if (nextLeft == 10)
                        {
                            swampCount++;
                        }
                        if (nextLeft == 11)
                        {
                            plainsCount++;
                        }
                    }

                    if (nextTLC != 12)
                    {
                        if (nextTLC == 0)
                        {
                            grassCount++;
                        }
                        if (nextTLC == 1)
                        {
                            sandCount++;
                        }
                        if (nextTLC == 2)
                        {
                            rocksCount++;
                        }
                        if (nextTLC == 3)
                        {
                            sHillsCount++;
                        }
                        if (nextTLC == 4)
                        {
                            snowCount++;
                        }
                        if (nextTLC == 5)
                        {
                            snowRocksCount++;
                        }
                        if (nextTLC == 6)
                        {
                            badlandsCount++;
                        }
                        if (nextTLC == 7)
                        {
                            mesaCount++;
                        }
                        if (nextTLC == 8)
                        {
                            jungleCount++;
                        }
                        if (nextTLC == 9)
                        {
                            savannaCount++;
                        }
                        if (nextTLC == 10)
                        {
                            swampCount++;
                        }
                        if (nextTLC == 11)
                        {
                            plainsCount++;
                        }
                    }
                    if (nextBLC != 12)
                    {
                        if (nextBLC == 0)
                        {
                            grassCount++;
                        }
                        if (nextBLC == 1)
                        {
                            sandCount++;
                        }
                        if (nextBLC == 2)
                        {
                            rocksCount++;
                        }
                        if (nextBLC == 3)
                        {
                            sHillsCount++;
                        }
                        if (nextBLC == 4)
                        {
                            snowCount++;
                        }
                        if (nextBLC == 5)
                        {
                            snowRocksCount++;
                        }
                        if (nextBLC == 6)
                        {
                            badlandsCount++;
                        }
                        if (nextBLC == 7)
                        {
                            mesaCount++;
                        }
                        if (nextBLC == 8)
                        {
                            jungleCount++;
                        }
                        if (nextBLC == 9)
                        {
                            savannaCount++;
                        }
                        if (nextBLC == 10)
                        {
                            swampCount++;
                        }
                        if (nextBLC == 11)
                        {
                            plainsCount++;
                        }
                    }
                    if (nextTRC != 12)
                    {
                        if (nextTRC == 0)
                        {
                            grassCount++;
                        }
                        if (nextTRC == 1)
                        {
                            sandCount++;
                        }
                        if (nextTRC == 2)
                        {
                            rocksCount++;
                        }
                        if (nextTRC == 3)
                        {
                            sHillsCount++;
                        }
                        if (nextTRC == 4)
                        {
                            snowCount++;
                        }
                        if (nextTRC == 5)
                        {
                            snowRocksCount++;
                        }
                        if (nextTRC == 6)
                        {
                            badlandsCount++;
                        }
                        if (nextTRC == 7)
                        {
                            mesaCount++;
                        }
                        if (nextTRC == 8)
                        {
                            jungleCount++;
                        }
                        if (nextTRC == 9)
                        {
                            savannaCount++;
                        }
                        if (nextTRC == 10)
                        {
                            swampCount++;
                        }
                        if (nextTRC == 11)
                        {
                            plainsCount++;
                        }
                    }
                    if (nextBRC != 12)
                    {
                        if (nextBRC == 0)
                        {
                            grassCount++;
                        }
                        if (nextBRC == 1)
                        {
                            sandCount++;
                        }
                        if (nextBRC == 2)
                        {
                            rocksCount++;
                        }
                        if (nextBRC == 3)
                        {
                            sHillsCount++;
                        }
                        if (nextBRC == 4)
                        {
                            snowCount++;
                        }
                        if (nextBRC == 5)
                        {
                            snowRocksCount++;
                        }
                        if (nextBRC == 6)
                        {
                            badlandsCount++;
                        }
                        if (nextBRC == 7)
                        {
                            mesaCount++;
                        }
                        if (nextBRC == 8)
                        {
                            jungleCount++;
                        }
                        if (nextBRC == 9)
                        {
                            savannaCount++;
                        }
                        if (nextBRC == 10)
                        {
                            swampCount++;
                        }
                        if (nextBRC == 11)
                        {
                            plainsCount++;
                        }
                    }



                    if (badlandsCount > 3)
                    {
                        tileArray[i, k] = 6;
                    }
                    if (mesaCount > 2)
                    {
                        tileArray[i, k] = 7;
                    }
                    if (rocksCount > 3)
                    {
                        tileArray[i, k] = 2;
                    }
                    if (sHillsCount > 3)
                    {
                        tileArray[i, k] = 3;
                    }
                    if (snowRocksCount > 3)
                    {
                        tileArray[i, k] = 5;
                    }
                    if (jungleCount > 3)
                    {
                        tileArray[i, k] = 8;
                    }
                    if (savannaCount > 3)
                    {
                        tileArray[i, k] = 9;
                    }
                    if (swampCount > 3)
                    {
                        tileArray[i, k] = 10;
                    }
                    if (sandCount > 3)
                    {
                        tileArray[i, k] = 1;
                    }
                    if (snowCount > 3)
                    {
                        tileArray[i, k] = 4;
                    }
                    if (plainsCount > 3)
                    {
                        tileArray[i, k] = 11;
                    }
                    if (grassCount > 3)
                    {
                        tileArray[i, k] = 0;
                    }

                    /*
                    if (grassCount == 0 && tileArray[i, k] == 0)
                    {
                        tileArray[i, k] = 8;
                    }
                    if (sandCount == 0 && tileArray[i, k] == 1)
                    {
                        tileArray[i, k] = 6;
                    }
                    if (rocksCount == 0 && tileArray[i, k] == 2)
                    {
                        tileArray[i, k] = 5;
                    }
                    if (sHillsCount == 0 && tileArray[i, k] == 3)
                    {
                        tileArray[i, k] = 1;
                    }
                    if (snowCount == 0 && tileArray[i, k] == 4)
                    {
                        tileArray[i, k] = 0;
                    }
                    if (snowRocksCount == 0 && tileArray[i, k] == 5)
                    {
                        tileArray[i, k] = 2;
                    }
                    if (badlandsCount == 0 && tileArray[i, k] == 6)
                    {
                        tileArray[i, k] = 1;
                    }
                    if (mesaCount == 0 && tileArray[i, k] == 7)
                    {
                        tileArray[i, k] = 3;
                    }
                    if (jungleCount == 0 && tileArray[i, k] == 8)
                    {
                        tileArray[i, k] = 9;
                    }
                    if (savannaCount == 0 && tileArray[i, k] == 9)
                    {
                        tileArray[i, k] = 0;
                    }
                    if (riverBedCount == 0 && tileArray[i, k] == 10)
                    {
                        tileArray[i, k] = 0;
                    }
                    */
                }
            }
            for (int k = 0; k < 35; k++)
            {
                for (int i = 0; i < 35; i++)
                {
                    int tileBiome = tileArray[i, k];
                    int height = heightArray[i, k];
                    if (tileBiome == 0)
                    {
                        byte[] flatTreeArray = new byte[36];
                        byte[] xRandom = new byte[36];
                        byte[] yRandom = new byte[36];

                        byte[] flatPlantArray = new byte[64];
                        byte[] xRandomPlant = new byte[64];
                        byte[] yRandomPlant = new byte[64];
                        if (height > 5)
                        {
                            height = 5;
                        }
                        if (height < -30)
                        {
                            height = -30;
                        }
                        for (int j = 0; j < 36; j ++)
                        {
                            int tempRand = Random.Range(0, 2);
                            if (tempRand == 0)
                            {
                                byte xRand = (byte)Random.Range(0, 4);
                                byte yRand = (byte)Random.Range(0, 4);
                                int treeNum = Random.Range(0, 19);
                                byte treeGen = 0;
                                if (treeNum == 0 || treeNum == 1 || treeNum == 2)
                                {
                                    treeGen = 1;
                                }
                                if (treeNum == 3 || treeNum == 4 || treeNum == 5)
                                {
                                    treeGen = 2;
                                }
                                if (treeNum == 6)
                                {
                                    treeGen = 3;
                                }
                                if (treeNum >= 7)
                                {
                                    treeGen = 0;
                                }
                                flatTreeArray[j] = treeGen;
                                xRandom[j] = xRand;
                                yRandom[j] = yRand;
                            }
                            else
                            {
                                flatTreeArray[j] = 100;
                                xRandom[j] = 100;
                                yRandom[j] = 100;
                            }
                        }
                        for (int j = 0; j < 64; j++)
                        {
                            int tempRand = Random.Range(0, 2);
                            if (tempRand == 0)
                            {
                                byte xRand = (byte)Random.Range(0, 5);
                                byte yRand = (byte)Random.Range(0, 5);
                                int plantNum = Random.Range(0, 43);
                                byte plantGen = 0;
                                if (plantNum < 15)
                                {
                                    plantGen = 0;
                                }
                                if (plantNum < 30 && plantNum >= 15)
                                {
                                    plantGen = 1;
                                }
                                if (plantNum == 30 || plantNum == 31 || plantNum == 32 || plantNum == 33)
                                {
                                    plantGen = 2;
                                }
                                if (plantNum == 34 || plantNum == 35)
                                {
                                    plantGen = 3;
                                }
                                if (plantNum == 36 || plantNum == 37)
                                {
                                    plantGen = 4;
                                }
                                if (plantNum == 38 || plantNum == 39)
                                {
                                    plantGen = 5;
                                }
                                if (plantNum == 40)
                                {
                                    plantGen = 6;
                                }
                                if (plantNum == 41)
                                {
                                    plantGen = 7;
                                }
                                if (plantNum == 42)
                                {
                                    plantGen = 8;
                                }
                                flatPlantArray[j] = plantGen;
                                xRandomPlant[j] = xRand;
                                yRandomPlant[j] = yRand;
                            }
                            else
                            {
                                flatPlantArray[j] = 100;
                                xRandomPlant[j] = 100;
                                yRandomPlant[j] = 100;
                            }
                        }
                        this.GetComponent<PhotonView>().RPC("GenerateForestTile", PhotonTargets.AllBuffered, i, k, height, (object)flatTreeArray, (object)flatPlantArray, 
                            (object)xRandom, (object)yRandom, (object)xRandomPlant, (object)yRandomPlant);
                    }
                    
                    if (tileBiome == 1)
                    {
                        byte[] flatTreeArray = new byte[9];
                        int[] xRandom = new int[9];
                        int[] yRandom = new int[9];
                        if (height > 0)
                        {
                            height = 0;
                        }
                        if (height < -30)
                        {
                            height = -30;
                        }
                        for (int j = 0; j < 9; j++)
                        {
                            int tempRand = Random.Range(0, 5);
                            if (tempRand == 0)
                            {
                                int xRand = Random.Range(-4, 5);
                                int yRand = Random.Range(-4, 5);
                                int treeNum = Random.Range(0, 5);
                                byte treeGen = 0;
                                if (treeNum == 0)
                                {
                                    treeGen = 0;
                                }
                                if (treeNum == 1)
                                {
                                    treeGen = 1;
                                }
                                if (treeNum == 2)
                                {
                                    treeGen = 3;
                                }
                                if (treeNum >= 3)
                                {
                                    treeGen = 2;
                                }
                                flatTreeArray[j] = treeGen;
                                xRandom[j] = xRand;
                                yRandom[j] = yRand;
                            }
                            else
                            {
                                flatTreeArray[j] = 100;
                                xRandom[j] = 100;
                                yRandom[j] = 100;
                            }
                        }
                        this.GetComponent<PhotonView>().RPC("GenerateDesertTile", PhotonTargets.AllBuffered, i, k, height, (object)flatTreeArray, (object)xRandom, (object)yRandom);
                    }
                    if (tileBiome == 2)
                    {
                        byte[] flatTreeArray = new byte[36];
                        byte[] xRandom = new byte[36];
                        byte[] yRandom = new byte[36];
                        if (height > 70)
                        {
                            height = 70;
                        }
                        if (height < 20)
                        {
                            height = 20;
                        }
                        for (int j = 0; j < 36; j++)
                        {
                            int tempRand = Random.Range(0, 4);
                            if (tempRand == 0)
                            {
                                byte xRand =(byte) Random.Range(0, 4);
                                byte yRand = (byte)Random.Range(0, 4);
                                int treeNum = Random.Range(0, 8);
                                byte treeGen = 0;
                                if (treeNum == 0)
                                {
                                    treeGen = 0;
                                }
                                if (treeNum == 1)
                                {
                                    treeGen = 1;
                                }
                                if (treeNum == 2)
                                {
                                    treeGen = 2;
                                }
                                if (treeNum == 3)
                                {
                                    treeGen = 3;
                                }
                                if (treeNum == 4)
                                {
                                    treeGen = 4;
                                }
                                if (treeNum == 5)
                                {
                                    treeGen = 5;
                                }
                                if (treeNum == 6)
                                {
                                    treeGen = 6;
                                }
                                if (treeNum == 7)
                                {
                                    treeGen = 7;
                                }
                                flatTreeArray[j] = treeGen;
                                xRandom[j] = xRand;
                                yRandom[j] = yRand;
                            }
                            else
                            {
                                flatTreeArray[j] = 100;
                                xRandom[j] = 100;
                                yRandom[j] = 100;
                            }
                        }
                        this.GetComponent<PhotonView>().RPC("GenerateMountainTile", PhotonTargets.AllBuffered, i, k, height, (object)flatTreeArray, (object)xRandom, (object)yRandom);
                    }
                    if (tileBiome == 3)
                    {
                        byte[] flatTreeArray = new byte[36];
                        byte[] xRandom = new byte[36];
                        byte[] yRandom = new byte[36];
                        if (height > 60)
                        {
                            height = 60;
                        }
                        if (height < 10)
                        {
                            height = 10;
                        }
                        for (int j = 0; j < 36; j++)
                        {
                            int tempRand = Random.Range(0, 4);
                            if (tempRand == 0)
                            {
                                byte xRand = (byte)Random.Range(0, 4);
                                byte yRand = (byte)Random.Range(0, 4);
                                int treeNum = Random.Range(0, 6);
                                byte treeGen = 0;
                                if (treeNum == 0)
                                {
                                    treeGen = 0;
                                }
                                if (treeNum == 1)
                                {
                                    treeGen = 1;
                                }
                                if (treeNum == 2)
                                {
                                    treeGen = 2;
                                }
                                if (treeNum == 3)
                                {
                                    treeGen = 3;
                                }
                                if (treeNum == 4)
                                {
                                    treeGen = 4;
                                }
                                if (treeNum == 5)
                                {
                                    treeGen = 5;
                                }
                                flatTreeArray[j] = treeGen;
                                xRandom[j] = xRand;
                                yRandom[j] = yRand;
                            }
                            else
                            {
                                flatTreeArray[j] = 100;
                                xRandom[j] = 100;
                                yRandom[j] = 100;
                            }
                        }
                        this.GetComponent<PhotonView>().RPC("GenerateDesertHillsTile", PhotonTargets.AllBuffered, i, k, height, (object)flatTreeArray, (object)xRandom, (object)yRandom);
                    }
                    if (tileBiome == 4)
                    {
                        byte[] flatTreeArray = new byte[36];
                        byte[] xRandom = new byte[36];
                        byte[] yRandom = new byte[36];

                        byte[] flatPlantArray = new byte[64];
                        byte[] xRandomPlant = new byte[64];
                        byte[] yRandomPlant = new byte[64];
                        if (height > 10)
                        {
                            height = 10;
                        }
                        if (height < -30)
                        {
                            height = -30;
                        }
                        for (int j = 0; j < 36; j++)
                        {
                            int tempRand = Random.Range(0, 2);
                            if (tempRand == 0)
                            {
                                byte xRand = (byte)Random.Range(0, 4);
                                byte yRand = (byte)Random.Range(0, 4);
                                int treeNum = Random.Range(0, 11);
                                byte treeGen = 0;
                                if (treeNum == 0 || treeNum == 1)
                                {
                                    treeGen = 0;
                                }
                                if (treeNum == 2 || treeNum == 3)
                                {
                                    treeGen = 1;
                                }
                                if (treeNum == 4 || treeNum == 5)
                                {
                                    treeGen = 2;
                                }
                                if (treeNum == 6 || treeNum == 7)
                                {
                                    treeGen = 3;
                                }
                                if (treeNum == 8 || treeNum == 9)
                                {
                                    treeGen = 4;
                                }
                                if (treeNum == 10)
                                {
                                    treeGen = 5;
                                }
                                flatTreeArray[j] = treeGen;
                                xRandom[j] = xRand;
                                yRandom[j] = yRand;
                            }
                            else
                            {
                                flatTreeArray[j] = 100;
                                xRandom[j] = 100;
                                yRandom[j] = 100;
                            }
                        }
                        for (int j = 0; j < 64; j++)
                        {
                            int tempRand = Random.Range(0, 2);
                            if (tempRand == 0)
                            {
                                byte xRand = (byte)Random.Range(0, 5);
                                byte yRand = (byte)Random.Range(0, 5);
                                int plantNum = Random.Range(0, 10);
                                byte plantGen = 0;
                                if (plantNum == 0)
                                {
                                    plantGen = 0;
                                }
                                if (plantNum == 1)
                                {
                                    plantGen = 1;
                                }
                                if (plantNum == 2)
                                {
                                    plantGen = 2;
                                }
                                if (plantNum == 3)
                                {
                                    plantGen = 3;
                                }
                                if (plantNum == 4 || plantNum == 5)
                                {
                                    plantGen = 4;
                                }
                                if (plantNum == 6 || plantNum == 7)
                                {
                                    plantGen = 5;
                                }
                                if (plantNum == 8)
                                {
                                    plantGen = 6;
                                }
                                if (plantNum == 9)
                                {
                                    plantGen = 7;
                                }
                                flatPlantArray[j] = plantGen;
                                xRandomPlant[j] = xRand;
                                yRandomPlant[j] = yRand;
                            }
                            else
                            {
                                flatPlantArray[j] = 100;
                                xRandomPlant[j] = 100;
                                yRandomPlant[j] = 100;
                            }
                        }
                        this.GetComponent<PhotonView>().RPC("GenerateTundraTile", PhotonTargets.AllBuffered, i, k, height, (object)flatTreeArray, (object)flatPlantArray,
                            (object)xRandom, (object)yRandom, (object)xRandomPlant, (object)yRandomPlant);
                    }
                    if (tileBiome == 5)
                    {
                        byte[] flatTreeArray = new byte[36];
                        byte[] xRandom = new byte[36];
                        byte[] yRandom = new byte[36];
                        if (height > 70)
                        {
                            height = 70;
                        }
                        if (height < 20)
                        {
                            height = 20;
                        }
                        for (int j = 0; j < 36; j++)
                        {
                            int tempRand = Random.Range(0, 4);
                            if (tempRand == 0)
                            {
                                byte xRand = (byte)Random.Range(0, 4);
                                byte yRand = (byte)Random.Range(0, 4);
                                int treeNum = Random.Range(0, 13);
                                byte treeGen = 0;
                                if (treeNum == 0)
                                {
                                    treeGen = 0;
                                }
                                if (treeNum == 1)
                                {
                                    treeGen = 1;
                                }
                                if (treeNum == 2)
                                {
                                    treeGen = 2;
                                }
                                if (treeNum == 3)
                                {
                                    treeGen = 3;
                                }
                                if (treeNum == 4)
                                {
                                    treeGen = 4;
                                }
                                if (treeNum == 5)
                                {
                                    treeGen = 5;
                                }
                                if (treeNum == 6)
                                {
                                    treeGen = 6;
                                }
                                if (treeNum == 7)
                                {
                                    treeGen = 7;
                                }
                                if (treeNum == 8)
                                {
                                    treeGen = 8;
                                }
                                if (treeNum == 9)
                                {
                                    treeGen = 9;
                                }
                                if (treeNum == 10)
                                {
                                    treeGen = 10;
                                }
                                if (treeNum == 11)
                                {
                                    treeGen = 11;
                                }
                                if (treeNum == 12)
                                {
                                    treeGen = 12;
                                }
                                flatTreeArray[j] = treeGen;
                                xRandom[j] = xRand;
                                yRandom[j] = yRand;
                            }
                            else
                            {
                                flatTreeArray[j] = 100;
                                xRandom[j] = 100;
                                yRandom[j] = 100;
                            }
                        }
                        this.GetComponent<PhotonView>().RPC("GenerateSnowyMountainTile", PhotonTargets.AllBuffered, i, k, height, (object)flatTreeArray, (object)xRandom, (object)yRandom);
                    }
                    if (tileBiome == 6)
                    {
                        byte[] flatTreeArray = new byte[36];
                        byte[] xRandom = new byte[36];
                        byte[] yRandom = new byte[36];
                        if (height > 0)
                        {
                            height = 0;
                        }
                        if (height < -30)
                        {
                            height = -30;
                        }
                        for (int j = 0; j < 36; j++)
                        {
                            int tempRand = Random.Range(0, 4);
                            if (tempRand == 0)
                            {
                                byte xRand = (byte)Random.Range(0, 4);
                                byte yRand = (byte)Random.Range(0, 4);
                                int treeNum = Random.Range(0, 11);
                                byte treeGen = 0;
                                if (treeNum == 0)
                                {
                                    treeGen = 0;
                                }
                                if (treeNum == 1)
                                {
                                    treeGen = 1;
                                }
                                if (treeNum == 2)
                                {
                                    treeGen = 2;
                                }
                                if (treeNum == 3)
                                {
                                    treeGen = 3;
                                }
                                if (treeNum == 4)
                                {
                                    treeGen = 4;
                                }
                                if (treeNum == 5)
                                {
                                    treeGen = 5;
                                }
                                if (treeNum == 6)
                                {
                                    treeGen = 6;
                                }
                                if (treeNum >= 7)
                                {
                                    treeGen = 7;
                                }
                                flatTreeArray[j] = treeGen;
                                xRandom[j] = xRand;
                                yRandom[j] = yRand;
                            }
                            else
                            {
                                flatTreeArray[j] = 100;
                                xRandom[j] = 100;
                                yRandom[j] = 100;
                            }
                        }
                        this.GetComponent<PhotonView>().RPC("GenerateBadlandsTile", PhotonTargets.AllBuffered, i, k, height, (object)flatTreeArray, (object)xRandom, (object)yRandom);
                    }
                    if (tileBiome == 7)
                    {
                        byte[] flatTreeArray = new byte[36];
                        byte[] xRandom = new byte[36];
                        byte[] yRandom = new byte[36];
                        if (height > 50)
                        {
                            height = 50;
                        }
                        if (height < 20)
                        {
                            height = 20;
                        }
                        for (int j = 0; j < 36; j++)
                        {
                            int tempRand = Random.Range(0, 4);
                            if (tempRand == 0)
                            {
                                byte xRand = (byte)Random.Range(0, 4);
                                byte yRand = (byte)Random.Range(0, 4);
                                int treeNum = Random.Range(0, 7);
                                byte treeGen = 0;
                                if (treeNum == 0)
                                {
                                    treeGen = 0;
                                }
                                if (treeNum == 1)
                                {
                                    treeGen = 1;
                                }
                                if (treeNum == 2)
                                {
                                    treeGen = 2;
                                }
                                if (treeNum == 3)
                                {
                                    treeGen = 3;
                                }
                                if (treeNum == 4)
                                {
                                    treeGen = 4;
                                }
                                if (treeNum == 5)
                                {
                                    treeGen = 5;
                                }
                                if (treeNum == 6)
                                {
                                    treeGen = 6;
                                }
                                flatTreeArray[j] = treeGen;
                                xRandom[j] = xRand;
                                yRandom[j] = yRand;
                            }
                            else
                            {
                                flatTreeArray[j] = 100;
                                xRandom[j] = 100;
                                yRandom[j] = 100;
                            }
                        }
                        this.GetComponent<PhotonView>().RPC("GenerateMesaTile", PhotonTargets.AllBuffered, i, k, height, (object)flatTreeArray, (object)xRandom, (object)yRandom);
                    }
                    if (tileBiome == 8)
                    {
                        byte[] flatTreeArray = new byte[144];
                        byte[] xRandom = new byte[144];
                        byte[] yRandom = new byte[144];

                        byte[] flatPlantArray = new byte[64];
                        byte[] xRandomPlant = new byte[64];
                        byte[] yRandomPlant = new byte[64];
                        if (height > 5)
                        {
                            height = 5;
                        }
                        if (height < -30)
                        {
                            height = -30;
                        }
                        for (int j = 0; j < 144; j++)
                        {
                            int tempRand = Random.Range(0, 2);
                            if (tempRand == 0)
                            {
                                byte xRand = (byte)Random.Range(0, 4);
                                byte yRand = (byte)Random.Range(0, 4);
                                int treeNum = Random.Range(0, 7);
                                byte treeGen = 0;
                                if (treeNum == 0)
                                {
                                    treeGen = 0;
                                }
                                if (treeNum == 1)
                                {
                                    treeGen = 1;
                                }
                                if (treeNum == 2)
                                {
                                    treeGen = 2;
                                }
                                if (treeNum == 3)
                                {
                                    treeGen = 3;
                                }
                                if (treeNum == 4)
                                {
                                    treeGen = 4;
                                }
                                if (treeNum == 5)
                                {
                                    treeGen = 5;
                                }
                                if (treeNum == 6)
                                {
                                    treeGen = 6;
                                }
                                flatTreeArray[j] = treeGen;
                                xRandom[j] = xRand;
                                yRandom[j] = yRand;
                            }
                            else
                            {
                                flatTreeArray[j] = 100;
                                xRandom[j] = 100;
                                yRandom[j] = 100;
                            }
                        }
                        for (int j = 0; j < 64; j++)
                        {
                            int tempRand = Random.Range(0, 3);
                            if (tempRand == 0)
                            {
                                byte xRand = (byte)Random.Range(0, 3);
                                byte yRand = (byte)Random.Range(0, 3);
                                int plantNum = Random.Range(0, 9);
                                byte plantGen = 0;
                                if (plantNum == 0 || plantNum == 1)
                                {
                                    plantGen = 0;
                                }
                                if (plantNum == 2 || plantNum == 3)
                                {
                                    plantGen = 1;
                                }
                                if (plantNum == 4)
                                {
                                    plantGen = 2;
                                }
                                if (plantNum == 5)
                                {
                                    plantGen = 3;
                                }
                                if (plantNum == 6)
                                {
                                    plantGen = 4;
                                }
                                if (plantNum == 7)
                                {
                                    plantGen = 5;
                                }
                                if (plantNum == 8)
                                {
                                    plantGen = 6;
                                }
                                flatPlantArray[j] = plantGen;
                                xRandomPlant[j] = xRand;
                                yRandomPlant[j] = yRand;
                            }
                            else
                            {
                                flatPlantArray[j] = 100;
                                xRandomPlant[j] = 100;
                                yRandomPlant[j] = 100;
                            }
                        }
                        this.GetComponent<PhotonView>().RPC("GenerateJungleTile", PhotonTargets.AllBuffered, i, k, height, (object)flatTreeArray, (object)flatPlantArray,
                            (object)xRandom, (object)yRandom, (object)xRandomPlant, (object)yRandomPlant);
                    }
                    if (tileBiome == 9)
                    {
                        byte[] flatTreeArray = new byte[9];
                        byte[] xRandom = new byte[9];
                        byte[] yRandom = new byte[9];

                        byte[] flatPlantArray = new byte[64];
                        byte[] xRandomPlant = new byte[64];
                        byte[] yRandomPlant = new byte[64];
                        if (height > 0)
                        {
                            height = 0;
                        }
                        if (height < -30)
                        {
                            height = -30;
                        }
                        for (int j = 0; j < 9; j++)
                        {
                            int tempRand = Random.Range(0, 4);
                            if (tempRand == 0)
                            {
                                byte xRand = (byte)Random.Range(0, 4);
                                byte yRand = (byte)Random.Range(0, 4);
                                int treeNum = Random.Range(0, 9);
                                byte treeGen = 0;
                                if (treeNum == 0)
                                {
                                    treeGen = 0;
                                }
                                if (treeNum == 1)
                                {
                                    treeGen = 1;
                                }
                                if (treeNum == 2)
                                {
                                    treeGen = 2;
                                }
                                if (treeNum == 3)
                                {
                                    treeGen = 3;
                                }
                                if (treeNum == 4)
                                {
                                    treeGen = 5;
                                }
                                if (treeNum == 5)
                                {
                                    treeGen = 6;
                                }
                                if (treeNum >= 6)
                                {
                                    treeGen = 4;
                                }
                                flatTreeArray[j] = treeGen;
                                xRandom[j] = xRand;
                                yRandom[j] = yRand;
                            }
                            else
                            {
                                flatTreeArray[j] = 100;
                                xRandom[j] = 100;
                                yRandom[j] = 100;
                            }
                        }
                        for (int j = 0; j < 64; j++)
                        {
                            int tempRand = Random.Range(0, 3);
                            if (tempRand == 0)
                            {
                                byte xRand = (byte)Random.Range(0, 4);
                                byte yRand = (byte)Random.Range(0, 4);
                                int plantNum = Random.Range(0, 13);
                                byte plantGen = 0;
                                if (plantNum == 0 || plantNum == 1 || plantNum == 2 || plantNum == 3)
                                {
                                    plantGen = 0;
                                }
                                if (plantNum == 4 || plantNum == 5 || plantNum == 6 || plantNum == 7)
                                {
                                    plantGen = 1;
                                }
                                if (plantNum == 8 || plantNum == 9 || plantNum == 10 || plantNum == 11)
                                {
                                    plantGen = 2;
                                }
                                if (plantNum == 12)
                                {
                                    plantGen = 3;
                                }
                                flatPlantArray[j] = plantGen;
                                xRandomPlant[j] = xRand;
                                yRandomPlant[j] = yRand;
                            }
                            else
                            {
                                flatPlantArray[j] = 100;
                                xRandomPlant[j] = 100;
                                yRandomPlant[j] = 100;
                            }
                        }
                        this.GetComponent<PhotonView>().RPC("GenerateSavannaTile", PhotonTargets.AllBuffered, i, k, height, (object)flatTreeArray, (object)flatPlantArray,
                            (object)xRandom, (object)yRandom, (object)xRandomPlant, (object)yRandomPlant);
                    }
                    if (tileBiome == 10)
                    {
                        byte[] flatTreeArray = new byte[16];
                        byte[] xRandom = new byte[16];
                        byte[] yRandom = new byte[16];

                        byte[] flatPlantArray = new byte[64];
                        byte[] xRandomPlant = new byte[64];
                        byte[] yRandomPlant = new byte[64];
                        if (height > -22)
                        {
                            height = Random.Range(-26, -22);
                        }
                        if (height < -27)
                        {
                            height = -27;
                        }
                        for (int j = 0; j < 16; j++)
                        {
                            int tempRand = Random.Range(0, 2);
                            if (tempRand == 0)
                            {
                                byte xRand = (byte)Random.Range(0, 4);
                                byte yRand = (byte)Random.Range(0, 4);
                                int treeNum = Random.Range(0, 4);
                                byte treeGen = 0;
                                if (treeNum == 0)
                                {
                                    treeGen = 0;
                                }
                                if (treeNum == 1)
                                {
                                    treeGen = 1;
                                }
                                if (treeNum == 2)
                                {
                                    treeGen = 2;
                                }
                                if (treeNum == 3)
                                {
                                    treeGen = 3;
                                }
                                flatTreeArray[j] = treeGen;
                                xRandom[j] = xRand;
                                yRandom[j] = yRand;
                            }
                            else
                            {
                                flatTreeArray[j] = 100;
                                xRandom[j] = 100;
                                yRandom[j] = 100;
                            }
                        }
                        for (int j = 0; j < 64; j++)
                        {
                            int tempRand = Random.Range(0, 3);
                            if (tempRand == 0)
                            {
                                byte xRand = (byte)Random.Range(0, 4);
                                byte yRand = (byte)Random.Range(0, 4);
                                int plantNum = Random.Range(0, 25);
                                byte plantGen = 0;
                                if (plantNum < 4)
                                {
                                    plantGen = 0;
                                }
                                if (plantNum < 8 && plantNum >= 4)
                                {
                                    plantGen = 1;
                                }
                                if (plantNum < 12 && plantNum >= 8)
                                {
                                    plantGen = 2;
                                }
                                if (plantNum == 12 || plantNum == 13)
                                {
                                    plantGen = 3;
                                }
                                if (plantNum == 14 || plantNum == 15)
                                {
                                    plantGen = 4;
                                }
                                if (plantNum == 16 || plantNum == 17)
                                {
                                    plantGen = 5;
                                }
                                if (plantNum == 18 || plantNum == 19)
                                {
                                    plantGen = 6;
                                }
                                if (plantNum == 20 || plantNum == 21)
                                {
                                    plantGen = 7;
                                }
                                if (plantNum == 22)
                                {
                                    plantGen = 8;
                                }
                                if (plantNum == 23)
                                {
                                    plantGen = 9;
                                }
                                if (plantNum == 24)
                                {
                                    plantGen = 10;
                                }
                                flatPlantArray[j] = plantGen;
                                xRandomPlant[j] = xRand;
                                yRandomPlant[j] = yRand;
                            }
                            else
                            {
                                flatPlantArray[j] = 100;
                                xRandomPlant[j] = 100;
                                yRandomPlant[j] = 100;
                            }
                        }
                        this.GetComponent<PhotonView>().RPC("GenerateSwampTile", PhotonTargets.AllBuffered, i, k, height, (object)flatTreeArray, (object)flatPlantArray,
                            (object)xRandom, (object)yRandom, (object)xRandomPlant, (object)yRandomPlant);
                    }
                    if (tileBiome == 11)
                    {
                        byte[] flatTreeArray = new byte[4];
                        int[] xRandom = new int[4];
                        int[] yRandom = new int[4];

                        byte[] flatPlantArray = new byte[64];
                        byte[] xRandomPlant = new byte[64];
                        byte[] yRandomPlant = new byte[64];
                        if (height > 0)
                        {
                            height = 0;
                        }
                        if (height < -30)
                        {
                            height = -30;
                        }
                        for (int j = 0; j < 4; j++)
                        {
                            int tempRand = Random.Range(0, 7);
                            if (tempRand == 0)
                            {
                                int xRand = Random.Range(-7, 8);
                                int yRand = Random.Range(-7, 8);
                                int treeNum = Random.Range(0, 10);
                                byte treeGen = 0;
                                if (treeNum == 0)
                                {
                                    treeGen = 1;
                                }
                                if (treeNum == 1)
                                {
                                    treeGen = 2;
                                }
                                if (treeNum >= 2)
                                {
                                    treeGen = 0;
                                }
                                flatTreeArray[j] = treeGen;
                                xRandom[j] = xRand;
                                yRandom[j] = yRand;
                            }
                            else
                            {
                                flatTreeArray[j] = 100;
                                xRandom[j] = 100;
                                yRandom[j] = 100;
                            }
                        }
                        for (int j = 0; j < 64; j++)
                        {
                            int tempRand = Random.Range(0, 2);
                            if (tempRand == 0)
                            {
                                byte xRand = (byte)Random.Range(0, 4);
                                byte yRand = (byte)Random.Range(0, 4);
                                int plantNum = Random.Range(0, 8);
                                byte plantGen = 0;
                                if (plantNum == 0 || plantNum == 1)
                                {
                                    plantGen = 0;
                                }
                                if (plantNum == 2 || plantNum == 3)
                                {
                                    plantGen = 1;
                                }
                                if (plantNum == 4 || plantNum == 5)
                                {
                                    plantGen = 2;
                                }
                                if (plantNum == 6)
                                {
                                    plantGen = 3;
                                }
                                if (plantNum == 7)
                                {
                                    plantGen = 4;
                                }
                                flatPlantArray[j] = plantGen;
                                xRandomPlant[j] = xRand;
                                yRandomPlant[j] = yRand;
                            }
                            else
                            {
                                flatPlantArray[j] = 100;
                                xRandomPlant[j] = 100;
                                yRandomPlant[j] = 100;
                            }
                        }
                        this.GetComponent<PhotonView>().RPC("GeneratePlainsTile", PhotonTargets.AllBuffered, i, k, height, (object)flatTreeArray, (object)flatPlantArray,
                            (object)xRandom, (object)yRandom, (object)xRandomPlant, (object)yRandomPlant);
                    }
                }
            }
            this.GetComponent<PhotonView>().RPC("GenerateResourceHolder", PhotonTargets.AllBuffered);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [PunRPC]
    public void GenerateResourceHolder()
    {
        GameObject rH;
        rH = (GameObject)Instantiate(resourceHolder, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        rH.GetComponent<ResourceHolder>().setResources(resources);
    }

    [PunRPC]
    public void CalculateWorld()
    {
        
    }
    [PunRPC]
    public void GenerateForestTile(int i, int k, int height, byte[] flatTreeArray, byte[] flatPlantArray,
        byte[] xRandom, byte[] yRandom, byte[] xRandPlant, byte[] yRandPlant)
    {
        Instantiate(grass, new Vector3(i * 48, height, k * 48), Quaternion.identity);
        if (height > -26)
        {
            int rotAmt = 0;
            for (int p = 0; p < 36; p++)
            {
                int treeGenInt = flatTreeArray[p];
                if (treeGenInt != 100)
                {
                    int j = (p / 6) * 8;
                    int l = (p % 6) * 8;
                    GameObject treeGen = oakTree;
                    GameObject arrResource;
                    if (treeGenInt == 0)
                    {
                        treeGen = oakTree;
                    }
                    else if (treeGenInt == 1)
                    {
                        treeGen = mapleTree;
                    }
                    else if (treeGenInt == 2)
                    {
                        treeGen = birchTree;
                    }
                    else if (treeGenInt == 3)
                    {
                        treeGen = fallenTree;
                    }
                    int xRand = xRandom[p];
                    int yRand = yRandom[p];
                    var localRotation = Quaternion.Euler(0, rotAmt, 0);
                    if (j == 0 && l == 0)
                    {
                        arrResource = (GameObject)Instantiate(treeGen, new Vector3((i * 48) + j - 21 + Mathf.Abs(xRand), height + 24, (k * 48) + l - 21 + Mathf.Abs(yRand)), localRotation);
                    }
                    else if (j == 0)
                    {
                        arrResource = (GameObject)Instantiate(treeGen, new Vector3((i * 48) + j - 21 + Mathf.Abs(xRand), height + 24, (k * 48) + l - 24 + yRand), localRotation);
                    }
                    else if (l == 0)
                    {
                        arrResource = (GameObject)Instantiate(treeGen, new Vector3((i * 48) + j - 24 + xRand, height + 24, (k * 48) + l - 21 + Mathf.Abs(yRand)), localRotation);
                    }
                    else
                    {
                        arrResource = (GameObject)Instantiate(treeGen, new Vector3((i * 48) + j - 24 + xRand, height + 24, (k * 48) + l - 24 + yRand), localRotation);
                    }
                    resources.Add(arrResource);
                    arrResource.GetComponent<Resource>().setArrListPlace(resources.Count);
                    rotAmt += 30;
                }
            }
        }
        if (height > -25)
        {
            int rotAmt = 0;
            for (int p = 0; p < 64; p++)
            {
                int plantGenInt = flatPlantArray[p];
                if (plantGenInt != 100)
                {
                    int j = (p / 8) * 6;
                    int l = (p % 8) * 6;
                    GameObject plantGen = forestGrass1;
                    if (plantGenInt == 0)
                    {
                        plantGen = forestGrass1;
                    }
                    else if (plantGenInt == 1)
                    {
                        plantGen = forestGrass2;
                    }
                    else if (plantGenInt == 2)
                    {
                        plantGen = forestPlant;
                    }
                    else if (plantGenInt == 3)
                    {
                        plantGen = forestFlower;
                    }
                    else if (plantGenInt == 4)
                    {
                        plantGen = log1;
                    }
                    else if (plantGenInt == 5)
                    {
                        plantGen = log2;
                    }
                    else if (plantGenInt == 6)
                    {
                        plantGen = brownMushroom1;
                    }
                    else if (plantGenInt == 7)
                    {
                        plantGen = brownMushroom2;
                    }
                    else if (plantGenInt == 8)
                    {
                        plantGen = redMushroom;
                    }
                    int xRand = xRandPlant[p];
                    int yRand = yRandPlant[p];
                    var localRotation = Quaternion.Euler(0, rotAmt, 0);
                    if (j == 0 && l == 0)
                    {
                        Instantiate(plantGen, new Vector3((i * 48) + j - 21 + Mathf.Abs(xRand), height + 24, (k * 48) + l - 21 + Mathf.Abs(yRand)), localRotation);
                    }
                    else if (j == 0)
                    {
                        Instantiate(plantGen, new Vector3((i * 48) + j - 21 + Mathf.Abs(xRand), height + 24, (k * 48) + l - 24 + yRand), localRotation);
                    }
                    else if (l == 0)
                    {
                        Instantiate(plantGen, new Vector3((i * 48) + j - 24 + xRand, height + 24, (k * 48) + l - 21 + Mathf.Abs(yRand)), localRotation);
                    }
                    else
                    {
                        Instantiate(plantGen, new Vector3((i * 48) + j - 24 + xRand, height + 24, (k * 48) + l - 24 + yRand), localRotation);
                    }
                    rotAmt += 30;
                }
            }
        }
    }
    [PunRPC]
    public void GenerateDesertTile(int i, int k, int height, byte[] flatTreeArray, int[] xRandom, int[] yRandom)
    {
        Instantiate(sand, new Vector3(i * 48, height, k * 48), Quaternion.identity);
        if (height > -25)
        {
            int rotAmt = 0;
            for (int p = 0; p < 9; p++)
            {
                int treeGenInt = flatTreeArray[p];
                if (treeGenInt != 100)
                {
                    int j = (p / 3) * 16;
                    int l = (p % 3) * 16;
                    GameObject treeGen = cactus1;
                    if (treeGenInt == 0)
                    {
                        treeGen = cactus1;
                    }
                    else if (treeGenInt == 1)
                    {
                        treeGen = cactus2;
                    }
                    else if (treeGenInt == 2)
                    {
                        treeGen = cactus3;
                    }
                    else if (treeGenInt == 3)
                    {
                        treeGen = deadBush1;
                    }
                    int xRand = xRandom[p];
                    int yRand = yRandom[p];
                    var localRotation = Quaternion.Euler(0, rotAmt, 0);
                    if (j == 0 && l == 0)
                    {
                        Instantiate(treeGen, new Vector3((i * 48) + j - 21 + Mathf.Abs(xRand), height + 24, (k * 48) + l - 21 + Mathf.Abs(yRand)), localRotation);
                    }
                    else if (j == 0)
                    {
                        Instantiate(treeGen, new Vector3((i * 48) + j - 21 + Mathf.Abs(xRand), height + 24, (k * 48) + l - 24 + yRand), localRotation);
                    }
                    else if (l == 0)
                    {
                        Instantiate(treeGen, new Vector3((i * 48) + j - 24 + xRand, height + 24, (k * 48) + l - 21 + Mathf.Abs(yRand)), localRotation);
                    }
                    else
                    {
                        Instantiate(treeGen, new Vector3((i * 48) + j - 24 + xRand, height + 24, (k * 48) + l - 24 + yRand), localRotation);
                    }
                    rotAmt += 30;
                }
            }
        }
    }
    [PunRPC]
    public void GenerateMountainTile(int i, int k, int height, byte[] flatTreeArray, byte[] xRandom, byte[] yRandom)
    {
        Instantiate(rocks, new Vector3(i * 48, height, k * 48), Quaternion.identity);
        int rotAmt = 0;
        for (int p = 0; p < 36; p++)
        {
            int treeGenInt = flatTreeArray[p];
            if (treeGenInt != 100)
            {
                int j = (p / 6) * 8;
                int l = (p % 6) * 8;
                GameObject treeGen = rock1;
                if (treeGenInt == 0)
                {
                    treeGen = rock1;
                }
                else if (treeGenInt == 1)
                {
                    treeGen = rock2;
                }
                else if (treeGenInt == 2)
                {
                    treeGen = rock3;
                }
                else if (treeGenInt == 3)
                {
                    treeGen = rock4;
                }
                else if (treeGenInt == 4)
                {
                    treeGen = rock5;
                }
                else if (treeGenInt == 5)
                {
                    treeGen = rock6;
                }
                else if (treeGenInt == 6)
                {
                    treeGen = rock7;
                }
                else if (treeGenInt == 7)
                {
                    treeGen = rock8;
                }
                int xRand = xRandom[p];
                int yRand = yRandom[p];
                var localRotation = Quaternion.Euler(0, rotAmt, 0);
                if (j == 0 && l == 0)
                {
                    Instantiate(treeGen, new Vector3((i * 48) + j - 21 + Mathf.Abs(xRand), height + 48, (k * 48) + l - 21 + Mathf.Abs(yRand)), localRotation);
                }
                else if (j == 0)
                {
                    Instantiate(treeGen, new Vector3((i * 48) + j - 21 + Mathf.Abs(xRand), height + 48, (k * 48) + l - 24 + yRand), localRotation);
                }
                else if (l == 0)
                {
                    Instantiate(treeGen, new Vector3((i * 48) + j - 24 + xRand, height + 48, (k * 48) + l - 21 + Mathf.Abs(yRand)), localRotation);
                }
                else
                {
                    Instantiate(treeGen, new Vector3((i * 48) + j - 24 + xRand, height + 48, (k * 48) + l - 24 + yRand), localRotation);
                }
                rotAmt += 30;
            }
        }
    }
    [PunRPC]
    public void GenerateDesertHillsTile(int i, int k, int height, byte[] flatTreeArray, byte[] xRandom, byte[] yRandom)
    {
        Instantiate(sandHills, new Vector3(i * 48, height, k * 48), Quaternion.identity);
        int rotAmt = 0;
        for (int p = 0; p < 36; p++)
        {
            int treeGenInt = flatTreeArray[p];
            if (treeGenInt != 100)
            {
                int j = (p / 6) * 8;
                int l = (p % 6) * 8;
                GameObject treeGen = desertRock1;
                if (treeGenInt == 0)
                {
                    treeGen = desertRock1;
                }
                else if (treeGenInt == 1)
                {
                    treeGen = desertRock2;
                }
                else if (treeGenInt == 2)
                {
                    treeGen = desertRock3;
                }
                else if (treeGenInt == 3)
                {
                    treeGen = desertRock4;
                }
                else if (treeGenInt == 4)
                {
                    treeGen = desertRock5;
                }
                else if (treeGenInt == 5)
                {
                    treeGen = desertRock6;
                }
                int xRand = xRandom[p];
                int yRand = yRandom[p];
                var localRotation = Quaternion.Euler(0, rotAmt, 0);
                if (j == 0 && l == 0)
                {
                    Instantiate(treeGen, new Vector3((i * 48) + j - 21 + Mathf.Abs(xRand), height + 48, (k * 48) + l - 21 + Mathf.Abs(yRand)), localRotation);
                }
                else if (j == 0)
                {
                    Instantiate(treeGen, new Vector3((i * 48) + j - 21 + Mathf.Abs(xRand), height + 48, (k * 48) + l - 24 + yRand), localRotation);
                }
                else if (l == 0)
                {
                    Instantiate(treeGen, new Vector3((i * 48) + j - 24 + xRand, height + 48, (k * 48) + l - 21 + Mathf.Abs(yRand)), localRotation);
                }
                else
                {
                    Instantiate(treeGen, new Vector3((i * 48) + j - 24 + xRand, height + 48, (k * 48) + l - 24 + yRand), localRotation);
                }
                rotAmt += 30;
            }
        }
    }
    [PunRPC]
    public void GenerateTundraTile(int i, int k, int height, byte[] flatTreeArray, byte[] flatPlantArray,
        byte[] xRandom, byte[] yRandom, byte[] xRandPlant, byte[] yRandPlant)
    {
        Instantiate(snow, new Vector3(i * 48, height, k * 48), Quaternion.identity);
        if (height > -26)
        {
            int rotAmt = 0;
            for (int p = 0; p < 36; p++)
            {
                int treeGenInt = flatTreeArray[p];
                if (treeGenInt != 100)
                {
                    int j = (p / 6) * 8;
                    int l = (p % 6) * 8;
                    GameObject treeGen = snowTree1;
                    if (treeGenInt == 0)
                    {
                        treeGen = snowTree1;
                    }
                    else if (treeGenInt == 1)
                    {
                        treeGen = snowTree2;
                    }
                    else if (treeGenInt == 2)
                    {
                        treeGen = snowTree3;
                    }
                    else if (treeGenInt == 3)
                    {
                        treeGen = snowTree4;
                    }
                    else if (treeGenInt == 4)
                    {
                        treeGen = snowTree5;
                    }
                    else if (treeGenInt == 5)
                    {
                        treeGen = deadTree;
                    }
                    int xRand = xRandom[p];
                    int yRand = yRandom[p];
                    var localRotation = Quaternion.Euler(0, rotAmt, 0);
                    if (j == 0 && l == 0)
                    {
                        Instantiate(treeGen, new Vector3((i * 48) + j - 21 + Mathf.Abs(xRand), height + 24, (k * 48) + l - 21 + Mathf.Abs(yRand)), localRotation);
                    }
                    else if (j == 0)
                    {
                        Instantiate(treeGen, new Vector3((i * 48) + j - 21 + Mathf.Abs(xRand), height + 24, (k * 48) + l - 24 + yRand), localRotation);
                    }
                    else if (l == 0)
                    {
                        Instantiate(treeGen, new Vector3((i * 48) + j - 24 + xRand, height + 24, (k * 48) + l - 21 + Mathf.Abs(yRand)), localRotation);
                    }
                    else
                    {
                        Instantiate(treeGen, new Vector3((i * 48) + j - 24 + xRand, height + 24, (k * 48) + l - 24 + yRand), localRotation);
                    }
                    rotAmt += 30;
                }
            }
        }
        if (height > -25)
        {
            int rotAmt = 0;
            for (int p = 0; p < 64; p++)
            {
                int plantGenInt = flatPlantArray[p];
                if (plantGenInt != 100)
                {
                    int j = (p / 8) * 6;
                    int l = (p % 8) * 6;
                    GameObject plantGen = tundraPlant1;
                    if (plantGenInt == 0)
                    {
                        plantGen = tundraPlant1;
                    }
                    else if (plantGenInt == 1)
                    {
                        plantGen = tundraPlant2;
                    }
                    else if (plantGenInt == 2)
                    {
                        plantGen = tundraPlant3;
                    }
                    else if (plantGenInt == 3)
                    {
                        plantGen = tundraPlant4;
                    }
                    else if (plantGenInt == 4)
                    {
                        plantGen = tundraPlant5;
                    }
                    else if (plantGenInt == 5)
                    {
                        plantGen = tundraPlant6;
                    }
                    else if (plantGenInt == 6)
                    {
                        plantGen = stick;
                    }
                    else if (plantGenInt == 7)
                    {
                        plantGen = tundraFlowers;
                    }
                    int xRand = xRandPlant[p];
                    int yRand = yRandPlant[p];
                    var localRotation = Quaternion.Euler(0, rotAmt, 0);
                    if (j == 0 && l == 0)
                    {
                        Instantiate(plantGen, new Vector3((i * 48) + j - 21 + Mathf.Abs(xRand), height + 24, (k * 48) + l - 21 + Mathf.Abs(yRand)), localRotation);
                    }
                    else if (j == 0)
                    {
                        Instantiate(plantGen, new Vector3((i * 48) + j - 21 + Mathf.Abs(xRand), height + 24, (k * 48) + l - 24 + yRand), localRotation);
                    }
                    else if (l == 0)
                    {
                        Instantiate(plantGen, new Vector3((i * 48) + j - 24 + xRand, height + 24, (k * 48) + l - 21 + Mathf.Abs(yRand)), localRotation);
                    }
                    else
                    {
                        Instantiate(plantGen, new Vector3((i * 48) + j - 24 + xRand, height + 24, (k * 48) + l - 24 + yRand), localRotation);
                    }
                    rotAmt += 30;
                }
            }
        }
    }
    [PunRPC]
    public void GenerateSnowyMountainTile(int i, int k, int height, byte[] flatTreeArray, byte[] xRandom, byte[] yRandom)
    {
        Instantiate(snowRocks, new Vector3(i * 48, height, k * 48), Quaternion.identity);
        int rotAmt = 0;
        for (int p = 0; p < 36; p++)
        {
            int treeGenInt = flatTreeArray[p];
            if (treeGenInt != 100)
            {
                int j = (p / 6) * 8;
                int l = (p % 6) * 8;
                GameObject treeGen = rock1;
                if (treeGenInt == 0)
                {
                    treeGen = rock1;
                }
                else if (treeGenInt == 1)
                {
                    treeGen = rock2;
                }
                else if (treeGenInt == 2)
                {
                    treeGen = rock3;
                }
                else if (treeGenInt == 3)
                {
                    treeGen = rock4;
                }
                else if (treeGenInt == 4)
                {
                    treeGen = snowRock1;
                }
                else if (treeGenInt == 5)
                {
                    treeGen = snowRock2;
                }
                else if (treeGenInt == 6)
                {
                    treeGen = snowRock3;
                }
                else if (treeGenInt == 7)
                {
                    treeGen = snowRock4;
                }
                else if (treeGenInt == 8)
                {
                    treeGen = snowTree1;
                }
                else if (treeGenInt == 9)
                {
                    treeGen = snowTree2;
                }
                else if (treeGenInt == 10)
                {
                    treeGen = snowTree3;
                }
                else if (treeGenInt == 11)
                {
                    treeGen = snowTree4;
                }
                else if (treeGenInt == 12)
                {
                    treeGen = snowTree5;
                }
                int xRand = xRandom[p];
                int yRand = yRandom[p];
                var localRotation = Quaternion.Euler(0, rotAmt, 0);
                if (j == 0 && l == 0)
                {
                    Instantiate(treeGen, new Vector3((i * 48) + j - 21 + Mathf.Abs(xRand), height + 48, (k * 48) + l - 21 + Mathf.Abs(yRand)), localRotation);
                }
                else if (j == 0)
                {
                    Instantiate(treeGen, new Vector3((i * 48) + j - 21 + Mathf.Abs(xRand), height + 48, (k * 48) + l - 24 + yRand), localRotation);
                }
                else if (l == 0)
                {
                    Instantiate(treeGen, new Vector3((i * 48) + j - 24 + xRand, height + 48, (k * 48) + l - 21 + Mathf.Abs(yRand)), localRotation);
                }
                else
                {
                    Instantiate(treeGen, new Vector3((i * 48) + j - 24 + xRand, height + 48, (k * 48) + l - 24 + yRand), localRotation);
                }
                rotAmt += 30;
            }
        }
    }
    [PunRPC]
    public void GenerateBadlandsTile(int i, int k, int height, byte[] flatTreeArray, byte[] xRandom, byte[] yRandom)
    {
        Instantiate(badlands, new Vector3(i * 48, height, k * 48), Quaternion.identity);
        int rotAmt = 0;
        for (int p = 0; p < 36; p++)
        {
            int treeGenInt = flatTreeArray[p];
            if (treeGenInt != 100)
            {
                int j = (p / 6) * 8;
                int l = (p % 6) * 8;
                GameObject treeGen = deadBush1;
                if (treeGenInt == 0)
                {
                    treeGen = deadBush2;
                }
                else if (treeGenInt == 1)
                {
                    treeGen = deadBush3;
                }
                else if (treeGenInt == 2)
                {
                    treeGen = mesaRock1;
                }
                else if (treeGenInt == 3)
                {
                    treeGen = mesaRock2;
                }
                else if (treeGenInt == 4)
                {
                    treeGen = badlandsPlant1;
                }
                else if (treeGenInt == 5)
                {
                    treeGen = badlandsPlant2;
                }
                else if (treeGenInt == 6)
                {
                    treeGen = badlandsPlant3;
                }
                else if (treeGenInt == 7)
                {
                    treeGen = deadBush1;
                }
                int xRand = xRandom[p];
                int yRand = yRandom[p];
                var localRotation = Quaternion.Euler(0, rotAmt, 0);
                if (j == 0 && l == 0)
                {
                    Instantiate(treeGen, new Vector3((i * 48) + j - 21 + Mathf.Abs(xRand), height + 24, (k * 48) + l - 21 + Mathf.Abs(yRand)), localRotation);
                }
                else if (j == 0)
                {
                    Instantiate(treeGen, new Vector3((i * 48) + j - 21 + Mathf.Abs(xRand), height + 24, (k * 48) + l - 24 + yRand), localRotation);
                }
                else if (l == 0)
                {
                    Instantiate(treeGen, new Vector3((i * 48) + j - 24 + xRand, height + 24, (k * 48) + l - 21 + Mathf.Abs(yRand)), localRotation);
                }
                else
                {
                    Instantiate(treeGen, new Vector3((i * 48) + j - 24 + xRand, height + 24, (k * 48) + l - 24 + yRand), localRotation);
                }
                rotAmt += 30;
            }
        }
    }
    [PunRPC]
    public void GenerateMesaTile(int i, int k, int height, byte[] flatTreeArray, byte[] xRandom, byte[] yRandom)
    {
        Instantiate(mesa, new Vector3(i * 48, height, k * 48), Quaternion.identity);
        int rotAmt = 0;
        for (int p = 0; p < 36; p++)
        {
            int treeGenInt = flatTreeArray[p];
            if (treeGenInt != 100)
            {
                int j = (p / 6) * 8;
                int l = (p % 6) * 8;
                GameObject treeGen = mesaRock1;
                if (treeGenInt == 0)
                {
                    treeGen = mesaRock1;
                }
                else if (treeGenInt == 1)
                {
                    treeGen = mesaRock2;
                }
                else if (treeGenInt == 2)
                {
                    treeGen = mesaRock3;
                }
                else if (treeGenInt == 3)
                {
                    treeGen = mesaRock4;
                }
                else if (treeGenInt == 4)
                {
                    treeGen = mesaRock5;
                }
                else if (treeGenInt == 5)
                {
                    treeGen = mesaRock6;
                }
                else if (treeGenInt == 6)
                {
                    treeGen = mesaRock7;
                }
                int xRand = xRandom[p];
                int yRand = yRandom[p];
                var localRotation = Quaternion.Euler(0, rotAmt, 0);
                if (j == 0 && l == 0)
                {
                    Instantiate(treeGen, new Vector3((i * 48) + j - 21 + Mathf.Abs(xRand), height + 48, (k * 48) + l - 21 + Mathf.Abs(yRand)), localRotation);
                }
                else if (j == 0)
                {
                    Instantiate(treeGen, new Vector3((i * 48) + j - 21 + Mathf.Abs(xRand), height + 48, (k * 48) + l - 24 + yRand), localRotation);
                }
                else if (l == 0)
                {
                    Instantiate(treeGen, new Vector3((i * 48) + j - 24 + xRand, height + 48, (k * 48) + l - 21 + Mathf.Abs(yRand)), localRotation);
                }
                else
                {
                    Instantiate(treeGen, new Vector3((i * 48) + j - 24 + xRand, height + 48, (k * 48) + l - 24 + yRand), localRotation);
                }
                rotAmt += 30;
            }
        }
    }
    [PunRPC]
    public void GenerateJungleTile(int i, int k, int height, byte[] flatTreeArray, byte[] flatPlantArray,
        byte[] xRandom, byte[] yRandom, byte[] xRandPlant, byte[] yRandPlant)
    {
        Instantiate(jungle, new Vector3(i * 48, height, k * 48), Quaternion.identity);
        if (height > -26)
        {
            int rotAmt = 0;
            for (int p = 0; p < 144; p++)
            {
                int treeGenInt = flatTreeArray[p];
                if (treeGenInt != 100)
                {
                    int j = (p / 12) * 4;
                    int l = (p % 12) * 4;
                    GameObject treeGen = jungleTree1;
                    if (treeGenInt == 0)
                    {
                        treeGen = jungleTree1;
                    }
                    else if (treeGenInt == 1)
                    {
                        treeGen = jungleTree2;
                    }
                    else if (treeGenInt == 2)
                    {
                        treeGen = jungleTree3;
                    }
                    else if (treeGenInt == 3)
                    {
                        treeGen = jungleTree4;
                    }
                    else if (treeGenInt == 4)
                    {
                        treeGen = jungleTree5;
                    }
                    else if (treeGenInt == 5)
                    {
                        treeGen = jungleTree6;
                    }
                    else if (treeGenInt == 6)
                    {
                        treeGen = jungleTree7;
                    }
                    int xRand = xRandom[p];
                    int yRand = yRandom[p];
                    var localRotation = Quaternion.Euler(0, rotAmt, 0);
                    if (j == 0 && l == 0)
                    {
                        Instantiate(treeGen, new Vector3((i * 48) + j - 21 + Mathf.Abs(xRand), height + 24, (k * 48) + l - 21 + Mathf.Abs(yRand)), localRotation);
                    }
                    else if (j == 0)
                    {
                        Instantiate(treeGen, new Vector3((i * 48) + j - 21 + Mathf.Abs(xRand), height + 24, (k * 48) + l - 24 + yRand), localRotation);
                    }
                    else if (l == 0)
                    {
                        Instantiate(treeGen, new Vector3((i * 48) + j - 24 + xRand, height + 24, (k * 48) + l - 21 + Mathf.Abs(yRand)), localRotation);
                    }
                    else
                    {
                        Instantiate(treeGen, new Vector3((i * 48) + j - 24 + xRand, height + 24, (k * 48) + l - 24 + yRand), localRotation);
                    }
                    rotAmt += 30;
                }
            }
        }
        if (height > -25)
        {
            int rotAmt = 0;
            for (int p = 0; p < 64; p++)
            {
                int plantGenInt = flatPlantArray[p];
                if (plantGenInt != 100)
                {
                    int j = (p / 8) * 6;
                    int l = (p % 8) * 6;
                    GameObject plantGen = junglePlant1;
                    if (plantGenInt == 0)
                    {
                        plantGen = junglePlant1;
                    }
                    else if (plantGenInt == 1)
                    {
                        plantGen = junglePlant2;
                    }
                    else if (plantGenInt == 2)
                    {
                        plantGen = junglePlant3;
                    }
                    else if (plantGenInt == 3)
                    {
                        plantGen = junglePlant4;
                    }
                    else if (plantGenInt == 4)
                    {
                        plantGen = junglePlant5;
                    }
                    else if (plantGenInt == 5)
                    {
                        plantGen = junglePlant6;
                    }
                    else if (plantGenInt == 6)
                    {
                        plantGen = junglePlant7;
                    }
                    int xRand = xRandPlant[p];
                    int yRand = yRandPlant[p];
                    var localRotation = Quaternion.Euler(0, rotAmt, 0);
                    if (j == 0 && l == 0)
                    {
                        Instantiate(plantGen, new Vector3((i * 48) + j - 21 + Mathf.Abs(xRand), height + 24, (k * 48) + l - 21 + Mathf.Abs(yRand)), localRotation);
                    }
                    else if (j == 0)
                    {
                        Instantiate(plantGen, new Vector3((i * 48) + j - 21 + Mathf.Abs(xRand), height + 24, (k * 48) + l - 24 + yRand), localRotation);
                    }
                    else if (l == 0)
                    {
                        Instantiate(plantGen, new Vector3((i * 48) + j - 24 + xRand, height + 24, (k * 48) + l - 21 + Mathf.Abs(yRand)), localRotation);
                    }
                    else
                    {
                        Instantiate(plantGen, new Vector3((i * 48) + j - 24 + xRand, height + 24, (k * 48) + l - 24 + yRand), localRotation);
                    }
                    rotAmt += 30;
                }
            }
        }
    }
    [PunRPC]
    public void GenerateSavannaTile(int i, int k, int height, byte[] flatTreeArray, byte[] flatPlantArray,
        byte[] xRandom, byte[] yRandom, byte[] xRandPlant, byte[] yRandPlant)
    {
        Instantiate(savanna, new Vector3(i * 48, height, k * 48), Quaternion.identity);
        if (height > -26)
        {
            int rotAmt = 0;
            for (int p = 0; p < 9; p++)
            {
                int treeGenInt = flatTreeArray[p];
                if (treeGenInt != 100)
                {
                    int j = (p / 3) * 16;
                    int l = (p % 3) * 16;
                    GameObject treeGen = savannaTree1;
                    if (treeGenInt == 0)
                    {
                        treeGen = savannaTree1;
                    }
                    else if (treeGenInt == 1)
                    {
                        treeGen = savannaTree2;
                    }
                    else if (treeGenInt == 2)
                    {
                        treeGen = savannaTree3;
                    }
                    else if (treeGenInt == 3)
                    {
                        treeGen = savannaTree4;
                    }
                    else if (treeGenInt == 4)
                    {
                        treeGen = savannaTree5;
                    }
                    else if (treeGenInt == 5)
                    {
                        treeGen = savannaTallGrass;
                    }
                    else if (treeGenInt == 6)
                    {
                        treeGen = deadBush1;
                    }
                    int xRand = xRandom[p];
                    int yRand = yRandom[p];
                    var localRotation = Quaternion.Euler(0, rotAmt, 0);
                    if (j == 0 && l == 0)
                    {
                        Instantiate(treeGen, new Vector3((i * 48) + j - 21 + Mathf.Abs(xRand), height + 24, (k * 48) + l - 21 + Mathf.Abs(yRand)), localRotation);
                    }
                    else if (j == 0)
                    {
                        Instantiate(treeGen, new Vector3((i * 48) + j - 21 + Mathf.Abs(xRand), height + 24, (k * 48) + l - 24 + yRand), localRotation);
                    }
                    else if (l == 0)
                    {
                        Instantiate(treeGen, new Vector3((i * 48) + j - 24 + xRand, height + 24, (k * 48) + l - 21 + Mathf.Abs(yRand)), localRotation);
                    }
                    else
                    {
                        Instantiate(treeGen, new Vector3((i * 48) + j - 24 + xRand, height + 24, (k * 48) + l - 24 + yRand), localRotation);
                    }
                    rotAmt += 30;
                }
            }
        }
        if (height > -25)
        {
            int rotAmt = 0;
            for (int p = 0; p < 64; p++)
            {
                int plantGenInt = flatPlantArray[p];
                if (plantGenInt != 100)
                {
                    int j = (p / 8) * 6;
                    int l = (p % 8) * 6;
                    GameObject plantGen = savannaGrass1;
                    if (plantGenInt == 0)
                    {
                        plantGen = savannaGrass1;
                    }
                    else if (plantGenInt == 1)
                    {
                        plantGen = savannaGrass2;
                    }
                    else if (plantGenInt == 2)
                    {
                        plantGen = savannaGrass3;
                    }
                    else if (plantGenInt == 3)
                    {
                        plantGen = savannaRedFlower;
                    }
                    int xRand = xRandPlant[p];
                    int yRand = yRandPlant[p];
                    var localRotation = Quaternion.Euler(0, rotAmt, 0);
                    if (j == 0 && l == 0)
                    {
                        Instantiate(plantGen, new Vector3((i * 48) + j - 21 + Mathf.Abs(xRand), height + 24, (k * 48) + l - 21 + Mathf.Abs(yRand)), localRotation);
                    }
                    else if (j == 0)
                    {
                        Instantiate(plantGen, new Vector3((i * 48) + j - 21 + Mathf.Abs(xRand), height + 24, (k * 48) + l - 24 + yRand), localRotation);
                    }
                    else if (l == 0)
                    {
                        Instantiate(plantGen, new Vector3((i * 48) + j - 24 + xRand, height + 24, (k * 48) + l - 21 + Mathf.Abs(yRand)), localRotation);
                    }
                    else
                    {
                        Instantiate(plantGen, new Vector3((i * 48) + j - 24 + xRand, height + 24, (k * 48) + l - 24 + yRand), localRotation);
                    }
                    rotAmt += 30;
                }
            }
        }
    }
    [PunRPC]
    public void GenerateSwampTile(int i, int k, int height, byte[] flatTreeArray, byte[] flatPlantArray,
        byte[] xRandom, byte[] yRandom, byte[] xRandPlant, byte[] yRandPlant)
    {
        Instantiate(swamp, new Vector3(i * 48, height, k * 48), Quaternion.identity);
        if (height > -26)
        {
            int rotAmt = 0;
            for (int p = 0; p < 16; p++)
            {
                int treeGenInt = flatTreeArray[p];
                if (treeGenInt != 100)
                {
                    int j = (p / 4) * 12;
                    int l = (p % 4) * 12;
                    GameObject treeGen = swampTree1;
                    if (treeGenInt == 0)
                    {
                        treeGen = swampTree1;
                    }
                    else if (treeGenInt == 1)
                    {
                        treeGen = swampTree2;
                    }
                    else if (treeGenInt == 2)
                    {
                        treeGen = swampTree3;
                    }
                    else if (treeGenInt == 3)
                    {
                        treeGen = swampTree4;
                    }
                    int xRand = xRandom[p];
                    int yRand = yRandom[p];
                    var localRotation = Quaternion.Euler(0, rotAmt, 0);
                    if (j == 0 && l == 0)
                    {
                        Instantiate(treeGen, new Vector3((i * 48) + j - 21 + Mathf.Abs(xRand), height + 24, (k * 48) + l - 21 + Mathf.Abs(yRand)), localRotation);
                    }
                    else if (j == 0)
                    {
                        Instantiate(treeGen, new Vector3((i * 48) + j - 21 + Mathf.Abs(xRand), height + 24, (k * 48) + l - 24 + yRand), localRotation);
                    }
                    else if (l == 0)
                    {
                        Instantiate(treeGen, new Vector3((i * 48) + j - 24 + xRand, height + 24, (k * 48) + l - 21 + Mathf.Abs(yRand)), localRotation);
                    }
                    else
                    {
                        Instantiate(treeGen, new Vector3((i * 48) + j - 24 + xRand, height + 24, (k * 48) + l - 24 + yRand), localRotation);
                    }
                    rotAmt += 30;
                }
            }
        }
        if (height > -25)
        {
            int rotAmt = 0;
            for (int p = 0; p < 64; p++)
            {
                int plantGenInt = flatPlantArray[p];
                if (plantGenInt != 100)
                {
                    int j = (p / 8) * 6;
                    int l = (p % 8) * 6;
                    GameObject plantGen = swampGrass1;
                    if (plantGenInt == 0)
                    {
                        plantGen = swampGrass1;
                    }
                    else if (plantGenInt == 1)
                    {
                        plantGen = swampGrass2;
                    }
                    else if (plantGenInt == 2)
                    {
                        plantGen = swampGrass3;
                    }
                    else if (plantGenInt == 3)
                    {
                        plantGen = swampPlant1;
                    }
                    else if (plantGenInt == 4)
                    {
                        plantGen = swampPlant2;
                    }
                    else if (plantGenInt == 5)
                    {
                        plantGen = swampPlant3;
                    }
                    else if (plantGenInt == 6)
                    {
                        plantGen = swampPlant4;
                    }
                    else if (plantGenInt == 7)
                    {
                        plantGen = swampLog;
                    }
                    else if (plantGenInt == 8)
                    {
                        plantGen = brownMushroom1;
                    }
                    else if (plantGenInt == 9)
                    {
                        plantGen = brownMushroom2;
                    }
                    else if (plantGenInt == 10)
                    {
                        plantGen = redMushroom;
                    }
                    int xRand = xRandPlant[p];
                    int yRand = yRandPlant[p];
                    var localRotation = Quaternion.Euler(0, rotAmt, 0);
                    if (j == 0 && l == 0)
                    {
                        Instantiate(plantGen, new Vector3((i * 48) + j - 21 + Mathf.Abs(xRand), height + 24, (k * 48) + l - 21 + Mathf.Abs(yRand)), localRotation);
                    }
                    else if (j == 0)
                    {
                        Instantiate(plantGen, new Vector3((i * 48) + j - 21 + Mathf.Abs(xRand), height + 24, (k * 48) + l - 24 + yRand), localRotation);
                    }
                    else if (l == 0)
                    {
                        Instantiate(plantGen, new Vector3((i * 48) + j - 24 + xRand, height + 24, (k * 48) + l - 21 + Mathf.Abs(yRand)), localRotation);
                    }
                    else
                    {
                        Instantiate(plantGen, new Vector3((i * 48) + j - 24 + xRand, height + 24, (k * 48) + l - 24 + yRand), localRotation);
                    }
                    rotAmt += 30;
                }
            }
        }
    }
    [PunRPC]
    public void GeneratePlainsTile(int i, int k, int height, byte[] flatTreeArray, byte[] flatPlantArray,
        int[] xRandom, int[] yRandom, byte[] xRandPlant, byte[] yRandPlant)
    {
        Instantiate(grass, new Vector3(i * 48, height, k * 48), Quaternion.identity);
        if (height > -26)
        {
            int rotAmt = 0;
            for (int p = 0; p < 4; p++)
            {
                int treeGenInt = flatTreeArray[p];
                if (treeGenInt != 100)
                {
                    int j = (p / 2) * 24;
                    int l = (p % 2) * 24;
                    GameObject treeGen = oakTree;
                    if (treeGenInt == 0)
                    {
                        treeGen = oakTree;
                    }
                    else if (treeGenInt == 1)
                    {
                        treeGen = pumpkins1;
                    }
                    else if (treeGenInt == 2)
                    {
                        treeGen = pumpkins2;
                    }
                    int xRand = xRandom[p];
                    int yRand = yRandom[p];
                    var localRotation = Quaternion.Euler(0, rotAmt, 0);
                    if (j == 0 && l == 0)
                    {
                        Instantiate(treeGen, new Vector3((i * 48) + j - 21 + Mathf.Abs(xRand), height + 24, (k * 48) + l - 21 + Mathf.Abs(yRand)), localRotation);
                    }
                    else if (j == 0)
                    {
                        Instantiate(treeGen, new Vector3((i * 48) + j - 21 + Mathf.Abs(xRand), height + 24, (k * 48) + l - 24 + yRand), localRotation);
                    }
                    else if (l == 0)
                    {
                        Instantiate(treeGen, new Vector3((i * 48) + j - 24 + xRand, height + 24, (k * 48) + l - 21 + Mathf.Abs(yRand)), localRotation);
                    }
                    else
                    {
                        Instantiate(treeGen, new Vector3((i * 48) + j - 24 + xRand, height + 24, (k * 48) + l - 24 + yRand), localRotation);
                    }
                    rotAmt += 30;
                }
            }
        }
        if (height > -25)
        {
            int rotAmt = 0;
            for (int p = 0; p < 64; p++)
            {
                int plantGenInt = flatPlantArray[p];
                if (plantGenInt != 100)
                {
                    int j = (p / 8) * 6;
                    int l = (p % 8) * 6;
                    GameObject plantGen = plainsGrass;
                    if (plantGenInt == 0)
                    {
                        plantGen = forestGrass1;
                    }
                    else if (plantGenInt == 1)
                    {
                        plantGen = forestGrass2;
                    }
                    else if (plantGenInt == 2)
                    {
                        plantGen = sunflower1;
                    }
                    else if (plantGenInt == 3)
                    {
                        plantGen = sunflower2;
                    }
                    int xRand = xRandPlant[p];
                    int yRand = yRandPlant[p];
                    var localRotation = Quaternion.Euler(0, rotAmt, 0);
                    if (j == 0 && l == 0)
                    {
                        Instantiate(plantGen, new Vector3((i * 48) + j - 21 + Mathf.Abs(xRand), height + 24, (k * 48) + l - 21 + Mathf.Abs(yRand)), localRotation);
                    }
                    else if (j == 0)
                    {
                        Instantiate(plantGen, new Vector3((i * 48) + j - 21 + Mathf.Abs(xRand), height + 24, (k * 48) + l - 24 + yRand), localRotation);
                    }
                    else if (l == 0)
                    {
                        Instantiate(plantGen, new Vector3((i * 48) + j - 24 + xRand, height + 24, (k * 48) + l - 21 + Mathf.Abs(yRand)), localRotation);
                    }
                    else
                    {
                        Instantiate(plantGen, new Vector3((i * 48) + j - 24 + xRand, height + 24, (k * 48) + l - 24 + yRand), localRotation);
                    }
                    rotAmt += 30;
                }
            }
        }
    }
}