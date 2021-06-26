using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgTest : MonoBehaviour
{
    BackgroundController controller;

    public Texture tex;
    public float speed;
    public bool smooth;
    // Start is called before the first frame update
    void Start()
    {
        controller = BackgroundController.instance;
    }

    // Update is called once per frame
    void Update()
    {
        BackgroundController.LAYER layer = null; 
        layer = controller.background;
        if (Input.GetKey(KeyCode.A))
        {
            print("a");
            layer.SetTexture(tex);
        }
    }
}
