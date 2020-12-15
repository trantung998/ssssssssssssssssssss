using UnityEngine;

namespace ServerSide.Battle
{
    public static class Constants
    {
        public static int FPS = 10;
        public static float TimePerFrame = 1f / FPS;
        public static float MaxX = 3.0f;
        public static float MaxY = 5.0f;
        public static Bounds BattleGroundBound = new Bounds(Vector3.zero, new Vector3(MaxX, MaxY));
    }
}