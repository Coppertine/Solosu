// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Input.Bindings;
using osu.Framework.Logging;
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

            LanePosition.BindValueChanged(e =>
            {
                this.MoveToX(e.NewValue * SolosuPlayfield.LANE_WIDTH);
                Logger.Log($"Lane is {e.NewValue}");
            });
            //Logger.Log("Positon is " + LanePosition.Value * SolosuPlayfield.LANE_WIDTH);
        }

        private int heldButton = 0; // -1 = left, 1 = right

        public bool OnPressed(SolosuAction action)
        {
            Logger.LogPrint("Action Pressed");
            if (heldButton != 0 && (action.Equals(SolosuAction.LeftButton) || action.Equals(SolosuAction.RightButton))) return false;

            switch (action)
            {
                case SolosuAction.LeftButton:
                    moveLane(-1);
                    heldButton = -1;
                    //Logger.Log("Positon is " + LanePosition.Value * SolosuPlayfield.LANE_WIDTH);
                    return true;

                case SolosuAction.RightButton:
                    moveLane(1);
                    heldButton = 1;
                    return true;

                case SolosuAction.Button1:
                    return true;

                case SolosuAction.Button2:
                    return true;
            }

            return false;
        }

        public void OnReleased(SolosuAction action)
        {
            // If left button is released while right button is held, the player should move to the right.
            //Logger.LogPrint("Action Pressed");
            if ((action == SolosuAction.RightButton && heldButton == 1) || (action == SolosuAction.LeftButton && heldButton == -1))
            {
                heldButton = 0;
                moveLane(0);
            }
        }

        private void moveLane(int movement)
        {
            LanePosition.Value = movement;
        }
    }
}
