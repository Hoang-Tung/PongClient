//------------------------------------------------------
// 
// Copyright - (c) - 2014 - Mille Boström 
//
// Youtube channel - http://www.speedcoding.net
//------------------------------------------------------

using Microsoft.Xna.Framework.Graphics;
using LetsCreateNetworkGame.OpenGL.Library;

namespace Pong
{
    public abstract class Componentss
    {
        private BaseObject _baseObject;
        public abstract ComponentType ComponentType { get; }

        public void Initialize(BaseObject baseObject)
        {
            _baseObject = baseObject;
        }

        public string GetOwnerId()
        {
            if (_baseObject == null)
                return "";
            return _baseObject.Username;
        }

        public int GetUserPoint()
        {
            if (_baseObject == null)
                return 0;
            return _baseObject.point;
        }

        public void RemoveMe()
        {
            _baseObject.RemoveComponent(this);
        }

        public void KillBaseObject()
        {
            _baseObject.Kill = true;
        }

        public TComponentType GetComponent<TComponentType>(ComponentType componentType) where TComponentType : Componentss
        {
            return _baseObject == null ? null : _baseObject.GetComponent<TComponentType>(componentType);
        }

        public abstract void Update(double gameTime);
        public abstract void Draw(SpriteBatch spritebatch);

        public virtual void Initialize() { }

        public virtual void Uninitalize() { }

    }
}



