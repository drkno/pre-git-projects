const request = require('request');

request({
    url: 'https://www.trustpower.co.nz/general-content/ajax-content/graphs/internetgraphpage?type=Internet&addressLine1=<censored>&consumerMeter=<censored>,<censored>&units=kwh',
    method: 'GET',
    headers: {
        'User-Agent': 'Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:52.0) Gecko/20100101 Firefox/52.0',
        'Accept': 'text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8',
        'Accept-Language': 'en-GB,en;q=0.5',
        'Referer': 'https://www.trustpower.co.nz/accounts/overview?st=Internet&ac=<censored>',
        'X-Requested-With': 'XMLHttpRequest'
    }
}, (error, response, data) => {
    if (error) {
        throw new Error(error);
    }
        
    const monthlyRegex = /"monthly": ([0-9.]+)/g;
    const monthlyData = parseFloat(monthlyRegex.exec(data)[1]);

    const bankedRegex = /"banked": ([0-9.]+)/g;
    const bankedData = parseFloat(bankedRegex.exec(data)[1]);

    const topupsRegex = /"topups": ([0-9.]+)/g;
    const topupsData = parseFloat(topupsRegex.exec(data)[1]);

    const usedRegex = /"used": ([0-9.]+)/g;
    const usedData = parseFloat(usedRegex.exec(data)[1]);

    const remainingRegex = /"remaining": ([0-9.]+)/g;
    const remainingData = parseFloat(remainingRegex.exec(data)[1]);

    const remainingDaysRegex = /Days remaining:[^0-9]+([0-9]+)/g;
    const remainingDaysData = parseInt(Array.from(remainingDaysRegex.exec(data))[1]);

    const averageDailyUsageRegex = /Average daily usage:[^0-9.]+([0-9.]+)[^l]+ll>([A-Z]+)/g;
    const averageDailyUsageExec = averageDailyUsageRegex.exec(data);
    const averageDailyUsageData = parseFloat(averageDailyUsageExec[1]);
    const averageDailyUsageUnit = averageDailyUsageExec[2];

    const avalibleDailyUsageRegex = /Available daily till month end:[^0-9.]+([0-9.]+)[^l]+ll>([A-Z]+)/g;
    const avalibleDailyUsageExec = avalibleDailyUsageRegex.exec(data);
    const avalibleDailyUsageData = parseFloat(avalibleDailyUsageExec[1]);
    const avalibleDailyUsageUnit = avalibleDailyUsageExec[2];

    const remainingPreciseRegex = /donut_center_main[^0-9]+([0-9.]+)[^>]+>([A-Z]+)/g;
    const remainingPreciseExec = remainingPreciseRegex.exec(data);
    const remainingPreciseData = parseFloat(remainingPreciseExec[1]);
    const remainingPreciseUnit = remainingPreciseExec[2];

    const usedPreciseRegex = /Data remaining[^0-9.]+([0-9.]+)[^A-Z]+([A-Z]+)/g;
    const usedPreciseExec = usedPreciseRegex.exec(data);
    const usedPreciseData = parseFloat(usedPreciseExec[1]);
    const usedPreciseUnit = usedPreciseExec[2];

    const projectedDaysRegex = /At this rate you&#39;ll run out in ([0-9]+) days/g;
    const projectedDaysDataExec = projectedDaysRegex.exec(data);
    let projectedDaysData;
    if (projectedDaysDataExec) {
        projectedDaysData = parseInt(Array.from(projectedDaysRegex.exec(data))[1]);
    }
    else {
        projectedDaysData = Math.floor(remainingData / (averageDailyUsageData / (avalibleDailyUsageUnit === 'GB' ? 1 : 1000)));
    }
    
    const outData = {
        chart: {
            monthly: monthlyData,
            banked: bankedData,
            topup: topupsData,
            remaining: remainingData,
            used: usedData
        },
        table: {
            used: {
                value: usedPreciseData,
                unit: usedPreciseUnit
            },
            remaining: {
                value: remainingPreciseData,
                unit: remainingPreciseUnit
            },
            avusage: {
                value: averageDailyUsageData,
                unit: averageDailyUsageUnit
            },
            avpday: {
                value: avalibleDailyUsageData,
                unit: avalibleDailyUsageUnit
            },
            daysrem: {
                value: remainingDaysData,
                unit: "day" + (remainingDaysData===1?'':'s')
            },
            daysproj: {
                value: projectedDaysData,
                unit: "day" + (projectedDaysData===1?'':'s')
            }
        }
    };
    console.log(JSON.stringify(outData,null,4));
});
