using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong.Components
{
    class ViewPoint : Componentss
    {
        public override ComponentType ComponentType
        {
            get { return ComponentType.Name; }
        }

        private SpriteFont _font;

        public ViewPoint(SpriteFont font)
        {
            _font = font;
        }

        public override void Update(double gameTime)
        {
            
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            var sprite = GetComponent<Sprite>(ComponentType.Sprite);
            if (sprite == null)
                return;
            var i = GetOwnerId();
            spritebatch.DrawString(_font, string.Format("<{0}>", GetUserPoint()), new Vector2(sprite.Position.X + 10, sprite.Position.Y - 10), Color.Black);
        }


    }
}
