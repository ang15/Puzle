using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]
    private Puzzles puzzles;

    private void Awake()
    {
        instance = this;
    }

    public void OnPuzzleClick(Puzzle puzzle)
    {

        if (puzzles.CanClick == true)
        {
            if ((puzzle.x == (puzzles.NullPuzzle.x - 1) && puzzle.y == puzzles.NullPuzzle.y)
              || (puzzle.y == (puzzles.NullPuzzle.y - 1) && puzzle.x == puzzles.NullPuzzle.x)
              || (puzzle.x == (puzzles.NullPuzzle.x + 1) && puzzle.y == puzzles.NullPuzzle.y)
              || (puzzle.y == (puzzles.NullPuzzle.y + 1) && puzzle.x == puzzles.NullPuzzle.x)
              )
            {
                puzzles.CanClick = false;
                StartCoroutine(DownBoxs( puzzle));
            }
        }
    }

    public void OnStart(Puzzle puzzle)
    {
        puzzles.CanClick = false;
        puzzles.CanClick = false;
        int second = puzzles.NullPuzzle.numberMaterial;
        int first = puzzle.numberMaterial;
        float NullPuzzlePozitionX = puzzle.transform.position.x;
        float NullPuzzlePozitionY = puzzle.transform.position.y;
        float NullPuzzlePozitionZ = puzzle.transform.position.z;
        puzzle.transform.position = puzzles.NullPuzzle.transform.position;
        puzzles.NullPuzzle.transform.position = new Vector3(NullPuzzlePozitionX, NullPuzzlePozitionY, NullPuzzlePozitionZ);

        int NullPuzzleX = puzzles.NullPuzzle.x;
        int NullPuzzleY = puzzles.NullPuzzle.y;
        puzzles.NullPuzzle.x = puzzle.x;
        puzzles.NullPuzzle.y = puzzle.y;
        puzzle.x = NullPuzzleX;
        puzzle.y = NullPuzzleY;
        puzzles.CanClick = true;
    }

        IEnumerator DownBoxs(Puzzle puzzle)
    {
            puzzles.moves -= 1;
            puzzles.CanClick = false;
            int second = puzzles.NullPuzzle.numberMaterial;
            int first = puzzle.numberMaterial;
            Debug.Log("ggg");
                yield return new WaitForSeconds(0.3f);
                float NullPuzzlePozitionX = puzzle.transform.position.x;
                 float NullPuzzlePozitionY = puzzle.transform.position.y;
                 float NullPuzzlePozitionZ = puzzle.transform.position.z;
                    puzzle.transform.position = puzzles.NullPuzzle.transform.position;
               puzzles.NullPuzzle.transform.position = new Vector3(NullPuzzlePozitionX, NullPuzzlePozitionY, NullPuzzlePozitionZ);

                int NullPuzzleX = puzzles.NullPuzzle.x;
                int NullPuzzleY = puzzles.NullPuzzle.y;
                puzzles.NullPuzzle.x = puzzle.x;
                puzzles.NullPuzzle.y =puzzle.y;
                puzzle.x = NullPuzzleX;
                puzzle.y = NullPuzzleY;
                puzzles.CanClick = true;
    }
    
}
