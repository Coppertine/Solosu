// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using NUnit.Framework;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Game.Beatmaps;
using osu.Game.Beatmaps.ControlPoints;
using osu.Game.Rulesets.Scoring;
using osu.Game.Rulesets.Solosu.Objects;
using osu.Game.Rulesets.Solosu.Objects.Drawables;
using osu.Game.Tests.Visual;
using osuTK;
using osuTK.Graphics;

namespace osu.Game.Rulesets.Solosu.Tests.Objects
{
    [TestFixture]
    public class TestSceneByte : OsuTestScene
    {
        private readonly Container content;
        protected override Container<Drawable> Content => content;

        private int depthIndex;

        public TestSceneByte()
        {
            base.Content.Add(content = new SolosuInputManager(new RulesetInfo { ID = 0 }));
            AddStep("Miss Single", () => testSingle());
            AddStep("Hit Single", () => testSingle(true));
        }

        private void testSingle(bool auto = false)
        {
            var circle = new SolosuByteObject
            {
                StartTime = Time.Current + 1000,
                Lane = 0,
                NoteColor = Color4.Orange,
            };

            circle.ApplyDefaults(new ControlPointInfo(), new BeatmapDifficulty { });

            var drawable = CreateDrawableTapNote(circle, auto);

            Add(drawable);
        }

        protected virtual TestDrawableByteObject CreateDrawableTapNote(SolosuByteObject circle, bool auto) => new TestDrawableByteObject(circle, auto)
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            Depth = depthIndex++,
        };

        protected class TestDrawableByteObject : DrawableByte
        {
            private readonly bool auto;

            public TestDrawableByteObject(SolosuByteObject h, bool auto)
                : base(h)
            {
                this.auto = auto;
            }

            public void TriggerJudgement() => UpdateResult(true);

            protected override void CheckForResult(bool userTriggered, double timeOffset)
            {
                if (auto && !userTriggered && timeOffset > 0)
                {
                    // force success
                    ApplyResult(r => r.Type = HitResult.Perfect);
                }
                else
                    base.CheckForResult(userTriggered, timeOffset);
            }
        }
    }
}
