using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using System.Windows.Forms;
using Autodesk.Revit.DB.Plumbing;


namespace LevelMarks
{
    [TransactionAttribute(TransactionMode.Manual)]
    [RegenerationAttribute(RegenerationOption.Manual)]
    public class LevelMarksClass : IExternalCommand
    {

        public Result Execute(
        ExternalCommandData commandData,
        ref string message,
        ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            UIDocument uiDoc = uiApp.ActiveUIDocument;
            Document doc = uiApp.ActiveUIDocument.Document;
            Form1 ui = new Form1();
            ui.uiDoc = uiDoc;
            return (SetLevelAnnotations(doc, ui));             
        }
        public Result SetLevelAnnotations(Document doc, Form1 ui)
        {
            try
            {
                List<View3D> listOfViews = new List<View3D>();
                List<string> listOfTeamplates = new List<string>();
                var textNoteTypeCollector = new FilteredElementCollector(doc).OfClass(typeof(TextNoteType));
                var levelCollector = new FilteredElementCollector(doc).OfClass(typeof(Level));
                var View3DCollector = new FilteredElementCollector(doc).OfClass(typeof(View3D)).Cast<View3D>().Where(x => !x.IsTemplate);
                foreach (View3D view in View3DCollector)
                {
                    var teamplateId = view.ViewTemplateId;
                    var isViewLocked = view.IsLocked;
                    var isTeamplateIdNotInvalid = view.ViewTemplateId != ElementId.InvalidElementId;
                    if (isViewLocked && isTeamplateIdNotInvalid)
                    {
                        var viewTeamplateName = doc.GetElement(view.ViewTemplateId).Name;
                        if (!listOfTeamplates.Contains(viewTeamplateName))
                        {
                            listOfTeamplates.Add(viewTeamplateName);
                        }
                        listOfViews.Add(view);
                    }
                }
                foreach (var name in listOfTeamplates)
                {
                    var teamplateNode = ui.TreeView.Nodes.Add(name);

                    foreach (var nameOfView in listOfViews)
                    {
                        if (doc.GetElement(nameOfView.ViewTemplateId).Name == teamplateNode.Text)
                        {
                            var viewNode = teamplateNode.Nodes.Add(nameOfView.Name);
                        }
                    }
                }
                foreach (var txtnote in textNoteTypeCollector)
                {
                    ui.TextNoteTypeComboBox.Items.Add(txtnote.Name);
                }
                foreach (Parameter param in levelCollector.FirstOrDefault().Parameters)
                {
                    if (param.IsReadOnly == false && (param.StorageType == StorageType.Integer || param.StorageType == StorageType.String))
                    {
                        ui.LevelComboBox.Items.Add(param.Definition.Name);
                    }
                }
                var uiResult = ui.ShowDialog();
                if (uiResult != DialogResult.OK)
                    return Result.Cancelled;
                Transaction tr = new Transaction(doc, "Отметки Уровней");
                tr.Start();
                var listOfCheckedNames = new List<string>();
                foreach (TreeNode node in ui.TreeView.Nodes)
                {
                    foreach (TreeNode childNode in node.Nodes)
                    {
                        if (childNode.Checked == true)
                        {
                            listOfCheckedNames.Add(childNode.Text);
                        }
                    }
                }

                var listOfChecked3DViews = new List<View3D>();
                foreach (var name in listOfCheckedNames)
                {

                    foreach (var el in View3DCollector)
                    {
                        if (name == el.Name)
                        {
                            listOfChecked3DViews.Add(el);
                        }
                    }
                }
                var list = new List<TextNote>();
                foreach (var view in listOfChecked3DViews)
                {
                    foreach (Level lvl in levelCollector)
                    {
                        BoundingBoxXYZ boxXYZ = new BoundingBoxXYZ();
                        boxXYZ.Max = new XYZ(100000, 100000, lvl.ProjectElevation);
                        boxXYZ.Min = new XYZ(-100000, -10000, lvl.ProjectElevation);
                        Outline outline = new Outline(boxXYZ.Min, boxXYZ.Max);
                        BoundingBoxIntersectsFilter intersectsFilter = new BoundingBoxIntersectsFilter(outline);
                        FilteredElementCollector elementsOnView = new FilteredElementCollector(doc, view.Id).OfClass(typeof(Pipe)).WherePasses(intersectsFilter);
                        Element pipe = elementsOnView.FirstOrDefault();
                        if (elementsOnView.Count() > 0)
                        {
                            XYZ origin = new XYZ();
                            var originX = pipe.get_BoundingBox(view).Max.X;
                            var originY = pipe.get_BoundingBox(view).Max.Y;
                            var originZ = lvl.ProjectElevation;
                            var direction = view.RightDirection;
                            var leftDirectionx = view.RightDirection.X;
                            var leftDirectiony = view.RightDirection.Y;
                            if (ui.radioButtonLeft.Checked)
                            {
                                XYZ leftDirection = new XYZ(leftDirectionx * -6, leftDirectiony * -6, view.RightDirection.Z);
                                XYZ origin1 = new XYZ(originX, originY, originZ) + leftDirection;
                                origin = origin1;
                            }
                            else if (ui.radioButtonRight.Checked)
                            {
                                XYZ origin1 = new XYZ(originX, originY, originZ) + direction;
                                origin = origin1;
                            }
                            string highMark = lvl.get_Parameter(BuiltInParameter.LEVEL_ELEV).AsValueString();
                            if (highMark.Length == 5)
                                highMark = highMark.Insert(2, ".");
                            else
                                highMark = highMark.Insert(1, ".");
                            var text = lvl.LookupParameter(ui.LevelComboBox.Text).AsString() + " " + "Эт." + " " + highMark;
                            ElementId textNoteType = null;
                            foreach (var type in textNoteTypeCollector)
                            {
                                if (type.Name == ui.TextNoteTypeComboBox.Text)
                                    textNoteType = type.Id;
                            }
                            TextNote note = TextNote.Create(doc, view.Id, origin, text, textNoteType);
                            
                            
                        }



                    }

                }
                tr.Commit();
                TaskDialog.Show("Готово", "Отметки уровней ВК выставлены");
                return Result.Succeeded;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace);
                return Result.Failed;
            }
        }
    }

}
