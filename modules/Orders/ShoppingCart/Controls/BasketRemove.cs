﻿using System;
using System.Web.UI;

using lw.Base;

namespace lw.ShoppingCart.Controls
{
	public class BasketRemove : System.Web.UI.HtmlControls.HtmlInputCheckBox
	{
		bool bound = false;

		int ItemId = -1;
		string options = "";

		public override void DataBind()
		{
			if (bound)
				return;
			bound = true;

			this.Visible = false;

			try
			{
				object obj = DataBinder.Eval(this.NamingContainer, "DataItem.ItemId");
				if (obj != null)
					ItemId = (int)obj;
				options = DataBinder.Eval(this.NamingContainer, "DataItem.OptionsKey").ToString();

				this.Value = "on";

				this.Visible = true;
			}
			catch (Exception Ex)
			{
				CustomPage page = this.Page as CustomPage;
			}
			base.DataBind();
		}
		public override string UniqueID
		{
			get
			{
				return string.Format("Remove_{0}_{1}", ItemId, options);
			}
		}
	}
}
