using System;

namespace UIScripts
{
    public interface IImageClamp
    { 
        Action <float, float> SetFillImage { get; }
    }
}