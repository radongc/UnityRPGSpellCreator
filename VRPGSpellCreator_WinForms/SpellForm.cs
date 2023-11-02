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
            comboBox_effect1Aura.SelectedIndex = 0;
            comboBox_Effect2.SelectedIndex = 0;
            comboBox_effect2Aura.SelectedIndex = 0;
            comboBox_Effect2Target.SelectedIndex = 0;
            comboBox_Effect3.SelectedIndex = 0;
            comboBox_effect3Aura.SelectedIndex = 0;
            comboBox_Effect3Target.SelectedIndex = 0;
        }

        private string GetSpellInsertSQL()
        {
            string spellId = textBox_SpellID.Text;
            string name = textBox_SpellName.Text;
            string description = textBox_SpellDesc.Text;
            string tooltip = textBox_tooltip.Text;
            string iconId = textBox_IconID.Text;
            string cooldown = textBox_SpellCooldown.Text;
            string powerCost = textBox_PowerCost.Text;
            string duration = textBox_duration.Text;
            int castType = GetEnumID(comboBox_CastType.Text);
            int directTarget = GetEnumID(comboBox_DirectTarget.Text);
            int secondaryTarget = GetEnumID(comboBox_SecondaryTarget.Text);
            
            int effect1 = GetEnumID(comboBox_Effect1.Text);
            int effect2 = GetEnumID(comboBox_Effect2.Text);
            int effect3 = GetEnumID(comboBox_Effect3.Text);

            string effectBasePoints1 = textBox_Effect1bp.Text;
            string effectBasePoints2 = textBox_Effect2bp.Text;
            string effectBasePoints3 = textBox_Effect3bp.Text;

            string effectDieSides1 = textBox_Effect1ds.Text;
            string effectDieSides2 = textBox_Effect2ds.Text;
            string effectDieSides3 = textBox_Effect3ds.Text;

            string effectMiscValue1 = textBox_Effect1mv.Text;
            string effectMiscValue2 = textBox_Effect2mv.Text;
            string effectMiscValue3 = textBox_Effect3mv.Text;

            int effectApplyAura1 = GetEnumID(comboBox_effect1Aura.Text);
            int effectApplyAura2 = GetEnumID(comboBox_effect2Aura.Text);
            int effectApplyAura3 = GetEnumID(comboBox_effect3Aura.Text);

            int effectTarget2 = GetEnumID(comboBox_Effect2Target.Text);
            int effectTarget3 = GetEnumID(comboBox_Effect3Target.Text);

            string meleeAbility = checkBox_meleeRangeAbility.Checked ? "1" : "0";
            string rangeMin = textBox_MinRange.Text;
            string rangeMax = textBox_MaxRange.Text;

            string visual1 = textBox_Visual1.Text;
            string visual2 = textBox_Visual2.Text;
            string auraStartVisual = textBox_auraStartVisual.Text;
            string auraVisual = textBox_auraVisual.Text;

            string hiddenAura = checkBox_hiddenAura.Checked ? "1" : "0";
            string harmfulAura = checkBox_harmfulAura.Checked ? "1" : "0";

            int castAnimation = GetEnumID(comboBox_Animation.Text);

            string sql = $"REPLACE INTO \"main\".\"spell\" (\"ID\", \"Name\", \"Description\", \"Tooltip\", \"IconID\", \"Cooldown\", \"PowerCost\", \"Duration\", \"CastType\", \"DirectTarget\", \"SecondaryTarget\", \"Effect1\", \"Effect2\", \"Effect3\", \"EffectBasePoints1\", \"EffectBasePoints2\", \"EffectBasePoints3\", \"EffectDieSides1\", \"EffectDieSides2\", \"EffectDieSides3\", \"EffectMiscValue1\", \"EffectMiscValue2\", \"EffectMiscValue3\", \"EffectApplyAura1\", \"EffectApplyAura2\", \"EffectApplyAura3\", \"EffectTarget2\", \"EffectTarget3\", \"Range_Min\", \"Range_Max\", \"MeleeAbility\", \"Visual1\", \"Visual2\", \"AuraStartVisual\", \"AuraVisual\", \"HiddenAura\", \"HarmfulAura\", \"CastAnimation\") VALUES ('{spellId}', '{name}', '{description}', '{tooltip}', '{iconId}', '{cooldown}', '{powerCost}', '{duration}', '{castType}', '{directTarget}', '{secondaryTarget}', '{effect1}', '{effect2}', '{effect3}', '{effectBasePoints1}', '{effectBasePoints2}', '{effectBasePoints3}', '{effectDieSides1}', '{effectDieSides2}', '{effectDieSides3}', '{effectMiscValue1}', '{effectMiscValue2}', '{effectMiscValue3}', '{effectApplyAura1}', '{effectApplyAura2}', '{effectApplyAura3}', '{effectTarget2}', '{effectTarget3}', '{rangeMin}', '{rangeMax}', '{meleeAbility}', '{visual1}', '{visual2}', '{auraStartVisual}', '{auraVisual}', '{hiddenAura}', '{harmfulAura}', '{castAnimation}');";
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
