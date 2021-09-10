using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class InputManager : MonoBehaviour
{
    private void Awake()
    {
        EnhancedTouchSupport.Enable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            if (UnityEngine.InputSystem.EnhancedTouch.Touch.activeFingers.Count == 1)
            {
                //получаем тач
                UnityEngine.InputSystem.EnhancedTouch.Touch activeTouch = UnityEngine.InputSystem.EnhancedTouch.Touch.activeFingers[0].currentTouch;

                //получаем hit и коллайдер объекта, по которому тапнули
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(activeTouch.startScreenPosition), Vector2.zero);
                var collider = hit.collider;

                //если коллайдер есть
                if (collider != null)
                {
                    if (collider.gameObject.tag.Contains("Circle"))
                    {
                        var circleScript = collider.gameObject.GetComponent<CircleObjectScript>();
                        circleScript.OnTap();
                    }
                    if (collider.gameObject.tag.Contains("Coin"))
                    {
                        var coinScript = collider.gameObject.GetComponent<CoinObjectScript>();
                        coinScript.OnTap();
                    }
                }
            }
        }
    }
}
