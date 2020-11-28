# 教程推荐

- [M_Studio的个人空间 - 哔哩哔哩 ( ゜- ゜)つロ 乾杯~ Bilibili](https://space.bilibili.com/370283072/channel/detail?cid=85776)

  - 01~07,10(Prefab相关, 必看), 12, 18, 21, 22, 25, 30

- [Unity教程:安装HUB和配置VS code作为脚本编辑器_哔哩哔哩 (゜-゜)つロ 干杯~-bilibili](https://www.bilibili.com/video/BV19741167zU)

  - 论如何使用vs code开发

- 一些有趣的教程(以备不时之需)

  - [Unity教程:制作Roguelike随机地下城02.RandomRoom 随机房间！_哔哩哔哩 (゜-゜)つロ 干杯~-bilibili](https://www.bilibili.com/video/BV197411B7Ne)

    - 随机关卡可能用到

  - [Unity教程:如何存储和加载游戏(ScriptableObject)_哔哩哔哩 (゜-゜)つロ 干杯~-bilibili](https://www.bilibili.com/video/BV1CJ41157DR)

    [Unity教程:背包系统03:数据库存储方法ScriptableObject_哔哩哔哩 (゜-゜)つロ 干杯~-bilibili](https://www.bilibili.com/video/BV1LJ411X78s)

    - 可能在保存游戏进度时用得到

  - [Unity教程 Your First Game|入门Tutorial:19 对话框Dialog_哔哩哔哩 (゜-゜)つロ 干杯~-bilibili](https://www.bilibili.com/video/BV1b4411y7yq)

    - 可能在添加帮助时用得到

# 基础功能

- [x] 修复多段跳跃的bug
  - 通过将 `ground` 的 `layer` 设置为 `ground` 来判断角色是否已经着地, 如果着地则将 `isJumping` 设置为 `false`, 从此来防止角色可以多段跳跃
  - 因此在新建 TileMap 之后需将 Layer 设置为 Ground 来完成落地的判定
  - 当然, 角色可以通过头顶墙壁等操作来实现多段跳跃, 但这也可以作为 feature
- [x] 完成镜头的跟随
  - 通过 cinemachine 插件来实现, 该插件提供了平滑移动/限制镜头移动区域等功能
- [ ] 完成球体材质的切换
- [x] 完成关卡间的切换
  - 在 level01 中的 Door 有一个 EnterNext 的 Prefab, 通过该 Prefab 完成对下一场景的加载, 之后加载下一场景也建议使用该 Prefab
- [ ] 完成简单的开始游戏的UI
  - [ ] 开始游戏
  - [ ] 选关
  - [ ] 帮助界面
  - [ ] 退出游戏
- [x] 完成死亡后重新开始游戏的机制
  - 在 Scene 中有 Deadline 对象, 该对象会在碰撞检测后重新载入游戏关卡
  - [ ] 调整 deadline 防止角色移动过快脱离判定的情况(调整为盒型可能更合适)
- [ ] 完成存档点(前提是要我们设计出足够长的关卡)
- [x] 三种球的运动性质
  - 通过 Material 下的三种不同的 Material 来模拟, 三种球的摩擦系数不同, 弹性系数不同, 同时质量也不同. 在移动时, 根据力和摩擦大小和质量来计算加速度. 通过 Unity 自带的弹性引擎完成反弹效果.
  - [ ] 使得运动手感更好(目前纸球似乎太轻了, 跳跃能力太强了)(可以再Project settings中的Phtsics 2D中进一步对物理材质进行自定义)
- [x] 三种球的跳跃性质
  - 通过质量来调整跳起的高度
  - [ ] 修改 Grab, 调整不同球的下落速度
- [ ] 完成对玩家游戏进度的保存
- [ ] 找到更多适合的材质
  - 材质在 addons 文件夹下, 可以在 asset store 中寻找更多材质
  - [ ] 木质材质
  - [ ] 气流
  - [ ] 背景图片

# 基础机关

- [x] 斜面
  - 测试发现使用三角形的 TileMap 即可实现倾斜向上走的效果
  - [ ] 找到不规则的材质, 制作出不规则的地面
- [ ] 完成平衡木机关的制作
- [ ] 完成尖刺机关的制作
- [ ] 完成气流机关的制作(纸球才能被吹起)
- [ ] 完成木质机关的制作(石球才能砸开)

# 基础关卡

- [ ] 完成三个基础关卡的设计

# 进阶功能

- [ ] 完成音效
  - [ ] 死亡音效
  - [ ] 移动音效
  - [ ] 反弹音效
- [ ] 完成动画
  - [ ] 完成球体放缩的动画(即在球反弹时会有压缩的动画)(应该可以通过调整球的放缩比例来实现)
  - [ ] 完成球死亡的动画
  - [ ] 完成淡入淡出的动画



