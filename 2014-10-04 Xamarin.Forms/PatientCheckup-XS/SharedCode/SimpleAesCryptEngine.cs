using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using Portable.Data.Sqlite;

//Example AES-based "crypt engine" for use with Portable.Data.Sqlite,
//  should work on all platforms supported by Portable.Data.Sqlite.

//Disclaimer:
//  THIS SAMPLE CODE IS BEING PROVIDED FOR DEMONSTRATION PURPOSES ONLY, AND
//  IS NOT INTENDED FOR USE WITH SOFTWARE THAT MUST PROVIDE ACTUAL DATA SECURITY.
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE 
//  SOFTWARE.

[assembly: Xamarin.Forms.Dependency(typeof(SimpleAesCryptEngine))]
public class SimpleAesCryptEngine : IObjectCryptEngine {

    string _cryptoKey;
    Aes _aesProvider;
    bool _initialized = false;

    private byte[] getBytes(string text, int requiredLength) {
        var result = new byte[requiredLength];
        byte[] textBytes = Encoding.UTF8.GetBytes(text);
        int offset = 0;
        while (offset < requiredLength) {
            int toCopy = (requiredLength >= (offset + textBytes.Length)) ?
                textBytes.Length : requiredLength - offset;
            Buffer.BlockCopy(textBytes, 0, result, offset, toCopy);
            offset += toCopy;
        }
        return result;
    }

    //Parameterless constructor required for Xamarin.Forms
    public SimpleAesCryptEngine() { }

    public SimpleAesCryptEngine(string cryptoKey) {
        this.Initialize(new Dictionary<string, object>() { { "CryptoKey", cryptoKey } });
    }

    public void Initialize(Dictionary<string, object> cryptoParams) {
        _cryptoKey = cryptoParams["CryptoKey"].ToString();
        _aesProvider = Aes.Create();
        _aesProvider.Key = getBytes(_cryptoKey, _aesProvider.Key.Length);
        //Here we are using the same value for all initialization vectors.
        //  This is NOT RECOMMENDED - it should be randomly generated;
        //  however, then you need a way to retrieve it for decryption.
        //  More info: http://en.wikipedia.org/wiki/Initialization_vector
        _aesProvider.IV = getBytes("THIS SHOULD BE RANDOM", _aesProvider.IV.Length);
        _initialized = true;
    }

    public T DecryptObject<T>(string stringToDecrypt) {
        if (!_initialized) throw new Exception("Crypt engine is not initialized.");
        T result = default(T);
        if (stringToDecrypt != null) {
            byte[] bytesToDecrypt = Convert.FromBase64String(stringToDecrypt);
            byte[] decryptedBytes =
                _aesProvider.CreateDecryptor().TransformFinalBlock(bytesToDecrypt, 0, bytesToDecrypt.Length);
            result =
                JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(decryptedBytes));
        }
        return result;
    }

    public string EncryptObject(object objectToEncrypt) {
        if (!_initialized) throw new Exception("Crypt engine is not initialized.");
        string result = null;
        if (objectToEncrypt != null) {
            byte[] bytesToEncrypt =
                Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(objectToEncrypt));
            //Not sure if I should be using TransformFinalBlock() here, 
            //  or if it is more secure if I break the byte array into
            //  blocks and process one block at a time.
            byte[] encryptedBytes =
                _aesProvider.CreateEncryptor().TransformFinalBlock(bytesToEncrypt, 0, bytesToEncrypt.Length);
            result = Convert.ToBase64String(encryptedBytes);
        }
        return result;
    }

    public void Dispose() {
        _cryptoKey = null;
        _aesProvider.Dispose();
        _aesProvider = null;
    }
}
