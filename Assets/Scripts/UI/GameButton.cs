using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    bool hasButtonBeenPressed = false;

    [SerializeField] private Button gameButton;
    [SerializeField] private Sprite clickedSprite;
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite hoverSprite;

    public void ButtonPressState()
    {
        if (gameButton.interactable)
        {
            if (!hasButtonBeenPressed)
            {
                gameButton.image.sprite = clickedSprite;

                hasButtonBeenPressed = true;
            }
            else
            {
                gameButton.image.sprite = normalSprite;

                hasButtonBeenPressed = false;
            }
        }
    }

    public void ButtonOnHoverStart()
    {
        if (gameButton.interactable)
        {
            gameButton.image.sprite = hoverSprite;
        }
    }

    public void ButtonOnHoverFinish()
    {
        if (gameButton.interactable)
        {
            gameButton.image.sprite = normalSprite;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ButtonOnHoverStart();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ButtonOnHoverFinish();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ButtonPressState();
    }
}
