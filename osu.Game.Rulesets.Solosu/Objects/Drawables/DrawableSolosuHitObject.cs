// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using JetBrains.Annotations;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.Scoring;
using osu.Game.Rulesets.UI.Scrolling;
using osuTK.Graphics;

namespace osu.Game.Rulesets.Solosu.Objects.Drawables
{
    public class DrawableSolosuHitObject : DrawableHitObject<SolosuHitObject>
    {
        /// <summary>
        /// Whether this <see cref="DrawableSolosuHitObject"/> should always remain alive.
        /// </summary>
        internal bool AlwaysAlive;

        /// <summary>
        /// The <see cref="SolosuAction"/> which causes this <see cref="DrawableSolosuHitObject{TObject}"/> to be hit.
        /// </summary>
        protected readonly IBindable<SolosuAction> Action = new Bindable<SolosuAction>();

        protected readonly IBindable<ScrollingDirection> Direction = new Bindable<ScrollingDirection>();

        public DrawableSolosuHitObject(SolosuHitObject hitObject)
            : base(hitObject)
        {
        }

        [BackgroundDependencyLoader(true)]
        private void load([CanBeNull] IBindable<SolosuAction> action, [NotNull] IScrollingInfo scrollingInfo)
        {
            if (action != null)
                Action.BindTo(action);
            Direction.BindTo(scrollingInfo.Direction);
            Direction.BindValueChanged(OnDirectionChanged, true);
        }

        protected virtual void OnDirectionChanged(ValueChangedEvent<ScrollingDirection> e)
        {
            Anchor = Origin = e.NewValue == ScrollingDirection.Up ? Anchor.TopCentre : Anchor.BottomCentre;
        }

        protected override bool ShouldBeAlive => AlwaysAlive || base.ShouldBeAlive;

        protected override void CheckForResult(bool userTriggered, double timeOffset)
        {
            if (timeOffset >= 0)
                // todo: implement judgement logic
                ApplyResult(r => r.Type = HitResult.Perfect);
        }

        protected override void UpdateStateTransforms(ArmedState state)
        {
            const double duration = 150;

            switch (state)
            {
                case ArmedState.Hit:
                    this.FadeOut(duration, Easing.OutQuint).Expire();
                    break;

                case ArmedState.Miss:

                    this.FadeColour(Color4.Red, duration);
                    this.FadeOut(duration, Easing.InQuint).Expire();
                    break;
            }
        }
    }

    public abstract class DrawableSolosuHitObject<TObject> : DrawableSolosuHitObject
        where TObject : SolosuHitObject
    {
        public new readonly TObject HitObject;

        protected DrawableSolosuHitObject(TObject hitObject)
            : base(hitObject)
        {
            HitObject = hitObject;
        }
    }
}
