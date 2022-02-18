using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TestScripts : MonoBehaviour
{

    public ScrollView m_ScrollView;
    
    // Start is called before the first frame update
    void Start()
    {
        var comp = gameObject.GetComponentInChildren<MaskableGraphic>();
        if (comp != null) 
            comp.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
