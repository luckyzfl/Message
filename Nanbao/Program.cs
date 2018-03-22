using qcloudsms_csharp;
using qcloudsms_csharp.httpclient;
using qcloudsms_csharp.json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Nanbao
{
    class Program
    {
        public static List<List<Course>> courselist = new List<List<Course>>();
        public static void ConsCL()
        {
            List<Course> c1 = new List<Course>();
            List<Course> c2 = new List<Course>();
            List<Course> c3 = new List<Course>();
            List<Course> c4 = new List<Course>();
            List<Course> c5 = new List<Course>();
            List<Course> c6 = new List<Course>();
            List<Course> c7 = new List<Course>();
            /*
             * FeilongZuo
             * 课程名，教室，起始周，结束周，起始节次，结束节次
            c1.Add(new Course("信息与网络安全", "A408", 10, 13, 2, 3));
            c1.Add(new Course("信息与网络安全", "B103", 3, 9, 2, 4));
            c1.Add(new Course("信息与网络安全", "第8微机室", 10, 13, 4, 4));
            c1.Add(new Course("数字媒体技术", "B阶201", 3, 10, 6, 8));
            c1.Add(new Course("数字媒体技术", "第3微机室", 3, 10, 9, 9));
            c1.Add(new Course("数字媒体技术", "第6微机室", 3, 10, 10, 10));
            c2.Add(new Course("计算机系统结构", "B阶203", 3, 16, 1, 4));
            c2.Add(new Course("电子电工实习", "未安排地点", 5, 9, 6, 9));
            c2.Add(new Course("大学生就业与创业指导", "A阶304", 5, 8, 11, 13));
            c3.Add(new Course("软件开发工具", "B阶303", 3, 9, 1, 3));
            c3.Add(new Course("软件开发工具", "第7微机室", 3, 8, 4, 4));
            c3.Add(new Course("软件开发工具", "第4微机室", 3, 8, 5, 5));
            c3.Add(new Course("技术经济与企业管理", "B阶104", 3, 16, 7, 9));
            c3.Add(new Course("软件工程", "A207", 1, 14, 11, 13));
            c4.Add(new Course("计算机网络", "A204", 1, 16, 11, 13));
            c5.Add(new Course("数字图像处理", "B阶201", 3, 16, 1, 3));
            c5.Add(new Course("人工智能导论", "B阶103", 3, 13, 6, 8));
            c5.Add(new Course("人工智能导论", "第9微机室", 12, 13, 9, 9));
            c5.Add(new Course("人工智能导论", "第10微机室", 12, 13, 10, 10));
            c5.Add(new Course("人工智能导论", "第9微机室", 12, 13, 11, 12));
            c6.Add(new Course("形势与政策", "A501", 8, 8, 1, 4));
            c6.Add(new Course("形势与政策", "A501", 10, 10, 1, 4));
            */
            c1.Add(new Course("化学基础试验(III)", "未安排教室", 2, 17, 1, 4));
            c1.Add(new Course("概率论与数理统计", "B303", 3, 15, 6, 8));
           
            c2.Add(new Course("物理化学(II)", "A212", 1, 16, 3, 5));
            c2.Add(new Course("马克思主义基本原理", "A310", 1, 11, 11, 13));

            
            c3.Add(new Course("概率论与数理统计", "A214", 11, 15, 1, 2));
            c3.Add(new Course("化工原理(上)", "A411", 2, 15, 3, 4));
            c3.Add(new Course("化工原理实验(上)", "未安排教室", 3, 13, 7, 7));
            c3.Add(new Course("羽毛球", "体育馆", 1, 16, 8, 9));

            c4.Add(new Course("化学基础试验(四)", "未安排教室", 2, 17, 6, 9));

            c5.Add(new Course("化工原理(上)", "A411", 1, 14, 3, 4));
            c5.Add(new Course("普通物理试验(I)", "未安排地点", 2, 10, 8, 10));
            c5.Add(new Course("普通物理试验(II)", "未安排地点", 11, 17, 8, 10));

            c6.Add(new Course("形势与政策", "A201", 12, 12, 6, 9));
            c6.Add(new Course("形势与政策", "A201", 14, 14, 6, 9));


            courselist.Add(c1);
            courselist.Add(c2);
            courselist.Add(c3);
            courselist.Add(c4);
            courselist.Add(c5);
            courselist.Add(c6);
            courselist.Add(c7);
        }
        public static string conscoursetext(int week,int day)
        {
            string coursetext = "";
            List<Course> validcourse = new List<Course>();
            for(int i=0;i<courselist[day-1].Count;i++)
            {
                if(courselist[day-1][i].sweek<=week&&courselist[day-1][i].eweek>=week)
                {
                    validcourse.Add(courselist[day - 1][i]);
                }
            }
            coursetext += "你今天有" + validcourse.Count + "节课  \n";
            for(int i=0;i<validcourse.Count;i++)
            {
                string xx = "";
                if(validcourse[i].sorder==validcourse[i].eorder)
                {
                    xx += "第" + validcourse[i].sorder + "节:";
                }
                else
                {
                    xx += "第" + validcourse[i].sorder +"--"+validcourse[i].eorder+ "节: ";
                }
                xx += validcourse[i].name;
                xx += "  ";
                xx += validcourse[i].room;
                xx += "\n";
                coursetext += xx;
            }           
            return coursetext;
        }
        public static string GetHttpData(string uri)
        {
            string result = null;
            Uri url = new Uri(uri);//初始化uri
            Stream stream = null;
            StreamReader reader = null;
            try
            {
                HttpWebRequest request = (System.Net.HttpWebRequest)WebRequest.Create(url);//初始化请求
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();//得到响应
                stream = response.GetResponseStream();//获取响应的主体
                reader = new StreamReader(stream);//初始化读取器
                result = reader.ReadToEnd();//读取，存储结果
                reader.Close();
                stream.Close();
            }
            catch (System.Net.WebException)
            {
                Console.WriteLine("请求超时");
            }
            return result;
        }
        public static string GetString(string cityname)
        {
            return "https://free-api.heweather.com/s6/weather/now?location="+cityname+"&key=2dd06e53945c461d864ac15cb3834ef0";
        }
        public static string GetString2(string cityname)//查询空气指数uri
        {
            return "https://free-api.heweather.com/s6/air/now?location=" + cityname + "&key=2dd06e53945c461d864ac15cb3834ef0";
        }
        public static string GetWea(string data)
        {
            string ans = "";
            string target = "cond_txt";
            int index = data.IndexOf(target);
            index += 11;
            for(;data[index]!='"';index++)
            {
                ans += data[index];
            }
            return ans;
        }
        public static string GetTemp(string data)
        {
            string ans = "";
            string target = "tmp";
            int index = data.IndexOf(target);
            index += 6;
            for (; data[index] != '"'; index++)
            {
                ans += data[index];
            }
            return ans;
        }
        public static string GetAQI(string data)//获取空气质量指数
        {
            string ans = "";
            string target = "aqi";
            int index = data.IndexOf(target);
            index += 6;
            for (; data[index] != '"'; index++)
            {
                ans += data[index];
            }
            return ans;
        }
        public static string GetQlty(string data)//获取空气质量
        {
            string ans = "";
            string target = "qlty";
            int index = data.IndexOf(target);
            index += 7;
            for (; data[index] != '"'; index++)
            {
                ans += data[index];
            }
            return ans;
        }
        static void Main(string[] args)
        {
            ConsCL();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic["Monday"] = "一";
            dic["Tuesday"] = "二";
            dic["Wednesday"] = "三";
            dic["Thursday"] = "四";
            dic["Friday"] = "五";
            dic["Saturday"] = "六";
            dic["Sunday"] = "日";
            Dictionary<string, int> dictoint = new Dictionary<string, int>();
            dictoint["Monday"] = 1;
            dictoint["Tuesday"] = 2;
            dictoint["Wednesday"] = 3;
            dictoint["Thursday"] = 4;
            dictoint["Friday"] = 5;
            dictoint["Saturday"] = 6;
            dictoint["Sunday"] = 7;

            string cityname = "北京";
            string uri = GetString(cityname);
            string res = GetHttpData(uri);
            string uri2 = GetString2(cityname);//空气指数
            string res2 = GetHttpData(uri2);

            //Console.WriteLine(res);
            //Console.WriteLine(res2);

            //return;

            // 短信应用SDK AppID
            int appid = 1400066350;
            // 短信应用SDK AppKey
            string appkey = "c9b1355bc16f6c84f707aaef08953227";
            // 需要发送短信的手机号码
            string[] phoneNumbers = { "13261660202","15010735298","13001023920" };
            // 短信模板ID，需要在短信应用中申请

            string weather = GetWea(res);
            string temp = GetTemp(res);
            string aqi = GetAQI(res2);
            string qlty = GetQlty(res2);

            //Console.WriteLine(aqi);
            //Console.WriteLine(qlty);
            //return;

            

            //int templateId = 83661; // NOTE: 这里的模板ID`7839`只是一个示例，真实的模板ID需要在短信控制台中申请
            string test = "小楠宝，你好，今天是" +
                DateTime.Now.Year.ToString() + "年"
                + DateTime.Now.Month.ToString() + "月"
                + DateTime.Now.Day.ToString() + "日，星期"
                + dic[DateTime.Now.DayOfWeek.ToString()]+"，"
                +cityname+"现在的温度是"+temp+"℃,天气是“"+weather+"”,空气质量指数为"+aqi+",空气质量为“"+qlty+"”,"
                + conscoursetext(DateTime.Now.Subtract(new DateTime(2018,2,26,0,0,0)).Days/7+1, dictoint[DateTime.Now.DayOfWeek.ToString()])+
                "。今天要开开心心的哦。--来自小小龙宝。\n";

            Console.WriteLine(test);
            return; 
            try
            {
                SmsSingleSender ssender = new SmsSingleSender(appid, appkey);
                var result = ssender.send(0, "86", phoneNumbers[0],
                    test, "", "");
                Console.WriteLine(result);
            }
            catch (JSONException e)
            {
                Console.WriteLine(e);
            }
            catch (HTTPException e)
            {
                Console.WriteLine(e);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            //Console.ReadLine();
        }
    }

    class Course
    {
        public string name;
        public string room;
        public int sweek;
        public int eweek;
        public int sorder;
        public int eorder;
        public Course(string name,string room,int sweek,int eweek,int sorder,int eorder)
        {
            this.name = name;
            this.room = room;
            this.sweek = sweek;
            this.eweek = eweek;
            this.sorder = sorder;
            this.eorder = eorder;
        }
    }
}
