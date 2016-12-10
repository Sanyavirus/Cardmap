# README #

### What HMI protocol can do ###

* 1) send registration
* 2) receive registration results
#
* 3) ask for IOT device list
* 4) receive IOT device list
* 5) receive IOT updates 
* 6) send IOT control via TEXT service
* 7) send IOT control via IOT value
* 8) run scenario
# 
* 9) ask for existing SCENARIOS
* 10) receive existing SCENARIOS
* 11) add/remove SCENARIOS
# 
* 12) ask for existing TEXT bindings
* 13) receive existing TEXT bindings
* 14) add/remove TEXT bindings
# 
* 15) ask for timetable from CRON
* 16) receice existing timetables from CRON
* 17) add/remove timetable 
# 
* 18) ask for triggers
* 19) receive existing triggers
* 20) add/remove triggers
#
### Protocol realization ###
#### Auth ####

```
#!xml

<header service="db" direction="request" command="authorize">
<body>
	<auth>
		<login>login</login>
		<password>password</password>
	</auth>
</body>

<header service="db" direction="response" command="authorize">
<body>
fail/success
</body>
```

#### IOT ####
```
#!xml

<header service="iot" direction="request" command="devicelist">
<body>
</body>

<header service="iot" direction="request" command="textcontrol">
<body>
enable light in room
</body>

<header service="iot" direction="request" command="control">
<body>
	<devices>
		<device name="name3" />
			<value name="name5" value="on" />
		</device>	
	</devices>
</body>

<header service="iot" direction="request" command="scenario">
<body>
scenario_id
</body>

<header service="iot" direction="response" command="devicelist">
<body>
	<devices>
		<device name="name" status="on">
			<value name="name1" valtype="indication" type="uint" minvalue="0" maxvalue="100" value="10" />
			<value name="name2" valtype="control" value="on" type="bool" />
		</device>
		<device name="name2" status="on"> 
			<value name="name3" valtype="indication" type="uint" minvalue="0" maxvalue="20" value="10" />
			<value name="name4" valtype="indication" type="bool" value="on" />
		</device>
		<device name="name3" status="off" />
			<value name="name5" valtype="control" type="bool" value="off" />
		</device>
	</devices>
</body>

<header service="iot" direction="response" command="updates">
<body>
	<devices>
		<device name="name" status="on">
			<value name="name1" value="10" />
			<value name="name2" value="on" />
		</device>
		<device name="name2" status="on"> 
			<value name="name3" value="10" />
			<value name="name4" value="on" />
		</device>
		<device name="name3" status="off" />
			<value name="name5" value="off" />
		</device>
	</devices>
</body>

```
#### Scenarios ####

```
#!xml

<header service="scenarios" direction="request" command="get">
<body>
</body>

<header service="scenarios" direction="request" command="add">
<body>
	<scenarios>
		<scenario name="name">
			<command position="1">text</command>
			<command position="2">text</command>
			<command position="3">text</command>
			<command position="4">text</command>
		</scenario>
		<scenario name="name2">
			<command position="1">text</command>
			<command position="2">text</command>
			<command position="3">text</command>
			<command position="4">text</command>
		</scenario>
	</scenarios>
</body>

<header service="scenarios" direction="request" command="remove">
<body>
	<scenarios>
		<scenario name="name" />
		<scenario name="name2" />
	</scenarios>
</body>

<header service="scenarios" direction="response" command="get">
<body>
	<scenarios>
		<scenario name="name">
			<command position="1">text</command>
			<command position="2">text</command>
			<command position="3">text</command>
			<command position="4">text</command>
		</scenario>
		<scenario name="name2">
			<command position="1">text</command>
			<command position="2">text</command>
			<command position="3">text</command>
			<command position="4">text</command>
		</scenario>
	</scenarios>
</body>
```
#### TextBinding ####

```
#!xml

<header service="textbinding" direction="request" command="get">
<body>
</body>

<header service="textbinding" direction="request" command="add">
<body>

	<valuebindings>
		<devicevalue name="name">
			<word>text</word>
			<word>text</word>
			<word>text</word>
		</devicevalue>
		<devicevalue name="name2">
			<word>text</word>
			<word>text</word>
			<word>text</word>
		</devicevalue>
	</valuebindings>
</body>

<header service="textbinding" direction="request" command="remove">
<body>
	<textbindings>
		<devicevalue name="name" />
		<devicevalue name="name2" />
	</textbindings>
</body>

<header service="textbinding" direction="response" command="get">
<body>
	<textbindings>
		<devicevalue name="name">
			<word>text</word>
			<word>text</word>
			<word>text</word>
		</devicevalue>
		<devicevalue name="name2">
			<word>text</word>
			<word>text</word>
			<word>text</word>
		</devicevalue>
	</textbindings>
</body>
```

#
### Services that can be accessed ###
* HMI -> IOT Service
* HMI -> TextProcessing Service
* HMI -> DB Service
* HMI -> Scenarios Service