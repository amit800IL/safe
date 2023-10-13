using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class GroundingLevelButton : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private FillingPot fillingPot;
    public Transform pouringSpot;                           // The top of the pot

    [Space, Header("Movement Variables")]
    [SerializeField] private float moveSpeed            = 40.0f;        // Speed of movement.
    [SerializeField] private float stoppingDistance     = 5.0f; // Distance at which movement stops.
    
    [Space, Header("Movement Variables")]
    [SerializeField] private float timeBetweenReachingToDissapearing = 1f;

    [Space, Header("Dissapearing Variables")]
    [SerializeField] private float disappearingSpeed    = 0.2f;        // Speed of movement.


    private bool isMoving = false;

    private bool isDissolving = false;
    private Button myButton;
    
    private void Awake() {
        myButton = GetComponent<Button>();

        myButton.onClick.AddListener(() => StartMovingTowardsPot());
    }
    /// <summary>
    /// available as an OnClick event for the button.
    /// </summary>
    public void StartMovingTowardsPot(){
        isMoving = true;

        myButton.interactable = false;
        myButton.transition = Selectable.Transition.ColorTint;
    }
    

    private void Update() {
        if (isMoving){
            MoveTowardsDestination(Time.deltaTime);
        }
        if (isDissolving){
            DisappearImage(Time.deltaTime);
        }
    }

    /// <summary>
    /// after set ammount of time
    /// let the filling pot know sand should fall, and start hiding the image
    /// </summary>
    IEnumerator StartDissolvingCoroutine(){
        yield return new WaitForSecondsRealtime(timeBetweenReachingToDissapearing);

        fillingPot.DissolveIntoPot();
        isDissolving = true;
    }

    /// <summary>
    /// moving the object in the direction of the pouring spot in moveSpeed speed.
    /// </summary>
    /// <param name="deltaTime"> the deltaTime to lean on (can be changed to Time.fixedDeltaTime if necc) </param>
    void MoveTowardsDestination(float deltaTime)
    {
        Vector3 direction = pouringSpot.position - transform.position;

        // Check if the object has reached the target.
        if (direction.magnitude <= stoppingDistance)
        {
            isMoving = false; // stop moving
            StartCoroutine(StartDissolvingCoroutine());
            return;
        }

        // Normalize the direction vector and move the object.
        transform.position += direction.normalized * moveSpeed * deltaTime;
    }


    /// <summary>
    /// slowly hide image until button should be deleted
    /// </summary>
    /// <param name="deltaTime"></param>
    void DisappearImage(float deltaTime){
        ColorBlock buttonColors = myButton.colors;

        var newColor = buttonColors.disabledColor;
        newColor.a -= disappearingSpeed * deltaTime;
        
        buttonColors.disabledColor = newColor;
        myButton.colors = buttonColors;

        if (newColor.a <= 0){
            Destroy(gameObject);
        }
    }







}
