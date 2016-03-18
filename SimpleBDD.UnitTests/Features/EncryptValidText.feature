Feature: EncryptValidText
	利用Des加解密基础组件加密明文，得到密文

@mytag
Scenario: Encrypt valid text
	Given 明文
	When 执行Des加密
	Then 得到密文，且无异常抛出
