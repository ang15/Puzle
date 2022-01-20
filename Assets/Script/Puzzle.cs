using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Puzzle : MonoBehaviour
{
    public int numberMaterial;
    public int x;
    public int y;

    private void OnMouseDown()
    {
        GameManager.instance.OnPuzzleClick(this);

    }


    public bool isSame(Puzzle puzzle)
    {
        return numberMaterial == puzzle.numberMaterial;
    }

    public void setMateral(int materialIndex)
    {
        GetComponent<Image>().sprite = MaterialManager.instanse.materials[materialIndex];
        numberMaterial = materialIndex;
    }


}
