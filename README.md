# MicMonitor

**Monitoring Windows microphone input. Prevents automatic muting.**

---

**Windowsマイク入力の監視。自動ミュートを防止します。**

---

## Overview / 概要

This tray application constantly monitors your default microphone input on Windows.  
If the microphone input is automatically muted by the system or other software, the app will unmute it instantly.

このアプリは、Windowsのデフォルトマイク入力を常に監視します。  
システムや他のソフトウェアによってマイクが自動的にミュートされた場合、即座にミュート解除します。

---

## Features / 主な特徴

- Automatic detection of microphone mute status  
  マイクミュート状態を自動監視
- Instantly unmutes the microphone if muted  
  ミュート時は即座にマイクをONに戻す
- Possible to run resident in the system tray (background)  
  タスクトレイ（バックグラウンド）で常駐も可能
- No administrator privileges required  
  管理者権限不要
- Simple and lightweight  
  シンプル＆軽量

---

## Installation / インストール方法

1. Build from source  
   ソースからビルドしてください
2. Run `windows-mic-input-monitor.exe`  
   `windows-mic-input-monitor.exe` を実行します
3. The application will appear in your system tray  
   アプリがタスクトレイにアイコン表示されます

---

## Usage / 使い方

- The app starts monitoring once launched  
  アプリを起動するとすぐに監視が始まります
- If your mic is muted, it will be unmuted automatically  
  マイクがミュートされた場合、自動でミュート解除されます
- To exit, either close the app or right-click the tray icon. 
  終了したい場合はアプリを閉じるか｡トレイアイコンを右クリックしてください

---

## Requirements / 動作要件

- Windows 10/11
- .NET 6.0 or later / .NET 6.0以上
- [NAudio](#maybeCitation:https://github.com/naudio/NAudio) ライブラリ

---

※本アプリケーションにはライセンス条項はありません。