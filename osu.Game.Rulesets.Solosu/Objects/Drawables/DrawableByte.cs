// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Collections.Generic;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Input.Bindings;
using osu.Game.Audio;
using osu.Game.Beatmaps.ControlPoints;
using osu.Game.Rulesets.Solosu.Objects.Drawables.Pieces;
using osu.Game.Rulesets.Solosu.UI;
using osu.Game.Rulesets.UI.Scrolling;
using osuTK;

namespace osu.Game.Rulesets.Solosu.Objects.Drawables
{
    public class DrawableByte : DrawableSolosuHitObject<SolosuByteObject>, IKeyBindingHandler<SolosuAction>
    {
        // TODO: Figure out if skinning is a good thing.
        private readonly BytePiece bytePiece;
        private BindableNumber<int> currentLane;

        public DrawableByte(SolosuByteObject hitObject)
            : base(hitObject)
        {
            Size = new Vector2(80);
            AddInternal(bytePiece = new BytePiece());
        }

        [BackgroundDependencyLoader]
        private void load(SolosuPlayfield playfield)
        {
            currentLane = playfield.CurrentLane.GetBoundCopy();
        }
        protected override IEnumerable<HitSampleInfo> GetSamples() => new[]
        {
            new HitSampleInfo
            {
                Bank = SampleControlPoint.DEFAULT_BANK,
                Name = HitSampleInfo.HIT_NORMAL,
            }
        };
        
        protected override void OnDirectionChanged(ValueChangedEvent<ScrollingDirection> e)
        {
            base.OnDirectionChanged(e);

            bytePiece.Anchor = bytePiece.Origin = e.NewValue == ScrollingDirection.Up ? Anchor.TopCentre : Anchor.BottomCentre;
        }

        public bool OnPressed(SolosuAction action) => true;

        public void OnReleased(SolosuAction action)
        {
        }
    }
}
