using System.Diagnostics;
using EFCore.BulkExtensions;
using LasDb;
using LasSharp;
using Microsoft.EntityFrameworkCore;

static async void Las2Db(string lasFilePath)
{
    int index = 0;
    int pointNum = 800000;
    LasPointDb[] lasPointDbs = new LasPointDb[pointNum];
    using (DataContext dataContext = new DataContext())
    {
        // 测试写入，总共写入8千万个点，耗时约为2小时
        LasReader lasReader = new LasReader(lasFilePath);
        LasPoint lasPoint;
        Random random = new Random();
        while (lasReader.MoveToNextPoint())
        {
            lasPoint = lasReader.CurrentPoint;
            lasPointDbs[index % pointNum] = new LasPointDb()
            {
                Index = index,
                Intensity = lasPoint.Intensity,
                X = lasPoint.X,
                Y = lasPoint.Y,
                Z = lasPoint.Z,
                ScanLineIndex = random.Next(pointNum),
            };
            index++;
            if (index % pointNum == 0)
            {
                Trace.WriteLine(DateTime.Now);
                Trace.WriteLine(index);
                await dataContext.BulkInsertAsync(lasPointDbs);
                Trace.WriteLine(DateTime.Now);
            }
            if (index / pointNum == 100)
            {
                break;
            }
        }
        // 测试读取，索引列，675ms
        LasPointDb[] a = dataContext.LasPointDbs.Where(x => x.ScanLineIndex == 4644).AsNoTracking().ToArray();
        // 测试读取，非索引列，5s
        LasPointDb[] b = dataContext.LasPointDbs.Where(x => x.Intensity == 4644).AsNoTracking().ToArray();
    }
}
Las2Db(@"D:\desktop\a.las");


