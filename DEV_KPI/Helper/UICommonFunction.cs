using Core.Helper;
using DEV_KPI.Common.UI;
using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace DEV_KPI.Helper
{
    public partial class UICommonFunction
    {
        public static object GetCurentDataInGridLookupEdit(GridLookUpEdit gridLookUpEdit)
        {
            return gridLookUpEdit.GetSelectedDataRow();
        }

        public static void ConfigDataSourceAndDefaultValueToGridLookUpEdit(GridLookUpEdit lookUpEdit,
               IList lstSourceString, String aValueMember, String aDisplayMember, object defaulValue = null,
            Nullable<Boolean> isReadonly = null, bool isShowCode = false, bool isAutoGenLayout = true, bool isSearchByCode = false
            , bool isAutoSort = true)
        {
            lookUpEdit.Properties.DataSource = lstSourceString;
            lookUpEdit.Properties.ValueMember = aValueMember;
            lookUpEdit.Properties.DisplayMember = aDisplayMember;
            lookUpEdit.Properties.PopupFilterMode = PopupFilterMode.Contains;
            lookUpEdit.Properties.TextEditStyle = TextEditStyles.Standard;
            lookUpEdit.Properties.NullText = "";
            lookUpEdit.Properties.AutoComplete = false;
            lookUpEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;

            lookUpEdit.Properties.PopupFilterMode = PopupFilterMode.Contains;
            lookUpEdit.Properties.View.OptionsView.ShowAutoFilterRow = true;
            if (isAutoGenLayout)
            {
                GridView view = lookUpEdit.Properties.View;

                view.OptionsView.ShowAutoFilterRow = true;
                view.Columns.Clear();
                if (isShowCode)
                {
                    view.Columns.Add(new GridColumn()
                    {
                        FieldName = aValueMember,
                        Visible = true,
                        Width = 100,
                        Caption = "Mã"
                    });
                }


                var colDisplay = new GridColumn()
                {
                    FieldName = aDisplayMember,
                    Visible = true,
                    Width = 200,
                    Caption = "Tên"
                };
                if (isAutoSort)
                {
                    colDisplay.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                }

                view.Columns.Add(colDisplay);

                if (isSearchByCode)
                {
                    lookUpEdit.Properties.DisplayMember = aValueMember;
                }
            }

            if (defaulValue != null)
            {
                lookUpEdit.EditValue = defaulValue;
            }

            if (isReadonly != null)
            {
                lookUpEdit.Properties.ReadOnly = isReadonly.Value;
            }

            foreach (GridColumn col in lookUpEdit.Properties.View.Columns)
            {
                col.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
            }
        }

        public static void AddGridViewGridLookUpToColumn(GridView grv, String aFieldName, IList lstSourceString, String aValueMember, String aDisplayMember,
                                                         String aGridColumnName = "", bool isShowCode = false, bool displayValueAsText = false)
        {
            var lookUpEdit = new RepositoryItemGridLookUpEdit();
            lookUpEdit.View = new GridView();
            lookUpEdit.View.OptionsView.ShowAutoFilterRow = true;
            lookUpEdit.DataSource = lstSourceString;
            lookUpEdit.ValueMember = aValueMember;
            lookUpEdit.DisplayMember = displayValueAsText ? aValueMember : aDisplayMember;
            if (isShowCode)
            {
                lookUpEdit.View.Columns.Add(new GridColumn()
                {
                    FieldName = aValueMember,

                    Visible = true,
                    Width = 100,
                    Caption = "Mã",
                    SortOrder = ColumnSortOrder.Ascending
                });
            }
            lookUpEdit.View.Columns.Add(new GridColumn()
            {
                FieldName = aDisplayMember,
                Visible = true,
                Width = 120,
                Caption = "Tên",
                SortOrder = ColumnSortOrder.Ascending

            });

            //grv.GridControl.RepositoryItems.AddRange(new RepositoryItem[] { lookUpEdit });
            if (isShowCode)
            {
                lookUpEdit.PopupFormWidth = 400;
            }

            foreach (GridColumn o in grv.Columns)
            {
                if (o.FieldName.ToUpper() == aFieldName.ToUpper())
                {
                    if (aGridColumnName != "")
                    {
                        if (o.Name == aGridColumnName)
                        {
                            o.ColumnEdit = lookUpEdit;
                            bool isClear = true;
                            foreach (GridSummaryItem sum in o.SummaryItem.Collection)
                            {
                                if (sum.SummaryType == SummaryItemType.Count)
                                {
                                    isClear = false;
                                    break;
                                }
                            }
                            if (isClear)
                            {
                                o.SummaryItem.Collection.Clear();
                            }
                            break;
                        }
                    }
                    else
                    {
                        o.ColumnEdit = lookUpEdit;
                        bool isClear = true;
                        foreach (GridSummaryItem sum in o.SummaryItem.Collection)
                        {
                            if (sum.SummaryType == SummaryItemType.Count)
                            {
                                isClear = false;
                                break;
                            }
                        }
                        if (isClear)
                        {
                            o.SummaryItem.Collection.Clear();
                        }
                    }
                }
            }
        }

        public static void SetGridColumnEnable(GridView grv, params GridColumn[] paramCol)
        {
            List<GridColumn> lstClAlow = new List<GridColumn>();
            foreach (GridColumn cl in paramCol)
            {
                if (!grv.Columns.Contains(cl))
                {
                    throw new Exception(string.Format("Grid view <{0}> không chứa cột <{1}> ", grv.Name, cl.Name));
                }
                lstClAlow.Add(cl);
            }

            grv.OptionsBehavior.Editable = lstClAlow.Count > 0;
            grv.OptionsBehavior.ReadOnly = lstClAlow.Count == 0;

            foreach (GridColumn clGrv in grv.Columns)
            {
                if (lstClAlow.Contains(clGrv))
                {
                    clGrv.OptionsColumn.AllowEdit = true;
                    clGrv.OptionsColumn.ReadOnly = false;
                }
                else
                {
                    clGrv.OptionsColumn.AllowEdit = false;
                    clGrv.OptionsColumn.ReadOnly = true;
                }
            }
        }

        public static void SelectBySpace(GridView grv, bool isFixSelectedColumn = true)
        {
            if (isFixSelectedColumn)
            {
                foreach (GridColumn col in grv.Columns)
                {
                    if (col.Visible && (col.FieldName.ToUpper() == "SELECT" || col.FieldName.ToUpper() == "SELECTED"))
                    {
                        col.Fixed = FixedStyle.Left;
                    }
                }
            }
            grv.KeyDown += grvSelect_KeyDown;
            grv.RowCellClick += grvSelect_RowCellClick;
        }

        public static void grvSelect_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            try
            {
                GridView grid = sender as GridView;
                if (grid == null)
                {
                    return;
                }

                if (!grid.IsDataRow(e.RowHandle))
                {
                    return;
                }

                if (e.Column == null || (e.Column.FieldName.ToUpper() != "SELECT" && e.Column.FieldName.ToUpper() != "SELECTED"))
                {
                    return;
                }

                var dto = grid.GetRow(e.RowHandle);
                if (dto == null)
                {
                    return;
                }

                if (e.Column.FieldName.ToUpper() == "SELECT")
                {
                    bool curentValue = (bool)ObjectHelper.GetPropValue(dto, "Select");
                    ObjectHelper.SetPropValue(dto, "Select", !curentValue);
                }
                else if (e.Column.FieldName.ToUpper() == "SELECTED")
                {
                    bool curentValue = (bool)ObjectHelper.GetPropValue(dto, "Selected");
                    ObjectHelper.SetPropValue(dto, "Selected", !curentValue);
                }

                grid.RefreshData();
                e.Handled = true;
            }
            catch (Exception ex)
            {
                MessageHelper.ShowException(ex);
            }
        }

        public static void grvSelect_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Space)
                {
                    GridView grid = sender as GridView;

                    if (grid != null)
                    {
                        int[] handleList = grid.GetSelectedRows();
                        if (handleList.Length > 0)
                        {
                            GridColumn focusColumn = grid.FocusedColumn;
                            int focusRowHandle = grid.FocusedRowHandle;

                            foreach (int i in handleList)
                            {
                                if (!grid.IsDataRow(i))
                                {
                                    continue;
                                }

                                //Nếu column đang focus chính là Column chọn
                                if (focusColumn != null && (focusColumn.FieldName.ToUpper() == "SELECT" || focusColumn.FieldName.ToUpper() == "SELECTED"))
                                {
                                    if (focusRowHandle == i)
                                    {
                                        grid.CloseEditor();
                                        continue;
                                    }
                                }

                                var dto = grid.GetRow(i);
                                if (dto != null)
                                {

                                    if (ObjectHelper.HasProperty(dto, "Select"))
                                    {
                                        bool curentValue = (bool)ObjectHelper.GetPropValue(dto, "Select");
                                        ObjectHelper.SetPropValue(dto, "Select", !curentValue);
                                    }
                                    if (ObjectHelper.HasProperty(dto, "Selected"))
                                    {
                                        bool curentValue = (bool)ObjectHelper.GetPropValue(dto, "Selected");
                                        ObjectHelper.SetPropValue(dto, "Selected", !curentValue);
                                    }
                                }
                            }
                            grid.RefreshData();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowException(ex);
            }
        }

        public static void SetGridViewStatus(GridControl grc, bool ReadOnly, bool UseFilter, bool ShowNewRow)
        {
            GridView gridView = grc.DefaultView as GridView;

            if (gridView != null)
            {
                gridView.OptionsBehavior.AllowAddRows = ReadOnly ? DevExpress.Utils.DefaultBoolean.False : DevExpress.Utils.DefaultBoolean.True;
                gridView.OptionsBehavior.AllowDeleteRows = ReadOnly ? DevExpress.Utils.DefaultBoolean.False : DevExpress.Utils.DefaultBoolean.True;
                gridView.OptionsBehavior.Editable = !ReadOnly;
                gridView.OptionsBehavior.ReadOnly = ReadOnly;
                gridView.OptionsCustomization.AllowGroup = true;
                gridView.OptionsCustomization.AllowSort = ShowNewRow ? ReadOnly : true;
                gridView.OptionsView.NewItemRowPosition = ShowNewRow ? NewItemRowPosition.Bottom : NewItemRowPosition.None;
                gridView.OptionsView.ShowAutoFilterRow = UseFilter;

            }
        }

        public static void SetGridViewConfig(GridControl grc, Type targetType = null, bool ReadOnly = true, bool UseFilter = true
                                            , bool ShowNewRow = false, bool ShowFooter = true, bool AllowCopy = true, bool isAddSum = true, List<string> lstFieldIgnoreSumery = null)
        {
            grc.LookAndFeel.UseDefaultLookAndFeel = true;
            grc.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
            //grc.LookAndFeel.SkinName = "DevExpress Style";
            GridView gridView = grc.DefaultView as GridView;

            var grcTag = grc.Tag as UIGridControlTag;

            grc.TabStop = false;
            if (gridView != null)
            {
                gridView.ClearSorting();
                if (!AllowCopy)
                {
                    gridView.KeyDown -= GridView_KeyDown;
                    gridView.KeyDown += GridView_KeyDown;
                }

                gridView.CustomUnboundColumnData -= new CustomColumnDataEventHandler(GridView_CustomUnboundColumnData);
                gridView.CustomUnboundColumnData += new CustomColumnDataEventHandler(GridView_CustomUnboundColumnData);

                gridView.RowCellStyle -= GridView_RowCellStyle;
                gridView.RowCellStyle += GridView_RowCellStyle;

                SetGridViewStatus(grc, ReadOnly, UseFilter, ShowNewRow);
                // Make the group footers always visible.
                gridView.OptionsView.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways;
                gridView.OptionsView.ShowFooter = targetType != null && ShowFooter;
                gridView.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
                gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;
                gridView.OptionsSelection.MultiSelect = true;
                gridView.OptionsBehavior.AutoExpandAllGroups = true;
                gridView.OptionsView.ShowDetailButtons = false; //Nếu dữ liệu DataSource là kiểu Master-Detail thì chặn không cho hiện dấu ( + ) ở từng row
                GridColumn col = GetFirstVisibleColumn(grc);
                if (col != null)
                {
                    AddRowCountToGrid(col, gridView);
                }

                Dictionary<string, List<UIGridCustomSummary>> dicSum = new Dictionary<string, List<UIGridCustomSummary>>();
                Dictionary<string, GridGroupSummaryItem> dicGroupSum = new Dictionary<string, GridGroupSummaryItem>();
                if (grcTag != null)
                {
                    dicSum = grcTag.GetDicColumnAndSummary();
                }

                if (!isAddSum)
                {
                    return;
                }
                foreach (GridColumn column in gridView.Columns)
                {
                    if (!lstFieldIgnoreSumery.IsNullOrEmpty() && lstFieldIgnoreSumery.Contains(column.FieldName))
                    {
                        continue;
                    }
                    if (col == null && column.Visible && column.VisibleIndex == 0)
                    {
                        AddRowCountToGrid(column, gridView);
                        col = column;
                    }

                    column.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
                    column.FilterMode = ColumnFilterMode.DisplayText;
                    //SetColumnAppearance(column);
                    if (targetType != null)
                    {

                        PropertyInfo property = ObjectHelper.GetProperty(targetType, column.FieldName);

                        if ((property != null && (property.PropertyType == typeof(Decimal) || property.PropertyType == typeof(Double)
                            || (property.PropertyType == typeof(int) && column.FieldName.ToUpper() != "STT"))
                            ) || (column != null && column.UnboundType == UnboundColumnType.Decimal)

                            )
                        {
                            column.Summary.Clear();
                            GridGroupSummaryItem groupSummaryItem = new GridGroupSummaryItem();
                            groupSummaryItem.ShowInGroupColumnFooter = column;
                            groupSummaryItem.FieldName = column.FieldName;
                            groupSummaryItem.Tag = column.FieldName;
                            if (column.Caption.ToUpper().StartsWith("TỶ LỆ"))
                            {
                                string columnFormat = column.DisplayFormat.FormatString;
                                string maskFormat = columnFormat;
                                string groupFormat = column.DisplayFormat.FormatString;
                                if (string.IsNullOrWhiteSpace(columnFormat))
                                {
                                    maskFormat = "N2";
                                    groupFormat = "{0:N2}";
                                    column.DisplayFormat.FormatString = "{0:N2}";
                                    column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                                    groupSummaryItem.SummaryType = SummaryItemType.Average;
                                    groupSummaryItem.DisplayFormat = "{0:N2}";
                                }
                                else
                                {
                                    groupFormat = columnFormat;
                                    if (columnFormat.StartsWith("N") || columnFormat.StartsWith("P"))
                                    {
                                        maskFormat = columnFormat;
                                        groupFormat = "{0:" + columnFormat + "}";
                                    }
                                }

                                if (column.RealColumnEdit != null)
                                {
                                    column.RealColumnEdit.EditFormat.FormatString = maskFormat;
                                    column.RealColumnEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                                }

                                column.Summary.Add(SummaryItemType.Average, column.FieldName, groupFormat);
                            }
                            else
                            {

                                string columnFormat = column.DisplayFormat.FormatString;
                                string maskFormat = columnFormat;
                                string groupFormat = column.DisplayFormat.FormatString;
                                if (string.IsNullOrWhiteSpace(columnFormat))
                                {
                                    maskFormat = "N0";
                                    columnFormat = "{0:N0}";
                                    column.DisplayFormat.FormatString = columnFormat;
                                    column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                                    groupFormat = columnFormat;
                                }
                                else
                                {
                                    groupFormat = columnFormat;
                                    if (columnFormat.StartsWith("N"))
                                    {
                                        maskFormat = columnFormat;
                                        groupFormat = "{0:" + columnFormat + "}";
                                    }
                                }


                                SetCurrencyMaskColumnEdit(column, groupFormat);

                                groupSummaryItem.SummaryType = SummaryItemType.Sum;
                                groupSummaryItem.DisplayFormat = groupFormat;

                                column.Summary.Add(SummaryItemType.Sum, column.FieldName, groupFormat);
                            }

                            if (dicSum.ContainsKey(column.FieldName) && dicSum[column.FieldName].Count >= 1)
                            {
                                if (!dicGroupSum.ContainsKey(column.FieldName))
                                {
                                    dicGroupSum.Add(column.FieldName, groupSummaryItem);
                                }
                            }
                            else
                            {
                                gridView.GroupSummary.Add(groupSummaryItem);
                            }
                        }
                        else
                        {
                            if (dicSum.ContainsKey(column.FieldName))
                            {
                                var lstColSum = dicSum[column.FieldName];
                                bool isDistinct = false;
                                foreach (var objSum in lstColSum)
                                {
                                    if (objSum is UIGridCustomSummaryDistinct)
                                    {
                                        isDistinct = true;
                                        break;
                                    }
                                }

                                if (isDistinct)
                                {
                                    if (col == column)
                                    {
                                        bool isRemove = false;
                                        foreach (GridGroupSummaryItem o in gridView.GroupSummary)
                                        {
                                            if (o.FieldName == col.FieldName)
                                            {
                                                if (!dicGroupSum.ContainsKey(col.FieldName))
                                                {
                                                    dicGroupSum.Add(col.FieldName, o);
                                                    isRemove = true;
                                                    break;
                                                }
                                            }
                                        }

                                        if (isRemove)
                                        {
                                            gridView.GroupSummary.Remove(dicGroupSum[col.FieldName]);
                                        }
                                    }
                                }
                            }
                        }

                    }
                }


                if (dicSum.Count > 0)
                {
                    foreach (String key in dicSum.Keys)
                    {
                        var sum = dicSum[key][0];
                        SummaryItemType type = SummaryItemType.Custom;
                        if (dicGroupSum.ContainsKey(key))
                        {
                            var groupItem = dicGroupSum[key];
                            Debug.Assert(sum != null, "sum != null");
                            if (sum is UIGridCustomSummaryPercent)
                            {
                                ((UIGridCustomSummaryPercent)sum).colThuong.SummaryItem.SummaryType = type;
                            }
                            else
                            {
                                type = ((UIGridCustomSummary)sum).SummaryType == SummaryItemType.None ? SummaryItemType.Custom : ((UIGridCustomSummary)sum).SummaryType;
                                ((UIGridCustomSummary)sum).BindingColumn.SummaryItem.SummaryType = type;
                            }

                            Debug.Assert(groupItem != null, "groupItem != null");
                            groupItem.SummaryType = type;
                            groupItem.Tag = groupItem.FieldName;

                            gridView.GroupSummary.Add(groupItem);
                        }
                        else
                        {
                            if (sum is UIGridCustomSummaryDistinct)
                            {
                                sum.BindingColumn.SummaryItem.SummaryType = type;

                            }
                        }
                    }
                }
            }
        }

        public static T GetCheckedSelectRow<T>(GridControl grd) where T : IList
        {
            var list = (T)InstanceHelper.CreateInstance(typeof(T));

            var ds = grd.DataSource;
            if (ds == null)
            {
                return list;
            }
            IList lstGrid = null;
            if (ds is BindingSource)
            {
                lstGrid = ((BindingSource)ds).DataSource as IList;
            }
            else
            {
                lstGrid = ds as IList;
            }

            if (lstGrid == null || lstGrid.Count == 0)
            {
                return list;
            }
            var type = lstGrid[0].GetType();
            var selectedCol = ObjectHelper.HasProperty(type, "SELECT") ? "SELECT" :
                                                (ObjectHelper.HasProperty(type, "SELECTED") ? "SELECTED" : "");

            if (string.IsNullOrWhiteSpace(selectedCol))
            {
                return list;
            }

            foreach (var o in lstGrid)
            {
                var selected = (bool)ObjectHelper.GetPropValue(o, selectedCol);
                if (selected)
                {
                    list.Add(o);
                }
            }

            return list;
        }

        private static void GridView_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                GridView grv = e.Column.View.GridControl.MainView as GridView;

                if (e.Column.View.IsDataRow(e.RowHandle))
                {
                    var lstSelectedCell = grv.GetSelectedCells(e.RowHandle);
                    bool isSelected = false;
                    if (lstSelectedCell != null && lstSelectedCell.Length > 0)
                    {
                        foreach (var col in lstSelectedCell)
                        {
                            if (col == e.Column)
                            {
                                isSelected = true;
                                break;
                            }
                        }
                    }

                    if ((!e.Column.OptionsColumn.AllowEdit || e.Column.OptionsColumn.ReadOnly)
                        && (!e.Column.View.OptionsBehavior.ReadOnly || e.Column.View.OptionsBehavior.Editable))
                    {
                        if (isSelected)
                        {
                            e.Appearance.BackColor = Color.FromArgb(255, 226, 234, 253);
                            e.Appearance.BackColor2 = Color.FromArgb(255, 226, 234, 253);
                            e.Appearance.ForeColor = Color.FromArgb(255, 32, 31, 53);
                            e.Column.RealColumnEdit.AppearanceReadOnly.ForeColor = Color.FromArgb(255, 32, 31, 53);
                            e.Column.RealColumnEdit.AppearanceReadOnly.BackColor = Color.FromArgb(255, 226, 234, 253);
                            e.Column.RealColumnEdit.AppearanceReadOnly.BackColor2 = Color.FromArgb(255, 226, 234, 253);
                        }
                        else
                        {
                            e.Appearance.BackColor = ColorTranslator.FromHtml("#e6e6e6");
                            e.Appearance.BackColor2 = ColorTranslator.FromHtml("#e6e6e6");
                            e.Column.RealColumnEdit.AppearanceReadOnly.BackColor = ColorTranslator.FromHtml("#e6e6e6");
                            e.Column.RealColumnEdit.AppearanceReadOnly.BackColor2 = ColorTranslator.FromHtml("#e6e6e6");
                        }
                    }
                    else
                    {
                        if (isSelected)
                        {
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowException(ex);
            }
        }

        private static void GridView_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.C)
                {
                    GridView grv = sender as GridView;
                    if (grv != null)
                    {
                        grv.ClearSelection();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowException(ex);
            }
        }

        private static void GridView_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            GridView grv = sender as GridView;
            if (grv != null && e.Column.UnboundType != UnboundColumnType.Bound)
            {
                if (e.IsGetData)
                {
                    e.Value = GetUnboundCellValue(grv, grv.GetRowHandle(e.ListSourceRowIndex), e.Column.Name);
                }
                else if (e.IsSetData)
                {
                    SetUnboundCellValue(grv, grv.GetRowHandle(e.ListSourceRowIndex), e.Column.Name, e.Value);
                }
            }
        }

        public static object GetUnboundCellValue(GridView grv, int rowHandle, String colName)
        {
            Dictionary<int, Dictionary<string, object>> dicValue = grv.Tag as Dictionary<int, Dictionary<string, object>>;
            if (dicValue != null && dicValue.ContainsKey(rowHandle) && dicValue[rowHandle] != null && dicValue[rowHandle].ContainsKey(colName))
            {
                return dicValue[rowHandle][colName];
            }

            return null;
        }

        public static bool SetUnboundCellValue(GridView grv, int rowHandle, String colName, object value)
        {
            Dictionary<int, Dictionary<string, object>> dicValue = grv.Tag as Dictionary<int, Dictionary<string, object>>;
            if (dicValue == null)
            {
                dicValue = new Dictionary<int, Dictionary<string, object>>();
                grv.Tag = dicValue;
            }

            if (grv.IsDataRow(rowHandle))
            {
                Dictionary<string, object> rowValues = null;
                if (!dicValue.ContainsKey(rowHandle))
                {
                    rowValues = new Dictionary<string, object>();
                    dicValue.Add(rowHandle, rowValues);
                }
                else
                {
                    rowValues = dicValue[rowHandle];
                }

                if (!rowValues.ContainsKey(colName))
                {
                    rowValues.Add(colName, value);
                }
                else
                {
                    rowValues[colName] = value;
                }

                return true;
            }

            return false;
        }

        public static GridColumn GetFirstVisibleColumn(GridControl grd)
        {
            if (grd.MainView is BandedGridView)
            {
                BandedGridView bandView = grd.MainView as BandedGridView;
                GridBand band = GetFirstGridBand(bandView.Bands.FirstVisibleBand);
                if (band != null && band.Columns.VisibleColumnCount > 0)
                {
                    BandedGridColumn colCurrent = band.Columns[0];
                    foreach (BandedGridColumn col in band.Columns)
                    {
                        if (col.Visible)
                        {
                            colCurrent = col;
                            break;
                        }
                    }
                    return colCurrent;
                }
                return bandView.Columns[0];
            }
            else
            {
                GridView gridView = grd.DefaultView as GridView;
                return gridView.GetVisibleColumn(0);
            }
        }

        public static GridBand GetFirstGridBand(GridBand rootBand)
        {
            GridBand rs = null;
            if (rootBand.HasChildren)
            {
                rs = GetFirstGridBand(rootBand.Children.FirstVisibleBand);
            }
            else
            {
                rs = rootBand;
            }
            return rs;
        }

        public static void AddRowCountToGrid(GridColumn column, GridView grdControl)
        {
            if (column != null)
            {
                column.Summary.Clear();
                GridGroupSummaryItem groupSummaryItem = new GridGroupSummaryItem();
                groupSummaryItem.ShowInGroupColumnFooter = column;
                groupSummaryItem.FieldName = column.FieldName;
                groupSummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                groupSummaryItem.DisplayFormat = "{0:N0}";
                grdControl.GroupSummary.Add(groupSummaryItem);

                column.Summary.Add(SummaryItemType.Count, column.FieldName, "{0:N0}");
            }
        }

        public static void SetCurrencyMaskColumnEdit(GridColumn column, String groupFormat)
        {
            if (column.ColumnEdit == null)
            {
                int iNChar = groupFormat.IndexOf('N');
                int iDecimal = 0;
                if (iNChar >= 0 && groupFormat.Length > iNChar + 1)
                {
                    int.TryParse(groupFormat.Substring(iNChar + 1, 1), out iDecimal);
                }

                RepositoryItemTextEdit editor = new RepositoryItemTextEdit();
                SetCurrencyMaskEdit(editor, iDecimal);
                column.ColumnEdit = editor;
            }
        }

        public static void SetCurrencyMaskEdit(RepositoryItemTextEdit txtControl, int DecimalDigits = 2, DevExpress.Utils.HorzAlignment Alignment = DevExpress.Utils.HorzAlignment.Far)
        {
            txtControl.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtControl.Mask.UseMaskAsDisplayFormat = true;
            txtControl.Mask.EditMask = "N" + DecimalDigits.ToString();
            txtControl.Appearance.TextOptions.HAlignment = Alignment;
        }
    }
}
