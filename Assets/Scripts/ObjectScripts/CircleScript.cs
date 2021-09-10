using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CircleScript : MonoBehaviour
{
    public delegate void CircleEvent(GameObject gameObject, bool isTapEvent);
    public event CircleEvent CircleEventNotify;

    public float Size { get; set; }
    public float SizeChangeInSecond { get; set; }
    public float ColorChangeFloat { get; set; }
    public int Order { get; set; }

    public Vector2 Center { get; set; }

    private void Awake()
    {
        NumberText = transform.Find("Number");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSpent += Time.deltaTime;
        Size -= SizeChangeInSecond * Time.deltaTime;
        ApplyNewSize();
        GetComponent<Image>().color = Color.Lerp(Color.green, Color.red, timeSpent * ColorChangeFloat);
        if (Size < 10)
        {
            CircleEventNotify?.Invoke(this.gameObject, false);
        }
    }

    public void SetModel(Level level, float size, int order, float posX, float posY)
    {
        Size = size;
        Center = new Vector2(posX, posY);
        SizeChangeInSecond = level.SizeChangeInSecondCircle;
        Order = order;
        NumberText.GetComponent<TextMeshProUGUI>().text = Order.ToString();
        ApplyNewSize(true);
        timeSpent = 0.0f;
    }

    public void OnTap()
    {
        CircleEventNotify?.Invoke(this.gameObject, true);
    }

    private void ApplyNewSize(bool isFromSetModel = false)
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(Size, Size);
        NumberText.GetComponent<RectTransform>().sizeDelta = new Vector2(Size, Size);
        if (isFromSetModel) NumberText.GetComponent<TextMeshProUGUI>().fontSize -= (214 - Size) / 4.28f;
        else NumberText.GetComponent<TextMeshProUGUI>().fontSize -= 10 * Time.deltaTime;
        ColorChangeFloat = (SizeChangeInSecond + 3.5f) / Size;
    }

    private float timeSpent;
    private Transform NumberText;
}
