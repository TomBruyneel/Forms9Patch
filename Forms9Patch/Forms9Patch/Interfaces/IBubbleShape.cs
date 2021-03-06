using System;

namespace Forms9Patch
{
    internal interface IBubbleShape : IShape
    {
        float PointerLength { get; set; }

        float PointerTipRadius { get; set; }

        float PointerAxialPosition { get; set; }

        PointerDirection PointerDirection { get; set; }

        float PointerCornerRadius { get; set; }

    }
}