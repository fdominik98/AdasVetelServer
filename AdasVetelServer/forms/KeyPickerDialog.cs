using AdasVetelServer.logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdasVetelServer
{
    public partial class KeyPickerDialog : Form
    {
        private FileIconControl FileControl; 
      
        public KeyPickerDialog(FileIconControl fileControl, string fileName, string text)
        {
            InitializeComponent();
            textBox.AutoWordSelection = true;           
            FileControl = fileControl;               
            textBox.Text = TextAnalyzer.Instance.formatData(text);
            Text = fileName;            

           
            keyStringLocked.Text = fileControl.KeyString;
            beforeContextNum.Value = fileControl.ContextBefore.Length >=3 ? fileControl.ContextBefore.Length:20;
            afterContextNum.Value = fileControl.ContextAfter.Length >= 3 ? fileControl.ContextAfter.Length : 20;
            afterCheckBox.Checked = fileControl.AfterContextCounts;
            beforeCheckBox.Checked = fileControl.BeforeContextCounts;
            isKeyCountBox.Checked = fileControl.KeyCounts;
            textBox.Select(fileControl.SelectionIndex, keyStringLocked.Text.Length);
            fileControl.KeySet = false;
            
        }

        private void textBox_SelectionChanged(object sender, EventArgs e)
        {
            textBox.ClearAllFormatting(textBox.Font);
            textBox.SelectionBackColor = Color.Yellow;
            textBox.SelectionColor = Color.Blue;
            textBox.SelectionFont = new Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));            
            selectionTextBox.Text = textBox.SelectedText;
            setBeforeAfterText();

        }


        private void saveButton_Click(object sender, EventArgs e)
        {
            try {                 

                FileControl.KeyCounts = isKeyCountBox.Checked;
                FileControl.BeforeContextCounts = beforeCheckBox.Checked;
                FileControl.AfterContextCounts = afterCheckBox.Checked;
                FileControl.setContext(afterTextLocked.Text, beforeTextLocked.Text,  keyStringLocked.Text, textBox.SelectionStart);
            
            } 
            catch (Exception ex) { }            
            Close();     
        }

        private void lockButton_Click(object sender, EventArgs e)
        {
            try
            {
                afterTextLocked.Text = afterText.Text;
                beforeTextLocked.Text = beforeText.Text;
                keyStringLocked.Text = selectionTextBox.Text;                   
                          
            }
            catch (Exception ex) { }          
           
        }
     
   

        private void zoomOutBtn_Click(object sender, EventArgs e)
        {
            if (textBox.ZoomFactor > 0.515625)
            {
                textBox.ZoomFactor = textBox.ZoomFactor -0.2f;
            }
        }

        private void zoomInBtn_Click(object sender, EventArgs e)
        {
            if (textBox.ZoomFactor < 64.5)
            {
                textBox.ZoomFactor = textBox.ZoomFactor + 0.2f;
            }
        }

        private void setBeforeAfterText()
        {
            try
            {
                afterText.Text = "";
                beforeText.Text = "";
                if (afterCheckBox.Checked) {
                    int space = 0;
                    if (textBox.Text[textBox.SelectionStart+ textBox.SelectionLength] == ' ')
                        space = 1;
                    afterText.Text = textBox.Text.Substring(textBox.SelectionStart+space + textBox.SelectionLength, (int)afterContextNum.Value);
                }
                if (beforeCheckBox.Checked) {
                    int space = 0;
                    if (textBox.Text[textBox.SelectionStart-1]== ' ')
                        space = 1;
                    beforeText.Text = textBox.Text.Substring(textBox.SelectionStart-space - (int)beforeContextNum.Value, (int)beforeContextNum.Value);
                }


            }
            catch (Exception ex) { }
        }

        private void beforeContextNum_ValueChanged(object sender, EventArgs e)
        {
            setBeforeAfterText();
        }

        private void afterContextNum_ValueChanged(object sender, EventArgs e)
        {
            setBeforeAfterText();
        }

        private void beforeCheckBox_CheckedChanged_1(object sender, EventArgs e)
        {
            if (beforeCheckBox.Checked)
            {
                beforeContextNum.Enabled = true;
                beforeText.Enabled = true;      
                beforeTextLocked.Enabled = true;           
            }
            else
            {
                beforeContextNum.Enabled = false;
                beforeText.Enabled = false;         
                beforeTextLocked.Enabled = false;         
            }
            setBeforeAfterText();
        }

        private void afterCheckBox_CheckedChanged_1(object sender, EventArgs e)
        {
            if (afterCheckBox.Checked)
            {
                afterContextNum.Enabled = true;
                afterText.Enabled = true;               
                afterTextLocked.Enabled = true;              
            }
            else
            {
                afterContextNum.Enabled = false;
                afterText.Enabled = false;               
                afterTextLocked.Enabled = false;               
            }
            setBeforeAfterText();
        }
    }
}
