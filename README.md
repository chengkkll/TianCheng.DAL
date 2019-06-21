# TianCheng.DAL

目标架构为：.NET Standard 2.0

数据库操作接口，及其数据库连接控制，日志处理。

## 日志处理

通过`TianCheng.Model`组件包使用Serilog作为日志处理的工具。已添加操作对象`DBLog`。`DBLog`是按固定的配置写日志。

`DBLog`的日志配置如下：

1. 控制台输出Warning级别以上的信息；
2. Debug窗口输出为全输出；
3. 文件输出为Warning级别以上的，文件名格式为`Logs/TianCheng.DBOperation-{Date}.txt`；
4. 邮件发送级别为Error，收件账号可以通过`ToEmail`属性设置。

例如：

```csharp
    DBLog.ToEmail = xxx@qq.com
```

## 数据库连接处理

可通过调用`LoadDB.Init()`来初始化数据库配置信息。

数据库的配置格式如下：

```Json
  "DBConnection": [
    {
      "Name": "default",
      "ServerAddress": "mongodb://localhost:27017",
      "Database": "samples",
      "Type": "MongoDB"
    }
  ]
```

说明：

>Name 为数据库的连接名称，如果不设置默认为default。数据库访问操作默认使用default的连接。该值主要是同时对多个数据库进行操作时有用。对多个数据库操作时，需要在操作对象的特性上指定连接名称。相关操作可以参考[TianCheng.DAL.MongoDB](https://github.com/chengkkll/TianCheng.DAL.MongoDB)。
>
>ServerAddress 为服务器的连接地址
>
>Database 为库名称
>
>Type 的值目前可以为MongoDB，最近打算写完关系型数据库：MsSql、MySql、PostgreSql。
>
