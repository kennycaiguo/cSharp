# Csharp

c#学习代码，包含c#操作常用数据库的代码
压缩文件的解压密码：name+year

# c# 中非常有用的日期操作：
<h3>
 MessageBox.Show(DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd "));//获取昨天的日期
 MessageBox.Show(DateTime.Today.AddDays(1).ToString("yyyy-MM-dd "));//获取明天的日期
 MessageBox.Show(DateTime.Today.AddYears(-1).ToString("yyyy-MM-dd "));//获取去年今天的日期
 MessageBox.Show(DateTime.Today.AddYears(1).ToString("yyyy-MM-dd HH:mm:ss"));//获取明年今天天的日期
 MessageBox.Show(DateTime.Today.AddMonths(-1).ToString("yyyy-MM-dd HH:mm:ss"));//获取上个月的今天的日期
 MessageBox.Show(DateTime.Today.AddMonths(1).ToString("yyyy-MM-dd HH:mm:ss"));//获取下个月的今天的日期
 MessageBox.Show(DateTime.Today.AddMonths(1).DayOfWeek.ToString());//获取下个月的今天是星期几
 MessageBox.Show(DateTime.Today.AddMonths(-1).DayOfWeek.ToString());//获取上个月的今天是星期几
 MessageBox.Show(DateTime.Today.AddYears(-1).DayOfWeek.ToString());//获取去年今天是星期几
 MessageBox.Show(DateTime.Today.AddYears(-1).DayOfWeek.ToString());//获取明年今天是星期几
 MessageBox.Show($"现在时间是{DateTime.Now.Date.ToLongDateString()}");//长日期格式
 MessageBox.Show($"现在时间是{DateTime.Now.Date.ToShortDateString()}");//短日期格式
 DateTime.Now.Month.ToString();      获取月份   // 6
 DateTime.Now.Day.ToString();     获取几号  //22
 DateTime.Now.DayOfWeek.ToString(); 获取星期   // Monday
 DateTime.Now.Hour.ToString();          获取小时    
 DateTime.Now.Minute.ToString();     获取分钟    
 DateTime.Now.Second.ToString();     获取秒数   
 MessageBox.Show(DateTime.Parse("2018-06-23").DayOfWeek.ToString()); //解析一个日期并且获得那天是星期几 
</h3>
