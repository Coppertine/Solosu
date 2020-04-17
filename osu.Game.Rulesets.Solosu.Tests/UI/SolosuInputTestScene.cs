// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Input.Bindings;
using osu.Game.Tests.Visual;

namespace osu.Game.Rulesets.Solosu.Tests.UI
{
    public abstract class SolosuInputTestScene : OsuTestScene
    {
        private readonly Container<Drawable> content;
        protected override Container<Drawable> Content => content ?? base.Content;

        protected SolosuInputTestScene(int keys)
        {
            base.Content.Add(content = new LocalInputManager(keys));
        }

        private class LocalInputManager : SolosuInputManager
        {
            public LocalInputManager(int variant)
                : base(new SolosuRuleset().RulesetInfo, variant)
            {
            }

            // protected override KeyBindingContainer<SolosuAction> CreateKeyBindingContainer(RulesetInfo ruleset, int variant, SimultaneousBindingMode unique)
            //     => new LocalKeyBindingContainer(ruleset, variant, unique);

            private class LocalKeyBindingContainer : RulesetKeyBindingContainer
            {
                public LocalKeyBindingContainer(RulesetInfo ruleset, int variant, SimultaneousBindingMode unique)
                    : base(ruleset, variant, unique)
                {
                }

                protected override void ReloadMappings()
                {
                    KeyBindings = DefaultKeyBindings;
                }
            }
        }
    }
}
