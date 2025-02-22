using System;
using System.Drawing;
using System.Threading.Tasks;
using Blazor.Extensions.Canvas.Canvas2D;

namespace P5.Core.Components
{
    public class SpriteRenderComponent : BaseComponent,IRenderable
    {
        private readonly Transform _transform;

        public SpriteRenderComponent(Sprite sprite, GameObject owner) : base(owner)
        {
            Sprite = sprite ;

            _transform = owner.Components.Get<Transform>() ??
                         throw new AccessViolationException("Transform component is required");
        }

        public async ValueTask Render(Canvas2DContext context)
        {
            double i = _transform.Direction.X;
            await context.SetGlobalCompositeOperationAsync("source-over");
            await context.ScaleAsync(i,1);
            await context.DrawImageAsync(Sprite.SpriteSheet,i* _transform.Position.X, _transform.Position.Y,
                i*Sprite.Size.Width, Sprite.Size.Height);
            await context.ScaleAsync(i,1);
        }

        public Sprite Sprite { get; }


    }
}