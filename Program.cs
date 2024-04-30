using AesSample;
string data = "This is the data to be encrypted";
var encrypted = AesEncryption.EncryptData(data);
AesEncryption.DecryptData(encrypted);

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
