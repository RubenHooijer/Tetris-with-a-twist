using UnityEngine;


/// <summary>
/// Registrates and acts upon player input
/// </summary>
public class PlayerInput : IupdateMe
{
    public System.Action<float> SpeedChange;
    public System.Action MoveShape;
    public System.Action RotateShape;

    [SerializeField] private float spedUpTimeIncrease = 8f;
    private GameController gameController;

    public PlayerInput(GameController _gameController, float _spedUpTimeIncrease)
    {
        gameController = _gameController;
        spedUpTimeIncrease = _spedUpTimeIncrease;
    }

    public void Update()
    {
        CheckForInput();
    }

    //TODO: Make the keys visible for editing
    private void CheckForInput()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            SpeedChange(spedUpTimeIncrease);
        } else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            SpeedChange(1);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gameController.mainBlockManager.MoveShapeTowards(Direction.Left);
            MoveShape();
        } else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            gameController.mainBlockManager.MoveShapeTowards(Direction.Right);
            MoveShape();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            RotateShape();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameController.mainBlockManager.SetCurrentShape(gameController.shapeSaver.SwapSavedShape(gameController.mainBlockManager.currentShape));

            gameController.mainBlockManager.RespawnShape();
            gameController.mainBlockManager.MoveShapeTowards(Direction.Down);
        }
    }
}
