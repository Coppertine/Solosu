// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.ComponentModel;
using osu.Framework.Input.Bindings;
using osu.Game.Rulesets.UI;

namespace osu.Game.Rulesets.Solosu
{
    public class SolosuInputManager : RulesetInputManager<SolosuAction>
    {
        public SolosuInputManager(RulesetInfo ruleset)
            : base(ruleset, 0, SimultaneousBindingMode.Unique)
        {
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
