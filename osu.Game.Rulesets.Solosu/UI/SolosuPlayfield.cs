// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Query.Expressions;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.Solosu.Objects;
using osu.Game.Rulesets.UI.Scrolling;

namespace osu.Game.Rulesets.Solosu.UI
{
    [Cached]
    public class SolosuPlayfield : ScrollingPlayfield
    {
        private readonly List<Lane> lanes = new List<Lane>();
        
        [BackgroundDependencyLoader]
        private void load()
        {
            AddRangeInternal(new Drawable[]
            {
                HitObjectContainer,
            });
        }
        
        public override void Add(DrawableHitObject h) => getLaneByLaneNum(((SolosuHitObject)h.HitObject).Lane).Add(h);

        public override bool Remove(DrawableHitObject h) => getLaneByLaneNum(((SolosuHitObject)h.HitObject).Lane).Remove(h);

        private Lane getLaneByLaneNum(int laneNumber)
        {
            // needs to offset to get correct lane (-1 = left, 0 = centre, 1 = right)
            
        }
    }
}
