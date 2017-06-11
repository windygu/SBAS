using Busines.DAL;
using Busines.IDAO;
using Common.DotNetUI;
using OpWeb.App_Code;
using OpWeb;
using System;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using OpWeb.UserControl;

namespace OpWeb.RMBase.SysMenu
{
	public class Button_List : PageBase
	{
		private RM_System_IDAO systemidao = new RM_System_Dal();
		protected HtmlHead Head1;
		protected HtmlForm form1;
		protected LoadButton LoadButton1;
		protected Repeater rp_Item;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				this.InitData();
			}
		}
		private void InitData()
		{
			DataTable dt = this.systemidao.GetButtonList();
			ControlBindHelper.BindRepeaterList(dt, this.rp_Item);
		}
	}
}
