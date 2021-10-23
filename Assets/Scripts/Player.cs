using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Toggle toggle;
    public InputField entry1;
    public InputField entry2;
    public InputField entry3;
    public InputField entry4;
    public int level = 3;
    public int health =40;
    public Text textFieldPrefab;
    public Text textFieldPrefab1;
    public GameObject canvas;
    public Dictionary<string, List<float>> SaleData = new Dictionary<string, List<float>>(){};
    public Dictionary<string, List<float>> SlabsArea = new Dictionary<string, List<float>>(){};
    public int area1;
    void Start(){
    }
    void Update()
    {

    }
    // Start is called before the first frame update
    public void SavePlayer(){
        SaveSystem.SavePlayer(this);


    }

    public void LoadPlayer(){
        PlayerData data = SaveSystem.LoadPlayer();

        level = data.level;
        health = data.health;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
        SlabsArea = data.SlabsArea;
        SaleData = data.SaleData;
        TextCreate();
    }
    public void SetIncoming(){
        List<string> KeysStone = new List<string>(SlabsArea.Keys);
        if (!KeysStone.Contains(entry1.text.ToString()))
        {
            List<float> dataList = new List<float>();
            dataList.Add(float.Parse(entry2.text.ToString()));
            SlabsArea[entry1.text.ToString()] = dataList;
            TextCreate();
        }
        else{
        SlabsArea[entry1.text.ToString()].Add(int.Parse(entry2.text.ToString()));
        TextCreate();
        }
    }
    public void SetSale(){
        List<string> KeysStone = new List<string>(SaleData.Keys);
        if (!KeysStone.Contains(entry3.text.ToString()))
        {
            List<float> dataList = new List<float>();
            dataList.Add(float.Parse(entry4.text.ToString()));
            SaleData[entry3.text.ToString()] = dataList;
            TextCreate();
        }
        else{
        SaleData[entry3.text.ToString()].Add(float.Parse(entry4.text.ToString()));
        TextCreate();
        }
    }
    public void TextCreate()
    {
        ShowTextData("TextStock",  SlabsArea, 280f, textFieldPrefab);
        ShowTextData("TextStock1", SaleData, 280f, textFieldPrefab1);

    }

    public void ShowTextData(string TextPrefabString, Dictionary<string, List<float>> SavedArea, float textPosition, Text inputTextFieldPrefab){

        GameObject[] textStockObjects = GameObject.FindGameObjectsWithTag(TextPrefabString);
        
        
        for (int  k= 0; k< textStockObjects.Length; k++)
        {
            Destroy(textStockObjects[k]);
        }

        List<string> KeysStone = new List<string>(SavedArea.Keys);
        for (int i = 0; i < KeysStone.Count; i++)
        {
            float totalArea = 0f;
            for (int j =0; j < SavedArea[KeysStone[i]].Count; j++){
                totalArea += SavedArea[KeysStone[i]][j];
            }
            Text textData = Instantiate(inputTextFieldPrefab, new Vector3(textPosition +  70f * (int) (i/9), 150f + 90f-i%9*30f, 0f), textFieldPrefab.transform.rotation);
            textData.text = KeysStone[i]  +" "+ totalArea.ToString();
            textData.transform.parent = canvas.transform;

        }
        
        }

        public void ToggleChange(){
        GameObject[] textStockObjects = GameObject.FindGameObjectsWithTag("TextStock");
        GameObject[] textStockObjects1 = GameObject.FindGameObjectsWithTag("TextStock1");
        Debug.Log(toggle.isOn);
        for(int i =0; i< textStockObjects.Length;i++){
            textStockObjects[i].GetComponent<Text>().enabled = !toggle.isOn;
        }
        for(int j =0; j< textStockObjects1.Length;j++){
            textStockObjects1[j].GetComponent<Text>().enabled = toggle.isOn;
        }

    }
}
