using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel.Design;
using JocysCom.ClassLibrary.Processes;
using System.Runtime.InteropServices;

namespace JocysCom.ClassLibrary.Controls
{
	[Docking(DockingBehavior.Ask)]
	public partial class ScrollableUserControl : UserControl
	{
		#region Properties

		private bool _IsContainerMouseDown;
		private Point _LastMousePosition;
		private bool _IsGripMouseDown;
		private bool _DisableScrolling;

		#endregion

		#region Designer Controls

		[Category("Appearance")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public Panel ContainerPanel
		{
			get { return _ContainerPanel; }
		}

		[DefaultValue(16), Category("Appearance")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public int BarWidth
		{
			get { return _BarPanel.Width; }
			set
			{
				_BarPanel.Width = value;
				UpdateOnSizeChange();
			}
		}

		[DefaultValue(typeof(Color), "ControlDark"), Category("Appearance")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public Color GripColor
		{
			get { return _GripPanel.BackColor; }
			set { _GripPanel.BackColor = value; }
		}

		[DefaultValue(typeof(Color), "ControlLight"), Category("Appearance")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public Color BarColor
		{
			get { return _BarPanel.BackColor; }
			set { _BarPanel.BackColor = value; }
		}

		[Category("Appearance")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Panel BarPanel
		{
			get { return _BarPanel; }
		}

		[Category("Appearance")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Panel GripPanel
		{
			get { return _GripPanel; }
		}

		#endregion

		#region Native Methods

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern bool SystemParametersInfo(int uAction, int uParam, ref int lpvParam, int flags);

		const int SPI_GETWHEELSCROLLLINES = 0x0068;
		const int DEFAULT_LINES_TO_SCROLL = 0x03;
		const int WHEEL_DELTA = 120;

		#endregion

		#region Mouse and Keyboard Hook

		MouseHook mouseHook;
		KeyboardHook keyboardHook;

		public int GetLinesToScrollUserSetting()
		{
			int userSetting = 0;
			// Retrieve the lines-to-scroll user setting. 
			bool success = SystemParametersInfo(SPI_GETWHEELSCROLLLINES, 0, ref userSetting, 0);
			// Use a default value if the API failed.
			if (!success)
			{
				userSetting = DEFAULT_LINES_TO_SCROLL;
			}
			return userSetting;
		}

		public ScrollableUserControl()
		{
			InitializeComponent();
			mouseHook = new MouseHook();
			mouseHook.OnMouseDown += mouseHook_OnMouseDown;
			mouseHook.OnMouseMove += mouseHook_OnMouseMove;
			mouseHook.OnMouseUp += mouseHook_OnMouseUp;
			mouseHook.OnMouseWheel += mouseHook_OnMouseWheel;
			mouseHook.Start();
			keyboardHook = new KeyboardHook();
			keyboardHook.KeyDown += keyboardHook_KeyDown;
			keyboardHook.Start();
		}

		void keyboardHook_KeyDown(object sender, KeyEventArgs e)
		{
			//var control = GetControlUnderMouse(System.Windows.Forms.Control.MousePosition);
			// If control is activated and visible on form then...
			var tlc = this.TopLevelControl;
			if (tlc != null && tlc.ContainsFocus && ControlsHelper.IsControlVisibleToUser(this))
			{
				if (e.KeyCode == Keys.PageDown) MoveContainer(-_ContainerPanel.Height);
				else if (e.KeyCode == Keys.PageUp) MoveContainer(_ContainerPanel.Height);
				else if (e.KeyCode == Keys.Up) MoveContainer(WHEEL_DELTA / DEFAULT_LINES_TO_SCROLL);
				else if (e.KeyCode == Keys.Down) MoveContainer(-WHEEL_DELTA / DEFAULT_LINES_TO_SCROLL);
			}
		}

		void mouseHook_OnMouseWheel(object sender, MouseEventArgs e)
		{
			var control = GetControlUnderMouse(e.Location);
			// If the mouse inside scrollable panel.
			if (control != null)
			{
				var linesToScroll = e.Delta / WHEEL_DELTA;
				MoveContainer(e.Delta);
			}
		}

		Control GetControlUnderMouse(Point p)
		{
			var hwnd = JocysCom.ClassLibrary.Win32.NativeMethods.WindowFromPoint(p);
			var control = Control.FromChildHandle(hwnd);
			Control panel = null;
			while (true)
			{
				if (control == null) break;
				if (control == _ContainerPanel || control == _GripPanel || control == this)
				{
					panel = control;
					break;
				}
				control = control.Parent;
			}
			return control;
		}

		#endregion

		#region Size Control

		object mouseActionLock = new object();

		void mouseHook_OnMouseMove(object sender, MouseEventArgs e)
		{
			lock (mouseActionLock)
			{
				var control = GetControlUnderMouse(e.Location);
				// If the mouse enters the container panel.
				if (control == _ContainerPanel)
				{
					if (Cursor == System.Windows.Forms.Cursors.Default)
					{
						// Change the cursor so the user knows they can scroll.
						//Cursor = System.Windows.Forms.Cursors.Hand;
					}
				}
				// If the mouse leaves the container panel.
				else if (control == this)
				{
					// Restore the cursor to default.
					//Cursor = System.Windows.Forms.Cursors.Default;
				}
				if (_IsGripMouseDown || _IsContainerMouseDown)
				{
					// Get the current mouse position.
					var currentMousePosition = GetMousePosition();
					var delta = currentMousePosition.Y - _LastMousePosition.Y;
					// If the mouse is down, aka we're scrolling with the bar then...
					if (_IsGripMouseDown)
					{
						MoveBar(delta);
					}
					else if (_IsContainerMouseDown)
					{
						MoveContainer(delta);
					}
					// Record the current mouse as the last mouse.
					_LastMousePosition = currentMousePosition;
				}
			}
		}

		void MoveBar(int delta)
		{
			// If it has not moved then return
			if (delta == 0) return;
			// Calculate new position.
			var gripNewTop = _GripPanel.Top + delta;
			// If it would be going over the top of the scroll bar then...
			if (gripNewTop < _BarPanel.Top)
			{
				// Set it to the top.
				gripNewTop = _BarPanel.Top;
			}
			// If it would be going past the bottom of the scroll bar then...
			else if (gripNewTop > (_BarPanel.Height + _BarPanel.Top - _GripPanel.Height))
			{
				// Set it to the bottom.
				gripNewTop = _BarPanel.Height + _BarPanel.Top - _GripPanel.Height;
			}
			// If position changed then...
			if (_GripPanel.Top != gripNewTop)
			{
				// Move it.
				_GripPanel.Top = gripNewTop;
			}
			// Update container panel.
			UpdateContainerPanel();
		}

		public void MoveContainerToTop()
		{
			// If position is not at the top then...
			if (_ContainerPanel.Top != 0)
			{
				// Move it.
				_ContainerPanel.Top = 0;
			}
			// Te-calculate the scroll bar based off our new main position.
			UpdateGripPanel();
		}

		public void MoveContainer(int delta)
		{
			// Calculate new position.
			var containerNewTop = _ContainerPanel.Top + delta;
			// If it would be going over the top of the panel then...
			if (containerNewTop > 0)
			{
				// Set it to the top.
				containerNewTop = 0;
			}
			// If it would be going past the bottom of the panel then...
			else if (containerNewTop < (this.Height - _ContainerPanel.Height))
			{
				// Set it to the bottom.
				containerNewTop = this.Height - _ContainerPanel.Height;
			}
			// If position changed then...
			if (_ContainerPanel.Top != containerNewTop)
			{
				// Move it.
				_ContainerPanel.Top = containerNewTop;
			}
			// Te-calculate the scroll bar based off our new main position.
			UpdateGripPanel();
		}

		void mouseHook_OnMouseUp(object sender, MouseEventArgs e)
		{
			lock (mouseActionLock)
			{
				var control = GetControlUnderMouse(e.Location);
				if (_IsGripMouseDown)
				{
					//finished scrolling
					_IsGripMouseDown = false;
				}
				if (_IsContainerMouseDown)
				{
					//finished scrolling
					_IsContainerMouseDown = false;
				}
			}
		}

		void mouseHook_OnMouseDown(object sender, MouseEventArgs e)
		{
			lock (mouseActionLock)
			{
				var control = GetControlUnderMouse(e.Location);
				if (control == _GripPanel)
				{
					// if the mouse is not already pressed and scrolling is not disabled
					if ((!_IsGripMouseDown) && (!_DisableScrolling))
					{
						//set the mouse to down (Scroll Bars)
						_IsGripMouseDown = true;
						//Record the position of the mouse down
						_LastMousePosition = GetMousePosition();
					}
				}
				else if (control == _ContainerPanel)
				{
					// if the mouse is not already pressed and scrolling is not disabled
					if ((!_IsContainerMouseDown) && (!_DisableScrolling))
					{
						//set the mouse to down (Main panel)
						_IsContainerMouseDown = true;
						//Record the position of the mouse down
						_LastMousePosition = GetMousePosition();
					}
				}
			}
		}

		/// <summary>
		/// Returns the position of the mouse within the screen.
		/// </summary>
		private Point GetMousePosition()
		{
			return (this.PointToScreen(System.Windows.Forms.Control.MousePosition));
		}


		void UpdateScrollGripSize()
		{
			// Fix scroll position and size.
			_BarPanel.Top = 0;
			_BarPanel.Left = this.Width - _BarPanel.Width;
			_BarPanel.Height = this.Height;
			// Fix scroll grip position.
			_GripPanel.Left = _BarPanel.Left;
			// Update scroll grip size.
			_GripPanel.Width = _BarPanel.Width;
			var heightPercent = _ContainerPanel.Height < this.Height
			? 1.0m
			: (decimal)this.Height / (decimal)_ContainerPanel.Height;
			_GripPanel.Height = Math.Max(16, (int)(_BarPanel.Height * heightPercent));
			// If the panel created to scroll is too small, turn off scrolling and disable the scroll bars.
			_DisableScrolling = _ContainerPanel.Height < this.Height;
			_GripPanel.Enabled = !_DisableScrolling;
			_BarPanel.Enabled = !_DisableScrolling;
		}

		/// <summary>
		/// Calculates the position of the scroll bar based off the position of the main panel
		/// </summary>
		private void UpdateGripPanel()
		{
			UpdateScrollGripSize();
			// Get the Y position currently at the top of the panel, being looked at
			var containerTop = (decimal)Math.Abs(_ContainerPanel.Top);
			// Find out what percent it is through the document, getting rid of the height of the panel so we go from 0-100
			var percent = _ContainerPanel.Height <= this.Height
				? 0.0m
				: (containerTop / (decimal)(_ContainerPanel.Height - this.Height));
			// Get the maximum movement area up and down for the Scroll panel.
			var gripMovementArea = (decimal)(_BarPanel.Height - _GripPanel.Height);
			//Translate the percentage looked at to the percentage along the scroll bar
			_GripPanel.Top = (int)(gripMovementArea * percent) + _BarPanel.Top;
		}

		/// <summary>
		/// Calculates the position of the main panel based off the position of the scroll bar.
		/// </summary>
		private void UpdateContainerPanel()
		{
			UpdateScrollGripSize();
			// Get the maximum movement area up and down for the Scroll panel.
			var gripMovementArea = (decimal)(_BarPanel.Height - _GripPanel.Height);
			//Find out how along the scroll bar we currently are
			var percent = gripMovementArea == 0
				? 1.0m
				: (decimal)(_GripPanel.Top - _BarPanel.Top) / gripMovementArea;
			//Get the maximum movement area for the scroll panel
			var ScrollArea = (decimal)(_ContainerPanel.Height - this.Height);
			//Translate the percentage along the scroll bar to the percentage along the scroll panel
			_ContainerPanel.Top = (int)(ScrollArea * percent) * -1;
		}

		void UpdateOnSizeChange()
		{
			UpdateGripPanel();
			UpdateContainerPanel();
			// Check free space under control.
			_ContainerPanel.Left = 0;
			_ContainerPanel.Width = this.Width - _BarPanel.Width;
			if (_ContainerPanel.Top < 0)
			{
				var visibleHeight = _ContainerPanel.Height + _ContainerPanel.Top;
				var extraHeight = this.Height - visibleHeight;
				if (extraHeight > 0)
				{
					_ContainerPanel.Top = _ContainerPanel.Top + extraHeight;
				}
			}
			_ContainerPanel.MinimumSize = new Size(this.Size.Width - BarPanel.Width, this.Height);
		}

		private void ScrollableUserControl_SizeChanged(object sender, EventArgs e)
		{
			UpdateOnSizeChange();
		}

		#endregion

		#region ReadCheck

		object checkReadLock = new object();

		bool _IsContainerBottomSeen;
		public bool IsContainerBottomSeen
		{
			get { return _IsContainerBottomSeen; }
			set
			{
				_IsContainerBottomSeen = value;
				CheckRead();
			}
		}

		void CheckRead()
		{
			lock (checkReadLock)
			{
				var containerBottom = _ContainerPanel.Height + ContainerPanel.Top;
				// If container is inside visible area then...
				if (containerBottom >= 0 && containerBottom <= this.Height)
				{
					if (!_IsContainerBottomSeen)
					{
						MarkAsSeenTimer.Stop();
						MarkAsSeenTimer.Start();
					}
				}
			}
		}

		public event EventHandler<EventArgs> ContainerBottomSeen;

		static System.Timers.Timer _MarkAsSeenTimer;
		static object MarkAsSeenTimerLock = new object();

		System.Timers.Timer MarkAsSeenTimer
		{
			get
			{
				lock (MarkAsSeenTimerLock)
				{
					if (_MarkAsSeenTimer == null)
					{
						_MarkAsSeenTimer = new System.Timers.Timer();
						_MarkAsSeenTimer.AutoReset = false;
						_MarkAsSeenTimer.Interval = 520;
						_MarkAsSeenTimer.SynchronizingObject = this;
						_MarkAsSeenTimer.Elapsed += markAsSeenTimer_Elapsed;
					}
					return _MarkAsSeenTimer;
				}
			}
		}

		void markAsSeenTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			lock (MarkAsSeenTimerLock)
			{
				var tlc = this.TopLevelControl;
				// If control is still visible to the user then...
				if (tlc != null && tlc.ContainsFocus && ControlsHelper.IsControlVisibleToUser(this))
				{
					_IsContainerBottomSeen = true;
					var ev = ContainerBottomSeen;
					if (ev != null) ContainerBottomSeen(this, new EventArgs());
				}
			}
		}

		#endregion

		private void _ContainerPanel_Move(object sender, EventArgs e)
		{
			CheckRead();
		}

		private void _ContainerPanel_Resize(object sender, EventArgs e)
		{
			CheckRead();
		}

		private void _ContainerPanel_Paint(object sender, PaintEventArgs e)
		{
			CheckRead();
		}

		private void _ContainerPanel_VisibleChanged(object sender, EventArgs e)
		{
			CheckRead();
		}
	}

}
