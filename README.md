# Snowflake53

Twitter Snowflake-alike ID generator 53bit for .NetCore 3.0. Available as [Nuget package](https://www.nuget.org/packages/Snowflake53)

## 说明

[Twitter's Snowflake](https://github.com/twitter/snowflake) 是一个ID自动生成的方法，可以用于生成数据库的主键。但是它生成的是64位的整数，在浏览器前端无法处理。Snowflake53生成53位长度的整数。

## 如何工作

Snowflake53由以下三部分合并组成:

* Timestamp
* Generator-id
* Sequence 

Timestamp是41位的时间戳，从2019年7月1日开始。
Generator-id是2位的生成器编号，从0到3，只有4个生成器，最多只能用于4台主机同时生成序列号。
Sequence是10位长度的序列号。


## 开始使用

从[Nuget package](https://www.nuget.org/packages/IdGen)安装并编写以下程序:

```c#
using Snowflake53;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var generator = new IdGenerator(0);
        Console.WriteLine(generator.CreateId());
    }
}
```

输出:
```
9410778017792
```

本程序在mac机器dotnet core 3.0环境下简单测试通过。MIT协议发布。
<hr>


