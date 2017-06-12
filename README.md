# 知乎爬虫
这个爬虫动用实验室十台电脑一起干活，可随时添加删除机器，具有良好的伸缩性，为了能够实现断点续爬和多台电脑之间的协作使用了Redis作队列，
为了保证不重复爬取使用Redis作hash表,所有爬取的任务都放到hash表中进行标记。
爬取太频繁会被知乎返回429（too many request）,应对的策略是挂代理，一种方法是使用专业的云代理服务（有点贵）,
另外一种自建代理池（https://github.com/wangqifan/ProxyPool ），定时爬取互联网上免费代理ip。最后数据使用sql server存储，
最后对数据进行分析，使用百度的echart.js进行画图
数据展示：
<image src="https://github.com/wangqifan/ZhiHu/blob/master/814953-20170108120707706-1003815196.png" width=500>
<image src="https://github.com/wangqifan/ZhiHu/blob/master/814953-20170108120724034-1950593592.png" width=500>
![image](https://github.com/wangqifan/ZhiHu/blob/master/814953-20170108120919675-1582035152.png)
![image](https://github.com/wangqifan/ZhiHu/blob/master/814953-20170108121032566-1417590158.png)

抓取百万知乎用户数据之爬取思路 http://www.cnblogs.com/zuin/p/6227834.html 

抓取百万知乎用户设计之实体设计 http://www.cnblogs.com/zuin/p/6227934.html 

抓取百万知乎用户信息之HttpHelper的迭代 http://www.cnblogs.com/zuin/p/6257125.html 

抓取知乎百万用户信息之自建代理池 http://www.cnblogs.com/zuin/p/6261677.html

抓取知乎百万用户信息之Redis篇 http://www.cnblogs.com/zuin/p/6261709.html 

抓取知乎百万用户信息之爬虫模块 http://www.cnblogs.com/zuin/p/6261745.html  

抓取知乎百万用户信息之总结篇 http://www.cnblogs.com/zuin/p/6261772.html  

如果需要运行程序  请装好Redis，sqlserver  并配置好

![image](http://images2015.cnblogs.com/blog/814953/201701/814953-20170108101133675-95314149.png)
