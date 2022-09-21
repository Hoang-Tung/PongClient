//------------------------------------------------------
// 
// Copyright - (c) - 2014 - Mille Boström 
//
// Youtube channel - http://www.speedcoding.net
//------------------------------------------------------

using System;

namespace Pong.MyEventArgs
{
    class KickEnemyEventArgs : EventArgs
    {
        public int UniqueId { get; set; }

        public KickEnemyEventArgs(int uniqueId)
        {
            UniqueId = uniqueId;
        }
    }
}
