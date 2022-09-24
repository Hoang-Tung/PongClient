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
    class ObstacleUpdateEventArgs : EventArgs
    {
        public List<Obstacle> Obstacles { get; set; }
        public bool CameraUpdate { get; set; }

        public ObstacleUpdateEventArgs(List<Obstacle> obstacles, bool cameraUpdate)
        {
            Obstacles = obstacles;
            CameraUpdate = cameraUpdate;
        }

    }
}
