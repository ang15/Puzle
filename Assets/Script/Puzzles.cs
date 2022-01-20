using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzles : MonoBehaviour
{
    [SerializeField]
    private Puzzle puzzlePrefab;
    public Puzzle[,] pozitionPuzzles;
    //public int[] pozitionX;
    //public int[] pozitiony;
    public int kol = 4;
    [SerializeField]
    private float Spacing;
    public bool CanClick = true; 
    //  private bool canGame = false;
    [SerializeField]
    private Text textMoves;
    public int moves = 100000;
    public int NullPuzzleX;
    public int NullPuzzleY;
    public Puzzle NullPuzzle;
    [SerializeField]
    private int i = 0;
    public GameObject Won;
    // Start is called before the first frame update
    void Start()
    {
        CreateField();

    }

    void Update()
    {
        //textMoves.text = "" + moves;
        //if (moves == 0)
        //{
        //    CanClick = false;
        //}
        //for (int j = i; j < 100; j++)
        //{
        //    int a = Random.Range(1, 5);
        //    Debug.Log(a);
        //    if (a == 1 && NullPuzzle.x + 1 < kol)
        //    {
        //        Debug.Log("NullPuzzle.x + 1");
        //        GameManager.instance.OnStart(pozitionPuzzles[NullPuzzle.x + 1, NullPuzzle.y]);
              
        //        i++;
        //    }
        //    if (a == 2 && NullPuzzle.x - 1 >= 0)
        //    {
        //        Debug.Log("NullPuzzle.x - 1");
        //        GameManager.instance.OnStart(pozitionPuzzles[NullPuzzle.x - 1, NullPuzzle.y]);
        //        i++;
        //    }
        //    if (a == 3 && NullPuzzle.y + 1 < kol)
        //    {
        //        Debug.Log("NullPuzzle.y + 1 ");
        //        GameManager.instance.OnStart(pozitionPuzzles[NullPuzzle.x, NullPuzzle.y + 1]);
        //        i++;
        //    }
        //    if (a == 4 && NullPuzzle.y - 1 >= 0)
        //    {
        //        Debug.Log("NullPuzzle.y - 1 ");
        //        GameManager.instance.OnStart(pozitionPuzzles[NullPuzzle.x, NullPuzzle.y - 1]);
        //        i++;
        //    }
        //    moves = 100;
        //}
    

        if (Win())
        {
            CanClick = false;
            Won.SetActive(true);
        }
    }


    public void Restart( int z)
    {
        i = z;
        Won.SetActive(false);
    }
    public bool Win()
    {
        for (int x = 0; x < kol; x++)
        {
            for (int y = 0; y < kol; y++)
            {
                if (pozitionPuzzles[x, y].x!=x )
                {
                    return false;
                }
                else if (pozitionPuzzles[x, y].y != y)
                {
                    return false;
                }

            }
        }
        return true;
    }
    public void CreateField()
    {
        pozitionPuzzles = new Puzzle[kol, kol];
        float fieldWidth = Screen.width - 30;
        var cellSize = (fieldWidth - (Spacing * (kol)) - Spacing) / (kol);

        float fieldHeight = (cellSize * (kol)) + (Spacing * (kol)) + Spacing;

        float startX = -(fieldWidth / 2) + (cellSize / 2) + Spacing;
        float startY = (fieldHeight / 2) - (cellSize / 2) - Spacing;

        for (int x = 0; x < kol; x++)
        {
            for (int y = 0; y < kol; y++)
            {
                pozitionPuzzles[x, y] = Instantiate(puzzlePrefab, transform, false);
                var position = new Vector2((startX + (x * cellSize)), (startY - ((kol - y) * (cellSize))));
                pozitionPuzzles[x, y].transform.localPosition = position;
                pozitionPuzzles[x, y].GetComponent<RectTransform>().sizeDelta = new Vector2(cellSize, cellSize);
                var col = pozitionPuzzles[x, y].GetComponent<BoxCollider2D>();
                col.size = new Vector2(cellSize, cellSize);
                pozitionPuzzles[x, y].x = x;
                pozitionPuzzles[x, y].y = y;
            }
        }
        int number = 0;
        for (int x = 0; x < kol; x++)
        {
            for (int y = 0; y < kol; y++)
            {
                pozitionPuzzles[x, y].setMateral(number);
                if (pozitionPuzzles[x, y].numberMaterial == MaterialManager.instanse.materialCount - 1)
                {
                    NullPuzzle = pozitionPuzzles[x, y];
                    NullPuzzleX = x;
                    NullPuzzleY = y;
                }
                number++;

            }
        }

     
    }

    private int setNewMaterialNow()
    {
        int rnd = Random.Range(0, kol*kol);
        while (setMaterial(rnd))
        {
            rnd = Random.Range(0, kol * kol);
        }
        return rnd;
    }

    private bool setMaterial(int rnd)
    {
        for (int x = 0; x < kol; x++)
        {
            for (int y = 0; y < kol; y++)
            {  
                if (pozitionPuzzles[x, y].numberMaterial == rnd)
                {
                 Debug.Log("pozitionPuzzles[x, y].numberMaterial " + pozitionPuzzles[x, y].numberMaterial);
                    return true;
                }
            }
        }
        
        return false;
    }


}
 

