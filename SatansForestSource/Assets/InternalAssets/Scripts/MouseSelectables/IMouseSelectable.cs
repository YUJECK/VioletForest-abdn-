namespace SatansForest.MouseSelections
{
    public interface IMouseSelectable
    {
        void OnPointed();
        void Select();
        void Deselect();
    }
}