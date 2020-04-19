// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Collections.Generic;
using System.ComponentModel;
using osu.Framework.Input.Bindings;
using osu.Framework.Input.Events;
using osu.Game.Rulesets.UI;

namespace osu.Game.Rulesets.Solosu
{
    
    public class SolosuInputManager : RulesetInputManager<SolosuAction>
    {
        public IEnumerable<SolosuAction> PressedActions => KeyBindingContainer.PressedActions;

        public bool AllowUserPresses
        {
            set => ((SolosuKeyBindingContainer)KeyBindingContainer).AllowUserPresses = value;
        }

        protected override KeyBindingContainer<SolosuAction> CreateKeyBindingContainer(RulesetInfo ruleset, int variant, SimultaneousBindingMode unique)
            => new SolosuKeyBindingContainer(ruleset, variant, unique);

        public SolosuInputManager(RulesetInfo ruleset)
            : base(ruleset, 0, SimultaneousBindingMode.Unique)
        {
        }

        private class SolosuKeyBindingContainer : RulesetKeyBindingContainer
        {
            public bool AllowUserPresses = true;

            public SolosuKeyBindingContainer(RulesetInfo ruleset, int variant, SimultaneousBindingMode unique)
                : base(ruleset, variant, unique)
            {
            }

            protected override bool Handle(UIEvent e)
            {
                if (!AllowUserPresses) return false;

                return base.Handle(e);
            }
        }
    }

    public enum SolosuAction
    {
        [Description("Left Button")]
        LeftButton,

        [Description("Right Button")]
        RightButton,

        [Description("Button 1")]
        Button1,

        [Description("Button 2")]
        Button2,
    }
}
