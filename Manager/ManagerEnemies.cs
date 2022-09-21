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
    class ManagerEnemies
    {
        private List<BaseObject> _enemies;//
        private ManagerNetwork _managerNetwork;
        private Texture2D _texture;
        private SpriteFont _font;

        public ManagerEnemies(ManagerNetwork managerNetwork)
        {
            _enemies = new List<BaseObject>();
            _managerNetwork = managerNetwork;
            _managerNetwork.EnemyUpdateEvent += EnemyUpdate;
            _managerNetwork.KickEnemyEvent += KickEnemyUpdate;
        }

        void KickEnemyUpdate(object sender, MyEventArgs.KickEnemyEventArgs e)
        {
            var itemToRemove = _enemies.Single(p => p.Username == e.UniqueId.ToString());
            var sprite = itemToRemove.GetComponent<Sprite>(ComponentType.Sprite);
            sprite.HideSprite();
        }

        void EnemyUpdate(object sender, MyEventArgs.EnemyUpdateEventArgs e)
        {
            foreach (var enemy in e.Enemies)
            {
                var baseObject = _enemies.FirstOrDefault(en => en.Username == enemy.UniqueId.ToString());
                if (baseObject != null)
                {
                    var sprite = baseObject.GetComponent<Sprite>(ComponentType.Sprite);
                    sprite.UpdatePosition(enemy, e.CameraUpdate);
                }
                else
                {
                    CreateObject(enemy);
                }
            }
        }

        private void CreateObject(Enemy enemy)
        {
            var baseObject = new BaseObject { Username = enemy.UniqueId.ToString() };
            baseObject.AddComponent(new Sprite(_texture, 32, 32, new Vector2(enemy.Position.ScreenXPosition, enemy.Position.ScreenYPosition), Color.Black, enemy.Position.Visible));
            baseObject.AddComponent(new MyAnimation(16, 16, 2));
            //Later we add specific component for enemies here.
            _enemies.Add(baseObject);
        }

        public void LoadContent(ContentManager content)
        {
            _texture = content.Load<Texture2D>("Octorok");
            _font = content.Load<SpriteFont>("font");
        }

        public void Update(double gameTime)
        { 
            foreach (var baseObject in _enemies)
            {    
                baseObject.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var baseObject in _enemies)
            {  
               baseObject.Draw(spriteBatch);
            }
        }
    }
}
