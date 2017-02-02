
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ChordEditor.UserControls
{

	[System.ComponentModel.DefaultEvent("Click")]
	public class ImageButton : System.Windows.Forms.UserControl
	{

		#region " Codice generato da Progettazione Windows Form "

		public ImageButton()
			: base()
		{
			EnabledChanged += ImageButtonEnabledChanged;
			MouseDown += ImageButtonMouseDown;
			MouseUp += ImageButtonMouseUp;
			MouseLeave += ImageButtonMouseLeave;
			MouseEnter += ImageButtonMouseEnter;

			//Chiamata richiesta da Progettazione Windows Form.
			InitializeComponent();

			//Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent()
			Init();
		}

		//UserControl esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if ((components != null))
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		//Richiesto da Progettazione Windows Form

		private System.ComponentModel.IContainer components;
		//NOTA: la procedura che segue è richiesta da Progettazione Windows Form.
		//Può essere modificata in Progettazione Windows Form.  
		//Non modificarla nell'editor del codice.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			//
			//ImageButton
			//
			this.Name = "ImageButton";
			this.Size = new System.Drawing.Size(200, 164);

		}

		#endregion

		private void Init()
		{
			SetStyle(System.Windows.Forms.ControlStyles.UserPaint, true);
			SetStyle(System.Windows.Forms.ControlStyles.AllPaintingInWmPaint, true);
			SetStyle(System.Windows.Forms.ControlStyles.DoubleBuffer, true);
			SetStyle(System.Windows.Forms.ControlStyles.ResizeRedraw, true);
			SetStyle(System.Windows.Forms.ControlStyles.SupportsTransparentBackColor, true);
			SetStyle(System.Windows.Forms.ControlStyles.ContainerControl, true);

			this.BackColor = Color.FromArgb(0, 0, 0, 0);
		}

		private Image _image;
		public virtual Image Image
		{
			get { return _image; }
			set
			{
				_image = value;
				SizingMode = SizingMode;
				Invalidate();
			}
		}

		public enum SizingModes
		{
			StretchImage,
			FixedSize
		}

		private SizingModes _sizingmode = SizingModes.FixedSize;
		public SizingModes SizingMode
		{
			get { return _sizingmode; }
			set
			{
				_sizingmode = value;
				if (SizingMode == SizingModes.FixedSize && (Image != null))
				{
					this.Size = new Size(Image.Width + 1, Image.Height + 1);
				}
			}
		}


		private Color _coloration = Color.Empty;
		public Color Coloration
		{
			get { return _coloration; }
			set { _coloration = value; }
		}


		protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
		{
			base.OnPaint(e);


			if ((Image != null) & this.Visible)
			{
				e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
				e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

				Image Tmp = (Image)Image.Clone();

				Point Point = new Point(0, 0);
				Size Size = new Size(Image.Width, Image.Height);

				if (SizingMode == SizingModes.StretchImage)
				{
					Size = new Size(this.Width - 1, this.Height - 1);
				}


				if (this.Enabled == false)
				{
					//Disabilitato
					Tmp = ImageTransform.GrayScale(Tmp);
					Tmp = ImageTransform.Brightness(Tmp, 0.11f);
					Tmp = ImageTransform.ChangeAlpha(Tmp, 150);
				}
				else
				{
					if (!Coloration.Equals(Color.Empty))
					{
						Tmp = ImageTransform.GrayScale(Tmp);
						Tmp = ImageTransform.Brightness(Tmp, -0.5f);
						Tmp = ImageTransform.Translate(Tmp, Coloration, 0);
					}

					if (RectangleToScreen(ClientRectangle).Contains(System.Windows.Forms.Cursor.Position))
					{
						if (MouseButtons == System.Windows.Forms.MouseButtons.Left)
						{
							//Contenuto con mouse premuto
							Tmp = ImageTransform.Brightness(Tmp, 0.15f);
							Point = new Point(1, 1);
						}
						else
						{
							//Contenuto con mouse non premuto
							Tmp = ImageTransform.Brightness(Tmp, 0.1f);
						}
					}
					else
					{
						//Non contenuto
						Tmp = ImageTransform.Brightness(Tmp, 0);
					}
				}

				if ((Tmp != null))
				{
					e.Graphics.DrawImage(Tmp, new Rectangle(Point, Size));
				}

			}

		}

		private void ImageButtonMouseEnter(object sender, System.EventArgs e)
		{
			Invalidate();
		}

		private void ImageButtonMouseLeave(object sender, System.EventArgs e)
		{
			Invalidate();
		}

		private void ImageButtonMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Invalidate();
		}

		private void ImageButtonMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Invalidate();
		}

		private void ImageButtonEnabledChanged(object sender, System.EventArgs e)
		{
			Invalidate();
		}

		protected override void OnControlAdded(System.Windows.Forms.ControlEventArgs e)
		{
			e.Control.MouseEnter += ImageButtonMouseEnter;
			e.Control.MouseLeave += ImageButtonMouseLeave;
			e.Control.MouseUp += ImageButtonMouseUp;
			e.Control.MouseDown += ImageButtonMouseDown;
		}

		protected override void OnControlRemoved(System.Windows.Forms.ControlEventArgs e)
		{
			e.Control.MouseEnter -= ImageButtonMouseEnter;
			e.Control.MouseLeave -= ImageButtonMouseLeave;
			e.Control.MouseUp -= ImageButtonMouseUp;
			e.Control.MouseDown -= ImageButtonMouseDown;
		}

	}



}
