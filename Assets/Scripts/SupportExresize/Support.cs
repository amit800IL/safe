using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Support : MonoBehaviour
{
    [SerializeField] private Button writeButton;
    private const int maxCharchters = 1000;


    private void Start()
    {
        writeButton.onClick.AddListener(WriteText);
    }

    public void WriteText()
    {
        TouchScreenKeyboard.Open(" ", TouchScreenKeyboardType.Default);
    }


}
