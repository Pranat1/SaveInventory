using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int level;
    public int health; 
    public float[] position;
    public Dictionary<string, List<float>> SlabsArea;
    public Dictionary<string, List<float>> SaleData;

    public PlayerData(Player player){
        
        level = player.level;
        health = player.health;
        SlabsArea = player.SlabsArea;
        SaleData = player.SaleData;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;


    }
}
