// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using NUnit.Framework;
using osu.Framework.Allocation;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics;
using osu.Game.Rulesets.Solosu.UI;
using osu.Game.Tests.Visual;

namespace osu.Game.Rulesets.Solosu.Tests.UI
{
    [TestFixture]
    public class TestScenePlayfield : OsuTestScene
    {
        private readonly Container content;
        protected override Container<Drawable> Content => content;

        public TestScenePlayfield()
        {
            base.Content.Add(
                content = new SolosuInputManager(
                new RulesetInfo { ID = 2 } // This ID is null, when creating new SolosuRuleset. Don't know why, but I think osu#8778 will resolve this.
                // Currently only std(0), taiko(1), catch(2) provides KeyBinding that matches this ruleset's KeyBinding enums(Refer to SolosuRuleset.cs).
                // It's not exact, but is a good stop-gap just to get things working.
                // In my tests, it seems I've been using the std ID, but never noticed since my keys are the same, and the enums are ordered exactly the same
                ));
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            Add(new ScrollingTestContainer(Rulesets.UI.Scrolling.ScrollingDirection.Down)
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                RelativeSizeAxes = Axes.Y,
                Width = 768,
                Children = new[]
                {
                    new SolosuPlayfield()
                }
            });
        }
    }
}