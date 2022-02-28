using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Bson;
public class PlayerData
{
    public ObjectId _id;
    public string username;
    public int score;
    public string datetime;


    public string Stringify()
    {
        return JsonUtility.ToJson(this);
    }

    public static PlayerData Parse(string json)
    {
        return JsonUtility.FromJson<PlayerData>(json);
    }
}


