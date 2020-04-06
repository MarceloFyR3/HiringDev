using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HiringDev.Util.Enun
{
    public enum TipoVideo
    {
        [Description("youtube#video")] Video = 1,
        [Description("youtube#channel")] Canal = 2,
        [Description("youtube#playlist")] PlayList = 3

    }
}
