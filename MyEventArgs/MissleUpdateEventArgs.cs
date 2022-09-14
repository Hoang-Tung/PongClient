//------------------------------------------------------
// 
// Copyright - (c) - 2014 - Mille Boström 
//
// Youtube channel - http://www.speedcoding.net
//------------------------------------------------------

using System;
using System.Collections.Generic;
using LetsCreateNetworkGame.OpenGL.Library;

namespace Pong.MyEventArgs
{
    class MissleUpdateEventArgs : EventArgs
    {
        public List<Missle> Missles { get; set; }
        public bool CameraUpdate { get; set; }

        public MissleUpdateEventArgs(List<Missle> missles, bool cameraUpdate)
        {
            Missles = missles;
            CameraUpdate = cameraUpdate;
        }

    }
}