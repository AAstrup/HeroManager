using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CardVisual
{

    public GameObject GB;
    public RectTransform rect;
    public Dictionary<string, Image> Images;
    public Dictionary<string, Text> Texts;

    public CardVisual(GameObject cardGameObject)
    {
        Images = new Dictionary<string, Image>();
        Texts = new Dictionary<string, Text>();

        GB = cardGameObject;
        rect = GB.GetComponent<RectTransform>();
        GB.GetComponentsInChildren<Image>().ToList().ForEach(typ => Images.Add(typ.name,typ));
        GB.GetComponentsInChildren<Text>().ToList().ForEach(typ => Texts.Add(typ.name, typ));
    }

}
