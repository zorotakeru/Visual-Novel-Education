using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemCount : MonoBehaviour
{
    public int count = 0;
    public Text counter;
    // Start is called before the first frame update
    void Start()
    {

        counter.text = "" + count + "";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setCount()
    {
        this.count += 1;
        counter.text = "" + count + "";
    }
}
