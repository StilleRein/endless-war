using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingRotation : MonoBehaviour
{
    float rand;

    // Start is called before the first frame update
    void Start()
    {
        rand = Random.Range(-50f, 50f);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.tag == "Ring 1"){
            transform.Rotate(new Vector3(0, Time.deltaTime * rand, 0));
        }

        else if(transform.tag == "Ring 2"){
            transform.Rotate(new Vector3(Time.deltaTime * 20, Time.deltaTime * 20, Time.deltaTime * 20));
        }

        else if(transform.tag == "Mid Ring"){
            transform.Rotate(new Vector3(Time.deltaTime * 50, 0, 0));
        }
    }
}
