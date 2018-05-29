/* Author: Matthew Baker
 * Email: Hackmattr@gmail.com
 * Program: LawnBot
 * File: MainActivity.cs
 * Date Created: 4/12/2018
 * Date Modified: 4/17/2018
 * 
 * Description: An android application with 4 buttons to control the direction of a lawn
 *              mowing robot. The application communicates with the Arduino of the robot
 *              through bluetooth. Application assumes that the bluetooth device is already 
 *              paired and on when app is first started. Will need to close the app to and 
 *              re-open to re=establish connection if switching to another app after its open.
 *              
 * ToDo:  - Modify the code to prevent app from crashing if the arduino is not on or if the 
 *          bluetooth module is not already paired.
 *        - Keep bluetooth connection if app is on pause
 *        - If two buttons are pressed and then one released, send command to continue in the
 *          direction that is still active.
 */


 // Libraries Used
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Bluetooth;
using System.Collections.Generic;
using Android.Views;
using System;


namespace LawnBot
{
    [Activity(Label = "LawnBot", MainLauncher = true)]
    public class MainActivity : Activity, View.IOnTouchListener
    {

        // Variables used for the blueooth connection
        private BluetoothAdapter bluetoothAdapter = BluetoothAdapter.DefaultAdapter;
        private BluetoothSocket socket;
        private System.IO.Stream output;
        private System.IO.Stream input;

        // Variables used to determine if the motors are already enabled
        private bool ForEnabled = false;
        private bool BackEnabled = false;
        private bool LeftEnabled = false;
        private bool RightEnabled = false;
        

        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);


            // Set buttons based on their IDs
            ImageButton ForwardButton = FindViewById<ImageButton>(Resource.Id.Forward);
            ImageButton BackwardButton = FindViewById<ImageButton>(Resource.Id.Backward);
            ImageButton LeftButton = FindViewById<ImageButton>(Resource.Id.Left);
            ImageButton RightButton = FindViewById<ImageButton>(Resource.Id.Right);

            // Set OnTouch Listeners for the buttons
            ForwardButton.SetOnTouchListener(this);
            BackwardButton.SetOnTouchListener(this);
            LeftButton.SetOnTouchListener(this);
            RightButton.SetOnTouchListener(this);

            bool connected = ConnectToDevice(EnableBTDevice());

        }

        public bool OnTouch(View v, MotionEvent e)
        {
            // Determine the button based on the ID
          switch (v.Id)
            {
                // Forward Button 
                case Resource.Id.Forward:
                    // If Forward Button Pressed and Motor is off
                    if ((e.Action == MotionEventActions.Down) & (ForEnabled == false ))
                    {
                        // Send F to the arduino
                        output.WriteByte((byte)'F');
                        Android.Util.Log.Debug("Forward Press", Convert.ToString((byte)'F') );
                        // ForEnabled set to true to show this code the motor is on
                        ForEnabled = true;

                    }
                    // When button is released
                    else if(e.Action == MotionEventActions.Up)
                    {
                        // Send f to the arduino
                        output.WriteByte((byte)'f');

                        // ForEnabled set to false to show this code the motor is off
                        ForEnabled = false;
                    }
                    break;
                
                // Backward Button
                case Resource.Id.Backward:
                    // If Backward button pressed and motor is off
                    if ((e.Action == MotionEventActions.Down) & (BackEnabled == false))
                    {
                        // Send B to the Arduino
                        output.WriteByte((byte)'B');

                        // BackEnabled set to true to show this code the motor is on
                        BackEnabled = true;
                    }
                    // When button is released
                    else if (e.Action == MotionEventActions.Up)
                    {
                        // Send b to the Arduino
                        output.WriteByte((byte)'b');

                        // BackEnabled set to false to show this code the motor is off
                        BackEnabled = false;
                    }
                    break;

                // Left Button 
                case Resource.Id.Left:
                    // If Left button pressed and motor is off
                    if ((e.Action == MotionEventActions.Down) &(LeftEnabled == false))
                    {
                        // Send L to the Arduino
                        output.WriteByte((byte)'L');

                        // LeftEnabled set to true to show this code the motor is on
                        LeftEnabled = true;
                    }
                    // When button is released
                    else if (e.Action == MotionEventActions.Up)
                    {
                        // Send l to Arduino
                        output.WriteByte((byte)'l');

                        // LeftEnabled set to false to show this code the motor is off
                        LeftEnabled = false;
                    }
                    break;

                // Right Button 
                case Resource.Id.Right:
                    // Right button pressed and motor is off
                    if ((e.Action == MotionEventActions.Down) & (RightEnabled == false))
                    {
                        // Send R to the Arduino
                        output.WriteByte((byte)'R');

                        // RightEnabled set to true to show this code the motor is on
                        RightEnabled = true;
                    }
                    // When Button Released
                    else if (e.Action == MotionEventActions.Up)
                    {
                        // Send r to Arduino
                        output.WriteByte((byte)'r');

                        //RightEnabled set to false to show this code the motor is off
                        RightEnabled = false;
                    }
                    break;

                default: break;
            }

            return true;
        }


        private bool EnableBTDevice()
        {
            // Variable returned
            bool result = true;

            // If the device does not have a bluetooth adapter, return false
            if (bluetoothAdapter == null)
            {
                Toast.MakeText(this, "Device does not support Bluetooth", ToastLength.Short).Show();
                result = false;
            }

            // If the device does not have bluetooth enabled, use system popup to alert user to turn it on.
            else if (!bluetoothAdapter.IsEnabled)
            {
                Intent enableAdapter = new Intent(BluetoothAdapter.ActionRequestEnable);
                StartActivityForResult(enableAdapter, 0);
                result = true;
            }
            return result;
        }

        private bool ConnectToDevice(bool connectionResult)
        {
            // Variable Return
            bool result = false;

            // Check if the EnableBTDevice function returned true. 
            if (connectionResult == true)
            {
                // Get all devices that the device has bonded to in the past.
                ICollection<BluetoothDevice> bondedDevice = bluetoothAdapter.BondedDevices;
                if (bondedDevice != null)
                {
                    // If there is at least one device, continue
                    if (bondedDevice.Count >= 1)
                    {
                        // foreach loop to go through each bonded device
                        foreach (BluetoothDevice device in bondedDevice)
                        {
                            // If the device name is equal to the HC05 adapter for the Arduino, create a connection
                            if (device.Name == "GD1")
                            {
                                socket = device.CreateInsecureRfcommSocketToServiceRecord(Java.Util.UUID.FromString("00001101-0000-1000-8000-00805f9b34fb"));
                                socket.Connect();

                                // assign the input and output streams
                                output = socket.OutputStream;
                                input = socket.InputStream;

                                // Exit function with result true
                                result = true;
                                return result;

                            }
                        }
                    }
                }
            }
            return result;
        }
    }
}

