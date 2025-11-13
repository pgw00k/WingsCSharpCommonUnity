/*
 * FileName:    CSharpAssetCreator
 * Author:      Wings
 * CreateTime:  2021_11_23
 * 
*/

using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

namespace GenOcean.Unity.Editor
{
    public class CSharpAssetCreator : UnityEditor.AssetModificationProcessor
    {
        #region Protected Fields

        protected static Regex _Regex = new Regex("\\.meta$");

        #endregion --Protected Fields

        #region Public Fields

        public static string CREATE_TIME_FORMAT = "yyyy_MM_dd";

        #endregion --Public Fields

        #region Private Fields
        #endregion --Private Fields

        #region Public Methods
        #endregion --Public Methods

        #region Private Methods
        #endregion --Public Methods

        #region Protected Methods
        #endregion --Protected Methods

        #region Unity Methods

        public static void OnWillCreateAsset(string path)
        {
            //Debug.Log(path);
            //EditorUtility.DisplayDialog("Message", path, "OK");
            if (path.ToLower().EndsWith(".cs.meta"))
            {
                string rawFile = _Regex.Replace(path, "");
                string content = File.ReadAllText(rawFile);
                content = content.Replace("#CREATETIME#", System.DateTime.Now.ToString(CREATE_TIME_FORMAT));
                File.WriteAllText(rawFile, content);
            }
        }

        #endregion --Unity Methods
    }
}
