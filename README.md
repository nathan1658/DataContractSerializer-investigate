# DataContractSerializer-investigate
While deserialize new version object to a old object, seems sometimes it will put the property in wrong position, maybe new property/order issue? still figuring out.
/WcfTest/bin/Debug/tmp.xml is the generate with the new object with a new property (ClassBinClassA), try to deserialize to old classA which dont have this property.
