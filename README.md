# Android-Controlled-Lawn-Mower
<h2> Introduction </h2>
<p>As someone that loves to tinker, I have always wanted to build a large robot. I could never decide what I wanted it to do though. When I noticed my backyard becoming more of a jungle after a major rainstorm, I decided to build a lawn mowing robot that I can control from my Android device.</p> 
<b>ADD VIDEO OF IT RUNNING</b>
<h2>Design</h2>
<p>As with most things I build, this robot was built mostly from recycled materials. The chassis was built from scrap metal and a shopping cart style wheel. The motors, drive wheels, and sprockets all came from electric Razor scooters that were found at a local thrift shop. The cutting head was turned from a scrap piece of cast aluminum. All of the other components were bought new.</p>
<p>The only part of this project I designed ahead of time was the electronics and how I would go about organizing the code for both the Android Application and the Arduino. A schematic of the electronics is shown below. </p> 
<img src = "https://github.com/mbaker92/Android-Controlled-Lawn-Mower/blob/master/Pictures/LawnMower1Updated_schem.jpg?raw=true"> 
<p>The actual wiring for the robot was modified so that the blade motor would always be on. I left the relay in the schematic in case someone wants to use it for their build. The schematic also does not show a main power switch that is needed.</p>
<h2>Software/IDE</h2>
<ul>
  <li>Visual Studio 2017 - Xamarin</li>
  <li>Arduino IDE</li>
</ul>
<h2>Materials/Tools</h2>
<img src="https://github.com/mbaker92/Android-Controlled-Lawn-Mower/blob/master/Pictures/IMG_20180413_184312.jpg?raw=true">
<h3>Materials</h3>
<ul>
  <li>Arduino Uno R3 </li>
  <li>50A Dual Motor Controller</li>
  <li>HC-05 Bluetooth Module</li>
  <li>2 100W Razor Scooter Motors</li>
  <li>1 250W Razor Scooter Motor</li>
  <li>1 1k&#8486 Resistor</li>
  <li>1 2k&#8486 Resistor</li>
  <li>2 12v 5Ah SLA Batteries</li>
  <li>1 Toggle Switch</li>
  <li>Misc Wiring</li>
  <li>Chassis Material (Steel) and Misc Bolts</li>
  <li>#25 Chain</li>
  <li>Terminal Strip</li>
  <li>Plastic Ammo Box</li>
  <li>2 Razor Scooter Wheels/Sprockets</li>
  <li>Shopping Cart Wheel</li>
  <li>Scrap Aluminum</li>
  <li>Spray Paint</li>
  <li>Weed Wacker Trimming Line</li>
  <li>Breadboard</li>
  <li>Heat Shrink Tubing</li>
</ul>
<h3>Tools</h3>
<ul>
  <li>Mig Welder (With Safety Gear)</li>
  <li>Angle Grinder (Cutting and Grinding Wheels)</li>
  <li>Drill Press (Metal Drill Bits)</li>
  <li>Mini Metal Lathe</li>
  <li>Clamps</li>
  <li>Wire Cutters and Strippers</li>
  <li>Soldering Iron and Heat Gun</li>
  <li>Screw Drivers and Socket Set</li>
  <li>3mm Tap</li>
</ul>
<h2>Cutting Head</h2>
<p>The cutting head is powered by a Razor scooter motor that had the sprocket removed. The cutting head itself is a turned piece of aluminum that has a thick weed wacker line passing through the end. 
<h2>Chassis</h2>
<h2>Electronics</h2>
<h2>Android Code</h2>
<h2>Arduino Code</h2>
<h2>Test Videos</h2>
<p>This video is the first test video where the LawnBot is moving based on the serial communication from the Android Application. The commands being sent for Forward and Backwards are opposite of actual movement so I needed to change it in the code. Click on Picture to see video on Youtube.</p>

[![Test 1](https://img.youtube.com/vi/AuVcFB6_y2I/0.jpg)](https://www.youtube.com/watch?v=AuVcFB6_y2I "Test 1" )

<h2>Conclusion</h2>
<img src="
