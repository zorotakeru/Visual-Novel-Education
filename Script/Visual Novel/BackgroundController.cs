using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundController : MonoBehaviour
{
    public static BackgroundController instance;

    public LAYER background = new LAYER();
    void Awake()
    {
        instance = this;
    }
    [System.Serializable]
    public class LAYER
    {
        public GameObject root;
        public GameObject newImageObjectReference;
        public RawImage activeImage;
        public List<RawImage> allImages = new List<RawImage>();

        public void SetTexture(Texture texture)
        {
            if (texture != null)
            {
                if (activeImage == null)
                {

                    CreateNewActiveImage();
                }
                else if (activeImage != null)
                {
                    allImages.Remove(activeImage);
                    GameObject.DestroyImmediate(activeImage.gameObject);
                    activeImage = null;
                    CreateNewActiveImage();
                }
                activeImage.texture = texture;
            }
        }

        

        void CreateNewActiveImage()
        {
            GameObject ob = Instantiate(newImageObjectReference, root.transform) as GameObject;
            ob.SetActive(true);
            RawImage raw = ob.GetComponent<RawImage>();
            activeImage = raw;
            allImages.Add(raw);
        }







        //public void TransitionToTexture(Texture texture, float speed = 1f, bool smooth = false)
        //{
        //    if(activeImage != null && activeImage.texture == texture)
        //    {
        //        return;
        //    }

        //    StopTransitioning();
        //    transitioning = BackgroundController.instance.StartCoroutine(Transitioning(texture, speed, smooth));
        //}

        //void StopTransitioning()
        //{
        //    if (isTransitioning)
        //    {
        //        BackgroundController.instance.StopCoroutine(transitioning);
        //    }
        //    transitioning = null;
        //}

        //public bool isTransitioning { get { return transitioning != null; } }
        //Coroutine transitioning = null;
        //IEnumerator Transitioning(Texture texture, float speed, bool smooth)
        //{
        //    if (texture != null)
        //    {
        //        for (int i = 0; i < allImages.Count; i++)
        //        {
        //            RawImage image = allImages[i];
        //            if (image.texture == texture)
        //            {
        //                activeImage = image;
        //                break;
        //            }
        //        }

        //        if (activeImage == null || activeImage.texture != texture)
        //        {
        //            CreateNewActiveImage();
        //            activeImage.texture = texture;
        //            activeImage.color = GlobalFunction.SetAlpha(activeImage.color, 0f);
        //        }
        //    }
        //    else
        //        activeImage = null;

        //    while (GlobalFunction.TransitionRawImages(ref activeImage, ref allImages, speed, smooth))
        //        yield return new WaitForEndOfFrame();

        //    StopTransitioning();
        //}
    }
}
