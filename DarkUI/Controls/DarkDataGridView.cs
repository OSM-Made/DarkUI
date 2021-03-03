using DarkUI.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DarkUI.Controls
{
    public partial class DarkDataGridView : DataGridView
    {
        public DarkDataGridView()
        {
            InitializeComponent();

            //Custom Colours
            RowsDefaultCellStyle.BackColor = Colors.HeaderBackground;
            AlternatingRowsDefaultCellStyle.BackColor = Colors.GreyBackground;
            ColumnHeadersDefaultCellStyle.ForeColor = Colors.LightText;
            ColumnHeadersDefaultCellStyle.BackColor = Colors.LighterBackground;
            EnableHeadersVisualStyles = false;
            DefaultCellStyle.ForeColor = Colors.LightText;
            DefaultCellStyle.BackColor = Colors.HeaderBackground;
            DefaultCellStyle.SelectionBackColor = Colors.BlueSelection;
            DefaultCellStyle.SelectionForeColor = Colors.LightText;
            BackColor = Colors.GreyHighlight;
            GridColor = Colors.HeaderBackground;
            BackgroundColor = Colors.GreyBackground;

            //Design
            BorderStyle = BorderStyle.None;
            CellBorderStyle = DataGridViewCellBorderStyle.None;
            ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            RowHeadersVisible = false;
            AllowUserToResizeRows = false;
            AllowUserToResizeColumns = false;
            AllowUserToOrderColumns = false;
            AllowUserToAddRows = false;

            //Focus Events
            Enter += DarkDataGridView_Enter;
            Leave += DarkDataGridView_Leave;

            //Scroll Bar Events
            ScrollBar.ValueChanged += ScrollBar_ValueChanged;
            Scroll += DarkDataGridView_Scroll;
            RowsAdded += DarkDataGridView_RowsAdded;
            RowsRemoved += DarkDataGridView_RowsRemoved;

            //Setup Scroll Bar
            ScrollBar.Minimum = 0;
            ScrollBar.Maximum = 100;
            ScrollBar.ViewSize = 99;
            ScrollBar.Visible = false;
            ScrollBar.BringToFront();
        }

        private void DarkDataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            ScrollBar.BringToFront();
            if (Rows.Count <= (Height / (Rows.GetRowsHeight(DataGridViewElementStates.None) / Rows.Count)) - 2)
            {
                ScrollBar.Minimum = 0;
                ScrollBar.Maximum = 100;
                ScrollBar.ViewSize = 99;

                ScrollBar.Visible = false;
            }
            else
            {
                ScrollBar.Minimum = 0;
                ScrollBar.Maximum = Rows.Count;
                ScrollBar.ViewSize = (Height / (Rows.GetRowsHeight(DataGridViewElementStates.None) / Rows.Count)) - 2;
                ScrollBar.Visible = true;
            }
        }

        private void DarkDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ScrollBar.BringToFront();
            if (Rows.Count <= (Height / (Rows.GetRowsHeight(DataGridViewElementStates.None) / Rows.Count)) - 2)
            {
                ScrollBar.Minimum = 0;
                ScrollBar.Maximum = 100;
                ScrollBar.ViewSize = 99;

                ScrollBar.Visible = false;
            }
            else
            {
                ScrollBar.Minimum = 0;
                ScrollBar.Maximum = Rows.Count;
                ScrollBar.ViewSize = (Height / (Rows.GetRowsHeight(DataGridViewElementStates.None) / Rows.Count)) - 2;
                ScrollBar.Visible = true;
            }
        }

        private void DarkDataGridView_Scroll(object sender, ScrollEventArgs e)
        {
            if (Rows.Count > 0)
            {
                ScrollBar.ScrollTo(e.NewValue);
                ScrollBar.UpdateScrollBar();
            }
        }

        private void ScrollBar_ValueChanged(object sender, ScrollValueEventArgs e)
        {
            if (Rows.Count > 0)
                FirstDisplayedScrollingRowIndex = e.Value;
        }

        private void DarkDataGridView_Enter(object sender, EventArgs e)
        {
            VerticalScrollBar.Visible = false;
            DefaultCellStyle.SelectionBackColor = Colors.BlueSelection;
        }

        private void DarkDataGridView_Leave(object sender, EventArgs e)
        {
            VerticalScrollBar.Visible = false;
            DefaultCellStyle.SelectionBackColor = Colors.GreySelection;
        }
    }
}
