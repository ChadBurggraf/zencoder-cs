

namespace Zencoder
{
    using System;

    /// <summary>
    /// Defines the possible output video rotations.
    /// </summary>
    public enum Rotate
    {
        /// <summary>
        /// Identifies that auto-rotation is diabled.
        /// </summary>
        None = 0,

        /// <summary>
        /// Identifies that the video is rotated 90 degrees.
        /// </summary>
        Ninety = 90,

        /// <summary>
        /// Identifies that the video is rotated 180 degrees.
        /// </summary>
        OneEighty = 180,

        /// <summary>
        /// Identifies that the video is rotated 270 degrees.
        /// </summary>
        TwoSeventy = 270
    }
}
