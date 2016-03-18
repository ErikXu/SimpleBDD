Feature: EncryptEmptyText
	利用Des加解密基础组件加密空字符串，等到空字符串

@mytag
Scenario: Encrypt empty text
	Given 空字符串
	When 执行Des加密
	Then 得到空字符串，且无异常抛出
