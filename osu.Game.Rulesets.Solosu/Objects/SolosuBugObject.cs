// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Game.Rulesets.Solosu.Objects.Types;

namespace osu.Game.Rulesets.Solosu.Objects
{
    public class SolosuBugObject : SolosuHitObject, IHasPosition, IHasLane, IHasSize
    {
        public new int Lane { get; set; }
        public float Position { get; set; }
        public float Size { get; set; }
    }
}
