using NaughtyAttributes;
using UnityEngine;

public class FieldRandomizer : MonoBehaviour {

    [System.Serializable]
    public enum SupportedTypes {
        single = 0,
        integer,
        vector2
    }

    public SupportedTypes type;

    public Component component;
    public string field;


    [ShowIf("type", SupportedTypes.single)] public float singleMin, singleMax;

    [ShowIf("type", SupportedTypes.vector2)] public Vector2 vectorMin, vectorMax;

    [ShowIf("type", SupportedTypes.integer)] public int integerMin, integerMax;


    void Start() {
        switch (type) {
            case SupportedTypes.single: {
                    float value = Random.Range(singleMin, singleMax);
                    SetAttribute(field, value);
                    break;
                }
            case SupportedTypes.integer: {
                    int value = Random.Range(integerMin, integerMax);
                    SetAttribute(field, value);
                    break;
                }
            case SupportedTypes.vector2: {
                    float x = Random.Range(vectorMin.x, vectorMax.x);
                    float y = Random.Range(vectorMin.y, vectorMax.y);
                    SetAttribute(field, new Vector2(x, y));
                    break;
                }
        }

    }

    private void SetAttribute(string name, object value) {
        if (string.IsNullOrEmpty(name)) return;
        if (component == null) return;
        if (component.GetType().GetField(name) == null) return;

        component.GetType().GetField(name).SetValue(component, value);
    }


}
