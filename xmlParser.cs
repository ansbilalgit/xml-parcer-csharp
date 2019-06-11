   public class XmlParser<T>
    {
        public static T getParsedObject(string path, string rootNode)
        {
            try
            {
                T deserializedObject = default(T);
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(path);
                var node = xmlDoc.SelectSingleNode(rootNode);
                if (node == null)
                    return deserializedObject;
                using (XmlReader reader = new XmlNodeReader(node))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    deserializedObject = (T)xmlSerializer.Deserialize(reader);
                }
                return deserializedObject;
            }
            catch (Exception ex)
            {
                throw new Exception("error in opening file " + ex.InnerException);
            }
        }
    }
