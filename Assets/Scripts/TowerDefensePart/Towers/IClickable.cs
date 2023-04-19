using System;

public interface IClickable
{
    public Action<IClickable> OnClicked { get; set; }
}
