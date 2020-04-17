// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Allocation;
using osu.Framework.Graphics.Primitives;
using osu.Game.Rulesets.UI;
using osu.Game.Rulesets.UI.Scrolling;
using osuTK;

namespace osu.Game.Rulesets.Solosu.UI
{
    [Cached]
    public class Lane : ScrollingPlayfield
    {
        private Line laneLine;
        private void load()
        {
            laneLine = new Line(, );
        }
    }
}
