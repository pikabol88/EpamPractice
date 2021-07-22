using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CustomizationPanelController : MonoBehaviour
{
    [SerializeField] private ToggleGroup _toggleGroup;    
    [SerializeField] private GameObject _bat;

    [SerializeField] private string[] _materialNames;
    [SerializeField] private Material[] _materials;
    private Dictionary<string, Material> _customizationList = new Dictionary<string, Material>();

    private void Start()
    {
        for (int i = 0; i< _materialNames.Length; i++)
        {
            _customizationList.Add(_materialNames[i], _materials[i]);
        }
    }
    public void ChangeColor()
    {
        Toggle theActiveToggle = _toggleGroup.ActiveToggles().FirstOrDefault();
        Material material = _customizationList[theActiveToggle.gameObject.name];
        if (material == null)
        {
            Debug.LogError("Selected material does not exist");
        }
        else
        {
            _bat.GetComponent<SkinnedMeshRenderer>().material = material;
        }
    }


}
