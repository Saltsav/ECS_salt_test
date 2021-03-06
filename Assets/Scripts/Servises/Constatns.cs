namespace ButtonsAndDoors
{
    public class Constatns
    {
        public const float FLOAT_ZERO = 0.0001f;
        public const float OPEN_DOOR_SPEED = 1;

        public const float OPEN_DOOR_DELTA = 2;

        public const float PLAYER_SPEED = 5;
        public const float MIN_DIS_TO_STOP = 0.01f;

        public const float MIN_DIS_TO_ACTIVE = 1f;

        public enum TypeID
        {
            green,
            blue
        }

        public enum ObjectType
        {
            level,
            player,
            door,
            button
        }
    }
}