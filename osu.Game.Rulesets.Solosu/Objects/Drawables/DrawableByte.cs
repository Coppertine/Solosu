// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Input.Bindings;
using osu.Game.Rulesets.Solosu.Objects.Drawables.Pieces;
using osu.Game.Rulesets.UI.Scrolling;

namespace osu.Game.Rulesets.Solosu.Objects.Drawables
{
    public class DrawableByte : DrawableSolosuHitObject<SolosuByteObject>, IKeyBindingHandler<SolosuAction>
    {
        // TODO: Figure out if skinning is a good thing.
        private readonly BytePiece bytePiece;

        public DrawableByte(SolosuByteObject hitObject)
            : base(hitObject)
        {
            AddInternal(bytePiece = new BytePiece
            {
            });
        }

        protected override void OnDirectionChanged(ValueChangedEvent<ScrollingDirection> e)
        {
            base.OnDirectionChanged(e);

            bytePiece.Anchor = bytePiece.Origin = e.NewValue == ScrollingDirection.Up ? Anchor.TopCentre : Anchor.BottomCentre;
        }
    }
}
