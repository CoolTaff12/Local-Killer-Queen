using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpriteAnimation : MonoBehaviour
{
    public Image myImage;
    public Sprite[] Circles;
    public float framesPerSecond;

    // Use this for initialization
    void Start ()
    {
        myImage = GameObject.Find("Load Circle").GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (myImage != null)
        {
            int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
            index = index % Circles.Length;
            myImage.sprite = Circles[index];
        }
    }
}
