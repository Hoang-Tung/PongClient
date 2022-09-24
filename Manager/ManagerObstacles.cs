using System.Collections.Generic;
using System.Linq;
using Pong.Components;
using LetsCreateNetworkGame.OpenGL.Library;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Pong.Component;

namespace Pong.Manager
{
    class ManagerObstacles
    {
        private List<BaseObject> _obstacles;
        private ManagerNetwork _managerNetwork;
        private Texture2D _texture;
        private SpriteFont _font;

        public ManagerObstacles(ManagerNetwork managerNetwork)
        {
            _obstacles = new List<BaseObject>();
            _managerNetwork = managerNetwork;
            managerNetwork.ObstacleUpdateEvent += ObstacleUpdate;
        }


        void ObstacleUpdate(object sender, MyEventArgs.ObstacleUpdateEventArgs e)
        {
            foreach (var obstacle in e.Obstacles)
            {
                var baseObject = _obstacles.FirstOrDefault(b => b.Username == obstacle.UniqueId.ToString());
                if (baseObject != null)
                {
                    var sprite = baseObject.GetComponent<Sprite>(ComponentType.Sprite);
                    sprite.UpdatePosition(obstacle, e.CameraUpdate);
                }
                else
                {
                    CreateObject(obstacle);
                }
            }
        }

        private void CreateObject(Obstacle obstacle)
        {
            var baseObject = new BaseObject { Username = obstacle.UniqueId.ToString() };
            baseObject.AddComponent(new Sprite(_texture, 32, 32, new Vector2(obstacle.Position.ScreenXPosition, obstacle.Position.ScreenYPosition), Color.White, obstacle.Position.Visible));
            baseObject.AddComponent(new MyAnimation(32, 32, 2));
            //Later we add specific component for enemies here.
            _obstacles.Add(baseObject);
        }

        public void LoadContent(ContentManager content)
        {
            _texture = content.Load<Texture2D>("Obstacle");
            _font = content.Load<SpriteFont>("font");
        }

        public void Update(double gameTime)
        {
            foreach (var baseObject in _obstacles)
            {
                baseObject.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var baseObject in _obstacles)
            {
                baseObject.Draw(spriteBatch);
            }
        }
    }
}
