using DevExpress.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;

namespace DEV_KPI.Common.UI
{
    public class UIGridControlTag
    {
        public string Title
        {
            get;
            set;
        }

        public bool AllowCopy
        {
            get;
            set;
        }

        private GridControl _parent = null;
        public GridControl Parent
        {
            get { return _parent; }
        }

        private GridView _defaultView = null;
        public GridView DefaultView
        {
            get { return _defaultView; }
        }

        private readonly Dictionary<Type, List<UIGridCustomSummary>> dicCustomSummary = new Dictionary<Type, List<UIGridCustomSummary>>();
        public List<UIGridCustomSummary> GetCustomSummaryByType(Type t)
        {
            if (dicCustomSummary.ContainsKey(t))
            {
                return dicCustomSummary[t];
            }

            return null;
        }

        /// <summary>
        /// FieldName, Summary
        /// </summary>
        private readonly Dictionary<string, List<UIGridCustomSummary>> dicColumnAndSummary = new Dictionary<string, List<UIGridCustomSummary>>();
        public Dictionary<string, List<UIGridCustomSummary>> GetDicColumnAndSummary()
        {
            return dicColumnAndSummary;
        }

        /// <summary>
        /// FieldName, Summary
        /// </summary>
        private readonly Dictionary<string, GridGroupSummaryItem> dicColumnGroupSummaryItem = new Dictionary<string, GridGroupSummaryItem>();
        public Dictionary<string, GridGroupSummaryItem> GetDicColumnAndGroupSummaryItem()
        {
            return dicColumnGroupSummaryItem;
        }

        public readonly Dictionary<UIGridCustomSummaryDistinct, Dictionary<String, object>> lstCustomSumDistinctValue = new Dictionary<UIGridCustomSummaryDistinct, Dictionary<String, object>>();
        public Dictionary<String, object> GetDistinctList(UIGridCustomSummaryDistinct obj)
        {
            if (lstCustomSumDistinctValue.ContainsKey(obj))
            {
                return lstCustomSumDistinctValue[obj];
            }

            return null;
        }

        public static UIGridControlTag Register(GridControl grc, string title, params UIGridCustomSummary[] summaryConfigs)
        {
            //Remove handle oldtag
            var oldTag = grc.Tag as UIGridControlTag;
            if (oldTag != null && oldTag._defaultView != null)
            {
                oldTag._defaultView.CustomSummaryCalculate -= oldTag.gridView_CustomSummaryCalculate;
            }

            UIGridControlTag tag = new UIGridControlTag();
            tag._parent = grc;
            tag.Title = title;

            tag._parent.Tag = tag;
            tag._defaultView = grc.DefaultView as GridView;
            if (tag._defaultView != null)
            {
                tag._defaultView.CustomSummaryCalculate += tag.gridView_CustomSummaryCalculate;
                if (summaryConfigs != null && summaryConfigs.Length > 0)
                {
                    tag.RegisterSummary(summaryConfigs);
                }
            }

            return tag;
        }

        public void RegisterSummary(params UIGridCustomSummary[] objs)
        {

            foreach (var o in objs)
            {
                var t = o.GetType();
                if (!dicCustomSummary.ContainsKey(t))
                {
                    dicCustomSummary.Add(t, new List<UIGridCustomSummary>());
                }
                dicCustomSummary[t].Add(o);
                AddToDicFieldName(o);
                if (o is UIGridCustomSummaryDistinct)
                {
                    lstCustomSumDistinctValue.Add(o as UIGridCustomSummaryDistinct, new Dictionary<string, object>());
                }
            }
        }

        private void AddToDicFieldName(UIGridCustomSummary sum)
        {
            string name = sum.BindingColumn.FieldName;
            if (!dicColumnAndSummary.ContainsKey(name))
            {
                dicColumnAndSummary.Add(name, new List<UIGridCustomSummary>());
            }
            dicColumnAndSummary[name].Add(sum);
        }

        public void ResetDistinctValue()
        {
            foreach (var o in lstCustomSumDistinctValue.Keys)
            {
                lstCustomSumDistinctValue[o].Clear();
            }
        }


        #region Method Process Summary
        protected virtual void gridView_CustomSummaryCalculate(object sender, CustomSummaryEventArgs e)
        {
            GridView defaultView = sender as GridView;
            //Finalization 
            ProcessCustomSummaryPercent(defaultView, e);
            ProcessCustomSummaryFormat(defaultView, e);
            ProcessCustomSummaryDistinct(defaultView, e);
        }

