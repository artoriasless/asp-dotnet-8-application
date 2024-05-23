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

1. 基于 	**ABP** 的 **.net 8 wasm** 应用
2. UI 库使用 **Blazorise.AntDesign**
3. [**UI 库引入使用**](https://blazorise.com/docs)，[**UI 库组件 API**](https://blazorise.com/docs/components)
4. [**ABP template refer**](./refer.md)
