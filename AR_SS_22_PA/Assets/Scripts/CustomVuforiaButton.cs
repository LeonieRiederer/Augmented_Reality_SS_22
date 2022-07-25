using UnityEngine;
using UnityEngine.Events;
using Vuforia;

/// <summary>
/// Custom class for the holding event
/// </summary>
[System.Serializable]
public class HoldingEvent : UnityEvent<float> {}

/// <summary>
/// Helper class to extend the standard functionality
/// of the virtual button from vuforia
/// </summary>
public class CustomVuforiaButton : MonoBehaviour
{
    /// <summary>
    /// Unity Event Triggers
    /// </summary>
	public UnityEvent onPress;
	public HoldingEvent onHolding;
    public UnityEvent onLongPress;
    public UnityEvent onRelease;

    /// <summary>
    /// Time to wait till the long press event is fired
    /// </summary>
    public float longPressTime = 2;

    /// <summary>
    /// Reference to the vuforia virtual button script
    /// </summary>
	private VirtualButtonBehaviour btn;

    /// <summary>
    /// Flag if button currently pressed
    /// </summary>
	private bool isPressed;

    /// <summary>
    /// Save the time when button was pressed down
    /// </summary>
    private float pressStartTime;

    /// <summary>
    /// Flag that stores if the long press event
    /// was already fired
    /// </summary>
    private bool longPressFired = false;

	void Start()
	{
        onHolding.Invoke(0);
        btn = GetComponent<VirtualButtonBehaviour>();
		btn.RegisterOnButtonPressed(OnButtonPressed);
        btn.RegisterOnButtonReleased(OnButtonReleased);
    }

	void Update()
	{
		if (isPressed) 
        {
            float progress = (Time.time - pressStartTime) / longPressTime;
            onHolding.Invoke(progress);

            // Fire long press event: when wait time is reached and not already fired
            if(Time.time - pressStartTime > longPressTime && !longPressFired) 
            {
                onLongPress.Invoke();
                longPressFired = true;
            }
        }        
	}

	public void OnButtonPressed(VirtualButtonBehaviour vb)
	{
        onPress.Invoke();
        pressStartTime = Time.time;
        isPressed = true;
    }

	public void OnButtonReleased(VirtualButtonBehaviour vb)
	{
        onHolding.Invoke(0);
        onRelease.Invoke();
        isPressed = false;
        longPressFired = false;
    }
}