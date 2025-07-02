# MicMonitor

**Monitoring Windows microphone input. Prevents automatic muting.**

---

**Windows�}�C�N���͂̊Ď��B�����~���[�g��h�~���܂��B**

---

## Overview / �T�v

This tray application constantly monitors your default microphone input on Windows.  
If the microphone input is automatically muted by the system or other software, the app will unmute it instantly.

���̃A�v���́AWindows�̃f�t�H���g�}�C�N���͂���ɊĎ����܂��B  
�V�X�e���⑼�̃\�t�g�E�F�A�ɂ���ă}�C�N�������I�Ƀ~���[�g���ꂽ�ꍇ�A�����Ƀ~���[�g�������܂��B

---

## Features / ��ȓ���

- Automatic detection of microphone mute status  
  �}�C�N�~���[�g��Ԃ������Ď�
- Instantly unmutes the microphone if muted  
  �~���[�g���͑����Ƀ}�C�N��ON�ɖ߂�
- Possible to run resident in the system tray (background)  
  �^�X�N�g���C�i�o�b�N�O���E���h�j�ŏ풓���\
- No administrator privileges required  
  �Ǘ��Ҍ����s�v
- Simple and lightweight  
  �V���v�����y��

---

## Installation / �C���X�g�[�����@

1. Build from source  
   �\�[�X����r���h���Ă�������
2. Run `windows-mic-input-monitor.exe`  
   `windows-mic-input-monitor.exe` �����s���܂�
3. The application will appear in your system tray  
   �A�v�����^�X�N�g���C�ɃA�C�R���\������܂�

---

## Usage / �g����

- The app starts monitoring once launched  
  �A�v�����N������Ƃ����ɊĎ����n�܂�܂�
- If your mic is muted, it will be unmuted automatically  
  �}�C�N���~���[�g���ꂽ�ꍇ�A�����Ń~���[�g��������܂�
- To exit, either close the app or right-click the tray icon. 
  �I���������ꍇ�̓A�v������邩��g���C�A�C�R�����E�N���b�N���Ă�������

---

## Requirements / ����v��

- Windows 10/11
- .NET 6.0 or later / .NET 6.0�ȏ�
- [NAudio](#maybeCitation:https://github.com/naudio/NAudio) ���C�u����

---

���{�A�v���P�[�V�����ɂ̓��C�Z���X�����͂���܂���B