        protected virtual void ProcessCustomSummaryPercent(GridView defaultView, CustomSummaryEventArgs e)
        {
            GridControl grc = defaultView.GridControl;
            if (!grc.Equals(_parent))
            {
                return;
            }

            if (e.SummaryProcess != CustomSummaryProcess.Finalize)
            {
                return;
            }

            var lstSum = GetCustomSummaryByType(typeof(UIGridCustomSummaryPercent));
            if (lstSum == null || lstSum.Count == 0)
            {
                return;
            }

            foreach (UIGridCustomSummaryPercent sum in lstSum)
            {
                if (e.IsTotalSummary)
                {
                    if (sum.colThuong.SummaryItem.FieldName == (e.Item as GridSummaryItem).FieldName)
                    {
                        decimal a = Convert.ToDecimal(sum.colSoBiChia.SummaryItem.SummaryValue);
                        decimal b = Convert.ToDecimal(sum.colSoChia.SummaryItem.SummaryValue);

                        e.TotalValue = CustomSumPercent(defaultView, sum, false, e, b, a);
                    }
                }
                else if (e.IsGroupSummary)
                {
                    if (sum.colThuong.FieldName == (e.Item as GridGroupSummaryItem).FieldName)
                    {
                        object chia = e.GetGroupSummary(e.GroupRowHandle, defaultView.GroupSummary[sum.colSoBiChia.FieldName]);
                        object biChia = e.GetGroupSummary(e.GroupRowHandle, defaultView.GroupSummary[sum.colSoChia.FieldName]);

                        e.TotalValue = CustomSumPercent(defaultView, sum, true, e, biChia, chia);
                    }
                }

            }
        }

        protected virtual void ProcessCustomSummaryFormat(GridView defaultView, CustomSummaryEventArgs e)
        {
            GridControl grc = defaultView.GridControl;
            if (!grc.Equals(_parent))
            {
                return;
            }

            if (e.SummaryProcess != CustomSummaryProcess.Finalize)
            {
                return;
            }

            var lstSum = GetCustomSummaryByType(typeof(UIGridCustomSummary));
            if (lstSum == null || lstSum.Count == 0)
            {
                return;
            }

            foreach (UIGridCustomSummary sum in lstSum)
            {
                if (e.IsTotalSummary)
                {
                    if (sum.BindingColumn.SummaryItem.FieldName == (e.Item as GridSummaryItem).FieldName)
                    {

                        e.TotalValue = CustomSumTotal(defaultView, sum.BindingColumn.SummaryItem.FieldName, false, e, null);
                    }
                }
                else if (e.IsGroupSummary)
                {
                    if (sum.BindingColumn.FieldName == (e.Item as GridGroupSummaryItem).FieldName)
                    {
                        GridColumn groupColumn = null;
                        if (e.GroupLevel >= 0)
                        {
                            foreach (GridColumn col in defaultView.GroupedColumns)
                            {
                                if (col.GroupIndex == e.GroupLevel)
                                {
                                    groupColumn = col;
                                    break;
                                }
                            }
                        }

                        e.TotalValue = CustomSumTotal(defaultView, sum.BindingColumn.SummaryItem.FieldName, true, e, groupColumn);
                    }
                }

            }
        }

        protected virtual void ProcessCustomSummaryDistinct(GridView defaultView, CustomSummaryEventArgs e)
        {
            GridControl grc = defaultView.GridControl;
            if (!grc.Equals(_parent))
            {
                return;
            }

            var lstSum = GetCustomSummaryByType(typeof(UIGridCustomSummaryDistinct));
            if (lstSum == null || lstSum.Count == 0)
            {
                return;
            }

            GridSummaryItem item = e.Item as GridSummaryItem;

            if (item == null)
            {
                return;
            }

            foreach (UIGridCustomSummaryDistinct sum in lstSum)
            {
                if (sum.BindingColumn.SummaryItem.FieldName == item.FieldName)
                {
                    if (e.SummaryProcess == CustomSummaryProcess.Start)
                    {
                        GetDistinctList(sum).Clear();
                    }
                    else
                    {
                        var data = GetDistinctList(sum);

                        if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                        {

                            object v = e.FieldValue;
                            if (sum.IgnoreEmptyData && (v == null || String.IsNullOrWhiteSpace(v.ToString())))
                            {
                                continue;
                            }

                            var vKey = UIGridCustomSummaryDistinct.GetKeyValue(v);
                            bool exist = data.ContainsKey(vKey);
                            if (!exist)
                            {
                                data.Add(vKey, v);
                            }
                        }

                        if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                        {
                            e.TotalValue = data.Count;
                        }
                    }
                }
            }
        }

        protected virtual object CustomSumPercent(GridView defaultView, UIGridCustomSummaryPercent sumDefine, bool isGroup, CustomSummaryEventArgs e, object objChia, object objBiChia)
        {
            decimal result = sumDefine.DefaultPercentValue;
            if (Convert.ToDecimal(objChia) != 0)
            {
                Decimal thuong = Convert.ToDecimal(objBiChia) / Convert.ToDecimal(objChia);
                result = sumDefine.IsPercent ? thuong * 100 : thuong;
            }
            return result;
        }

        protected virtual object CustomSumTotal(GridView defaultView, String fieldName, bool isGroup, CustomSummaryEventArgs e, GridColumn groupColumn)
        {
            return null;
        }

        #endregion
    }


}
