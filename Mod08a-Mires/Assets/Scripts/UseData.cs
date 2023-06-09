using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UseData : MonoBehaviour
{/**
  * Tutorial link
  * https://github.com/tikonen/blog/tree/master/csvreader
  * */

    List<Dictionary<string, object>> data; 
    public GameObject myCube;//prefab
    public int rowCount; //variable 

    float startDelay = 2f;
    float timeInterval = .01f;
    public object tempObject;
    public float tempFloat;

    void Awake()
    {

        data = CSVReader.Read("TestCO2");//udata is the name of the csv file 

        for (var i = 0; i < data.Count; i++)
        {
            //name, age, speed, description, is the headers of the database
            print("xco2 " + data[i]["xco2"] + " ");
        }
        rowCount = 0;


    }//end Awake()

    // Use this for initialization
    void Start()
    {
        /*for (var i = 0; i < data.Count; i++)
        {
            object xco2 = data[i]["xco2"];//get age data
            gameObject.transform.localScale = new Vector3((float)xco2, (float)xco2, (float)xco2);
        
            //
            //  cubeCount += (int)xco2;//convert age data to int and add to cubeCount
            //Debug.Log("cubeCount " +cubeCount);
            //
        }*/

        InvokeRepeating("SpawnObject", startDelay, timeInterval);
    }//end Start()

    // Update is called once per frame
    void Update()
    {
        /*for (var i = 0; i < data.Count; i++)
        {
            object xco2 = data[i]["xco2"];//get age data
            gameObject.transform.localScale = new Vector3((float)xco2, (float)xco2, (float)xco2);
        }
            //As long as cube count is not zero, instantiate prefab
             while (cubeCount > 0)
             {
                 Instantiate(myCube);
                 cubeCount--;
                 Debug.Log("cubeCount" + cubeCount);
             }
            */


        }//end Update()

    void SpawnObject()
    {
        if (rowCount < data.Count) {
        Debug.Log("rowCount: " + rowCount);
        Debug.Log("dataCount: " + data.Count);
        tempObject = (data[rowCount]["xco2"]);
        tempFloat = System.Convert.ToSingle(tempObject);
        tempFloat -= 388f;
        rowCount++;

        transform.localScale = new Vector3(tempFloat, tempFloat, tempFloat);

        Debug.Log("tempFloat: " + tempFloat);
        Debug.Log("tempObject: " + tempObject);
    }
        else
        {
            Debug.Log("Done.");
            Destroy(gameObject);
        }

        /*if (cubeCount > 0)
        {
            Instantiate(myCube);
            cubeCount--;
            Debug.Log("cubeCount " + cubeCount);
        }*/
    }

}