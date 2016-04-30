using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WelcomeToTheFruitBowl.Engine
{
    public class Texture
    {
        public Vector2 Position;

        private Texture2D texture { get; set; }
        private float scale { get; set; }

        public float Rotation { get; set; }

        public float Width => texture.Width * scale;
        public float Height => texture.Height * scale;

        public float Left
        {
            get
            {
                return Position.X;
            }
            set
            {
                Position.X = value;
            }
        }

        public float Right
        {
            get
            {
                return Position.X + Width;
            }
            set
            {
                Position.X = value - Width;
            }
        }

        public float Top
        {
            get
            {
                return Position.Y;
            }
            set
            {
                Position.Y = value;
            }
        }

        public float Bottom
        {
            get
            {
                return Position.Y + Height;
            }
            set
            {
                Position.Y = value - Height;
            }
        }

        public Texture(Texture2D texture, Vector2 position, float scale, float rotation)
        {
            this.texture = texture;
            this.Position = position;
            this.scale = scale;

            Rotation = rotation;
        }

        public Texture(Texture2D texture, Vector2 position, float scale) : this(texture, position, scale, 1f) { }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, null, Color.White, Rotation, Vector2.Zero, scale, SpriteEffects.None, 0f);
        }
    }
}
