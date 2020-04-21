// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Bindables;
using osu.Game.Rulesets.Judgements;
using osu.Game.Rulesets.Scoring;
using osu.Game.Rulesets.Solosu.Judgements;
using osu.Game.Rulesets.Solosu.Objects.Types;
using osuTK;
using IHasPosition = osu.Game.Rulesets.Objects.Types.IHasPosition;

namespace osu.Game.Rulesets.Solosu.Objects
{
    public class SolosuBugObject : SolosuHitObject, IHasPosition, IHasLane, IHasSize
    {
        public new int Lane { get; set; }
        public float Size { get; set; }
        protected override HitWindows CreateHitWindows() => HitWindows.Empty;
        public override Judgement CreateJudgement() => new SolosuJudgement();
        public readonly Bindable<Vector2> PositionBindable = new Bindable<Vector2>();

        public virtual Vector2 Position
        {
            get => PositionBindable.Value;
            set => PositionBindable.Value = value;
        }

        public float X => Position.X;
        public float Y => Position.Y;
    }
}
