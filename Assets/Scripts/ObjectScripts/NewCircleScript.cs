using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCircleScript : MonoBehaviour
{
    public float Width;
    public float Height;
    public float SizeChangeInSecond;

    private void Awake()
    {
        GetComponent<Transform>().
        GetComponent<RectTransform>().sizeDelta = new Vector2(Width, Height);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
