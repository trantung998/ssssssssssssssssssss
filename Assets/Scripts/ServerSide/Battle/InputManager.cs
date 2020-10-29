using ServerSide.Services;

namespace ServerSide.Battle
{
    public class InputData
    {
        public short InputType;
    }

    public class SpawnTroopInput : InputData
    {
        public int TroopIndex;
    }

    //chỗ nhận input
    public class InputManager
    {
        public InputManager()
        {
        }

        public void OnGetUserInput(InputData data)
        {
            
        }
    }
}