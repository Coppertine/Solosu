// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Input.Bindings;
using osuTK;

namespace osu.Game.Rulesets.Solosu.UI.Packet
{
    public class SolosuPacket : CompositeDrawable, IKeyBindingHandler<SolosuAction>
    {
        /// <summary>
        /// The lower the value, the further left the packet/player is.
        /// </summary>
        public BindableInt LanePosition = new BindableInt
        {
            Value = 0,
            MinValue = -1,
            MaxValue = 1
        };

        private Box playerObject;

        [BackgroundDependencyLoader]
        private void load(SolosuPlayfield playfield)
        {
            Size = new Vector2(SolosuPlayfield.LANE_WIDTH / 1.5f);
            AddInternal(playerObject = new Box
            {
                FillMode = FillMode.Fit,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                RelativeSizeAxes = Axes.Both,
            });
            LanePosition.BindValueChanged(e => { this.MoveToX(e.NewValue * SolosuPlayfield.LANE_WIDTH); });
        }

        public bool OnPressed(SolosuAction action)
        {
            switch (action)
            {
                case SolosuAction.LeftButton:
                    return true;
                default:
                    return false;
            }
        }

        public void OnReleased(SolosuAction action)
        {
            
        }
    }
}
