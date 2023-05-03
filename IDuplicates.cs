
namespace CADAutoPrintPlugin_2023
{
    interface IDuplicates
    {
        string selectedDrawing { get; set; }
        string[] duplicateFiles { get; set; }
    }
}
