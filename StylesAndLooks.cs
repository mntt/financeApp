using financeApp.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace financeApp
{
    public class StylesAndLooks
    {
        public void SetFormLooks(Form formName)
        {
            formName.FormBorderStyle = FormBorderStyle.FixedSingle;
            formName.BackColor = Color.FromArgb(17, 17, 17);
            formName.Text = String.Empty;
            formName.Icon = Resources.finance_icon;
        }

        public void SetButtonStyle(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.Font = new Font("MS Reference Sans Serif", 7);
            button.FlatAppearance.BorderColor = Color.FromArgb(25, 102, 25);
            button.ForeColor = Color.White;
            button.BackColor = Color.FromArgb(17, 17, 17);
            button.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 174, 219);
            button.FlatAppearance.MouseDownBackColor = Color.FromArgb(55, 215, 255);
        }

        public void SetDisabledButtonStyle(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.Font = new Font("MS Reference Sans Serif", 7);
            button.FlatAppearance.BorderColor = Color.FromArgb(31, 31, 20);
            button.ForeColor = Color.Black;
            button.BackColor = Color.FromArgb(17, 17, 17);            
        }

        public void SetDataGridLooks(DataGridView dataGridName)
        {
            dataGridName.EnableHeadersVisualStyles = false;
            dataGridName.BackgroundColor = Color.FromArgb(17, 17, 17);
            dataGridName.BorderStyle = BorderStyle.None;
            dataGridName.GridColor = Color.FromArgb(25, 102, 25);
        }

        public void SetColumnStyle(DataGridView dataGridName, DataGridViewAutoSizeColumnsMode mode, bool isHeaderVisible)
        {
            dataGridName.AutoSizeColumnsMode = mode;        
            dataGridName.ColumnHeadersVisible = isHeaderVisible;
            dataGridName.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(17, 17, 17);
            dataGridName.ColumnHeadersDefaultCellStyle.Font = new Font("MS Reference Sans Serif", 9);
            dataGridName.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dataGridName.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridName.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridName.ColumnHeadersHeight = 30;
            dataGridName.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridName.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 174, 219);
            dataGridName.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dataGridName.AllowUserToOrderColumns = false;
            dataGridName.AllowUserToResizeColumns = false;
            
            foreach (DataGridViewColumn col in dataGridName.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                col.Width = 105;
            }
        }

        public void SetSimplisticColumnStyle(DataGridView dataGridName)
        {
            dataGridName.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridName.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(17, 17, 17);
            dataGridName.ColumnHeadersDefaultCellStyle.Font = new Font("MS Reference Sans Serif", 9);
            dataGridName.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dataGridName.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridName.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridName.ColumnHeadersHeight = 30;
            dataGridName.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridName.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 174, 219);
            dataGridName.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dataGridName.AllowUserToOrderColumns = false;
            dataGridName.AllowUserToResizeColumns = false;

            foreach (DataGridViewColumn col in dataGridName.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        public void SetRowStyle(DataGridView dataGridName, DataGridViewAutoSizeRowsMode rowMode, DataGridViewRowHeadersWidthSizeMode headerMode, int rowHeaderWidth)
        {
            dataGridName.AutoSizeRowsMode = rowMode;
            dataGridName.RowHeadersWidthSizeMode = headerMode;
            dataGridName.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridName.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(17, 17, 17);
            dataGridName.RowHeadersDefaultCellStyle.Font = new Font("MS Reference Sans Serif", 9);
            dataGridName.RowHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dataGridName.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridName.RowHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridName.RowHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 174, 219);
            dataGridName.RowHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridName.AllowUserToResizeRows = false;

            if (headerMode == DataGridViewRowHeadersWidthSizeMode.DisableResizing)
            {
                dataGridName.RowHeadersWidth = rowHeaderWidth;
            }
        }

        public void SetRowHeaderWidths(DataGridView firstDataGrid, DataGridView secondDataGrid)
        {
            int counter = 0;

            foreach(DataGridViewRow row in firstDataGrid.Rows)
            {
                var chars = row.HeaderCell.Value.ToString().ToCharArray();
                
                if(chars.Length > 14)
                {
                    firstDataGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
                    secondDataGrid.RowHeadersWidth = firstDataGrid.RowHeadersWidth;
                    counter++;
                    break;
                }
            }

            if(counter == 0)
            {
                firstDataGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                firstDataGrid.RowHeadersWidth = 115;
                secondDataGrid.RowHeadersWidth = 115;
            }
        }


        public void SetCellStyle(DataGridView dataGridName)
        {
            dataGridName.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridName.DefaultCellStyle.ForeColor = Color.White;
            dataGridName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridName.DefaultCellStyle.Font = new Font("MS Reference Sans Serif", 8);
            dataGridName.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridName.DefaultCellStyle.BackColor = Color.FromArgb(17, 17, 17);
            dataGridName.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 174, 219);
            dataGridName.DefaultCellStyle.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridName.DefaultCellStyle.Format = "C2";
        }

        public void PaintColumnAsSelected(DataGridView dataGridName, int columnIndex)
        {
            dataGridName.Columns[columnIndex].HeaderCell.Style.BackColor = Color.FromArgb(0, 174, 219);
            dataGridName.Columns[columnIndex].HeaderCell.Style.ForeColor = Color.FromArgb(17, 17, 17);

            for (int i = 0; i < dataGridName.Rows.Count; i++)
            {
                dataGridName.Rows[i].Cells[columnIndex].Style.BackColor = Color.FromArgb(0, 174, 219);
                dataGridName.Rows[i].Cells[columnIndex].Style.ForeColor = Color.FromArgb(17, 17, 17);
            }
        }

        public void ChangeSelectedColumn(DataGridView dataGridName, int columnIndex)
        {
            for (int i = 0; i < dataGridName.Columns.Count; i++)
            {
                if (i != columnIndex)
                {
                    if (dataGridName.Columns[i].HeaderCell.Style.BackColor == Color.FromArgb(0, 174, 219) &&
                        dataGridName.Columns[i].HeaderCell.Style.ForeColor == Color.FromArgb(17, 17, 17))
                    {

                        for (int j = 0; j < dataGridName.Rows.Count; j++)
                        {
                            dataGridName.Columns[i].HeaderCell.Style.BackColor = Color.FromArgb(17, 17, 17);
                            dataGridName.Columns[i].HeaderCell.Style.ForeColor = Color.White;

                            dataGridName.Rows[j].Cells[i].Style.BackColor = Color.FromArgb(17, 17, 17);
                            dataGridName.Rows[j].Cells[i].Style.ForeColor = Color.White;
                        }     
                    }
                }
            }
        }

        public void ClearSelection(DataGridView dataGridName, bool clearGridPaint, bool clearGridSelection)
        {
            if (clearGridPaint)
            {    
                RemovePainting(dataGridName); 
            }

            if (clearGridSelection)
            {
                dataGridName.ClearSelection();
            }
        }

        private void RemovePainting(DataGridView dataGridName)
        {
            for (int column = 0; column < dataGridName.Columns.Count; column++)
            {
                if (dataGridName.Columns[column].HeaderCell.Style.BackColor == Color.FromArgb(0, 174, 219) &&
                        dataGridName.Columns[column].HeaderCell.Style.ForeColor == Color.FromArgb(17, 17, 17))
                {
                    dataGridName.Columns[column].HeaderCell.Style.BackColor = Color.FromArgb(17, 17, 17);
                    dataGridName.Columns[column].HeaderCell.Style.ForeColor = Color.White;

                    for (int row = 0; row < dataGridName.Rows.Count; row++)
                    {
                        dataGridName.Rows[row].Cells[column].Style.BackColor = Color.FromArgb(17, 17, 17);
                        dataGridName.Rows[row].Cells[column].Style.ForeColor = Color.White;
                    }
                }
            }
        }

        public void SetLabelStyle(Label label, int fontSize)
        {
            label.Font = new Font("MS Reference Sans Serif", fontSize);
            label.BackColor = Color.FromArgb(17, 17, 17);
            label.ForeColor = Color.White;
        }

        public void SetTextBoxStyle(TextBox textbox)
        {
            textbox.Font = new Font("MS Reference Sans Serif", 8);
            textbox.BackColor = Color.White;
            textbox.ForeColor = Color.FromArgb(17, 17, 17);
            textbox.BorderStyle = BorderStyle.Fixed3D;
        }

        public void SetRichTextBoxStyle(RichTextBox richTextBox)
        {
            richTextBox.Font = new Font("MS Reference Sans Serif", 7);
            richTextBox.ForeColor = Color.White;
            richTextBox.BackColor = Color.FromArgb(17, 17, 17);
            richTextBox.ReadOnly = true;
            richTextBox.BorderStyle = BorderStyle.FixedSingle;
        }

        public void SetPanelStyle(Panel panel)
        {
            panel.BackColor = Color.FromArgb(17, 17, 17);
            panel.BorderStyle = BorderStyle.FixedSingle;
        }

    }
}
