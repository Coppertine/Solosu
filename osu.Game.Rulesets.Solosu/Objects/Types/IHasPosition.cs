// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

namespace osu.Game.Rulesets.Solosu.Objects.Types
{
    /// <summary>
    /// The interface for objects which do not respect to playfield lanes.
    /// </summary>
    public interface IHasPosition
    {
        /// <summary>
        /// The X Position of the object.
        /// </summary>
        public float Position { get; set; }
    }
}
