using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PostLetter : MonoBehaviour
{
    //private string secretKey = "123456";
    public string addLetterValue = "http://localhost/LetterPost.php";

    public void Start()
    {
        StartCoroutine(Post_Letter("a", 1));
    }

    /*public void AClick()
    {
        //Click A button
        Post_Letter("a", 1);
    }*/


    IEnumerator Post_Letter(string letter, int value)
    {
        Debug.Log(value);
        //string hash = Md5Sum(letter + value + secretKey);
        WWWForm form = new WWWForm();        
        form.AddField("letterPost", letter);
        form.AddField("valuePost", value);
        //form.AddField("hashPost", hash);
        WWW www = new WWW(addLetterValue, form);
        yield return www;
    }

    
    public string Md5Sum(string strToEncrypt)
    {
        System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
        byte[] bytes = ue.GetBytes(strToEncrypt);
        // encrypt bytes
        System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] hashBytes = md5.ComputeHash(bytes);
        // Convert the encrypted bytes back to a string (base 16)
        string hashString = "";
        for (int i = 0; i < hashBytes.Length; i++)
        {
            hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
        }
        return hashString.PadLeft(32, '0');
    }
}
