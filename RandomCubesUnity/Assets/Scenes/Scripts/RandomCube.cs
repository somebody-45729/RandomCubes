/****
 * Created By: Kyunghoon Han
 * Date Created: 1/24/2022
 * 
 * Last Edited By: Kyunghoon Han
 * Lasted Edited: 1/24/2022
 * 
 * Description: Multiple Cube prefabs will spawn into the scene
 *
 *****/





using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCube : MonoBehaviour
{
    public GameObject cubePrefab; // new GameObject
    public float scalingFactor = 0.95f; //amount each cube will shrink
    public int numberOfCubes = 0; // Total number of cubes instatied

    [HideInInspector] // "attribute" that hides the object but still accessible by code
    public List<GameObject> gameObjectList; // List for all the cubes


    // Start is called before the first frame update
    void Start()
    {
        gameObjectList = new List<GameObject>(); // instatates the list
    }

    // Update is called once per frame
    void Update()
    {
        numberOfCubes++; // add to the number of cubes

        GameObject gObj = Instantiate<GameObject>(cubePrefab); // creates cube instance

        gObj.name = "Cube" + numberOfCubes; // name of cube instance

        Color randColor = new Color(Random.value, Random.value, Random.value); // create a random color
        gObj.GetComponent<Renderer>().material.color = randColor; // assigns random color to game object

        gObj.transform.position = Random.insideUnitSphere; // random location inside a sphere radius of 1 out from 0,0,0

        gameObjectList.Add(gObj); // add to list

        List<GameObject> removeList = new List<GameObject>(); // for removed objects

        foreach(GameObject goTemp in gameObjectList) {
            float scale = goTemp.transform.localScale.x; // records current scale
            scale *= scalingFactor; // scale multiplied by scale factor
            goTemp.transform.localScale = Vector3.one * scale; // transform scale

            if(scale <= 0.1f)
            {
                removeList.Add(goTemp);
            } // end if(scale <= 0.1f)

        }// end for each (GameObject goTemp in gameObjectList)

        foreach(GameObject goTemp in removeList)
        {
            gameObjectList.Remove(goTemp); // remove from game object list
            Destroy(goTemp); // destroys game object
           
        } // end for each(GameObject goTemp in removeList)
        Debug.Log(removeList.Count); // debugs the remove list
    }
    // Derived from page 83 of book
}
