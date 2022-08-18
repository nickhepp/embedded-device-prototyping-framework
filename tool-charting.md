# <img src='PC/HostApp/HostApp/Resources/charts.png' style="width:60px;"/> Charting Tool
Charts the flow of device data.

## TODO: Insert GIF

The charting Tool is a very powerful and flexible tool that offers a lot of functionality and at the same time requires little effort to set up. The charting Tool can be customized to plot multiple graphs and 1 or more plot lines on those graphs, and all of this can be setup with a simple expression string that describes the fields and intended layout of the data.

Let's look at the graph setup to show how simple it can be. As talked about during the commands video, commands can return sensor samples. Using the macro tool in loop mode, users can continually return a stream of samples that are continually charted on the graphs.  To setup the charting tool, users craft an expression string that tells the host application the number of data series lines involved and the graphs to plot those lines on.  Here is an example from the EDPF demo kit, which is a controller gamepad project.  The typical sample from the EDPF demo kit looks like this:
```na
kit:510,501,0,0,0,0,0
```
And an expression string to chart these values could look like this:
```na
kit:{x|chart1},{y|chart1},{d|chart2},{pb1|chart3},{pb1|chart3},{pb2|chart3},{pb3|chart3},{pb4|chart3}
```

And with these put together the EDPF can create graphs like this:
<insert graph>


Now let’s look at the sample, the EDPF demo kit formatting string, and the general form of the formatting string:
```na
kit:510,501,0,0,0,0,0
```
```na
kit:{x|chart1},{y|chart1},{d|chart2},{pb1|chart3},{pb1|chart3},{pb2|chart3},{pb3|chart3},{pb4|chart3}
```

```na
<start-identifier>:<line-and-chart-1>[...,<line-and-chart-n>]
```
At the front is the “kit” token followed by a colon.  The charting tool relies on a unique start identifier that identifies the start of the following data that should be charted.  And in this case the start identifier is “kit”.  After the start identifier and the colon comes, comes a comma separated array of line and chart tuples.  Users can specify practically any number of lines, or data series, to chart on practically any number of charts.  The lines can be on their own graph, or multiple lines can share a graph. Here is the syntax to identify lines and charts --  the general form looks like this:
```na
{<line-name>|<chart-name>}
```

So first is the open curly, followed by the name of the line, then the pipe symbol, followed by the chart name.  So for one named line and one named chart the part of the formatting string would look like this:
```na
{x|chart1}
```
So the “x” line is on “chart1”.  The number of lines can be configured to be any size, but must match the number of samples coming out of the actual device output.  Let’s look at the 


distinguish that this line of output comes from the EDPF kit sensor reading command and is used 

