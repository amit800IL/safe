using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(RTLTextAttribute))]
public class RTLTextDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (property.propertyType == SerializedPropertyType.String)
        {
            string originalText = property.stringValue;

            string displayedText = originalText.IsRTL() ? ReverseString(originalText) : originalText;

            string newText = EditorGUI.TextField(position, label, displayedText);

            property.stringValue = newText;
        }
        else
        {
            EditorGUI.LabelField(position, label.text, "Use [RTLText] with strings.");
        }
    }

    // Method to reverse the string for RTL display
    private string ReverseString(string input)
    {
        char[] charArray = input.ToCharArray();
        System.Array.Reverse(charArray);
        return new string(charArray);
    }
}

// Extension method to check if text is RTL
public static class StringExtensions
{
    public static bool IsRTL(this string text)
    {
        if (string.IsNullOrEmpty(text))
            return false;

        char firstChar = text[0];
        return (firstChar >= 0x600 && firstChar <= 0x6FF) || (firstChar >= 0x0590 && firstChar <= 0x05FF);
    }
}