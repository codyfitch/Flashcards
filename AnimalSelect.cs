using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AnimalSelect : MonoBehaviour
{
    string duckOn = "https://flashcardsappdemo.000webhostapp.com/DuckOn.php";
    string duckOff = "https://flashcardsappdemo.000webhostapp.com/DuckOff.php";
    string lionOn = "https://flashcardsappdemo.000webhostapp.com/LionOn.php";
    string lionOff = "https://flashcardsappdemo.000webhostapp.com/LionOff.php";
    string monkeyOn = "https://flashcardsappdemo.000webhostapp.com/MonkeyOn.php";
    string monkeyOff = "https://flashcardsappdemo.000webhostapp.com/MonkeyOff.php";

    bool duckStatus = false;
    bool lionStatus = false;
    bool monkeyStatus = false;

    private void Start()
    {
        StartCoroutine(DuckStop());
        StartCoroutine(LionStop());
        StartCoroutine(MonkeyStop());
    }
    public void DuckClick()
    {
        if(duckStatus == false)
        {
            StartCoroutine(DuckStart());
        } else if(duckStatus == true)
        {
            StartCoroutine(DuckStop());
        }
    }

    public void LionClick()
    {
        if(lionStatus == false)
        {
            StartCoroutine(LionStart());
        } else if(lionStatus == true)
        {
            StartCoroutine(LionStop());
        }
    }

    public void MonkeyClick()
    {
        if(monkeyStatus == false)
        {
            StartCoroutine(MonkeyStart());
        } else if(monkeyStatus == true)
        {
            StartCoroutine(MonkeyStop());
        }
    }


    IEnumerator DuckStart()
    {
        UnityWebRequest messUpdate = UnityWebRequest.Get(duckOn);
        yield return messUpdate.SendWebRequest();
        duckStatus = true;
    }

    IEnumerator DuckStop()
    {
        UnityWebRequest messUpdate = UnityWebRequest.Get(duckOff);
        yield return messUpdate.SendWebRequest();
        duckStatus = false;
    }

    IEnumerator LionStart()
    {
        UnityWebRequest messUpdate = UnityWebRequest.Get(lionOn);
        yield return messUpdate.SendWebRequest();
        lionStatus = true;
    }

    IEnumerator LionStop()
    {
        UnityWebRequest messUpdate = UnityWebRequest.Get(lionOff);
        yield return messUpdate.SendWebRequest();
        lionStatus = false;
    }

    IEnumerator MonkeyStart()
    {
        UnityWebRequest messUpdate = UnityWebRequest.Get(monkeyOn);
        yield return messUpdate.SendWebRequest();
        monkeyStatus = true;
    }

    IEnumerator MonkeyStop()
    {
        UnityWebRequest messUpdate = UnityWebRequest.Get(monkeyOff);
        yield return messUpdate.SendWebRequest();
        monkeyStatus = false;
    }
}
