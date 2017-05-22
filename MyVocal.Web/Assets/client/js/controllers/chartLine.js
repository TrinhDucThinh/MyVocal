var lineChartData = {
    labels: ["Lần 1", "Lần 2", "Lần 3", "Lần 4", "Lần 5", "Lần 6", "Lần 7"],
    datasets: [{
        fillColor: "rgba(220,220,220,0)",
        strokeColor: "rgba(220,180,0,1)",
        pointColor: "rgba(220,180,0,1)",
        data: [0, 10, 20, 20, 12, 10, 10]
    }]
}

Chart.defaults.global.animationSteps = 50;
Chart.defaults.global.tooltipYPadding = 16;
Chart.defaults.global.tooltipCornerRadius = 0;
Chart.defaults.global.tooltipTitleFontStyle = "normal";
Chart.defaults.global.tooltipFillColor = "rgba(0,160,0,0.8)";
Chart.defaults.global.animationEasing = "easeOutBounce";
Chart.defaults.global.responsive = true;
Chart.defaults.global.scaleLineColor = "black";
Chart.defaults.global.scaleFontSize = 16;

var ctx = document.getElementById("chartLine").getContext("2d");
var LineChartDemo = new Chart(ctx).Line(lineChartData, {
    pointDotRadius: 4,
    bezierCurve: false,
    scaleShowVerticalLines: false,
    scaleGridLineColor: "black"
});

//chart pie

var pieData = [
{
    value: 25,
    label: 'Java',
    color: '#811BD6'
},
{
    value: 10,
    label: 'Scala',
    color: '#9CBABA'
},
{
    value: 30,
    label: 'PHP',
    color: '#D18177'
},
{
    value: 35,
    label: 'HTML',
    color: '#6AE128'
}
];

var context = document.getElementById('chartPie').getContext('2d');
var skillsChart = new Chart(context).Pie(pieData);