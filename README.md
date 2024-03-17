# asp-dotnet-8-application

.net 8 + ABP + nextjs 应用，前后端分离

## why start this repo ?

- 【背景】近期在做 **windows 客户端** 的自动化构建发布服务。
- 【过程】初期首选考虑过使用 **Jenkins** 来解决这个需求，实际使用过后才发现几个躲不开的点：
  1. 直接使用 **Jenkins** 提供的插件进行 **`msbuild`** 来构建，需要额外配置一下 **`msbuild`** 环境，但是 **Visual Studio** 安装完成后已经提供了两个（`cmd` + `powershell`） **集成终端 `Developer Command Prompt` + `Developer Powershell`** ，**为什么我要额外再配置一下 msbuild ？我只想无脑直接用！（虽然只需要一次）**
  2. 没办法那么灵活解析解决方案下的项目，需要额外开发 **Jenkins** 相关的插件，工作量又上来了。再加上这个服务需要集成到另一个平台，两边联调，还没测试过，不保证会遇到什么跨域、鉴权的问题
  3. 从现阶段线下构建的场景，还是直接写服务吧，至少可以完全自定义逻辑，不需要按照 **Jenkins** 的实现逻辑
  4. 有点重了
- 【结果】花了几周时间搭了个 **asp .net 6 应用** ，完成基础功能了：
  1. 指定分支进行构建发布
  2. 指定 **configuration** 和 **runtime** 进行构建发布（和 **Visual Studio** 内构建流程逻辑一致）
  3. 可以指定签名配置对发布结果的 **.exe** 进行签名
  4. 使用 **advanced installer** 出 **installer.exe**
  5. 推送发布 **installer.exe** 到发布平台
  6. 查询构建发布历史和日志，下载免安装版的 **archive.zip** 、 **installer.exe**
  7. 【TODO】构建、发布、推送 **nuget package**
  8. 【TODO】构建、发布其他类型的应用：**electron application**
- 【额外收获】
  1. **.net 6** 支持跨平台，为什么不在 **MacOS** 下也用 **asp .net core** 作为后端？
  2. **asp .net core** 的 **ORM** 真好用，比 **java** 平台高出 N 个 **sequelize**
  3. **asp .net core** 的 **web** 模板框架真·无脑好上手，很 **eggjs**

## what would this repo contains ?

1. 基础的前后端分离的 **web** 应用脚手架，基于 **ABP** 做了身份认证、权限管理
2. 基于脚手架进行开发的自己的一个 **web** 应用

## about develop plan ...

### milestone 1

- **2024.05.01** 完成基础脚手架搭建
  1. 包含注册登录和鉴权逻辑
  2. 前端完成脚手架搭建，可以本地进行开发调试和注册登录

### _to be continued_

## Sln Detail

> 简单介绍说明一下模板项目基础之上的一些自定义模块，以及魔改后的配置，便于二次开发使用

### 数据库表结构初始化 + Migration
> 如果在项目初期已经完成了数据库表结构设计，快速开发的话，可以直接使用 **`DBContext.database.EnsureCreated()`**，但是从长远角度考虑，还是建议使用项目中最新的 **`migrate`** 版本
>
> **先大概说明一下整体流程** ： 
>
> ① 创建 models ，定义模型，映射数据库表
>
> ② 使用 EF 工具创建相关的 migration 代码（ SQL 语句）
>
> ③ 项目启动后，会根据 migration ，同步数据库表结构
>
> 另外提供一点小 tips ：EF calls CreateWebHostBuilder or BuildWebHost without running Main. So Iconfiguration is null.
>
> 所以在 **`MySqlDBContext`** 的基础之上还有一个 **`Factory`** ，执行 EF 工具的时候会调用该 **`Factory`**

1. 需要安装 **`EF`** 工具：`dotnet tool install --global dotnet-ef`
2. 添加 **Migrattion**（需要和项目配置文件同目录执行）：`dotnet ef migrations add InitTable --verbose`
    ```bash
    建议命名规则：<operateType>_<tableName>_<subOp> ，如果涉及到多个表，或者是初始化，可考虑将表名去掉
    InitTable
    UpdateTable_test_addColumnAlias
    UpdateTable_test_modifyColumnName
    ```
3. 在 **Migrations** 目录下有相关的代码，会根据当前最新版本的 **Model** 自动生成相关 SQL 语句

### 其他细节说明
1. **`Directory.Build.props`** + **`Directory.Build.targets`**
> DTOs 目录中存放的是和端侧通信的数据结构，考虑到习惯，采用的小驼峰的命名方式
>
> 但是 c# 中首选且建议用大驼峰作为属性名，所以针对该目录，抑制 IDE1006 的警告
