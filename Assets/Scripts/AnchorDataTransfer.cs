using UnityEngine;
using UnityEngine.Events;

public static class AnchorDataTransfer
{
    public static Transform _anchor = null;
    public static UnityEvent OnAnchorChange = new UnityEvent();
    public static Transform anchor
    {
        get
        {
            return _anchor;
        }
        set
        {
            if (_anchor != value)
            {
                _anchor = value;
                OnAnchorChange?.Invoke();
            }
        }
    }
}
