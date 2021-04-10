using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject TestObject;
    private bool clicked = false;

    private GameObject currentplacableObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (TestObject != null)
            {
                clicked = true;
            }
        }

        if (clicked)
        {
            mooveCurrentObjectToMouse();
            clicked = false;
            Debug.Log("CALL FOCNTION");
        }

    }

    private void mooveCurrentObjectToMouse()
    {

        //TEST1
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfos;
        if (Physics.Raycast(ray, out hitInfos))
        {
            if (hitInfos.collider.tag == "Socle")
            {
                Vector3 posPlacable = hitInfos.collider.transform.position + new Vector3(0,0, -2);
                currentplacableObject = Instantiate(TestObject, posPlacable, Quaternion.identity);
                Debug.Log("INSTANCIATE");
            }
        }

    }
}
