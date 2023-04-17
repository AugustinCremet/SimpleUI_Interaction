using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AddButton : MonoBehaviour
{
    [SerializeField] GameObject item;
    [SerializeField] Sprite[] image;
    GameObject itemParent;
    GameObject newItem;
    void Start()
    {
        itemParent = GameObject.Find("BG Image");
    }
    public void AddItem()
    {
        if(itemParent.transform.childCount < 18)
        {
            int cost;
            // create a new object then set his parameter
            newItem = Instantiate(item, new Vector3(0, 0, 0), Quaternion.identity);
            newItem.transform.SetParent(itemParent.transform);
            newItem.transform.Find("Image").GetComponent<Image>().sprite = image[Random.Range(0, image.Length)];
            newItem.transform.Find("Name").GetComponent<Text>().text = newItem.transform.Find("Image").GetComponent<Image>().sprite.name;
            cost = Random.Range(1000, 10001);
            newItem.transform.Find("Cost").GetComponent<Text>().text = cost.ToString() + " $";
        }
    }

    void Update()
    {
        int totalCost = 0;
        for(int i = 0; i < itemParent.transform.childCount; ++i)
        {
            // get the length of the string
            int sLength = itemParent.transform.GetChild(i).Find("Cost").GetComponent<Text>().text.Length;
            // get the int out of the string and add it to total
            totalCost += int.Parse(itemParent.transform.GetChild(i).Find("Cost").GetComponent<Text>().text.Substring(0, sLength - 2));
            // set name of object
            itemParent.transform.GetChild(i).name = "Item " + (i + 1);
        }
        // change the value of the total cost
        GameObject.Find("Total Image/Text").GetComponent<Text>().text = "Cost: " + totalCost.ToString() + " $";
    }
}
