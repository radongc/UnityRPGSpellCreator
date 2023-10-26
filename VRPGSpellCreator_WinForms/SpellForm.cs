using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VRPGSpellCreator_WinForms
{
    public partial class SpellForm : Form
    {
        public SpellForm()
        {
            InitializeComponent();
        }

        private void button_CopySQL_Click(object sender, EventArgs e)
        {
            string builtSql = GetSpellInsertSQL();

            Clipboard.SetText(builtSql);

            MessageBox.Show($"Copied spell {textBox_SpellName.Text} (ID {textBox_SpellID.Text}) SQL insert to clipboard! Execute it on 'game.db' in the root folder for the server (where the game executable lies on server builds, or in the project directory if using the Unity Editor) and copy the database over to client build(s).", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void SpellForm_Load(object sender, EventArgs e)
        {
            comboBox_CastType.SelectedIndex = 0;
            comboBox_DirectTarget.SelectedIndex = 0;
            comboBox_SecondaryTarget.SelectedIndex = 0;
            comboBox_Animation.SelectedIndex = 0;
            comboBox_Effect1.SelectedIndex = 0;
            comboBox_Effect2.SelectedIndex = 0;
            comboBox_Effect2Target.SelectedIndex = 0;
            comboBox_Effect3.SelectedIndex = 0;
            comboBox_Effect3Target.SelectedIndex = 0;
        }

        private string GetSpellInsertSQL()
        {
            string spellId = textBox_SpellID.Text;
            string name = textBox_SpellName.Text;
            string description = textBox_SpellDesc.Text;
            string iconId = textBox_IconID.Text;
            string cooldown = textBox_SpellCooldown.Text;
            string powerCost = textBox_PowerCost.Text;
            int castType = GetEnumID(comboBox_CastType.Text);
            int effect1 = GetEnumID(comboBox_Effect1.Text);
            string effectBasePoints1 = textBox_Effect1bp.Text;
            string effectDieSides1 = textBox_Effect1ds.Text;
            string effectMiscValue1 = textBox_Effect1mv.Text;
            int effect2 = GetEnumID(comboBox_Effect2.Text);
            string effectBasePoints2 = textBox_Effect2bp.Text;
            string effectDieSides2 = textBox_Effect2ds.Text;
            string effectMiscValue2 = textBox_Effect2mv.Text;
            int effectTarget2 = GetEnumID(comboBox_Effect2Target.Text);
            int effect3 = GetEnumID(comboBox_Effect3.Text);
            string effectBasePoints3 = textBox_Effect3bp.Text;
            string effectDieSides3 = textBox_Effect3ds.Text;
            string effectMiscValue3 = textBox_Effect3mv.Text;
            int effectTarget3 = GetEnumID(comboBox_Effect3Target.Text);
            int directTarget = GetEnumID(comboBox_DirectTarget.Text);
            int secondaryTarget = GetEnumID(comboBox_SecondaryTarget.Text);
            string meleeAbility = "0";
            string rangeMin = textBox_MinRange.Text;
            string rangeMax = textBox_MaxRange.Text;
            string visualId = textBox_VisualID.Text;
            int castAnimation = GetEnumID(comboBox_Animation.Text);

            string sql = $"REPLACE INTO \"main\".\"spell\" (\"ID\", \"Name\", \"Description\", \"IconID\", \"Cooldown\", \"PowerCost\", \"CastType\", \"Effect1\", \"EffectBasePoints1\", \"EffectDieSides1\", \"EffectMiscValue1\", \"Effect2\", \"EffectBasePoints2\", \"EffectDieSides2\", \"EffectMiscValue2\", \"EffectTarget2\", \"Effect3\", \"EffectBasePoints3\", \"EffectDieSides3\", \"EffectMiscValue3\", \"EffectTarget3\", \"DirectTarget\", \"SecondaryTarget\", \"MeleeAbility\", \"Range_Min\", \"Range_Max\", \"VisualID\", \"CastAnimation\") VALUES ('{spellId}', '{name}', '{description}', '{iconId}', '{cooldown}', '{powerCost}', '{castType}', '{effect1}', '{effectBasePoints1}', '{effectDieSides1}', '{effectMiscValue1}', '{effect2}', '{effectBasePoints2}', '{effectDieSides2}', '{effectMiscValue2}', '{effectTarget2}', '{effect3}', '{effectBasePoints3}', '{effectDieSides3}', '{effectMiscValue3}', '{effectTarget3}', '{directTarget}', '{secondaryTarget}', '{meleeAbility}', '{rangeMin}', '{rangeMax}', '{visualId}', '{castAnimation}');";
            return sql;
        }

        private int GetEnumID(string dropDownText)
        {
            string[] dropDownTextSplit = dropDownText.Split("-");
            return Convert.ToInt32(dropDownTextSplit[dropDownTextSplit.Length - 1]);
        }

        private void button_ImportSpellSQL_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not yet implemented.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private Image GetIconByID(int id)
        {
            string className = string.Empty;
            int fileNumber = 0;

            for (int i = 1; i <= 502; i++)
            {
                if (i <= 50)
                {
                    fileNumber = i;
                    className = "Archerskill_";
                }
                else if (i <= 100)
                {
                    fileNumber = i - 50;
                    className = "Assassinskill_";
                }
                else if (i <= 150)
                {
                    fileNumber = i - 100;
                    className = "Druideskill_";
                }
                else if (i <= 200)
                {
                    fileNumber = i - 150;
                    className = "Engineerskill_";
                }
                else if (i <= 250)
                {
                    fileNumber = i - 200;
                    className = "Mageskill_";
                }
                else if (i <= 300)
                {
                    fileNumber = i - 250;
                    className = "Paladinskill_";
                }
                else if (i <= 350)
                {
                    fileNumber = i - 300;
                    className = "Priestskill_";
                }
                else if (i <= 400)
                {
                    fileNumber = i - 350 <= 17 ? i - 350 : i - 351;
                    className = "Shamanskill_";
                }
                else if (i <= 450)
                {
                    fileNumber = i - 401;
                    className = "Warlock_";
                }
                else if (i <= 500)
                {
                    fileNumber = i - 451;
                    className = "Warriorskill_";
                }
                else
                {
                    fileNumber = 50;
                    className = "Warriorskill_";
                }

                if (fileNumber < 10)
                    className = className + "0";
                
                if (i == id)
                {
                    Image img = (Image)Properties.Resources.ResourceManager.GetObject(className + fileNumber);
                    return img;
                }
            }

            return null;
        }

        private void textBox_IconID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Image spellImg = GetIconByID(Convert.ToInt32(textBox_IconID.Text));

                if (spellImg != null)
                    pictureBox1.Image = spellImg;
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
