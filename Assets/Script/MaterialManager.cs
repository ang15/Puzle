using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialManager : MonoBehaviour
{
    public List<Sprite> materials;
    public static MaterialManager instanse;
    public int materialCount => materials.Count;
    
    public void Awake()
    {
        instanse = this;
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
