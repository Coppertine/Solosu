// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Game.Graphics;
using osu.Game.Graphics.Containers;

namespace osu.Game.Rulesets.Solosu.UI
{
    public class LaneContainer : BeatSyncedContainer
    {
        private FillFlowContainer fill;

        private readonly Container content = new Container
        {
            RelativeSizeAxes = Axes.Both,
        };

        protected override Container<Drawable> Content => content;

        [BackgroundDependencyLoader]
        private void load(OsuColour colours)
        {
            InternalChildren = new Drawable[]
            {
                fill = new FillFlowContainer
                {
                    RelativeSizeAxes = Axes.X,
                    AutoSizeAxes = Axes.Y,
                },
                content,
            };

            for (int i = 0; i < SolosuPlayfield.LANE_COUNT; i++)
            {
                fill.Add(new Lane
                {
                    RelativeSizeAxes = Axes.Y,
                    Width = SolosuPlayfield.LANE_WIDTH,
                });
            }
        }
    }
}
