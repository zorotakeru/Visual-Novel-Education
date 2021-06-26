using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    private bool pickUpAllowed = false;
    private ItemCount itemCount;

    private float _currentScale;
    private float TargetScale;
    private float InitScale;
    private int FramesCount = 50;
    private float AnimationTimeSeconds = 1;
    private float _deltaTime;
    private float _dx;
    private bool _upScale = true;
    // Start is called before the first frame update

    void Start()
    {
        sizeScaller();
        itemCount = FindObjectOfType(typeof(ItemCount)) as ItemCount;
        StartCoroutine(Breath());
    }

    

    // Update is called once per frame
    void Update()
    {
        if (pickUpAllowed)
        {
            itemCount.setCount();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player")) ;
        {
            pickUpAllowed = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player")) ;
        {
            pickUpAllowed = false;
        }
    }

    private void sizeScaller()
    {
        InitScale = gameObject.transform.localScale.x;
        TargetScale = InitScale + 0.2f;
        _currentScale = InitScale;
        _deltaTime = AnimationTimeSeconds / FramesCount;
        _dx = (TargetScale - InitScale) / FramesCount;
    }

    private IEnumerator Breath() //https://answers.unity.com/questions/1074165/how-to-increase-and-decrease-object-scale-over-tim.html
    {
        while (true)
        {
            while (_upScale)
            {
                _currentScale += _dx;
                if (_currentScale > TargetScale)
                {
                    _upScale = false;
                    _currentScale = TargetScale;
                }
                gameObject.transform.localScale = Vector3.one * _currentScale;
                yield return new WaitForSeconds(_deltaTime);
            }

            while (!_upScale)
            {
                _currentScale -= _dx;
                if (_currentScale < InitScale)
                {
                    _upScale = true;
                    _currentScale = InitScale;
                }
                gameObject.transform.localScale = Vector3.one * _currentScale;
                yield return new WaitForSeconds(_deltaTime);
            }
        }
    }

}
