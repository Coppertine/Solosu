// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.Solosu.UI.Packet;
using osu.Game.Rulesets.UI.Scrolling;
using osuTK;

namespace osu.Game.Rulesets.Solosu.UI
{
    [Cached]
    public class SolosuPlayfield : ScrollingPlayfield
    {
        /// <summary>
        /// Default height of a <see cref="SolosuPlayfield"/> when inside a <see cref="DrawableSolosuRuleset"/>.
        /// </summary>
        public const float DEFAULT_WIDTH = 178;

        public const float LANE_WIDTH = 70;
        public const int LANE_COUNT = 3;

        private SolosuPacket packetPlayer;
        public BindableInt CurrentLane => packetPlayer.LanePosition;

        [BackgroundDependencyLoader]
        private void load()
        {
            AddRangeInternal(new Drawable[]
            {
                new LaneContainer
                {
                    RelativeSizeAxes = Axes.Y,
                    AutoSizeAxes = Axes.X,
                    Anchor = Anchor.BottomCentre,
                    Origin = Anchor.BottomCentre,
                    Child = new Container
                    {
                        RelativeSizeAxes = Axes.X,
                        AutoSizeAxes = Axes.Y,
                        Padding = new MarginPadding
                        {

                            Left = LANE_WIDTH / 2,
                            Right = LANE_WIDTH
                        },
                        Children = new Drawable[]
                        {
                            HitObjectContainer,
                            packetPlayer = new SolosuPacket()
                            {
                                Anchor = Anchor.BottomCentre,
                                Origin = Anchor.BottomCentre,
                                Position = new Vector2(0)
                            }
                        }
                    }
                }
            });
        }
    }
}
