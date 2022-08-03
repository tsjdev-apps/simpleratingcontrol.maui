namespace SimpleRatingControlMaui;

public class SimpleRatingControl : HorizontalStackLayout
{
    public static readonly BindableProperty CurrentValueProperty =
          BindableProperty.Create(nameof(CurrentValue), typeof(double), typeof(SimpleRatingControl), defaultValue: 0d, propertyChanged: OnRefreshControl);

    public double CurrentValue
    {
        get => (double)GetValue(CurrentValueProperty);
        set => SetValue(CurrentValueProperty, value);
    }

    public static readonly BindableProperty AmountProperty =
      BindableProperty.Create(nameof(Amount), typeof(int), typeof(SimpleRatingControl), defaultValue: 10, propertyChanged: OnRefreshControl);

    public int Amount
    {
        get => (int)GetValue(AmountProperty);
        set => SetValue(AmountProperty, value);
    }

    public static readonly BindableProperty StarSizeProperty =
      BindableProperty.Create(nameof(StarSize), typeof(double), typeof(SimpleRatingControl), defaultValue: 24d, propertyChanged: OnRefreshControl);

    public double StarSize
    {
        get => (double)GetValue(StarSizeProperty);
        set => SetValue(StarSizeProperty, value);
    }

    public static readonly BindableProperty AccentColorProperty =
        BindableProperty.Create(nameof(AccentColor), typeof(Color), typeof(SimpleRatingControl), defaultValue: Colors.Red, propertyChanged: OnRefreshControl);

    public Color AccentColor
    {
        get => (Color)GetValue(AccentColorProperty);
        set => SetValue(AccentColorProperty, value);
    }

    public static readonly BindableProperty RatingTypeProperty =
        BindableProperty.Create(nameof(RatingType), typeof(RatingType), typeof(SimpleRatingControl), defaultValue: RatingType.Star, propertyChanged: OnRefreshControl);

    public RatingType RatingType
    {
        get => (RatingType)GetValue(RatingTypeProperty);
        set => SetValue(RatingTypeProperty, value);
    }


    private static void OnRefreshControl(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is SimpleRatingControl ratingControl)
            ratingControl.UpdateLayout();
    }


    private void UpdateLayout()
    {
        Children.Clear();

        var intValue = (int)ClampValue(CurrentValue);
        var decimalPart = CurrentValue - intValue;
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
        var label = new Label { FontFamily = "MDI", TextColor = AccentColor, FontSize = StarSize };

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
            return 0;

        if (value > Amount)
            return Amount;

        return value;
    }
}
