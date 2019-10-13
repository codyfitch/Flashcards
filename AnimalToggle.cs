using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class AnimalToggle : MonoBehaviour
{
    public GameObject duck;
    public GameObject lion;
    public GameObject monkey;

    public Text duckText;
    public Text lionText;
    public Text monkeyText;

    //Add sound effects

    //Get SQL data through PHP script for security
    string messageData = "https://10.0.0.21/messageData.php";
    public Text incomingText;

    private void Start()
    {
        StartCoroutine(GetData());
    }


    private void Update()
    {

        if (int.Parse(duckText.text) == 1)
        {
            duck.SetActive(true);
        }
        else
        {
            duck.SetActive(false);
        }

        if (int.Parse(lionText.text) == 1)
        {
            lion.SetActive(true);
        }
        else
        {
            lion.SetActive(false);
        }

        if (int.Parse(monkeyText.text) == 1)
        {
            monkey.SetActive(true);
        }
        else
        {
            monkey.SetActive(false);
        }
    }

    //Coroutine to determine how often to ping the server to prevent overflow
    IEnumerator DataTimer()
    {
        yield return new WaitForSeconds(5.0f);
        StartCoroutine(GetData());
    }

    IEnumerator GetData()
    {
        //Import data from SQL server through PHP script above
        UnityWebRequest messUpdate = UnityWebRequest.Get(messageData);
        yield return messUpdate.SendWebRequest();

        if (messUpdate.error != null)
        {
            Debug.Log(messUpdate.error);
        }
        else
        {
            //Split incoming string into message categories
            incomingText.text = messUpdate.downloadHandler.text;
            string allData = incomingText.text;
            string[] splitStr = allData.Split(" "[0]);
            int[] value = new int[splitStr.Length - 1];
            string[] splitArr = allData.Split(char.Parse(";"));
            duckText.text = splitArr[0];
            lionText.text = splitArr[1];
            monkeyText.text = splitArr[2];
        }

        StartCoroutine(DataTimer());
    }
}
