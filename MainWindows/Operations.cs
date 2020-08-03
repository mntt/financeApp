using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace financeApp
{
    public partial class Operations : Form
    {   
        private int rowIndex { get; set; }
        private int columnIndex { get; set; }
        private List<TempOperationInfo> tempInfo = new List<TempOperationInfo>();
        private bool isValueNull = true;
        private bool isValueInDatabase = true;
        private Form menuForm;

        public Operations(Form _menuForm)
        {
            InitializeComponent();
            StopAllTabs();
            menuForm = _menuForm;
        }

        private void StopAllTabs()
        {
            StopTab(addOperation);
            StopTab(deleteRows);
            StopTab(saveOperations);
            StopTab(operationsBackButton);
        }

        private void StopTab(Button button)
        {
            button.TabStop = false;
        }

        private void Operations_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (saveOperations.Enabled == true)
            {
                DialogResult result = MessageBox.Show("Jūsų atlikti pakeitimai bus neišsaugoti. " +
                    "Ar tikrai norite išeiti?", "Pranešimas", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    this.FormClosing -= Operations_FormClosing;
                    Application.Exit();
                }

                e.Cancel = (result == DialogResult.No);                
            }
            else if(saveOperations.Enabled == false)
            {
                Application.Exit();
            }
        }

        private void operationsBackButton_Click(object sender, EventArgs e)
        {
            if (saveOperations.Enabled == true)
            {
                DialogResult result = MessageBox.Show("Jūsų atlikti pakeitimai bus neišsaugoti. " +
                    "Ar tikrai norite grįžti į Meniu?", "Pranešimas", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    this.FormClosing -= Operations_FormClosing;
                    this.Close();
                    menuForm.Show();                   
                }
            }
            else if(saveOperations.Enabled == false)
            {
                this.FormClosing -= Operations_FormClosing;
                this.Hide();
                menuForm.Show();
            } 
        }

        private void LoadTypesToComboBox()
        {
            SetStyleForComboBox();
            var types = Connection.db.GetTable<OperationTypes>();
            foreach (var item in types)
            {
                operationType.Items.Add(item.Type);  
            }
        }

        private void SetStyleForComboBox()
        {
            operationType.FlatStyle = FlatStyle.Flat;
            operationType.DefaultCellStyle.BackColor = Color.FromArgb(17, 17, 17);
            operationType.DefaultCellStyle.ForeColor = Color.White;
            operationType.DefaultCellStyle.Font = new Font("MS Reference Sans Serif", 8);
            operationType.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 174, 219);
            operationType.DefaultCellStyle.SelectionForeColor = Color.FromArgb(17, 17, 17);           
        }

        private void LoadOperations()
        {
            var operationInfo = Connection.db.GetTable<OperationInfo>().Where(x => x.UserId == User.ID);
            int counter = 0;
            foreach (var item in operationInfo)
            {
                operationLog.Rows.Add();
                operationLog.Rows[counter].Cells[0].Value = item.Date.ToString("yyyy-MM-dd");
                operationLog.Rows[counter].Cells[1].Value = item.OperationText;
                operationLog.Rows[counter].Cells[2].Value = item.Sum;
                operationLog.Rows[counter].Cells[3].Value = item.SelectedType;

                TempOperationInfo op = new TempOperationInfo(item.Date, item.OperationText, item.Sum, item.SelectedType, item.UserId);
                tempInfo.Add(op);
                counter++;
            }
        }

        private void Operations_Load(object sender, EventArgs e)
        {
            LoadTypesToComboBox();
            LoadOperations();
            SetStylesAndLooks();

            if (operationLog.Rows.Count > 0)
            {
                deleteRows.Enabled = true;
                Connection.style.SetButtonStyle(deleteRows);
            }
            else if(operationLog.Rows.Count == 0)
            {
                deleteRows.Enabled = false;
                Connection.style.SetDisabledButtonStyle(deleteRows);
            }
        }

        private void addOperation_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            string todaysDate = today.ToString("yyyy-MM-dd");

            operationLog.Rows.Add();
            operationLog.Rows[operationLog.Rows.Count-1].Cells[0].Value = todaysDate;                
            
            deleteRows.Enabled = true;
            Connection.style.SetButtonStyle(deleteRows);
        }

        private void OperationLog_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = operationLog.CurrentCell.RowIndex;
            columnIndex = operationLog.CurrentCell.ColumnIndex;

            if (operationLog.Rows[rowIndex].Cells[columnIndex].Value == null)
            {
                isValueNull = true;
            }

            if (operationLog.Rows[rowIndex].Cells[columnIndex].Value != null)
            {
                isValueNull = false;
            }
        }

        private void OperationLog_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;
            columnIndex = e.ColumnIndex;

            if (operationLog.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
            {
                isValueNull = true;
            }

            if (operationLog.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                isValueNull = false;
            }
        }

        private void deleteRows_Click(object sender, EventArgs e)
        {            
            if(operationLog.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nepažymėjote eilutės, kurią norite ištrinti.", "Klaida");
            }
            else
            {
                bool showWarningMessage = true;

                foreach (DataGridViewRow row in operationLog.SelectedRows)
                {
                    var selectedRow = operationLog.Rows[row.Index];

                    if (selectedRow.Cells[0].Value == null || selectedRow.Cells[1].Value == null ||
                        selectedRow.Cells[2].Value == null || selectedRow.Cells[3].Value == null)
                    {
                        operationLog.Rows.RemoveAt(row.Index);
                        saveOperations.Enabled = true;
                        Connection.style.SetButtonStyle(saveOperations);
                    }
                    else if (selectedRow.Cells[0].Value != null && selectedRow.Cells[1].Value != null &&
                        selectedRow.Cells[2].Value != null && selectedRow.Cells[3].Value != null)
                    {
                        if (showWarningMessage)
                        {
                            DialogResult result = MessageBox.Show("Vienoje arba daugiau eilučių yra duomenų, " +
                             "kurie susiję su kitomis lentelėmis.\nAr tikrai norite ištrinti pažymėtas eilutes?",
                             "Pranešimas", MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                            {
                                DeleteSelectedRows(row);
                                showWarningMessage = false;
                            }
                            else if (result == DialogResult.No)
                            {
                                break;
                            }

                        }   
                        else if (!showWarningMessage)
                        {
                            DeleteSelectedRows(row);
                        }
                    }
                }
                ReloadTempInfoList();
            }     
        }

        private void DeleteSelectedRows(DataGridViewRow row)
        {
            operationLog.Rows.RemoveAt(row.Index);
            saveOperations.Enabled = true;
            Connection.style.SetButtonStyle(saveOperations);

            if (operationLog.Rows.Count == 0)
            {
                deleteRows.Enabled = false;
                Connection.style.SetDisabledButtonStyle(deleteRows);
            }
        }

        private void ReloadTempInfoList()
        {
            tempInfo.Clear();

            if (operationLog.Rows.Count > 0)
            {
                for (int i = 0; i < operationLog.Rows.Count; i++)
                {
                    if (operationLog.Rows[i].Cells[0].Value != null && 
                        operationLog.Rows[i].Cells[1].Value != null && 
                        operationLog.Rows[i].Cells[2].Value != null && 
                        operationLog.Rows[i].Cells[3].Value != null)
                    {
                        TempOperationInfo op = new TempOperationInfo
                        (
                            DateTime.Parse(operationLog.Rows[i].Cells[0].Value.ToString()),
                            operationLog.Rows[i].Cells[1].Value.ToString(),
                            Double.Parse(operationLog.Rows[i].Cells[2].Value.ToString()),
                            operationLog.Rows[i].Cells[3].Value.ToString(),
                            User.ID
                        );
                        tempInfo.Add(op);
                    }
                }
            }
        }

        async Task LoadingImage()
        {
            await Task.Run(() =>
            {
                LoadingScreen.ShowLoadingScreen(1000);
            });
        }

        private async void WaitForLoadingImageEnd()
        {
            await LoadingImage();
        }

        private void saveOperations_Click(object sender, EventArgs e)
        {
            if(Connection.CheckConnectivity() == true)
            {
                WaitForLoadingImageEnd();

                Thread.Sleep(1000);

                int allCells = operationLog.Columns.Count * operationLog.Rows.Count;
                int notNullCells = 0;

                for (int i = 0; i < operationLog.Rows.Count; i++)
                {
                    for (int j = 0; j < operationLog.Columns.Count; j++)
                    {
                        if (operationLog.Rows[i].Cells[j].Value != null)
                        {
                            notNullCells++;
                        }
                    }
                }

                if (allCells > notNullCells)
                {
                    MessageBox.Show("Negalima išsaugoti duomenų, kol yra tuščių laukelių." +
                        "\nUžpildykite visus laukelius, arba ištrinkite tuščias eilutes.", "Pranešimas");
                }
                else if (allCells == notNullCells)
                {
                    Connection.iwdb.DeleteData("OperationInfo", User.ID);

                    if (tempInfo.Count > 0)
                    {
                        Connection.iwdb.InsertOperationInfo(tempInfo);
                        MessageBox.Show("Operacijos įrašytos!", "Pranešimas");
                        saveOperations.Enabled = false;
                        Connection.style.SetDisabledButtonStyle(saveOperations);
                        StopAllTabs();
                    }
                    else if (tempInfo.Count == 0)
                    {
                        MessageBox.Show("Pakeitimai išsaugoti!", "Pranešimas");
                        saveOperations.Enabled = false;
                        deleteRows.Enabled = false;
                        Connection.style.SetDisabledButtonStyle(saveOperations);
                        Connection.style.SetDisabledButtonStyle(deleteRows);
                        StopAllTabs();
                    }
                }
            }            
        }

        private void CheckDatabaseForSpecificItem(int _rowIndex)
        {
            var operationIDs = Connection.db.GetTable<OperationInfo>().Where(x => x.UserId == User.ID).Select(x => x.Id).ToList();

            foreach(var item in operationIDs)
            {
                if(_rowIndex == (item-1))
                {
                    isValueInDatabase = true;
                    break;
                }
                else
                {
                    isValueInDatabase = false;
                }
            }
        }

        private void ReturnYesResult(int _rowIndex)
        {
            operationLog.Rows.Remove(operationLog.Rows[_rowIndex]);
            tempInfo.Clear();

            for (int i = 0; i < operationLog.Rows.Count; i++)
            {
                //istrinam pazymeta eilute ir persirasom lista
                if (operationLog.Rows[i].Cells[0].Value != null &&
                    operationLog.Rows[i].Cells[1].Value != null &&
                    operationLog.Rows[i].Cells[2].Value != null &&
                    operationLog.Rows[i].Cells[3].Value != null)
                {
                    TempOperationInfo op = new TempOperationInfo
                    (
                        DateTime.Parse(operationLog.Rows[i].Cells[0].Value.ToString()),
                        operationLog.Rows[i].Cells[1].Value.ToString(),
                        Double.Parse(operationLog.Rows[i].Cells[2].Value.ToString()),
                        operationLog.Rows[i].Cells[3].Value.ToString(),
                        User.ID
                    );
                    tempInfo.Add(op);
                }
            }
        }

        private void ReturnNoResult(int _rowIndex, int _columnIndex)
        {
            var operationInfo = Connection.db.GetTable<OperationInfo>().Where(x => x.UserId == User.ID).ToList();

            switch (_columnIndex)
            {
                case 0:
                    if(_rowIndex < operationInfo.Count)
                    {
                        operationLog.Rows[_rowIndex].Cells[0].Value = operationInfo[_rowIndex].Date.ToString("yyyy-MM-dd");
                    }                   
                    break;
                case 1:
                    if (_rowIndex < operationInfo.Count)
                    {
                        operationLog.Rows[_rowIndex].Cells[1].Value = operationInfo[_rowIndex].OperationText;
                    }
                    break;
                case 2:
                    if (_rowIndex < operationInfo.Count)
                    {
                        operationLog.Rows[_rowIndex].Cells[2].Value = operationInfo[_rowIndex].Sum;
                    }
                    break;
                case 3:
                    if (_rowIndex < operationInfo.Count)
                    {
                        operationLog.Rows[_rowIndex].Cells[3].Value = operationInfo[_rowIndex].SelectedType;
                    }
                    break;
                default:
                    break;
            }
        }

        private void ReturnResultIfChangedValueIsNotNull(int _rowIndex)
        {
            if (operationLog.Rows[_rowIndex].Cells[0].Value != null)
            {
                var firstDate = Connection.db.GetTable<OperationInfo>().Where(x => x.Id == 1 && x.UserId == User.ID)
                    .Select(x => x.Date).ToList();

                if(firstDate.Count > 0)
                {
                    string constructedDate = firstDate[0].ToString("yyyy-MM");
                    string today = DateTime.Today.ToString("yyyy-MM-dd");

                    if (DateTime.Parse(operationLog.Rows[_rowIndex].Cells[0].Value.ToString()) < DateTime.Parse(constructedDate))
                    {
                        MessageBox.Show("Jūsų įvestos datos mėnuo yra mažesnis nei jūsų pačios pirmos įvestos datos. Pataisykite datą.", "Klaida");
                        operationLog.Rows[_rowIndex].Cells[0].Value = null;
                    }
                    else if (DateTime.Parse(operationLog.Rows[_rowIndex].Cells[0].Value.ToString()) > DateTime.Parse(today))
                    {
                        MessageBox.Show("Negalima įvesti vėlesnės datos nei šiandienos data.", "Klaida");
                        operationLog.Rows[_rowIndex].Cells[0].Value = today;
                    }
                }  
            }
            else
            {
                tempInfo.Clear();
                for (int i = 0; i < operationLog.Rows.Count; i++)
                {
                    if (operationLog.Rows[i].Cells[0].Value != null &&
                        operationLog.Rows[i].Cells[1].Value != null &&
                        operationLog.Rows[i].Cells[2].Value != null &&
                        operationLog.Rows[i].Cells[3].Value != null)
                    {
                        TempOperationInfo op = new TempOperationInfo
                        (
                            DateTime.Parse(operationLog.Rows[i].Cells[0].Value.ToString()),
                            operationLog.Rows[i].Cells[1].Value.ToString(),
                            Double.Parse(operationLog.Rows[i].Cells[2].Value.ToString()),
                            operationLog.Rows[i].Cells[3].Value.ToString(),
                            User.ID
                        );
                        tempInfo.Add(op);
                    }
                }
                saveOperations.Enabled = true;
                Connection.style.SetButtonStyle(saveOperations);
            }
        }

        private void ReturnResultIfChangedValueBecomesNull(int _rowIndex, int _columnIndex)
        {
            DialogResult result = MessageBox.Show("Pavienio įrašo ištrinti negalima, " +
                            "galima tik jį pakeisti.\nJeigu visgi norite ištrinti šį įrašą, " +
                            "kartu bus ištrinta visa duomenų eilutė.\nIštrinti pažymėtą eilutę?",
                            "Pranešimas", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                ReturnYesResult(_rowIndex);
            }
            else if (result == DialogResult.No)
            {
                ReturnNoResult(_rowIndex, _columnIndex);
            }
        }

        private void OperationLog_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CheckingDateChars(e.RowIndex);
            CheckingSumChars(e.RowIndex);
            CheckDatabaseForSpecificItem(e.RowIndex);

            if (isValueInDatabase)
            {
                if (!isValueNull)
                {
                    if (operationLog.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                    {
                        ReturnResultIfChangedValueBecomesNull(e.RowIndex, e.ColumnIndex);
                        saveOperations.Enabled = true;
                        Connection.style.SetButtonStyle(saveOperations);
                    }
                    else if (operationLog.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                    {
                        ReturnResultIfChangedValueIsNotNull(e.RowIndex);
                        saveOperations.Enabled = true;
                        Connection.style.SetButtonStyle(saveOperations);
                    }
                }               
            }
            else if (!isValueInDatabase)
            {
                var firstDate = Connection.db.GetTable<OperationInfo>().Where(x => x.UserId == User.ID)
                    .Select(x => x.Date).First();

                string constructedDate = firstDate.ToString("yyyy-MM");
                string today = DateTime.Today.ToString("yyyy-MM-dd");
                
                if(operationLog.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    if (DateTime.Parse(operationLog.Rows[e.RowIndex].Cells[0].Value.ToString()) < DateTime.Parse(constructedDate))
                    {
                        MessageBox.Show("Jūsų įvestos datos mėnuo yra mažesnis nei jūsų pačios pirmos įvestos datos. " +
                            "Pataisykite datą.", "Klaida");
                        operationLog.Rows[e.RowIndex].Cells[0].Value = null;
                    }
                    else if (DateTime.Parse(operationLog.Rows[e.RowIndex].Cells[0].Value.ToString()) > DateTime.Parse(today))
                    {
                        MessageBox.Show("Negalima įvesti vėlesnės datos nei šiandienos data.", "Klaida");
                        operationLog.Rows[e.RowIndex].Cells[0].Value = today;
                    }
                }   
            }
            
            if (isValueNull)
            {
                tempInfo.Clear();
                for (int i = 0; i < operationLog.Rows.Count; i++)
                {
                    if (operationLog.Rows[i].Cells[0].Value != null && 
                        operationLog.Rows[i].Cells[1].Value != null && 
                        operationLog.Rows[i].Cells[2].Value != null && 
                        operationLog.Rows[i].Cells[3].Value != null)
                    {                        
                        TempOperationInfo op = new TempOperationInfo
                        (
                            DateTime.Parse(operationLog.Rows[i].Cells[0].Value.ToString()),
                            operationLog.Rows[i].Cells[1].Value.ToString(),
                            double.Parse(operationLog.Rows[i].Cells[2].Value.ToString()),
                            operationLog.Rows[i].Cells[3].Value.ToString(),
                            User.ID
                        );
                        tempInfo.Add(op);
                        saveOperations.Enabled = true;
                        Connection.style.SetButtonStyle(saveOperations);
                    }
                }                
            }

        }

        private void SetStylesAndLooks()
        {
            Connection.style.SetFormLooks(this);
            Connection.style.SetDataGridLooks(operationLog);
            Connection.style.SetSimplisticColumnStyle(operationLog);
            Connection.style.SetRowStyle(operationLog, DataGridViewAutoSizeRowsMode.DisplayedCells, 
                DataGridViewRowHeadersWidthSizeMode.DisableResizing, 20);
            Connection.style.SetCellStyle(operationLog);
            Connection.style.SetButtonStyle(addOperation);
            Connection.style.SetDisabledButtonStyle(saveOperations);
            Connection.style.SetButtonStyle(operationsBackButton);
        }

        private void OperationLog_MouseUp(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitInfo = operationLog.HitTest(e.X, e.Y);
            if (hitInfo.Type == DataGridViewHitTestType.TopLeftHeader)
            {
                Connection.style.ClearSelection(operationLog, false, true);
            }

            if(hitInfo.Type == DataGridViewHitTestType.ColumnHeader)
            {
                Connection.style.ClearSelection(operationLog, false, true);
            }
        }

        private void CheckingDateChars(int _rowIndex)
        {
            DateTime tempDate;

            if (operationLog.Rows[_rowIndex].Cells[0].Value != null)
            {
                try
                {
                    tempDate = DateTime.Parse(operationLog.Rows[_rowIndex].Cells[0].Value.ToString());
                }
                catch
                {
                    operationLog.Rows[_rowIndex].Cells[0].Value = null;
                    MessageBox.Show("Blogas datos formatas. Pataisykite laukelį.", "Klaida");
                    isValueNull = true;
                }
            }
        }

        private void CheckingSumChars(int _rowIndex)
        {
            double tempSum;

            if (operationLog.Rows[_rowIndex].Cells[2].Value != null)
            {
                try
                {
                    tempSum = double.Parse(operationLog.Rows[_rowIndex].Cells[2].Value.ToString());
                }
                catch
                {
                    string tempValue = "";
                    var tempChars = operationLog.Rows[_rowIndex].Cells[2].Value.ToString().ToCharArray().ToList();
                    if (tempChars.Count >= 6 && tempChars[tempChars.Count - 2] == ' ' && tempChars[tempChars.Count - 1] == '€')
                    {
                        tempChars.RemoveAt(tempChars.Count - 2);
                        tempChars.RemoveAt(tempChars.Count - 1);

                        foreach (var item in tempChars)
                        {
                            tempValue += item;
                        }

                        operationLog.Rows[_rowIndex].Cells[2].Value = tempValue;
                    }
                    else
                    {
                        operationLog.Rows[_rowIndex].Cells[2].Value = null;
                        MessageBox.Show("Įvesti blogi duomenys. Pataisykite laukelį.", "Klaida");
                        isValueNull = true;
                    }
                }
            }
        }

        private void OperationLog_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (columnIndex == 0 && (e.KeyChar != (char)Keys.Back) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }

            if(columnIndex == 2 && (e.KeyChar != (char)Keys.Back) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void OperationLog_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(OperationLog_KeyPress);

            TextBox tb = e.Control as TextBox;

            if (columnIndex == 0 || columnIndex == 2)
            {
                tb.KeyPress += new KeyPressEventHandler(OperationLog_KeyPress);
            }
        }

        private void OperationLog_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            double value;
            if (rowIndex >= 0 && columnIndex >= 0)
            {
                if (e.Value != null && double.TryParse(e.Value.ToString(), out value))
                {                    
                    e.Value = value.ToString("C2");
                }
            }
        }

        private void addOperation_MouseEnter(object sender, EventArgs e)
        {
            addOperation.ForeColor = Color.FromArgb(17, 17, 17);
        }

        private void addOperation_MouseLeave(object sender, EventArgs e)
        {
            addOperation.ForeColor = Color.White;
        }

        private void deleteRows_MouseEnter(object sender, EventArgs e)
        {
            deleteRows.ForeColor = Color.FromArgb(17, 17, 17);
        }

        private void deleteRows_MouseLeave(object sender, EventArgs e)
        {
            deleteRows.ForeColor = Color.White;
        }

        private void saveOperations_MouseEnter(object sender, EventArgs e)
        {
            saveOperations.ForeColor = Color.FromArgb(17, 17, 17);
        }

        private void saveOperations_MouseLeave(object sender, EventArgs e)
        {
            saveOperations.ForeColor = Color.White;
        }

        private void operationsBackButton_MouseEnter(object sender, EventArgs e)
        {
            operationsBackButton.ForeColor = Color.FromArgb(17, 17, 17);
        }

        private void operationsBackButton_MouseLeave(object sender, EventArgs e)
        {
            operationsBackButton.ForeColor = Color.White;
        }


    }
}
