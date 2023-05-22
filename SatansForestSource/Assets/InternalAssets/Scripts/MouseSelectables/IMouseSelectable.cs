namespace SatansForest.MouseSelections
{
    public interface IMouseSelectable
    {
        void OnMousePointed();
        void Select();
        void OnMouseDepointed();
    }
}