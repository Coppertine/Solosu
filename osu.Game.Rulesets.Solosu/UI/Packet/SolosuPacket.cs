// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Allocation;
using osu.Framework.Bindables;
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
        
        private SolosuPlayfield solosuPlayfield;
        private Box playerObject;

        [BackgroundDependencyLoader]
        private void load(SolosuPlayfield playfield)
        {
            solosuPlayfield = playfield;
            AddInternal(playerObject = new Box
            {
                Size = new Vector2(10)
            });
        }

        protected override void Update()
        {
            base.Update();
            Position = new Vector2(0 + (LanePosition.Value * solosuPlayfield.LaneWidth), 100);
        }

        public bool OnPressed(SolosuAction action) => throw new System.NotImplementedException();

        public void OnReleased(SolosuAction action)
        {
            throw new System.NotImplementedException();
        }
    }
}
