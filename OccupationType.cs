using System;
using System.ComponentModel;

namespace battleship
{
    public enum OccupationType
    {
        [Description("B")]
        BATTLESHIP,
        [Description("C")]
        CRUISER,
        [Description("D")]
        DESTROYER,
        [Description("S")]
        SUBMARINE,
        [Description("X")]
        HIT,
        [Description("M")]
        MISS,
        [Description("0")]
        EMPTY
    }
}