using System.Collections.Generic;
using System.Linq;
using Pong.Components;
using LetsCreateNetworkGame.OpenGL.Library;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Pong.Component;
using System;

namespace Pong.Manager
{
    class ManagerMissles
    {
        private List<BaseObject> _missles;
        private ManagerNetwork _managerNetwork;
        private Texture2D _texture;
        private SpriteFont _font;

        public ManagerMissles(ManagerNetwork managerNetwork)
        {
            _managerNetwork = managerNetwork;
            _missles = new List<BaseObject>();
            _managerNetwork.MissleUpdateEvent += MissleUpdate;
        }

        void MissleUpdate(object sender, MyEventArgs.MissleUpdateEventArgs e)
        {
            foreach (var missle in e.Missles)
            {
                var baseObject = _missles.FirstOrDefault(mi => mi.Username == missle.UniqueId.ToString());
                if (baseObject != null)
                {
                    var sprite = baseObject.GetComponent<Sprite>(ComponentType.Sprite);
                    sprite.UpdatePosition(missle, e.CameraUpdate);
                }
                else
                {
                    CreateObject(missle);
                }
            }
        }

        private void CreateObject(Missle missle)
        {
            var baseObject = new BaseObject { Username = missle.UniqueId.ToString() };
            baseObject.AddComponent(new Sprite(_texture, 16, 16, new Vector2(missle.Position.ScreenXPosition, missle.Position.ScreenYPosition), Color.Black, missle.Position.Visible));
            baseObject.AddComponent(new MyAnimation(16, 16, 2));
            //Later we add specific component for enemies here.
            _missles.Add(baseObject);
        }

        public void LoadContent(ContentManager content)
        {
            _texture = content.Load<Texture2D>("Octorok_bullet");
            _font = content.Load<SpriteFont>("font");
        }

        public void Update(double gameTime)
        {
            foreach (var baseObject in _missles)
            {
                baseObject.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var baseObject in _missles)
            {
                baseObject.Draw(spriteBatch);
            }
        }
    }
}
