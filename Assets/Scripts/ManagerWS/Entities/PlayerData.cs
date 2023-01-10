namespace Entities
{
    public class PlayerData
    {
        public int UserID { get; set; }        
        public string ConnectionUUID { get; set; }
        public string Nick { get; set; }

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        
        public float RotationX { get; set; }
        public float RotationY { get; set; }
        public float RotationZ { get; set; }
        public float MouseX { get; set; }
        public float MouseY { get; set; }

    }
}
