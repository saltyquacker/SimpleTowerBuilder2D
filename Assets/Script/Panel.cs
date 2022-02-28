using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    private BoxCollider2D collider;
    private Rigidbody2D body;

    private Vector3 thisLocation;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(GlobalVar.squareCount);
    }

    // Update is called once per frame
    void Update()
    {
        thisLocation = transform.position;
        Debug.Log("Previous Target: " + GlobalVar.targetMin + " - " + GlobalVar.targetMax);

        //Debug.Log(name + " THISlocation: " + thisLocation + " - " + transform.position.x);




        if (GlobalVar.targetMin >= transform.position.x && GlobalVar.targetMax <= transform.position.x)
        {
            Debug.Log(name + "is IN at location: " + transform.position);


            GetComponent<SpriteRenderer>().color = Color.black;
        }
        else
        {
            Debug.Log(name + "is OUT at location: " + transform.position);

        }
        //GetComponent<Panel>().enabled = false;

    }
    //void OnTriggerEnter2D(Collider2D collision)
    //{
    //    thisLocation = transform.position;
    //    Debug.Log("Previous Target: " + GlobalVar.targetMin + " - " + GlobalVar.targetMax);
       
    //    //Debug.Log(name + " THISlocation: " + thisLocation + " - " + transform.position.x);

    


    //    if (GlobalVar.targetMin <= transform.position.x && GlobalVar.targetMax >= transform.position.x)
    //    {
    //        Debug.Log(name + "is IN at location: " + transform.position.x + " - ");

        
    //        GetComponent<SpriteRenderer>().color = Color.black;
    //    }
    //    else
    //    {
    //        Debug.Log(name + "is OUT at location: " + transform.position.x + " - ");

    //    }


    //}
    
}
