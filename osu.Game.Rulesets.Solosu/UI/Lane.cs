// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Allocation;
using osu.Framework.Input.Bindings;
using osu.Framework.Logging;
using osu.Game.Rulesets.UI.Scrolling;

namespace osu.Game.Rulesets.Solosu.UI
{
    [Cached]
    public class Lane : ScrollingPlayfield, IKeyBindingHandler<SolosuAction>
    {
        public bool OnPressed(SolosuAction action)
        {
            Logger.Log("Pressed Lane");
            return true;
        }

        public void OnReleased(SolosuAction action)
        {
        }
    }
}
