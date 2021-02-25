using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Collections.ObjectModel;

namespace SwmSuite.Presentation.Common.RadioGroup {
	
	public partial class RadioGroupControl : UserControl {

		#region -_ Private members _-

		private Collection<RadioGroupItem> _items = new Collection<RadioGroupItem>();
		private Collection<RadioButton> _radioButtons = new Collection<RadioButton>();

		#endregion

		#region -_ Public Properties _-

		public event EventHandler<RadioGroupSelectionChangedEventArgs> SelectionChanged;

		public Collection<RadioGroupItem> Items {
			get {
				return _items;
			}
		}

		#endregion

		#region -_ Construction _-

		public RadioGroupControl() {
			InitializeComponent();
			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			this.SetStyle( ControlStyles.UserPaint , true );
			this.BackColor = Color.Transparent;
		}

		#endregion

		#region -_ Public Methods _-

		public void RefreshRadioButtons() {
			this.Controls.Clear();
			_radioButtons.Clear();
			int topOffset = 0;
			foreach( RadioGroupItem item in this.Items ) {
				RadioButton radioButton = new RadioButton();
				radioButton.Text = item.Text;
				radioButton.Checked = item.Checked;
				radioButton.Tag = item;
				radioButton.CheckedChanged += new EventHandler( radioButton_CheckedChanged );
				radioButton.Bounds = new Rectangle( this.ClientRectangle.Left , this.ClientRectangle.Top + topOffset , this.ClientRectangle.Width - 30 , 20 );
				this.Controls.Add( radioButton );
				topOffset += 20;
			}
		}

		void radioButton_CheckedChanged( object sender , EventArgs e ) {
			RadioButton senderRadioButton = sender as RadioButton;
			if( senderRadioButton.Checked ) {
				foreach( RadioGroupItem item in this.Items ) {
					if( (RadioGroupItem)senderRadioButton.Tag == item ) {
						item.Checked = true;
						RaiseSelectionChanged( item );
					} else {
						item.Checked = false;
					}
				}
			}
		}

		/// <summary>
		/// Gets the checked item.
		/// </summary>
		/// <returns></returns>
		public String GetCheckedItem() {
			foreach( RadioGroupItem item in this.Items ) {
				if( item.Checked ) {
					return item.Text;
				}
			}
			return String.Empty;
		}

		#endregion

		#region -_ Private Methods _-

		private void RaiseSelectionChanged( RadioGroupItem item ){
			if( SelectionChanged != null ){
				SelectionChanged( this , new RadioGroupSelectionChangedEventArgs( item ) );
			}
		}

		#endregion

	}

}
