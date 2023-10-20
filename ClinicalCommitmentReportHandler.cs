using Ellucian.Colleague.Domain.Entities;
using Newtonsoft.Json;
using NipissingU.SelfServe.WebSite.Areas.SelfServe.Models.Student;
using Spire.Pdf;
using Spire.Pdf.Fields;
using Spire.Pdf.Widget;
using System.Web;
using NipissingU.SelfServe.WebSite.Security;
using System.Collections;

namespace NipissingU.SelfServe.WebSite.Reports.Handlers
{
    public class ClinicalCommitment : IReportHandler
    {
        private const string TemplatePath = "~/Reports/Templates/ClinicalCommitment.pdf";
        private const string TemplateName = "ClinicalCommitment.pdf";

        public string GetTemplatePath()
        {
            return HttpContext.Current.Server.MapPath(TemplatePath);
        }

        public string GetTemplateName()
        {
            return TemplateName;
        }

        public PdfDocument GetPopulatedReport(string id, object jsonReportData, string userName)
        {
            var templatePath = GetTemplatePath();

            PdfDocument pdf = new PdfDocument();

            pdf.LoadFromFile(templatePath);

            ClinicalCommitmentViewModel viewModel = JsonConvert.DeserializeObject<ClinicalCommitmentViewModel>(jsonReportData.ToString());

            PdfFormWidget formWidget = pdf.Form as PdfFormWidget;

            const string headersFieldPath = "form[0].subform[0].";
            const string ssTableFieldPath = "form[0].subform[0].ss_table[0].";
            const string faTableFieldPath = "form[0].subform[0].fa_table[0].";
            const string wiTableFieldPath = "form[0].subform[0].wi_table[0].";

            for (int i = 0; i < formWidget.FieldsWidget.List.Count; i++)
            {
                PdfField field = formWidget.FieldsWidget.List[i] as PdfField;

                //Fill the data for textBoxField
                if (field is PdfTextBoxFieldWidget)
                {
                    PdfTextBoxFieldWidget textBoxField = field as PdfTextBoxFieldWidget;

                    switch (textBoxField.Name)
                    {
                        // heading info 
                        //
                        case headersFieldPath + "student_name[0]":
                            textBoxField.Text = userName;
                            break;
                        case headersFieldPath + "student_id[0]":
                            textBoxField.Text = id;
                            break;


                      
                        // spring summer options 
                        //
                        case headersFieldPath + "ss_title[0]":
                            textBoxField.Text = viewModel.SpringSemesterTitle;
                            break;

                        
                        case ssTableFieldPath + "option1[0].ss_course1[0]":
                            textBoxField.Text = viewModel.SpringCourseOptions[0].DisplayWithDescription;
                            break;
                        case ssTableFieldPath + "option2[0].ss_course2[0]":
                            textBoxField.Text = viewModel.SpringCourseOptions[1].DisplayWithDescription;
                            break;
                        case ssTableFieldPath + "option3[0].ss_course3[0]":
                            textBoxField.Text = viewModel.SpringCourseOptions[2].DisplayWithDescription;
                            break;
                        case ssTableFieldPath + "option4[0].ss_course4[0]":
                            textBoxField.Text = viewModel.SpringCourseOptions[3].DisplayWithDescription;
                            break;
                        case ssTableFieldPath + "option5[0].ss_course5[0]":
                            textBoxField.Text = viewModel.SpringCourseOptions[4].DisplayWithDescription;
                            break;
                        case ssTableFieldPath + "option6[0].ss_course6[0]":
                            textBoxField.Text = viewModel.SpringCourseOptions[5].DisplayWithDescription;
                            break;
                        
                            
                        // fall options
                        //
                        case faTableFieldPath + "fa_title[0]":
                            textBoxField.Text = viewModel.FallCourseOptions[0].DisplayWithDescription;
                            break;
                        case faTableFieldPath + "option1[0].fa_course1[0]":
                            textBoxField.Text = viewModel.FallCourseOptions[1].DisplayWithDescription;
                            break;
                        case faTableFieldPath + "option2[0].fa_course2[0]":
                            textBoxField.Text = viewModel.FallCourseOptions[2].DisplayWithDescription;
                            break;
                        case faTableFieldPath + "option3[0].fa_course3[0]":
                            textBoxField.Text = viewModel.FallCourseOptions[3].DisplayWithDescription;
                            break;
                        case faTableFieldPath + "option4[0].fa_course4[0]":
                            textBoxField.Text = viewModel.FallCourseOptions[4].DisplayWithDescription;
                            break;
                        case faTableFieldPath + "option5[0].fa_course5[0]":
                            textBoxField.Text = viewModel.FallCourseOptions[5].DisplayWithDescription;
                            break;
                        case faTableFieldPath + "option6[0].fa_course6[0]":
                            textBoxField.Text = viewModel.FallCourseOptions[6].DisplayWithDescription;
                            break;
                        case faTableFieldPath + "option7[0].fa_course7[0]":
                            textBoxField.Text = viewModel.FallCourseOptions[7].DisplayWithDescription;
                            break;
                        

                        // winter options
                        //
                        case wiTableFieldPath + "wi_title[0]":
                            textBoxField.Text = viewModel.WinterCourseOptions[0].DisplayWithDescription;
                            break;


                            




                        case wiTableFieldPath + "option1[0].wi_course1[0]":
                            textBoxField.Text = viewModel.WinterCourseOptions[0].DisplayWithDescription;
                            break;
                        case wiTableFieldPath + "option2[0].wi_course2[0]":
                            textBoxField.Text = viewModel.WinterCourseOptions[1].DisplayWithDescription;
                            break;
                        case wiTableFieldPath + "option3[0].wi_course3[0]":
                            textBoxField.Text = viewModel.WinterCourseOptions[2].DisplayWithDescription;
                            break;
                        case wiTableFieldPath + "option4[0].wi_course4[0]":
                            textBoxField.Text = viewModel.WinterCourseOptions[4].DisplayWithDescription;
                            break;  
                        case wiTableFieldPath + "option5[0].wi_course5[0]":
                            textBoxField.Text = viewModel.WinterCourseOptions[5].DisplayWithDescription;
                            break;
                        case wiTableFieldPath + "option6[0].wi_course6[0]":
                            textBoxField.Text = viewModel.WinterCourseOptions[6].DisplayWithDescription;
                            break;
                        case wiTableFieldPath + "option7[0].wi_course7[0]":
                            textBoxField.Text = viewModel.WinterCourseOptions[7].DisplayWithDescription;
                            break;
                       

                    }
                }

                //Fill the data for checkBoxField
                if (field is PdfCheckBoxWidgetFieldWidget)
                {
                    PdfCheckBoxWidgetFieldWidget checkBoxField = field as PdfCheckBoxWidgetFieldWidget;
                    switch (checkBoxField.Name)
                    {

                        // spring summer options 
                        //
                        //case "form1[0].#subform[0].ss_table[0].option1[0].ss_sel1[0]":
                        //    checkBoxField.Checked = ;
                        //    break;
                        //case "form1[0].#subform[0].ss_table[0].option1[0].ss_sel2[0]":
                        //    checkBoxField.Checked = ;
                        //    break;
                        //case "form1[0].#subform[0].ss_table[0].option1[0].ss_sel3[0]":
                        //    checkBoxField.Checked = ;
                        //    break;
                        //case "form1[0].#subform[0].ss_table[0].option1[0].ss_sel4[0]":
                        //    checkBoxField.Checked = ;
                        //    break;
                        //case "form1[0].#subform[0].ss_table[0].option1[0].ss_sel5[0]":
                        //    checkBoxField.Checked = ;
                        //    break;
                        //case "form1[0].#subform[0].ss_table[0].option1[0].ss_sel6[0]":
                        //    checkBoxField.Checked = ;
                        //    break;

                        // fall options
                        //
                        //case "form1[0].#subform[0].fa_table[0].option1[0].fa_sel1[0]":
                        //    checkBoxField.Checked = ;
                        //    break;
                        //case "form1[0].#subform[0].fa_table[0].option1[0].fa_sel2[0]":
                        //    checkBoxField.Checked = ;
                        //    break;
                        //case "form1[0].#subform[0].fa_table[0].option1[0].fa_sel3[0]":
                        //    checkBoxField.Checked = ;
                        //    break;
                        //case "form1[0].#subform[0].fa_table[0].option1[0].fa_sel4[0]":
                        //    checkBoxField.Checked = ;
                        //    break;
                        //case "form1[0].#subform[0].fa_table[0].option1[0].fa_sel5[0]":
                        //    checkBoxField.Checked = ;
                        //    break;
                        //case "form1[0].#subform[0].fa_table[0].option1[0].fa_sel6[0]":
                        //    checkBoxField.Checked = ;
                        //    break;
                        //case "form1[0].#subform[0].fa_table[0].option1[0].fa_sel7[0]":
                        //    checkBoxField.Checked = ;
                        //    break;
                        //case "form1[0].#subform[0].fa_table[0].option1[0].fa_sel8[0]":
                        //    checkBoxField.Checked = ;
                        //    break;


                        // winter options
                        //
                        //case "form1[0].#subform[0].wi_table[0].option1[0].wi_sel1[0]":
                        //    checkBoxField.Checked = ;
                        //    break;
                        //case "form1[0].#subform[0].wi_table[0].option1[0].wi_sel2[0]":
                        //    checkBoxField.Checked = ;
                        //    break;
                        //case "form1[0].#subform[0].wi_table[0].option1[0].wi_sel3[0]":
                        //    checkBoxField.Checked = ;
                        //    break;
                        //case "form1[0].#subform[0].wi_table[0].option1[0].wi_sel4[0]":
                        //    checkBoxField.Checked = ;
                        //    break;
                        //case "form1[0].#subform[0].wi_table[0].option1[0].wi_sel5[0]":
                        //    checkBoxField.Checked = ;
                        //    break;
                        //case "form1[0].#subform[0].wi_table[0].option1[0].wi_sel6[0]":
                        //    checkBoxField.Checked = ;
                        //    break;
                        //case "form1[0].#subform[0].wi_table[0].option1[0].wi_sel7[0]":
                        //    checkBoxField.Checked = ;
                        //    break;
                        //case "form1[0].#subform[0].wi_table[0].option1[0].wi_sel8[0]":
                        //    checkBoxField.Checked = ;
                        //    break;

                    }
                }


                //Fill the data for listBoxField
                if (field is PdfListBoxWidgetFieldWidget)
                {
                    PdfListBoxWidgetFieldWidget listBoxField = field as PdfListBoxWidgetFieldWidget;
                    switch (listBoxField.Name)
                    {

                        case "email_format":
                            int[] index = { 1 };
                            listBoxField.SelectedIndex = index;
                            break;

                    }
                }

                //Fill the data for comBoxField
                if (field is PdfComboBoxWidgetFieldWidget)
                {
                    PdfComboBoxWidgetFieldWidget comBoxField = field as PdfComboBoxWidgetFieldWidget;
                    switch (comBoxField.Name)
                    {

                        case "title":
                            int[] items = { 0 };
                            comBoxField.SelectedIndex = items;
                            break;
                    }
                }

                // set fields readonly 
                field.ReadOnly = true;
                //field.Flatten = true;
            }

            return pdf;
        }

    }
}