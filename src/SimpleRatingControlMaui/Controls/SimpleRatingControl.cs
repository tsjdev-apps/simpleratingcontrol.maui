using Maui.BindableProperty.Generator.Core;

namespace SimpleRatingControlMaui;

public partial class SimpleRatingControl : HorizontalStackLayout
{
    [AutoBindable(DefaultValue = "0d", OnChanged = nameof(UpdateLayout))]
    private readonly double _currentValue;

    [AutoBindable(DefaultValue = "10", OnChanged = nameof(UpdateLayout))]
    private readonly int _amount;

    [AutoBindable(DefaultValue = "24d", OnChanged = nameof(UpdateLayout))]
    private readonly double _fontSize;

    [AutoBindable(DefaultValue = "Colors.Red", OnChanged = nameof(UpdateLayout))]
    private readonly Color _accentColor;

    [AutoBindable(DefaultValue = "RatingType.Star", OnChanged = nameof(UpdateLayout))]
    private readonly RatingType _ratingType;


    public SimpleRatingControl()
    {
        HorizontalOptions = LayoutOptions.Center;
        VerticalOptions = LayoutOptions.Center;

        UpdateLayout();
    }

    private void UpdateLayout()
    {
        Children.Clear();

        int intValue = (int)ClampValue(CurrentValue);
        double decimalPart = CurrentValue - intValue;
        bool isHalfStar = false;

        if (decimalPart > .25)
        {
            if (decimalPart > 0.25 && decimalPart <= .75)
            {
                isHalfStar = true;
            }
            else
            {
                intValue++;
            }
        }

        for (int i = 0; i < Amount; i++)
        {
            if (intValue > i)
            {
                Add(CreateLabel(State.Full));
            }
            else if (intValue <= i && isHalfStar)
            {
                Add(CreateLabel(State.Half));
                isHalfStar = false;
            }
            else
            {
                Add(CreateLabel(State.Empty));
            }
        }
    }

    private Label CreateLabel(State state)
    {
        Label label = new()
        {
            FontFamily = "MDI",
            TextColor = AccentColor,
            FontSize = FontSize
        };

        switch (RatingType)
        {
            case RatingType.Star:
                label.Text = state switch
                {
                    State.Empty => MaterialDesignIconsFont.StarOutline,
                    State.Half => MaterialDesignIconsFont.StarHalfFull,
                    State.Full => MaterialDesignIconsFont.Star,
                    _ => MaterialDesignIconsFont.StarOutline,
                };
                break;

            case RatingType.Heart:
                label.Text = state switch
                {
                    State.Empty => MaterialDesignIconsFont.HeartOutline,
                    State.Half => MaterialDesignIconsFont.HeartHalfFull,
                    State.Full => MaterialDesignIconsFont.Heart,
                    _ => MaterialDesignIconsFont.HeartOutline,
                };
                break;

            case RatingType.Circle:
                label.Text = state switch
                {
                    State.Empty => MaterialDesignIconsFont.CircleOutline,
                    State.Half => MaterialDesignIconsFont.CircleHalfFull,
                    State.Full => MaterialDesignIconsFont.Circle,
                    _ => MaterialDesignIconsFont.CircleOutline,
                };
                break;

            case RatingType.Shield:
                label.Text = state switch
                {
                    State.Empty => MaterialDesignIconsFont.ShieldOutline,
                    State.Half => MaterialDesignIconsFont.ShieldHalfFull,
                    State.Full => MaterialDesignIconsFont.Shield,
                    _ => MaterialDesignIconsFont.ShieldOutline,
                };
                break;
        }

        return label;
    }

    private double ClampValue(double value)
    {
        if (value < 0)
        {
            return 0;
        }

        if (value > Amount)
        {
            return Amount;
        }

        return value;
    }
}
