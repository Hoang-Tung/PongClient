//------------------------------------------------------
// 
// Copyright - (c) - 2014 - Mille Boström 
//
// Youtube channel - http://www.speedcoding.net
//------------------------------------------------------

using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Pong
{
    public class BaseObject
    {
        public string Username { get; set; }
        public bool Kill { get; set; }

        public int point { get; set; }

        private readonly List<Componentss> _components;

        public BaseObject()
        {
            _components = new List<Componentss>();
            Kill = false;
        }

        public TComponentType GetComponent<TComponentType>(ComponentType componentType) where TComponentType : Componentss
        {
            return _components.Find(c => c.ComponentType == componentType) as TComponentType;
        }

        public void AddComponent(Componentss component)
        {
            _components.Add(component);
            component.Initialize(this);
        }

        public void AddComponent(List<Componentss> components)
        {
            _components.AddRange(components);
            foreach (var component in components)
            {
                component.Initialize(this);
            }
        }

        public void RemoveComponent(Componentss component)
        {
            _components.Remove(component);

        }

        public virtual void Update(double gameTime)
        {
            foreach (var component in _components)
            {
                component.Update(gameTime);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            foreach (var component in _components)
            {
                component.Draw(spriteBatch);
            }
        }


        public void Initialize()
        {
            if (_components == null)
                return;
            _components.ForEach(c => c.Initialize());
        }

        public void Uninitialize()
        {
            if (_components == null)
                return;
            _components.ForEach(c => c.Uninitalize());
        }
    }
}



