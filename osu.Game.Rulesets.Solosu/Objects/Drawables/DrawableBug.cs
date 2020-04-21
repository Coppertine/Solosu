// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Game.Rulesets.Scoring;
using osu.Game.Rulesets.Solosu.UI.Packet;

namespace osu.Game.Rulesets.Solosu.Objects.Drawables
{
    public class DrawableBug : DrawableSolosuHitObject<SolosuBugObject>
    {
        public SolosuPacket packet;
        private SolosuBugObject bugObject;

        public DrawableBug(SolosuBugObject hitObject)
            : base(hitObject)
        {
            bugObject = hitObject;
        }

        private double missTime;

        protected override void CheckForResult(bool userTriggered, double timeOffset)
        {
            // just gonna grab from BOSU
            if (timeOffset > 0)
            {
                if (collidedWithPacket(packet))
                {
                    ApplyResult(r => r.Type = HitResult.Miss);
                }
            }

            base.CheckForResult(userTriggered, timeOffset);
        }

        private bool collidedWithPacket(SolosuPacket solosuPacket) => solosuPacket.Position.X.Equals(bugObject.Position.X);
    }
}
