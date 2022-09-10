//------------------------------------------------------
// 
// Copyright - (c) - 2014 - Mille Boström 
//
// Youtube channel - http://www.speedcoding.net
//------------------------------------------------------

using System;

namespace Pong.MyEventArgs
{
    class KickPlayerEventArgs : EventArgs
    {
        public string Username { get; set; }

        public KickPlayerEventArgs(string username)
        {
            Username = username;
        }
    }
}
