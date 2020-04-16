// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osuTK;

namespace osu.Game.Rulesets.Solosu.Objects.Drawables.Pieces
{
    public class BytePiece : CompositeDrawable
    {
        private Box innerBox;

        /// <summary>
        /// The transparent box with a border that acts as the outer shell of the byte
        /// </summary>
        private Box outerBox;

        private void load()
        {
            Size = new Vector2(80);

            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;

        }
    }
}
