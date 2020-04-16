// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Bindables;
using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Scoring;
using osu.Game.Rulesets.Solosu.Objects.Types;
using osu.Game.Rulesets.Solosu.Scoring;
using osuTK.Graphics;

namespace osu.Game.Rulesets.Solosu.Objects
{
    public class SolosuHitObject : HitObject, IHasLane
    {
        protected override HitWindows CreateHitWindows() => new SolosuHitWindows();

        public Color4 NoteColor { get; set; }
        public readonly Bindable<int> LaneBindable = new Bindable<int>();

        public virtual int Lane
        {
            get => LaneBindable.Value;
            set => LaneBindable.Value = value;
        }
    }
}
