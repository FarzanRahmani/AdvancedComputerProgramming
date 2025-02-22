using System.Drawing;
using System.Numerics;
using System.Threading.Tasks;

namespace P5.Core.Components
{
    public class Transform : BaseComponent // madar
    {
        public Transform(GameObject owner) : base(owner) 
        {// Constructor bache constructor mamano seda mizane
        }

        public Vector2 Position { get; set; } = Vector2.Zero;
        public Vector2 Direction { get; set; } = Vector2.One;
        public Size Size { get; set; } = Size.Empty;

    }
}