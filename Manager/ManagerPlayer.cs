﻿using System.Collections.Generic;
using System.Linq;
using Pong.Components;
using LetsCreateNetworkGame.OpenGL.Library;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Pong.Component;

namespace Pong.Manager
{
    class ManagerPlayers
    {
        private List<BaseObject> _players;
        private ManagerNetwork _managerNetwork;
        private Texture2D _texture;
        private SpriteFont _font;

        public ManagerPlayers(ManagerNetwork managerNetwork)
        {
            _players = new List<BaseObject>();
            _managerNetwork = managerNetwork;
            managerNetwork.PlayerUpdateEvent += PlayerUpdate;
            managerNetwork.KickPlayerEvent += KickPlayerUpdate;
        }

        void KickPlayerUpdate(object sender, MyEventArgs.KickPlayerEventArgs e)
        {
            var itemToRemove = _players.Single(p => p.Username == e.Username);
            var sprite = itemToRemove.GetComponent<Sprite>(ComponentType.Sprite);
            sprite.RemoveMe();
        }

        void PlayerUpdate(object sender, MyEventArgs.PlayerUpdateEventArgs e)
        {
            foreach (var player in e.Players)
            {
                var baseObject = _players.FirstOrDefault(b => b.Username == player.Username);
                if (baseObject != null)
                {
                    var sprite = baseObject.GetComponent<Sprite>(ComponentType.Sprite);
                    sprite.UpdatePosition(player, e.CameraUpdate);
                }
                else
                {
                    CreateObject(player);
                }
            }
        }

        private void CreateObject(Player player)
        {
            var baseObject = new BaseObject { Username = player.Username };
            baseObject.AddComponent(new Sprite(_texture, 32, 32, new Vector2(player.Position.ScreenXPosition, player.Position.ScreenYPosition), Color.White, player.Position.Visible));
            baseObject.AddComponent(new MyAnimation(16, 16, 2));
            if (player.Username == _managerNetwork.Username)
            {
                baseObject.AddComponent(new MainPlayer(_managerNetwork));
            }
            else
            {
                baseObject.AddComponent(new Name(_font));
            }
            _players.Add(baseObject);
        }

        public void LoadContent(ContentManager content)
        {
            _texture = content.Load<Texture2D>("Octorok");
            _font = content.Load<SpriteFont>("font");
        }

        public void Update(double gameTime)
        {
            foreach (var baseObject in _players)
            {
                baseObject.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var baseObject in _players)
            {
                baseObject.Draw(spriteBatch);
            }
        }
    }
}
