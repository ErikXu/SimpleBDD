Feature: EncryptNullText
	利用Des加解密基础组件加密null，抛出ArgumentNullException异常

@mytag
Scenario: Encrypt null text
	Given null
	When 执行Des加密
	Then 抛出ArgumentNullException异常
