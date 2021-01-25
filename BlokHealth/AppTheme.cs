using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlokHealth
{
    class AppTheme
    {
        // Nagłówek:
        public enum ExampleTheme
        {
            StandardDarkTheme = 0,
            StandardLightTheme = 1
        }

        public static ExampleTheme ChoseTheme = ExampleTheme.StandardDarkTheme; // zmienić na pobieranie z pliku ustawień

        // Metoda pobiera ustawiony motyw i zwraca go
        public static AppTheme DownloadTheme()
        {
            AppTheme ArgTheme;

            #region Argumenty

            Color ArgProductNameForeColor;

            Color ArgControlBox;
            Color ArgControlBoxAppNameColor;
            Image ArgCloseImg;
            Image ArgMaximalizeImg;
            Image ArgMinimalizeImg;

            Image ArgArrowLeftImg;
            Image ArgArrowRightImg;

            Color ArgConvertComboBoxBackgroundColor;
            Color ArgConvertComboBoxForeColor;

            Color ArgLeftPanel;
            Color ArgCentralPanel;
            Color ArgRightPanel;

            Image ArgButtonOpenSettingsFormBackgroundImage;
            Color ArgInfoButtonBackgroundColor;
            Color ArgInfoButtonForeColor;
            Color ArgNotebookHeaderForeColor;
            Color ArgFontStyleButtonForeColor;
            Color ArgNotebookBackgroundColor;
            Color ArgCiekawostkaHeaderForeColor;
            Color ArgButtonNextCiekawostkaForeColor;
            Color ArgLabelCiekawostkiForeColor;
            Color ArgCwiczennikBackgroundColor;
            Color ArgCwiczennikForeColor;

            Color ArgButtonButtonTypeOfConvertEnergiaBackgroundColor;
            Color ArgButtonButtonTypeOfConvertMasaBackgroundColor;
            Color ArgButtonButtonTypeOfConvertForeColor;
            Color ArgLabelsKonwertujZ_lub_NaForeColor;
            Color ArgCalculatorTextBoxBackgroundColor;
            Color ArgCalculatorTextBoxForeColor;
            Color ArgButtonsOfCalculatorBackgroundColor;
            Color ArgButtonsOfCalculatorForeColor;
            Color ArgKonwertujWynikButtonBackgroundColor;
            Color ArgKonwertujWynikButtonForeColor;
            Color ArgLabelWynikForeColor;

            Color ArgLabelDescribeOfProductForeColorMainForm;
            Color ArgLabelWartOdzywczeForeColorMainForm;
            Color ArgLabelWartEnergetyczneForeColorMainForm;
            Color ArgLabelBialkoForeColorMainForm;
            Color ArgLabelTluszczForeColorMainForm;
            Color ArgLabelWeglowodanyForeColorMainForm;
            Color ArgLabelBlonnikForeColorMainForm;
            Color ArgLabelWitaminyForeColorMainForm;
            Color ArgLabelMineralyForeColorMainForm;
            Color ArgLabelPodWitaminyIPodMineralyMainForm;
            Color ArgEditAndDeleteProductBorderColor;
            Color ArgEditAndDeleteProductForeColor;
            Color ArgAddProductForeColor;

            Color ArgPanelLineBackgroundColor;
            Color ArgFoodTitleForeColor;

            Color ArgPanelMainInformationAboutApplication;

            Color ArgLabelWersjaForeColor;
            Color ArgLabelProduktForeColor;
            Color ArgLabelTworcyForeColor;
            Color ArgLabelAutorzyForeColor;
            Color ArgButtonCloseInformationAboutApplicationBackgroundColor;
            Color ArgButtonCloseInformationAboutApplicationForeColor;


            Image ArgIntroFormBackgroundImage; //TODO no nw

            Color ArgExerciseDictonaryMainPanelColor;

            Color ArgLabelHeaderForeColor;
            Color ArgLabelSecondHeadersForeColor;
            Color ArgTextExerciseDictonaryForeColor;
            Color ArgTitleForeColor;

            Color ArgCentralPanelAddAndEditProductFormsBackgroundColor;
            Color ArgLabelNazwaProduktuForeColorAddAndEditProductForms;
            Color ArgLabelWartoscEnergetycznaColorAddAndEditProductForms;
            Color ArgLabelBialkoForeColorAddAndEditProductForms;
            Color ArgLabelTluszczForeColorAddAndEditProductForms;
            Color ArgLabelWeglowodanyForeColorAddAndEditProductForms;
            Color ArgLabelBlonnikForeColorAddAndEditProductForms;
            Color ArgLabelWitaminyForeColorAddAndEditProductForms;
            Color ArgLabelMineralyForeColorAddAndEditProductForms;
            Color ArgLabelOpisProduktuForeColorAddAndEditProductForms;

            Color ArgTextBoxAndComboBoxBackgroundColorAddAndEditProductForms;
            Color ArgTextBoxAndComboBoxForeColorAddAndEditProductForms;

            Color ArgWarningsColor;

            Color ArgPodpowiedz_ZalecanaNazwa_ForeColor;
            Color ArgPodpowiedz_ZapisUlamkow_ForeColor;
            Color ArgLabelWartoscWGramachForeColor;


            Color ArgProductNameForeColorEditProductForm;
            Color ArgProductNameBackgroundColorEditProductForm;

            Color ArgButtonWybierzObrazekBackgroundColor;
            Color ArgButtonWybierzObrazekForeColor;

            Color ArgButtonsWybierzObrazekAndResetBorderColor;

            Color ArgButtonResetBackgroundColor;
            Color ArgButtonResetForeColor;

            Color ArgButtonZapiszDodajProduktBackgroundColor;
            Color ArgButtonZapiszDodajProduktForeColor;

            Color ArgCentralPanelSettingsFormBackgroundColor;
            Color ArgLabelUstawieniaSettingsFormForeColor;
            Color ArgLabelMotywSettingsFormForeColor;
            Color ArgMotywComboBoxSettingsFormBackgroundColor;
            Color ArgMotywComboBoxSettingsFormForeColor;
            Color ArgButtonAnulujSettingsFormForeColor;
            Color ArgButtonAnulujSettingsFormBackgroundColor;
            Color ArgButtonZastosujSettingsFormForeColor;
            Color ArgButtonZastosujSettingsFormBackgroundColor;

            #endregion

            switch (ChoseTheme)
            {
                case ExampleTheme.StandardLightTheme: // For StandardLightTheme
                    #region StandardLightTheme

                    ArgProductNameForeColor = System.Drawing.Color.Navy;

                    ArgControlBox = SystemColors.ControlLightLight;
                    ArgControlBoxAppNameColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
                    ArgCloseImg = BlokHealth.Properties.Resources.krzyzykDark;
                    ArgMaximalizeImg = BlokHealth.Properties.Resources.okienkoDark;
                    ArgMinimalizeImg = BlokHealth.Properties.Resources.podkreslnikDark;

                    ArgArrowLeftImg = BlokHealth.Properties.Resources.left_arrow_dark;
                    ArgArrowRightImg = BlokHealth.Properties.Resources.right_arrow_dark;

                    ArgConvertComboBoxBackgroundColor = System.Drawing.Color.White;
                    ArgConvertComboBoxForeColor = System.Drawing.Color.Black;

                    ArgLeftPanel = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(232)))), ((int)(((byte)(228)))));
                    ArgCentralPanel = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
                    ArgRightPanel = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))));

                    ArgButtonOpenSettingsFormBackgroundImage = BlokHealth.Properties.Resources.ZembatkaDarkMini;
                    ArgInfoButtonBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(255)))));
                    ArgInfoButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
                    ArgNotebookHeaderForeColor = System.Drawing.Color.DimGray;
                    ArgFontStyleButtonForeColor = System.Drawing.Color.Gray;
                    ArgNotebookBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                    ArgCiekawostkaHeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                    ArgButtonNextCiekawostkaForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
                    ArgLabelCiekawostkiForeColor = System.Drawing.Color.DimGray;
                    ArgCwiczennikBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(214)))), ((int)(((byte)(150)))));
                    ArgCwiczennikForeColor = System.Drawing.Color.Black;

                    ArgButtonButtonTypeOfConvertEnergiaBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(150)))), ((int)(((byte)(134)))));
                    ArgButtonButtonTypeOfConvertMasaBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(145)))), ((int)(((byte)(148)))));
                    ArgButtonButtonTypeOfConvertForeColor = System.Drawing.Color.White;
                    ArgLabelsKonwertujZ_lub_NaForeColor = System.Drawing.Color.Black;
                    ArgCalculatorTextBoxBackgroundColor = SystemColors.Window;
                    ArgCalculatorTextBoxForeColor = System.Drawing.Color.Black;
                    ArgButtonsOfCalculatorBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(255)))), ((int)(((byte)(225)))));
                    ArgButtonsOfCalculatorForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                    ArgKonwertujWynikButtonBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
                    ArgKonwertujWynikButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                    ArgLabelWynikForeColor = SystemColors.ControlText;

                    ArgLabelDescribeOfProductForeColorMainForm = System.Drawing.Color.Black;
                    ArgLabelWartOdzywczeForeColorMainForm = System.Drawing.Color.Green;
                    ArgLabelWartEnergetyczneForeColorMainForm = System.Drawing.Color.OrangeRed;
                    ArgLabelBialkoForeColorMainForm = System.Drawing.Color.DimGray;
                    ArgLabelTluszczForeColorMainForm = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                    ArgLabelWeglowodanyForeColorMainForm = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(140)))), ((int)(((byte)(90)))));
                    ArgLabelBlonnikForeColorMainForm = System.Drawing.Color.DarkSlateGray;
                    ArgLabelWitaminyForeColorMainForm = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
                    ArgLabelMineralyForeColorMainForm = System.Drawing.Color.Purple;
                    ArgLabelPodWitaminyIPodMineralyMainForm = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                    ArgEditAndDeleteProductBorderColor = System.Drawing.Color.DarkSlateGray;
                    ArgEditAndDeleteProductForeColor = System.Drawing.Color.DarkMagenta;
                    ArgAddProductForeColor = System.Drawing.Color.Olive;

                    ArgPanelLineBackgroundColor = System.Drawing.Color.Silver;

                    ArgFoodTitleForeColor = System.Drawing.Color.Black;

                    ArgPanelMainInformationAboutApplication = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));

                    ArgLabelWersjaForeColor = System.Drawing.Color.Black;
                    ArgLabelProduktForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                    ArgLabelTworcyForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                    ArgLabelAutorzyForeColor = System.Drawing.Color.DarkOliveGreen;
                    ArgButtonCloseInformationAboutApplicationBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(200)))), ((int)(((byte)(195)))));
                    ArgButtonCloseInformationAboutApplicationForeColor = System.Drawing.Color.Black;


                    ArgIntroFormBackgroundImage = BlokHealth.Properties.Resources.IntroImageBassicVersion; //toDO intro light

                    ArgExerciseDictonaryMainPanelColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));

                    ArgLabelHeaderForeColor = System.Drawing.Color.DarkGreen;
                    ArgLabelSecondHeadersForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                    ArgTextExerciseDictonaryForeColor = System.Drawing.Color.Gray;
                    ArgTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(32)))), ((int)(((byte)(0)))));

                    ArgCentralPanelAddAndEditProductFormsBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(233)))), ((int)(((byte)(240)))));
                    ArgLabelNazwaProduktuForeColorAddAndEditProductForms = System.Drawing.Color.Black;
                    ArgLabelWartoscEnergetycznaColorAddAndEditProductForms = System.Drawing.Color.Black;
                    ArgLabelBialkoForeColorAddAndEditProductForms = System.Drawing.Color.Black;
                    ArgLabelTluszczForeColorAddAndEditProductForms = System.Drawing.Color.Black;
                    ArgLabelWeglowodanyForeColorAddAndEditProductForms = System.Drawing.Color.Black;
                    ArgLabelBlonnikForeColorAddAndEditProductForms = System.Drawing.Color.Black;
                    ArgLabelWitaminyForeColorAddAndEditProductForms = System.Drawing.Color.Black;
                    ArgLabelMineralyForeColorAddAndEditProductForms = System.Drawing.Color.Black;
                    ArgLabelOpisProduktuForeColorAddAndEditProductForms = System.Drawing.Color.Black;

                    ArgTextBoxAndComboBoxBackgroundColorAddAndEditProductForms = SystemColors.Window;
                    ArgTextBoxAndComboBoxForeColorAddAndEditProductForms = SystemColors.WindowText;

                    ArgWarningsColor = System.Drawing.Color.DarkRed;

                    ArgPodpowiedz_ZalecanaNazwa_ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
                    ArgPodpowiedz_ZapisUlamkow_ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
                    ArgLabelWartoscWGramachForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));

                    ArgProductNameForeColorEditProductForm = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                    ArgProductNameBackgroundColorEditProductForm = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));

                    ArgButtonWybierzObrazekBackgroundColor = System.Drawing.Color.Azure;
                    ArgButtonWybierzObrazekForeColor = System.Drawing.Color.Black;
                    ArgButtonsWybierzObrazekAndResetBorderColor = System.Drawing.Color.DarkSlateGray;
                    ArgButtonResetBackgroundColor = System.Drawing.Color.Azure;
                    ArgButtonResetForeColor = System.Drawing.Color.Black;
                    ArgButtonZapiszDodajProduktBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(25)))));
                    ArgButtonZapiszDodajProduktForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));

                    ArgCentralPanelSettingsFormBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(248)))));
                    ArgLabelUstawieniaSettingsFormForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                    ArgLabelMotywSettingsFormForeColor = System.Drawing.Color.Black;
                    ArgMotywComboBoxSettingsFormBackgroundColor = System.Drawing.Color.White;
                    ArgMotywComboBoxSettingsFormForeColor = System.Drawing.Color.Black;
                    ArgButtonAnulujSettingsFormBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
                    ArgButtonAnulujSettingsFormForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
                    ArgButtonZastosujSettingsFormBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
                    ArgButtonZastosujSettingsFormForeColor = System.Drawing.Color.Snow;

                    #endregion
                    break;

                case ExampleTheme.StandardDarkTheme: // For StandardDarkTheme
                default: // For DefaultTheme
                    #region StandardDarkTheme

                    ArgProductNameForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(211)))), ((int)(((byte)(244)))));

                    ArgControlBox = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
                    ArgControlBoxAppNameColor = System.Drawing.Color.White;
                    ArgCloseImg = BlokHealth.Properties.Resources.BialyKrzyzyk;
                    ArgMaximalizeImg = BlokHealth.Properties.Resources.BialyMaksymalize;
                    ArgMinimalizeImg = BlokHealth.Properties.Resources.BialyMinimalize;

                    ArgArrowLeftImg = BlokHealth.Properties.Resources.BialaLeftArrow;
                    ArgArrowRightImg = BlokHealth.Properties.Resources.BialaRightArrow;

                    ArgConvertComboBoxBackgroundColor = SystemColors.Window;
                    ArgConvertComboBoxForeColor = SystemColors.WindowText;

                    ArgLeftPanel = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(52)))));
                    ArgCentralPanel = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(45)))), ((int)(((byte)(54)))));
                    ArgRightPanel = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));

                    ArgButtonOpenSettingsFormBackgroundImage = BlokHealth.Properties.Resources.zembatkaLightMini;
                    ArgInfoButtonBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(62)))));
                    ArgInfoButtonForeColor = System.Drawing.Color.White;
                    ArgNotebookHeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(188)))));
                    ArgFontStyleButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                    ArgNotebookBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
                    ArgCiekawostkaHeaderForeColor = System.Drawing.Color.LimeGreen;
                    ArgButtonNextCiekawostkaForeColor = System.Drawing.Color.Gray;
                    ArgLabelCiekawostkiForeColor = System.Drawing.Color.SpringGreen;
                    ArgCwiczennikBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                    ArgCwiczennikForeColor = System.Drawing.Color.Goldenrod;

                    ArgButtonButtonTypeOfConvertEnergiaBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(90)))), ((int)(((byte)(74)))));
                    ArgButtonButtonTypeOfConvertMasaBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(24)))), ((int)(((byte)(40)))));
                    ArgButtonButtonTypeOfConvertForeColor = SystemColors.ControlLight;
                    ArgLabelsKonwertujZ_lub_NaForeColor = System.Drawing.Color.White;
                    ArgCalculatorTextBoxBackgroundColor = SystemColors.Window;
                    ArgCalculatorTextBoxForeColor = SystemColors.WindowText;
                    ArgButtonsOfCalculatorBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
                    ArgButtonsOfCalculatorForeColor = SystemColors.ControlText;
                    ArgKonwertujWynikButtonBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(84)))), ((int)(((byte)(92)))));
                    ArgKonwertujWynikButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
                    ArgLabelWynikForeColor = System.Drawing.Color.White;

                    ArgLabelDescribeOfProductForeColorMainForm = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(255)))), ((int)(((byte)(253)))));
                    ArgLabelWartOdzywczeForeColorMainForm = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
                    ArgLabelWartEnergetyczneForeColorMainForm = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
                    ArgLabelBialkoForeColorMainForm = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
                    ArgLabelTluszczForeColorMainForm = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(121)))), ((int)(((byte)(11)))));
                    ArgLabelWeglowodanyForeColorMainForm = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(140)))), ((int)(((byte)(90)))));
                    ArgLabelBlonnikForeColorMainForm = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(250)))), ((int)(((byte)(197)))));
                    ArgLabelWitaminyForeColorMainForm = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(223)))), ((int)(((byte)(255)))));
                    ArgLabelMineralyForeColorMainForm = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(221)))));
                    ArgLabelPodWitaminyIPodMineralyMainForm = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
                    ArgEditAndDeleteProductBorderColor = System.Drawing.Color.DarkGray;
                    ArgEditAndDeleteProductForeColor = System.Drawing.Color.LightSalmon;
                    ArgAddProductForeColor = System.Drawing.Color.Orange;

                    ArgPanelLineBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(100)))), ((int)(((byte)(110)))));

                    ArgFoodTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(254)))), ((int)(((byte)(244)))));

                    ArgPanelMainInformationAboutApplication = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));

                    ArgLabelWersjaForeColor = System.Drawing.Color.White;
                    ArgLabelProduktForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
                    ArgLabelTworcyForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
                    ArgLabelAutorzyForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
                    ArgButtonCloseInformationAboutApplicationBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(63)))), ((int)(((byte)(68)))));
                    ArgButtonCloseInformationAboutApplicationForeColor = System.Drawing.Color.White;


                    ArgIntroFormBackgroundImage = BlokHealth.Properties.Resources.IntroImageBassicVersion; //TODO no nw

                    ArgExerciseDictonaryMainPanelColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));

                    ArgLabelHeaderForeColor = System.Drawing.Color.MediumAquamarine;
                    ArgLabelSecondHeadersForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                    ArgTextExerciseDictonaryForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
                    ArgTitleForeColor = System.Drawing.Color.SandyBrown;

                    ArgCentralPanelAddAndEditProductFormsBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(39)))));
                    ArgLabelNazwaProduktuForeColorAddAndEditProductForms = System.Drawing.Color.Azure;
                    ArgLabelWartoscEnergetycznaColorAddAndEditProductForms = System.Drawing.Color.Azure;
                    ArgLabelBialkoForeColorAddAndEditProductForms = System.Drawing.Color.Azure;
                    ArgLabelTluszczForeColorAddAndEditProductForms = System.Drawing.Color.Azure;
                    ArgLabelWeglowodanyForeColorAddAndEditProductForms = System.Drawing.Color.Azure;
                    ArgLabelBlonnikForeColorAddAndEditProductForms = System.Drawing.Color.Azure;
                    ArgLabelWitaminyForeColorAddAndEditProductForms = System.Drawing.Color.Azure;
                    ArgLabelMineralyForeColorAddAndEditProductForms = System.Drawing.Color.Azure;
                    ArgLabelOpisProduktuForeColorAddAndEditProductForms = System.Drawing.Color.Azure;

                    ArgTextBoxAndComboBoxBackgroundColorAddAndEditProductForms = SystemColors.Window;
                    ArgTextBoxAndComboBoxForeColorAddAndEditProductForms = SystemColors.WindowText;

                    ArgWarningsColor = System.Drawing.Color.Red;

                    ArgPodpowiedz_ZalecanaNazwa_ForeColor = System.Drawing.Color.Gainsboro;
                    ArgPodpowiedz_ZapisUlamkow_ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
                    ArgLabelWartoscWGramachForeColor = System.Drawing.Color.LightGray;

                    ArgProductNameForeColorEditProductForm = SystemColors.ButtonHighlight;
                    ArgProductNameBackgroundColorEditProductForm = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));

                    ArgButtonWybierzObrazekBackgroundColor = System.Drawing.Color.IndianRed;
                    ArgButtonWybierzObrazekForeColor = System.Drawing.Color.LightCyan;
                    ArgButtonsWybierzObrazekAndResetBorderColor = System.Drawing.Color.Azure;
                    ArgButtonResetBackgroundColor = System.Drawing.Color.Gray;
                    ArgButtonResetForeColor = System.Drawing.Color.LightCyan;
                    ArgButtonZapiszDodajProduktBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
                    ArgButtonZapiszDodajProduktForeColor = System.Drawing.Color.Cyan;

                    ArgCentralPanelSettingsFormBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
                    ArgLabelUstawieniaSettingsFormForeColor = System.Drawing.Color.LightSkyBlue;
                    ArgLabelMotywSettingsFormForeColor = System.Drawing.Color.White;
                    ArgMotywComboBoxSettingsFormBackgroundColor = SystemColors.Window;
                    ArgMotywComboBoxSettingsFormForeColor = SystemColors.WindowText;
                    ArgButtonAnulujSettingsFormBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
                    ArgButtonAnulujSettingsFormForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
                    ArgButtonZastosujSettingsFormBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0))))); 
                    ArgButtonZastosujSettingsFormForeColor = System.Drawing.Color.Snow;

                    #endregion
                    break;

                    #region SzablonMotywu

                    //ArgProductNameForeColor = ;

                    //ArgControlBox = ;
                    //ArgControlBoxAppNameColor = ;
                    //ArgCloseImg = ;
                    //ArgMaximalizeImg = ;
                    //ArgMinimalizeImg = ;

                    //ArgArrowLeftImg = ;
                    //ArgArrowRightImg = ;

                    //ArgConvertComboBoxBackgroundColor = ;
                    //ArgConvertComboBoxForeColor = ;

                    //ArgLeftPanel =;
                    //ArgCentralPanel =;
                    //ArgRightPanel = ;

                    //ArgButtonOpenSettingsFormBackgroundImage = ;
                    //ArgInfoButtonBackgroundColor = ;
                    //ArgInfoButtonForeColor = ;
                    //ArgNotebookHeaderForeColor = ;
                    //ArgFontStyleButtonForeColor = ;
                    //ArgNotebookBackgroundColor = ;
                    //ArgCiekawostkaHeaderForeColor = ;
                    //ArgButtonNextCiekawostkaForeColor = ;
                    //ArgLabelCiekawostkiForeColor = ;
                    //ArgCwiczennikBackgroundColor = ;
                    //ArgCwiczennikForeColor = ;

                    //ArgButtonButtonTypeOfConvertEnergiaBackgroundColor=;
                    //ArgButtonButtonTypeOfConvertMasaBackgroundColor =;
                    //ArgButtonButtonTypeOfConvertForeColor = ;
                    //ArgLabelsKonwertujZ_lub_NaForeColor = ;
                    //ArgCalculatorTextBoxBackgroundColor = ;
                    //ArgCalculatorTextBoxForeColor = ;
                    //ArgButtonsOfCalculatorBackgroundColor = ;
                    //ArgButtonsOfCalculatorForeColor = ;
                    //ArgKonwertujWynikButtonBackgroundColor = ;
                    //ArgKonwertujWynikButtonForeColor = ;
                    //ArgLabelWynikForeColor = ;

                    //ArgLabelDescribeOfProductForeColorMainForm =;
                    //ArgLabelWartOdzywczeForeColorMainForm = ;
                    //ArgLabelWartEnergetyczneForeColorMainForm =;
                    //ArgLabelBialkoForeColorMainForm = ;
                    //ArgLabelTluszczForeColorMainForm = ;
                    //ArgLabelWeglowodanyForeColorMainForm = ;
                    //ArgLabelBlonnikForeColorMainForm = ;
                    //ArgLabelWitaminyForeColorMainForm = ;
                    //ArgLabelMineralyForeColorMainForm = ;
                    //ArgLabelPodWitaminyIPodMineralyMainForm = ;
                    //ArgEditAndDeleteProductBorderColor = ;
                    //ArgEditAndDeleteProductForeColor = ;
                    //ArgAddProductForeColor = ;

                    //ArgPanelLineBackgroundColor = ;

                    //ArgFoodTitleForeColor = ;

                    //ArgPanelMainInformationAboutApplication = ;

                    //ArgLabelWersjaForeColor = ;
                    //ArgLabelProduktForeColor = ;
                    //ArgLabelTworcyForeColor = ;
                    //ArgLabelAutorzyForeColor = ;
                    //ArgButtonCloseInformationAboutApplicationBackgroundColor = ;
                    //ArgButtonCloseInformationAboutApplicationForeColor = ;


                    //ArgIntroFormBackgroundImage = BlokHealth.Properties.Resources.IntroImageBassicVersion; //TODO intro light

                    //ArgExerciseDictonaryMainPanelColor =;

                    //ArgLabelHeaderForeColor = ;
                    //ArgLabelSecondHeadersForeColor = ;
                    //ArgTextExerciseDictonaryForeColor =;
                    //ArgTitleForeColor = ;

                    //ArgCentralPanelAddAndEditProductFormsBackgroundColor = ;
                    //ArgLabelNazwaProduktuForeColorAddAndEditProductForms = ;
                    //ArgLabelWartoscEnergetycznaColorAddAndEditProductForms =;
                    //ArgLabelBialkoForeColorAddAndEditProductForms = ;
                    //ArgLabelTluszczForeColorAddAndEditProductForms = ;
                    //ArgLabelWeglowodanyForeColorAddAndEditProductForms = ;
                    //ArgLabelBlonnikForeColorAddAndEditProductForms = ;
                    //ArgLabelWitaminyForeColorAddAndEditProductForms = ;
                    //ArgLabelMineralyForeColorAddAndEditProductForms = ;
                    //ArgLabelOpisProduktuForeColorAddAndEditProductForms = ;

                    //ArgTextBoxAndComboBoxBackgroundColorAddAndEditProductForms = ;
                    //ArgTextBoxAndComboBoxForeColorAddAndEditProductForms =

                    //ArgWarningsColor = ;

                    //ArgPodpowiedz_ZalecanaNazwa_ForeColor = ;
                    //ArgPodpowiedz_ZapisUlamkow_ForeColor = ;
                    //ArgLabelWartoscWGramachForeColor = ;

                    //ArgProductNameForeColorEditProductForm = ;
                    //ArgProductNameBackgroundColorEditProductForm = ;

                    //ArgButtonWybierzObrazekBackgroundColor = ;
                    //ArgButtonWybierzObrazekForeColor = ;
                    //ArgButtonsWybierzObrazekAndResetBorderColor;
                    //ArgButtonResetBackgroundColor = ;
                    //ArgButtonResetForeColor = ;
                    //ArgButtonZapiszDodajProduktBackgroundColor = ;
                    //ArgButtonZapiszDodajProduktForeColor = ;

                    //ArgCentralPanelSettingsFormBackgroundColor = ;
                    //ArgLabelUstawieniaSettingsFormForeColor = ;
                    //ArgLabelMotywSettingsFormForeColor = ;
                    //ArgMotywComboBoxSettingsFormBackgroundColor = ;
                    //ArgMotywComboBoxSettingsFormForeColor =;
                    //ArgButtonAnulujSettingsFormForeColor = ;
                    //ArgButtonAnulujSettingsFormBackgroundColor =;
                    //ArgButtonZastosujSettingsFormForeColor = ;
                    //ArgButtonZastosujSettingsFormBackgroundColor = ;

                    #endregion
            }

            // Create_AppTheme_object
            ArgTheme = new AppTheme
            (
            #region ArgsForConstructorObject

            ArgProductNameForeColor,

            ArgControlBox,
            ArgControlBoxAppNameColor,
            ArgCloseImg,
            ArgMaximalizeImg,
            ArgMinimalizeImg,

            ArgArrowLeftImg,
            ArgArrowRightImg,

            ArgConvertComboBoxBackgroundColor,
            ArgConvertComboBoxForeColor,

            ArgLeftPanel,
            ArgCentralPanel,
            ArgRightPanel,

            ArgButtonOpenSettingsFormBackgroundImage,
            ArgInfoButtonBackgroundColor,
            ArgInfoButtonForeColor,
            ArgNotebookHeaderForeColor,
            ArgFontStyleButtonForeColor,
            ArgNotebookBackgroundColor,
            ArgCiekawostkaHeaderForeColor,
            ArgButtonNextCiekawostkaForeColor,
            ArgLabelCiekawostkiForeColor,
            ArgCwiczennikBackgroundColor,
            ArgCwiczennikForeColor,

            ArgButtonButtonTypeOfConvertEnergiaBackgroundColor,
            ArgButtonButtonTypeOfConvertMasaBackgroundColor,
            ArgButtonButtonTypeOfConvertForeColor,
            ArgLabelsKonwertujZ_lub_NaForeColor,
            ArgCalculatorTextBoxBackgroundColor,
            ArgCalculatorTextBoxForeColor,
            ArgButtonsOfCalculatorBackgroundColor,
            ArgButtonsOfCalculatorForeColor,
            ArgKonwertujWynikButtonBackgroundColor,
            ArgKonwertujWynikButtonForeColor,
            ArgLabelWynikForeColor,

            ArgLabelDescribeOfProductForeColorMainForm,
            ArgLabelWartOdzywczeForeColorMainForm,
            ArgLabelWartEnergetyczneForeColorMainForm,
            ArgLabelBialkoForeColorMainForm,
            ArgLabelTluszczForeColorMainForm,
            ArgLabelWeglowodanyForeColorMainForm,
            ArgLabelBlonnikForeColorMainForm,
            ArgLabelWitaminyForeColorMainForm,
            ArgLabelMineralyForeColorMainForm,
            ArgLabelPodWitaminyIPodMineralyMainForm,
            ArgEditAndDeleteProductBorderColor,
            ArgEditAndDeleteProductForeColor,
            ArgAddProductForeColor,

            ArgPanelLineBackgroundColor,
            ArgFoodTitleForeColor,

            ArgPanelMainInformationAboutApplication,

            ArgLabelWersjaForeColor,
            ArgLabelProduktForeColor,
            ArgLabelTworcyForeColor,
            ArgLabelAutorzyForeColor,
            ArgButtonCloseInformationAboutApplicationBackgroundColor,
            ArgButtonCloseInformationAboutApplicationForeColor,


            ArgIntroFormBackgroundImage, //TODO no nw

            ArgExerciseDictonaryMainPanelColor,

            ArgLabelHeaderForeColor,
            ArgLabelSecondHeadersForeColor,
            ArgTextExerciseDictonaryForeColor,
            ArgTitleForeColor,

            ArgCentralPanelAddAndEditProductFormsBackgroundColor,
            ArgLabelNazwaProduktuForeColorAddAndEditProductForms,
            ArgLabelWartoscEnergetycznaColorAddAndEditProductForms,
            ArgLabelBialkoForeColorAddAndEditProductForms,
            ArgLabelTluszczForeColorAddAndEditProductForms,
            ArgLabelWeglowodanyForeColorAddAndEditProductForms,
            ArgLabelBlonnikForeColorAddAndEditProductForms,
            ArgLabelWitaminyForeColorAddAndEditProductForms,
            ArgLabelMineralyForeColorAddAndEditProductForms,
            ArgLabelOpisProduktuForeColorAddAndEditProductForms,

            ArgTextBoxAndComboBoxBackgroundColorAddAndEditProductForms,
            ArgTextBoxAndComboBoxForeColorAddAndEditProductForms,

            ArgWarningsColor,

            ArgPodpowiedz_ZalecanaNazwa_ForeColor,
            ArgPodpowiedz_ZapisUlamkow_ForeColor,
            ArgLabelWartoscWGramachForeColor,


            ArgProductNameForeColorEditProductForm,
            ArgProductNameBackgroundColorEditProductForm,

            ArgButtonWybierzObrazekBackgroundColor,
            ArgButtonWybierzObrazekForeColor,

            ArgButtonsWybierzObrazekAndResetBorderColor,

            ArgButtonResetBackgroundColor,
            ArgButtonResetForeColor,

            ArgButtonZapiszDodajProduktBackgroundColor,
            ArgButtonZapiszDodajProduktForeColor,

            ArgCentralPanelSettingsFormBackgroundColor,
            ArgLabelUstawieniaSettingsFormForeColor,
            ArgLabelMotywSettingsFormForeColor,
            ArgMotywComboBoxSettingsFormBackgroundColor,
            ArgMotywComboBoxSettingsFormForeColor,
            ArgButtonAnulujSettingsFormForeColor,
            ArgButtonAnulujSettingsFormBackgroundColor,
            ArgButtonZastosujSettingsFormForeColor,
            ArgButtonZastosujSettingsFormBackgroundColor

            #endregion
            );

            return ArgTheme;
        }

        /* ---------------------------------------------------------------- */

        // Varibles
        #region Ogólne

        public Color ProductNameForeColor;

        public Color ControlBox;
        public Color ControlBoxAppNameColor;
        public Image CloseImg;
        public Image MaximalizeImg;
        public Image MinimalizeImg;

        public Image ArrowLeftImg;
        public Image ArrowRightImg;

        public Color ConvertComboBoxBackgroundColor;
        public Color ConvertComboBoxForeColor;


        #endregion

        #region MainForm

        // Główne:
        public Color LeftPanel;
        public Color CentralPanel;
        public Color RightPanel;

        // LeftPanel:
        public Image ButtonOpenSettingsFormBackgroundImage;
        public Color InfoButtonBackgroundColor;
        public Color InfoButtonForeColor;
        public Color NotebookHeaderForeColor;
        public Color FontStyleButtonForeColor;
        public Color NotebookBackgroundColor;
        public Color CiekawostkaHeaderForeColor;
        public Color ButtonNextCiekawostkaForeColor;
        public Color LabelCiekawostkiForeColor;
        public Color CwiczennikBackgroundColor;
        public Color CwiczennikForeColor;

        // CentralPanel
        public Color ButtonButtonTypeOfConvertEnergiaBackgroundColor;
        public Color ButtonButtonTypeOfConvertMasaBackgroundColor;
        public Color ButtonButtonTypeOfConvertForeColor;
        public Color LabelsKonwertujZ_lub_NaForeColor;
        public Color CalculatorTextBoxBackgroundColor;
        public Color CalculatorTextBoxForeColor;
        public Color ButtonsOfCalculatorBackgroundColor;
        public Color ButtonsOfCalculatorForeColor;
        public Color KonwertujWynikButtonBackgroundColor;
        public Color KonwertujWynikButtonForeColor;
        public Color LabelWynikForeColor;

        // RightPanel
        public Color LabelDescribeOfProductForeColorMainForm;
        public Color LabelWartOdzywczeForeColorMainForm;
        public Color LabelWartEnergetyczneForeColorMainForm;
        public Color LabelBialkoForeColorMainForm;
        public Color LabelTluszczForeColorMainForm;
        public Color LabelWeglowodanyForeColorMainForm;
        public Color LabelBlonnikForeColorMainForm;
        public Color LabelWitaminyForeColorMainForm;
        public Color LabelMineralyForeColorMainForm;
        public Color LabelPodWitaminyIPodMineralyMainForm;
        public Color EditAndDeleteProductBorderColor;
        public Color EditAndDeleteProductForeColor;
        public Color AddProductForeColor;

        public Color PanelLineBackgroundColor;
        public Color FoodTitleForeColor;


        #endregion

        #region InformationAboutApplication

        public Color PanelMainInformationAboutApplication;

        public Color LabelWersjaForeColor;
        public Color LabelProduktForeColor;
        public Color LabelTworcyForeColor;
        public Color LabelAutorzyForeColor;
        public Color ButtonCloseInformationAboutApplicationBackgroundColor;
        public Color ButtonCloseInformationAboutApplicationForeColor;

        #endregion

        //TODO zobaczyć czy się opłaca to zrobić
        #region IntroForm

        public Image IntroFormBackgroundImage; //TODO no nw

        #endregion 

        #region ExerciseDictonary

        public Color ExerciseDictonaryMainPanelColor;

        public Color LabelHeaderForeColor;
        public Color LabelSecondHeadersForeColor;
        public Color TextExerciseDictonaryForeColor;
        public Color TitleForeColor;

        #endregion

        #region AddAndEditProductForms

        public Color CentralPanelAddAndEditProductFormsBackgroundColor;
        public Color LabelNazwaProduktuForeColorAddAndEditProductForms;
        public Color LabelWartoscEnergetycznaColorAddAndEditProductForms;
        public Color LabelBialkoForeColorAddAndEditProductForms;
        public Color LabelTluszczForeColorAddAndEditProductForms;
        public Color LabelWeglowodanyForeColorAddAndEditProductForms;
        public Color LabelBlonnikForeColorAddAndEditProductForms;
        public Color LabelWitaminyForeColorAddAndEditProductForms;
        public Color LabelMineralyForeColorAddAndEditProductForms;
        public Color LabelOpisProduktuForeColorAddAndEditProductForms;

        public Color TextBoxAndComboBoxBackgroundColorAddAndEditProductForms;
        public Color TextBoxAndComboBoxForeColorAddAndEditProductForms;

        public Color WarningsColor;

        public Color Podpowiedz_ZalecanaNazwa_ForeColor;
        public Color Podpowiedz_ZapisUlamkow_ForeColor;
        public Color LabelWartoscWGramachForeColor;


        public Color ProductNameForeColorEditProductForm;
        public Color ProductNameBackgroundColorEditProductForm;

        public Color ButtonWybierzObrazekBackgroundColor;
        public Color ButtonWybierzObrazekForeColor;
        public Color ButtonsWybierzObrazekAndResetBorderColor;
        public Color ButtonResetBackgroundColor;
        public Color ButtonResetForeColor;
        public Color ButtonZapiszDodajProduktBackgroundColor;
        public Color ButtonZapiszDodajProduktForeColor;

        #endregion

        #region SettingsForm

        public Color CentralPanelSettingsFormBackgroundColor;
        public Color LabelUstawieniaSettingsFormForeColor;
        public Color LabelMotywSettingsFormForeColor;
        public Color MotywComboBoxSettingsFormBackgroundColor;
        public Color MotywComboBoxSettingsFormForeColor;
        public Color ButtonAnulujSettingsFormForeColor;
        public Color ButtonAnulujSettingsFormBackgroundColor;
        public Color ButtonZastosujSettingsFormForeColor;
        public Color ButtonZastosujSettingsFormBackgroundColor;

        #endregion

        // Methods:

        public AppTheme
        (
        #region ConstructorArguments
            Color ArgProductNameForeColor,

            Color ArgControlBox,
            Color ArgControlBoxAppNameColor,
            Image ArgCloseImg,
            Image ArgMaximalizeImg,
            Image ArgMinimalizeImg,

            Image ArgArrowLeftImg,
            Image ArgArrowRightImg,

            Color ArgConvertComboBoxBackgroundColor,
            Color ArgConvertComboBoxForeColor,

            // Główne:
            Color ArgLeftPanel,
            Color ArgCentralPanel,
            Color ArgRightPanel,

            // LeftPanel:
            Image ArgButtonOpenSettingsFormBackgroundImage,
            Color ArgInfoButtonBackgroundColor,
            Color ArgInfoButtonForeColor,
            Color ArgNotebookHeaderForeColor,
            Color ArgFontStyleButtonForeColor,
            Color ArgNotebookBackgroundColor,
            Color ArgCiekawostkaHeaderForeColor,
            Color ArgButtonNextCiekawostkaForeColor,
            Color ArgLabelCiekawostkiForeColor,
            Color ArgCwiczennikBackgroundColor,
            Color ArgCwiczennikForeColor,

            // CentralPanel
            Color ArgButtonButtonTypeOfConvertEnergiaBackgroundColor,
            Color ArgButtonButtonTypeOfConvertMasaBackgroundColor,
            Color ArgButtonButtonTypeOfConvertForeColor,
            Color ArgLabelsKonwertujZ_lub_NaForeColor,
            Color ArgCalculatorTextBoxBackgroundColor,
            Color ArgCalculatorTextBoxForeColor,
            Color ArgButtonsOfCalculatorBackgroundColor,
            Color ArgButtonsOfCalculatorForeColor,
            Color ArgKonwertujWynikButtonBackgroundColor,
            Color ArgKonwertujWynikButtonForeColor,
            Color ArgLabelWynikForeColor,

            // RightPanel
            Color ArgLabelDescribeOfProductForeColorMainForm,
            Color ArgLabelWartOdzywczeForeColorMainForm,
            Color ArgLabelWartEnergetyczneForeColorMainForm,
            Color ArgLabelBialkoForeColorMainForm,
            Color ArgLabelTluszczForeColorMainForm,
            Color ArgLabelWeglowodanyForeColorMainForm,
            Color ArgLabelBlonnikForeColorMainForm,
            Color ArgLabelWitaminyForeColorMainForm,
            Color ArgLabelMineralyForeColorMainForm,
            Color ArgLabelPodWitaminyIPodMineralyMainForm,
            Color ArgEditAndDeleteProductBorderColor,
            Color ArgEditAndDeleteProductForeColor,
            Color ArgAddProductForeColor,

            Color ArgPanelLineBackgroundColor,
            Color ArgFoodTitleForeColor,

            Color ArgPanelMainInformationAboutApplication,

            Color ArgLabelWersjaForeColor,
            Color ArgLabelProduktForeColor,
            Color ArgLabelTworcyForeColor,
            Color ArgLabelAutorzyForeColor,
            Color ArgButtonCloseInformationAboutApplicationBackgroundColor,
            Color ArgButtonCloseInformationAboutApplicationForeColor,

            Image ArgIntroFormBackgroundImage, //TODO no nw

            Color ArgExerciseDictonaryMainPanelColor,

            Color ArgLabelHeaderForeColor,
            Color ArgLabelSecondHeadersForeColor,
            Color ArgTextExerciseDictonaryForeColor,
            Color ArgTitleForeColor,

            Color ArgCentralPanelAddAndEditProductFormsBackgroundColor,
            Color ArgLabelNazwaProduktuForeColorAddAndEditProductForms,
            Color ArgLabelWartoscEnergetycznaColorAddAndEditProductForms,
            Color ArgLabelBialkoForeColorAddAndEditProductForms,
            Color ArgLabelTluszczForeColorAddAndEditProductForms,
            Color ArgLabelWeglowodanyForeColorAddAndEditProductForms,
            Color ArgLabelBlonnikForeColorAddAndEditProductForms,
            Color ArgLabelWitaminyForeColorAddAndEditProductForms,
            Color ArgLabelMineralyForeColorAddAndEditProductForms,
            Color ArgLabelOpisProduktuForeColorAddAndEditProductForms,

            Color ArgTextBoxAndComboBoxBackgroundColorAddAndEditProductForms,
            Color ArgTextBoxAndComboBoxForeColorAddAndEditProductForms,

            Color ArgWarningsColor,

            Color ArgPodpowiedz_ZalecanaNazwa_ForeColor,
            Color ArgPodpowiedz_ZapisUlamkow_ForeColor,
            Color ArgLabelWartoscWGramachForeColor,


            Color ArgProductNameForeColorEditProductForm,
            Color ArgProductNameBackgroundColorEditProductForm,

            Color ArgButtonWybierzObrazekBackgroundColor,
            Color ArgButtonWybierzObrazekForeColor,

            Color ArgButtonsWybierzObrazekAndResetBorderColor,

            Color ArgButtonResetBackgroundColor,
            Color ArgButtonResetForeColor,

            Color ArgButtonZapiszDodajProduktBackgroundColor,
            Color ArgButtonZapiszDodajProduktForeColor,

            Color ArgCentralPanelSettingsFormBackgroundColor,
            Color ArgLabelUstawieniaSettingsFormForeColor,
            Color ArgLabelMotywSettingsFormForeColor,
            Color ArgMotywComboBoxSettingsFormBackgroundColor,
            Color ArgMotywComboBoxSettingsFormForeColor,
            Color ArgButtonAnulujSettingsFormForeColor,
            Color ArgButtonAnulujSettingsFormBackgroundColor,
            Color ArgButtonZastosujSettingsFormForeColor,
            Color ArgButtonZastosujSettingsFormBackgroundColor
        #endregion
        )
        {
            ProductNameForeColor = ArgProductNameForeColor;

            ControlBox = ArgControlBox;
            ControlBoxAppNameColor = ArgControlBoxAppNameColor;
            CloseImg = ArgCloseImg;
            MaximalizeImg = ArgMaximalizeImg;
            MinimalizeImg = ArgMinimalizeImg;

            ArrowLeftImg = ArgArrowLeftImg;
            ArrowRightImg = ArgArrowRightImg;

            ConvertComboBoxBackgroundColor = ArgConvertComboBoxBackgroundColor;
            ConvertComboBoxForeColor = ArgConvertComboBoxForeColor;

            LeftPanel = ArgLeftPanel;
            CentralPanel = ArgCentralPanel;
            RightPanel = ArgRightPanel;

            ButtonOpenSettingsFormBackgroundImage = ArgButtonOpenSettingsFormBackgroundImage;
            InfoButtonBackgroundColor = ArgInfoButtonBackgroundColor;
            InfoButtonForeColor = ArgInfoButtonForeColor;
            NotebookHeaderForeColor = ArgNotebookHeaderForeColor;
            FontStyleButtonForeColor = ArgFontStyleButtonForeColor;
            NotebookBackgroundColor = ArgNotebookBackgroundColor;
            CiekawostkaHeaderForeColor = ArgCiekawostkaHeaderForeColor;
            ButtonNextCiekawostkaForeColor = ArgButtonNextCiekawostkaForeColor;
            LabelCiekawostkiForeColor = ArgLabelCiekawostkiForeColor;
            CwiczennikBackgroundColor = ArgCwiczennikBackgroundColor;
            CwiczennikForeColor = ArgCwiczennikForeColor;

            ButtonButtonTypeOfConvertEnergiaBackgroundColor = ArgButtonButtonTypeOfConvertEnergiaBackgroundColor;
            ButtonButtonTypeOfConvertMasaBackgroundColor = ArgButtonButtonTypeOfConvertMasaBackgroundColor;
            ButtonButtonTypeOfConvertForeColor = ArgButtonButtonTypeOfConvertForeColor;
            LabelsKonwertujZ_lub_NaForeColor = ArgLabelsKonwertujZ_lub_NaForeColor;
            CalculatorTextBoxBackgroundColor = ArgCalculatorTextBoxBackgroundColor;
            CalculatorTextBoxForeColor = ArgCalculatorTextBoxForeColor;
            ButtonsOfCalculatorBackgroundColor = ArgButtonsOfCalculatorBackgroundColor;
            ButtonsOfCalculatorForeColor = ArgButtonsOfCalculatorForeColor;
            KonwertujWynikButtonBackgroundColor = ArgKonwertujWynikButtonBackgroundColor;
            KonwertujWynikButtonForeColor = ArgKonwertujWynikButtonForeColor;
            LabelWynikForeColor = ArgLabelWynikForeColor;

            LabelDescribeOfProductForeColorMainForm = ArgLabelDescribeOfProductForeColorMainForm;
            LabelWartOdzywczeForeColorMainForm = ArgLabelWartOdzywczeForeColorMainForm;
            LabelWartEnergetyczneForeColorMainForm = ArgLabelWartEnergetyczneForeColorMainForm;
            LabelBialkoForeColorMainForm = ArgLabelBialkoForeColorMainForm;
            LabelTluszczForeColorMainForm = ArgLabelTluszczForeColorMainForm;
            LabelWeglowodanyForeColorMainForm = ArgLabelWeglowodanyForeColorMainForm;
            LabelBlonnikForeColorMainForm = ArgLabelBlonnikForeColorMainForm;
            LabelWitaminyForeColorMainForm = ArgLabelWitaminyForeColorMainForm;
            LabelMineralyForeColorMainForm = ArgLabelMineralyForeColorMainForm;
            LabelPodWitaminyIPodMineralyMainForm = ArgLabelPodWitaminyIPodMineralyMainForm;
            EditAndDeleteProductBorderColor = ArgEditAndDeleteProductBorderColor;
            EditAndDeleteProductForeColor = ArgEditAndDeleteProductForeColor;
            AddProductForeColor = ArgAddProductForeColor;

            PanelLineBackgroundColor = ArgPanelLineBackgroundColor;
            FoodTitleForeColor = ArgFoodTitleForeColor;


            PanelMainInformationAboutApplication = ArgPanelMainInformationAboutApplication;

            LabelWersjaForeColor = ArgLabelWersjaForeColor;
            LabelProduktForeColor = ArgLabelProduktForeColor;
            LabelTworcyForeColor = ArgLabelTworcyForeColor;
            LabelAutorzyForeColor = ArgLabelAutorzyForeColor;
            ButtonCloseInformationAboutApplicationBackgroundColor = ArgButtonCloseInformationAboutApplicationBackgroundColor;
            ButtonCloseInformationAboutApplicationForeColor = ArgButtonCloseInformationAboutApplicationForeColor;

            IntroFormBackgroundImage = ArgIntroFormBackgroundImage; //TODO no nw


            ExerciseDictonaryMainPanelColor = ArgExerciseDictonaryMainPanelColor;

            LabelHeaderForeColor = ArgLabelHeaderForeColor;
            LabelSecondHeadersForeColor = ArgLabelSecondHeadersForeColor;
            TextExerciseDictonaryForeColor = ArgTextExerciseDictonaryForeColor;
            TitleForeColor = ArgTitleForeColor;

            CentralPanelAddAndEditProductFormsBackgroundColor = ArgCentralPanelAddAndEditProductFormsBackgroundColor;
            LabelNazwaProduktuForeColorAddAndEditProductForms = ArgLabelNazwaProduktuForeColorAddAndEditProductForms;
            LabelWartoscEnergetycznaColorAddAndEditProductForms = ArgLabelWartoscEnergetycznaColorAddAndEditProductForms;
            LabelBialkoForeColorAddAndEditProductForms = ArgLabelBialkoForeColorAddAndEditProductForms;
            LabelTluszczForeColorAddAndEditProductForms = ArgLabelTluszczForeColorAddAndEditProductForms;
            LabelWeglowodanyForeColorAddAndEditProductForms = ArgLabelWeglowodanyForeColorAddAndEditProductForms;
            LabelBlonnikForeColorAddAndEditProductForms = ArgLabelBlonnikForeColorAddAndEditProductForms;
            LabelWitaminyForeColorAddAndEditProductForms = ArgLabelWitaminyForeColorAddAndEditProductForms;
            LabelMineralyForeColorAddAndEditProductForms = ArgLabelMineralyForeColorAddAndEditProductForms;
            LabelOpisProduktuForeColorAddAndEditProductForms = ArgLabelOpisProduktuForeColorAddAndEditProductForms;

            TextBoxAndComboBoxBackgroundColorAddAndEditProductForms = ArgTextBoxAndComboBoxBackgroundColorAddAndEditProductForms;
            TextBoxAndComboBoxForeColorAddAndEditProductForms = ArgTextBoxAndComboBoxForeColorAddAndEditProductForms;

            WarningsColor = ArgWarningsColor;

            Podpowiedz_ZalecanaNazwa_ForeColor = ArgPodpowiedz_ZalecanaNazwa_ForeColor;
            Podpowiedz_ZapisUlamkow_ForeColor = ArgPodpowiedz_ZapisUlamkow_ForeColor;
            LabelWartoscWGramachForeColor = ArgLabelWartoscWGramachForeColor;


            ProductNameForeColorEditProductForm = ArgProductNameForeColorEditProductForm;
            ProductNameBackgroundColorEditProductForm = ArgProductNameBackgroundColorEditProductForm;

            ButtonWybierzObrazekBackgroundColor = ArgButtonWybierzObrazekBackgroundColor;
            ButtonWybierzObrazekForeColor = ArgButtonWybierzObrazekForeColor;

            ButtonsWybierzObrazekAndResetBorderColor = ArgButtonsWybierzObrazekAndResetBorderColor;

            ButtonResetBackgroundColor = ArgButtonResetBackgroundColor;
            ButtonResetForeColor = ArgButtonResetForeColor;

            ButtonZapiszDodajProduktBackgroundColor = ArgButtonZapiszDodajProduktBackgroundColor;
            ButtonZapiszDodajProduktForeColor = ArgButtonZapiszDodajProduktForeColor;

            CentralPanelSettingsFormBackgroundColor = ArgCentralPanelSettingsFormBackgroundColor;
            LabelUstawieniaSettingsFormForeColor = ArgLabelUstawieniaSettingsFormForeColor;
            LabelMotywSettingsFormForeColor = ArgLabelMotywSettingsFormForeColor;
            MotywComboBoxSettingsFormBackgroundColor = ArgMotywComboBoxSettingsFormBackgroundColor;
            MotywComboBoxSettingsFormForeColor = ArgMotywComboBoxSettingsFormForeColor;
            ButtonAnulujSettingsFormBackgroundColor = ArgButtonAnulujSettingsFormBackgroundColor;
            ButtonAnulujSettingsFormForeColor = ArgButtonAnulujSettingsFormForeColor;
            ButtonZastosujSettingsFormBackgroundColor = ArgButtonZastosujSettingsFormBackgroundColor;
            ButtonZastosujSettingsFormForeColor = ArgButtonZastosujSettingsFormForeColor;
        }

        public AppTheme() { }
    }
}
