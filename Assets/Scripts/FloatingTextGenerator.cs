using UnityEngine;

static public class FloatingTextGenerator
{
    static readonly int MAX_SIZE = 95;
    static readonly int MIN_SIZE = 40;
    static readonly int ACTION_TEXT_SIZE = 35;
    static Color critColor = new(0.67f, 0.06f, 0.06f);
    static Color healColor = new(0.5f, 0.72f, 0.09f);
    static Color actionColor = new(0.75f, 0.75f, 0.75f);

    public static FloatingText CreateText(Vector3 pos, string text, Color color, int randScale = 1)
    {
        // offset
        pos += Vector3.up * 2;
        Vector3 randomOffsetVec = Random.onUnitSphere * randScale;
        pos += new Vector3(randomOffsetVec.x, 0f, randomOffsetVec.z);

        var newText = GameObject.Instantiate(Resources.Load<GameObject>("FloatingText"), pos, Camera.main.transform.rotation).GetComponent<FloatingText>();
        newText.SetColor(color);
        newText.SetText(text);

        return newText;
    }
}
