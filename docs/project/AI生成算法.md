# AI 生成算法

游戏玩法为 Roguelike 游戏，算法设计主要从管理时间、计算视野、寻路、生成地图和 AI 这五个方面展开。

# 算法设计

## 管理时间

## 计算视野

## 寻路
把地图中的每个方格看作图（Graph）里的节点，以玩家人物所处位置为起点，用 Dijkstra 算法标记出每个节点到起点的距离，最后让怪物始终沿着距离减小的方向移动——也就是逐步逼近玩家人物。

参考文献 [The Incredible Power of Dijkstra Maps](./http://www.roguebasin.com/index.php?title=The_Incredible_Power_of_Dijkstra_Maps)

## 生成地图

## AI

# 参考文献
- [教你做游戏：浅谈 Roguelike 游戏中的算法](./https://www.gcores.com/articles/101550)
