import { createRequire } from "module";
import { defineConfig } from "vitepress";

const require = createRequire(import.meta.url);
const pkg = require("../package.json");

export default defineConfig({
  lang: "en-US",
  title: "尘星",
  description: "《尘星》产品文档，机密文件，请勿外传。",

  lastUpdated: true,
  cleanUrls: true,

  head: [["meta", { name: "theme-color", content: "#3c8772" }]],

  markdown: {
    headers: {
      level: [0, 0],
    },
  },

  themeConfig: {
    logo: "/logo.svg",

    nav: nav(),

    sidebar: {
      "/database/": sidebarDatabase(),
      "/project/": sidebarProject(),
    },

    editLink: {
      pattern: "https://github.com/logeast/pluck-stars/edit/main/docs/:path",
      text: "在 GitHub 上编辑此页",
    },

    socialLinks: [
      { icon: "github", link: "https://github.com/logeast/pluck-stars" },
    ],

    footer: {
      message: "构建持久不衰的游戏，让宇宙物理走入民间。",
      copyright: "Copyright © 2023-present Logeast",
    },

    // algolia: {
    //   appId: "8J64VVRP8K",
    //   apiKey: "a18e2f4cc5665f6602c5631fd868adfd",
    //   indexName: "vitepress",
    // },

    // carbonAds: {
    //   code: "CEBDT27Y",
    //   placement: "vuejsorg",
    // },
  },
});

function nav() {
  return [
    { text: "项目管理", link: "/project/index", activeMatch: "/project/" },
    { text: "数据库", link: "/database/index", activeMatch: "/database/" },
    {
      // text: pkg.version,
      text: "更多",
      items: [
        {
          text: "如何贡献",
          link: "/project/如何贡献",
        },
        {
          text: "路线图",
          link: "/project/路线图",
        },
        {
          text: "项目看板",
          link: "https://github.com/users/logeast/projects/5",
        },
      ],
    },
  ];
}

function sidebarDatabase() {
  return [
    {
      text: "角色",
      collapsed: false,
      items: [
        { text: "宇航员列表", link: "/database/宇航员列表" },
        { text: "天体列表", link: "/database/天体列表" },
      ],
    },
    {
      text: "道具",
      collapsed: false,
      items: [
        { text: "武器列表", link: "/database/武器列表" },
        { text: "被动列表", link: "/database/被动列表" },
        { text: "超武列表", link: "/database/超武列表" },
        { text: "拼写命令", link: "/database/拼写命令" },
      ],
    },
    {
      text: "场景及成就",
      collapsed: false,
      items: [
        { text: "场景列表", link: "/database/场景列表" },
        { text: "成就列表", link: "/database/成就列表" },
        { text: "秘籍信息", link: "/database/秘籍信息" },
      ],
    },
  ];
}

function sidebarProject() {
  return [
    {
      text: "全景",
      collapsed: false,
      items: [
        { text: "项目需求书", link: "/project/index" },
        { text: "路线图", link: "/project/路线图" },
        { text: "迭代计划", link: "/project/迭代计划" },
      ],
    },
    {
      text: "游戏策划",
      collapsed: false,
      items: [
        { text: "游戏背景", link: "/project/游戏背景" },
        { text: "世界观", link: "/project/世界观" },
        { text: "AI 生成算法", link: "/project/AI生成算法" },
        { text: "数值参数", link: "/project/数值参数" },
        { text: "战斗数值", link: "/project/战斗数值" },
        { text: "经济数值", link: "/project/经济数值" },
        { text: "成就数值", link: "/project/成就数值" },
      ],
    },
    {
      text: "商业化",
      collapsed: false,
      items: [{ text: "广告变现", link: "/project/广告变现" }],
    },
    {
      text: "游戏美术",
      collapsed: false,
      items: [
        { text: "地图设计", link: "/project/地图设计" },
        { text: "2D 角色设计", link: "/project/2D角色设计" },
        { text: "特效美术设计", link: "/project/特效美术设计" },
      ],
    },
    {
      text: "游戏程序",
      collapsed: false,
      items: [
        { text: "新手教程", link: "/project/新手教程" },
        { text: "Unity 技巧汇总", link: "/project/Unity技巧汇总" },
      ],
    },
    {
      text: "贡献指南",
      collapsed: false,
      items: [
        { text: "如何贡献", link: "/project/如何贡献" },
        { text: "分成机制", link: "/project/分成机制" },
      ],
    },
    {
      text: "参考文献",
      collapsed: false,
      items: [
        {
          text: "参考文献",
          link: "/project/参考文献",
        },
      ],
    },
  ];
}
