using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace SwmSuite.Presentation.Common.TimeTable {

	public class OccupationRenderer {

		#region -_ Private Members _-

		private int _rowHeight;
		private int _hourWidth;

		private Rectangle _headerRectangle;
		private Rectangle _footerRectangle;
		private Rectangle _descriptionRectangle;
		private Rectangle _summaryRectangle;
		private Rectangle _contentRectangle;
		private Rectangle _dateRectangle;

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Initializes a new instance of the <see cref="OccupationRenderer"/> class.
		/// </summary>
		public OccupationRenderer() {

		}

		#endregion

		#region -_ Construction _-

		#endregion

		#region -_ Public Methods _-

		public void Render( Graphics graphics , Rectangle drawRectangle , DateTime selection , TimeTableColumnCollection columns , OccupationSettings settings , OccupationScheme scheme ) {
			// Calculate dimensions.
			CalculateDimensions( drawRectangle , columns , settings , scheme );
			// Draw description column.
			RenderDescriptionColumn( graphics , columns , scheme );
			// Draw header.
			RenderHeader( graphics , settings , scheme );
			RenderFooter( graphics , settings , scheme );
			RenderDate( graphics , selection , scheme );
			// Draw summary column.
			RenderSummaryColumn( graphics , columns , scheme );
			// Draw contents.
			RenderEntries( graphics , columns , settings , scheme );
			// Draw seperators.
			Pen borderPen = new Pen( scheme.SeperatorColor );
			graphics.DrawLine( borderPen , _headerRectangle.Left , _headerRectangle.Bottom , _headerRectangle.Right , _headerRectangle.Bottom );
			graphics.DrawLine( borderPen , _footerRectangle.Left , _footerRectangle.Top , _footerRectangle.Right , _footerRectangle.Top );
			graphics.DrawLine( borderPen , _descriptionRectangle.Right , drawRectangle.Top , _descriptionRectangle.Right , drawRectangle.Bottom );
			graphics.DrawLine( borderPen , _summaryRectangle.Left , drawRectangle.Top , _summaryRectangle.Left , drawRectangle.Bottom );
			graphics.DrawRectangle( borderPen , drawRectangle );
			borderPen.Dispose();
		}

		#endregion

		#region -_ Private Methods _-

		private void CalculateDimensions( Rectangle bounds , TimeTableColumnCollection columns , OccupationSettings settings , OccupationScheme scheme ) {
			// Calculate number of rows.
			int totalHeight = bounds.Height - scheme.HeaderHeight - scheme.HeaderHeight;
			//_rowHeight = totalHeight / ( columns.Count > 0 ? columns.Count : 1 );
			_rowHeight = ( scheme.BarHeight + scheme.BarGap * 2 );
			// Calculate hourwidth.
			int numberOfHours = settings.EndHour - settings.StartHour;
			int totalWidth = bounds.Width - scheme.DescriptionColumnWidth - scheme.SummaryColumnWidth;
			_hourWidth = totalWidth / numberOfHours;
			// Calculate rectangles.
			_headerRectangle = new Rectangle( bounds.Left , bounds.Top , bounds.Width , scheme.HeaderHeight );
			_footerRectangle = new Rectangle( bounds.Left , bounds.Bottom - scheme.HeaderHeight , bounds.Width , scheme.HeaderHeight );
			_descriptionRectangle = new Rectangle( bounds.Left , bounds.Top + scheme.HeaderHeight , scheme.DescriptionColumnWidth , bounds.Height - scheme.HeaderHeight - scheme.HeaderHeight );
			int contentsWidth = _hourWidth * ( settings.EndHour - settings.StartHour );
			_summaryRectangle = new Rectangle( bounds.Left + scheme.DescriptionColumnWidth + contentsWidth , bounds.Top + scheme.HeaderHeight , scheme.SummaryColumnWidth , bounds.Height - scheme.HeaderHeight - scheme.HeaderHeight );
			_contentRectangle = new Rectangle( bounds.Left + scheme.DescriptionColumnWidth , bounds.Top + scheme.HeaderHeight , contentsWidth , bounds.Height - scheme.HeaderHeight - scheme.HeaderHeight );
			_dateRectangle = new Rectangle( bounds.Left , bounds.Top , scheme.DescriptionColumnWidth , scheme.HeaderHeight );
		}

		private void RenderDate( Graphics graphics , DateTime selection , OccupationScheme scheme ) {
			TextRenderer.DrawText( graphics , selection.ToString( "dddd dd MMMM yyyy" ) , scheme.TimeCaptionFont , _dateRectangle , scheme.TimeCaptionColor , TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter );
		}

		private void RenderDescriptionColumn( Graphics graphics , TimeTableColumnCollection columns , OccupationScheme scheme ) {
			for( int i = 0 ; i < columns.Count ; i++ ) {
				Rectangle rowRectangle = new Rectangle( _descriptionRectangle.Left , _descriptionRectangle.Top + i * _rowHeight + scheme.BarGap , _descriptionRectangle.Width , _rowHeight );
				TextRenderer.DrawText( graphics , columns[i].Caption , scheme.DescriptionCaptionFont , rowRectangle , scheme.DescriptionCaptionColor , TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter );
			}
		}

		private void RenderSummaryColumn( Graphics graphics , TimeTableColumnCollection columns , OccupationScheme scheme ) {
			for( int i = 0 ; i < columns.Count ; i++ ) {
				Rectangle rowRectangle = new Rectangle( _summaryRectangle.Left , _summaryRectangle.Top + i * _rowHeight + scheme.BarGap , _summaryRectangle.Width , _rowHeight );
				TimeSpan totalTime = new TimeSpan( 0 , 0 , 0 );
				foreach( TimeTableControlEntry entry in columns[i].TimeTableEntries ) {
					totalTime = totalTime.Add( entry.End - entry.Begin );
				}
				TextRenderer.DrawText( graphics , totalTime.TotalHours.ToString() + "h" , scheme.SummaryCaptionFont , rowRectangle , scheme.SummaryCaptionColor , TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter );
			}
		}

		private void RenderHeader( Graphics graphics , OccupationSettings settings , OccupationScheme scheme ) {
			// Render background.
			Rectangle topRectangle = new Rectangle( _headerRectangle.Left , _headerRectangle.Top , _headerRectangle.Width , _headerRectangle.Height / 2 );
			Rectangle bottomRectangle = new Rectangle( _headerRectangle.Left , topRectangle.Bottom , _headerRectangle.Width , _headerRectangle.Height / 2 );
			LinearGradientBrush columnHeaderBackgroundBrush1 = new LinearGradientBrush( topRectangle , scheme.ColumnHeaderBackgroundColor1 , scheme.ColumnHeaderBackgroundColor2 , LinearGradientMode.Vertical );
			LinearGradientBrush columnHeaderBackgroundBrush2 = new LinearGradientBrush( bottomRectangle , scheme.ColumnHeaderBackgroundColor3 , scheme.ColumnHeaderBackgroundColor4 , LinearGradientMode.Vertical );
			graphics.FillRectangle( columnHeaderBackgroundBrush1 , topRectangle );
			graphics.FillRectangle( columnHeaderBackgroundBrush2 , bottomRectangle );
			columnHeaderBackgroundBrush2.Dispose();
			columnHeaderBackgroundBrush1.Dispose();
			// Render contents.
			Pen largeRulerPen = new Pen( scheme.LargeRulerColor );
			Pen smallRulerPen = new Pen( scheme.SmallRulerColor );
			for( int i = 0 ; i < ( settings.EndHour - settings.StartHour ) ; i++ ) {
				Rectangle hourRectangle = new Rectangle( _contentRectangle.Left + i * _hourWidth , _contentRectangle.Top - 5 , _hourWidth , _contentRectangle.Height + 5 );
				Rectangle halfHourRectangle = new Rectangle( _contentRectangle.Left + i * _hourWidth , _contentRectangle.Top , _hourWidth / 2 , _contentRectangle.Height );
				graphics.DrawLine( largeRulerPen , hourRectangle.Right , hourRectangle.Top , hourRectangle.Right , hourRectangle.Bottom );
				graphics.DrawLine( smallRulerPen , halfHourRectangle.Right , halfHourRectangle.Top , halfHourRectangle.Right , halfHourRectangle.Bottom );
				Rectangle captionRectangle = new Rectangle( _contentRectangle.Left - _hourWidth + ( i * _hourWidth ) , _headerRectangle.Top , _hourWidth * 2 , _headerRectangle.Height );
				if( i > 0 ) {
					String caption = ( (int)( i + settings.StartHour ) ).ToString( "D2" );
					TextRenderer.DrawText( graphics , caption , scheme.TimeCaptionFont , captionRectangle , scheme.TimeCaptionColor , TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter );
				}
			}
			smallRulerPen.Dispose();
			largeRulerPen.Dispose();
		}

		private void RenderFooter( Graphics graphics , OccupationSettings settings , OccupationScheme scheme ) {
			// Render background.
			Rectangle topRectangle = new Rectangle( _footerRectangle.Left , _footerRectangle.Top , _footerRectangle.Width , _footerRectangle.Height / 2 );
			Rectangle bottomRectangle = new Rectangle( _footerRectangle.Left , topRectangle.Bottom , _footerRectangle.Width , _footerRectangle.Height / 2 );
			LinearGradientBrush columnFooterBackgroundBrush1 = new LinearGradientBrush( topRectangle , scheme.SummaryRowBackgroundColor1 , scheme.SummaryRowBackgroundColor2 , LinearGradientMode.Vertical );
			LinearGradientBrush columnFooterBackgroundBrush2 = new LinearGradientBrush( bottomRectangle , scheme.SummaryRowBackgroundColor3 , scheme.SummaryRowBackgroundColor4 , LinearGradientMode.Vertical );
			graphics.FillRectangle( columnFooterBackgroundBrush1 , topRectangle );
			graphics.FillRectangle( columnFooterBackgroundBrush2 , bottomRectangle );
			columnFooterBackgroundBrush2.Dispose();
			columnFooterBackgroundBrush1.Dispose();
		}

		private void RenderEntries( Graphics graphics , TimeTableColumnCollection columns , OccupationSettings settings , OccupationScheme scheme ) {
			for( int i = 0 ; i < columns.Count ; i++ ) {
				Rectangle rowRectangle = new Rectangle( _contentRectangle.Left , _contentRectangle.Top + i * _rowHeight + scheme.BarGap , _contentRectangle.Width , _rowHeight );
				foreach( TimeTableControlEntry entry in columns[i].TimeTableEntries ) {
					DateTime startOffsetDateTime = new DateTime( entry.Begin.Year , entry.Begin.Month , entry.Begin.Day , settings.StartHour , 0 , 0 );
					TimeSpan leftOffsetTimeSpan = entry.Begin - startOffsetDateTime;
					int leftOffset = (int)( leftOffsetTimeSpan.TotalHours * (double)_hourWidth );
					TimeSpan entryDuration = entry.End - entry.Begin;
					int width = (int)( entryDuration.TotalHours * (double)_hourWidth );
					Rectangle entryRectangle = new Rectangle( rowRectangle.Left + leftOffset , rowRectangle.Top + rowRectangle.Height / 2 - scheme.BarHeight / 2 , width , scheme.BarHeight );
					//entryRectangle = new Rectangle( entryRectangle.Left , entryRectangle.Top , entryRectangle.Width , entryRectangle.Height );
					LinearGradientBrush fillBrush = new LinearGradientBrush( entryRectangle , entry.BackColor1 , entry.BackColor2 , LinearGradientMode.Vertical );
					Pen borderPen = new Pen( entry.BorderColor );
					graphics.FillRectangle( fillBrush , entryRectangle );
					graphics.DrawRectangle( borderPen , entryRectangle );
					TextRenderer.DrawText( graphics , entry.ToString() , scheme.TimeCaptionFont , entryRectangle , scheme.DescriptionCaptionColor , TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter );
					borderPen.Dispose();
					fillBrush.Dispose();
				}
			}
		}

		#endregion

	}

}
