namespace Core.Helpers
{
    public static class Vector2Extention
    {
        public static UnityEngine.Vector2 ToUnityVector2(this Vector2 vector)
        {
            return new UnityEngine.Vector2(vector.x, vector.y);
        }

        public static Vector2 ToVector2Model(this UnityEngine.Vector2 vector)
        {
            return new Vector2(vector.x, vector.y);
        }
        
        public static Vector2 ToVector2Model(this UnityEngine.Vector3 vector)
        {
            return new Vector2(vector.x, vector.y);
        }
    }
}