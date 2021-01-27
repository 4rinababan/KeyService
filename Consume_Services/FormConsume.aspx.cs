using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Data;


namespace Consume_Services
{
    
    public partial class FormConsume : System.Web.UI.Page
    {
        
        KeyReference.KeyServicesSoapClient soapClient = new KeyReference.KeyServicesSoapClient();
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            string  response;
            //soapClient.Open();
            
            switch (DropDownList1.Text)
            {
                case "Reserve IMEI":
                     response = soapClient.ReserveImeiKey(txtPartNo.Text, txtQty.Text, txtWo.Text);
                    GridView1.DataSource = JsonConvert.DeserializeObject<DataSet>(response);
                    GridView1.DataBind();
                    break;
                case "Reserve MAC":
                    response = soapClient.ReserveMacKey(txtPartNo.Text, txtQty.Text, txtWo.Text);
                    GridView1.DataSource = JsonConvert.DeserializeObject<DataSet>(response);
                    GridView1.DataBind();
                    break;
                case "Reserve KEYBOX":
                    response = soapClient.ReserveKeybox(txtPartNo.Text, txtQty.Text, txtWo.Text);
                    GridView1.DataSource = JsonConvert.DeserializeObject<DataSet>(response);
                    GridView1.DataBind();
                    break;
                case "Reserve ATTKEY":
                    response = soapClient.ReserveAttestationKey(txtPartNo.Text, txtQty.Text, txtWo.Text);
                    GridView1.DataSource = JsonConvert.DeserializeObject<DataSet>(response);
                    GridView1.DataBind();
                    break;
                case "Get Single IMEI":
                    response = soapClient.GetImeiKey(txtPartNo.Text, txtQty.Text, txtWo.Text, txtProductId.Text);
                    GridView1.DataSource = JsonConvert.DeserializeObject<DataSet>(response);
                    GridView1.DataBind();
                    break;
                case "Get Single MAC":
                    response = soapClient.GetMacKey(txtPartNo.Text, txtQty.Text, txtWo.Text, txtProductId.Text);
                    GridView1.DataSource = JsonConvert.DeserializeObject<DataSet>(response);
                    GridView1.DataBind();
                    break;
                case "Get Single KEYBOX":
                    response = soapClient.GetKeybox(txtPartNo.Text, txtQty.Text, txtWo.Text, txtProductId.Text);
                    GridView1.DataSource = JsonConvert.DeserializeObject<DataSet>(response);
                    GridView1.DataBind();
                    break;
                case "Get Single ATTKEY":
                    response = soapClient.GetAttestationKey(txtPartNo.Text, txtQty.Text, txtWo.Text, txtProductId.Text);
                    GridView1.DataSource = JsonConvert.DeserializeObject<DataSet>(response);
                    GridView1.DataBind();
                    break;
                case "Get IMEI by WO":
                    response = soapClient.GetImeiKey(txtPartNo.Text, txtQty.Text, txtWo.Text, txtProductId.Text);
                    GridView1.DataSource = JsonConvert.DeserializeObject<DataSet>(response);
                    GridView1.DataBind();
                    break;
                case "Get MAC by WO":
                    response = soapClient.GetMacKey(txtPartNo.Text, txtQty.Text, txtWo.Text, txtProductId.Text);
                    GridView1.DataSource = JsonConvert.DeserializeObject<DataSet>(response);
                    GridView1.DataBind();
                    break;
                case "Get KEYBOX by WO":
                    response = soapClient.GetKeyBoxKeyByWoID(txtPartNo.Text, txtQty.Text, txtWo.Text, txtProductId.Text);
                    GridView1.DataSource = JsonConvert.DeserializeObject<DataSet>(response);
                    GridView1.DataBind();
                    break;
                case "Get ATTKEY by WO":
                    response = soapClient.GetAttestationKeyByWoID(txtPartNo.Text, txtQty.Text, txtWo.Text, txtProductId.Text);
                    GridView1.DataSource = JsonConvert.DeserializeObject<DataSet>(response);
                    GridView1.DataBind();
                    break;

                default:
                    //
                    break;

            }            
        }
    }
}