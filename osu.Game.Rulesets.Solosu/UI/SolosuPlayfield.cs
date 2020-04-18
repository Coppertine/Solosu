// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.Solosu.UI.Packet;
using osu.Game.Rulesets.UI.Scrolling;

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
                        RelativeSizeAxes = Axes.Y,
                        AutoSizeAxes = Axes.X,
                        Padding = new MarginPadding
                        {
                            Left = 200,
                            Top = LANE_WIDTH / 2,
                            Bottom = LANE_WIDTH / 2
                        },
                        Children = new Drawable[]
                        {
                            HitObjectContainer,
                            packetPlayer = new SolosuPacket()
                            {
                                Origin = Anchor.Centre,
                            }
                        }
                    }
                }
            });
        }
    }
}
