using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class Web : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetMyScores(GlobalVar.currentUser));
    }

    IEnumerator GetMyScores(string currentUsername)
    {
        WWWForm form = new WWWForm();
        form.AddField("currentUser",currentUsername);

        //Request.Get to get info, Request.Post to post info
        using(UnityWebRequest www = UnityWebRequest.Post("http://localhost/GetScore.php",form))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);

            }
            else
            {
                Debug.Log(www.downloadHandler.text);

                
            }

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
