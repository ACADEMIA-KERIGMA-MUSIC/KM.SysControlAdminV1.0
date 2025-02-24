CREATE DATABASE KMSysControlAdminDB
GO
    USE KMSysControlAdminDB
GO
CREATE TABLE [Role](
    Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Name] VARCHAR(30) NOT NULL
    );
GO
    INSERT INTO [Role] VALUES('Desarrollador');
	INSERT INTO [Role] VALUES('Administrador');
	INSERT INTO [Role] VALUES('Instructor/Docente');
    INSERT INTO [Role] VALUES('Alumno/a');
    INSERT INTO [Role] VALUES('Secretario/a');
GO
CREATE TABLE [User](
    Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Name] VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Email VARCHAR(50) NOT NULL,
    [Password] VARCHAR(32) NOT NULL,
    [Status] TINYINT NOT NULL,
    DateCreated DATETIME NOT NULL,
    DateModification DATETIME NOT NULL,
	ImageData VARBINARY(MAX) NOT NULL,
	IdRole INT NOT NULL FOREIGN KEY REFERENCES [Role](Id) ON DELETE CASCADE
    );
GO
    INSERT INTO [User] (IdRole, [Name], LastName, Email, [Password], [Status], DateCreated, DateModification, ImageData) 
    VALUES (1, 'Flexcode', 'Freelancer', 'DesAdmin@kerigmamusic.com', 'c8aa131427a72781b156ac723ddb917f', 1, SYSDATETIME(), SYSDATETIME(), 0xFFD8FFE000104A46494600010100000100010000FFDB008400060606060706070808070A0B0A0B0A0F0E0C0C0E0F1610111011101622151915151915221E241E1C1E241E362A26262A363E3432343E4C44444C5F5A5F7C7CA701060606060706070808070A0B0A0B0A0F0E0C0C0E0F1610111011101622151915151915221E241E1C1E241E362A26262A363E3432343E4C44444C5F5A5F7C7CA7FFC20011080200020003012200021101031101FFC400310001000203010000000000000000000000000506010304020101000301010000000000000000000000000103040502FFDA000C03010002100310000002B5000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000009000000000000000000C43CC717BAF4C8543D6BCB7057E4B368EF63355A09000031E7CD76DA7A266A5DFA33ECE2B3562632D2D146E691B9A46E691B9A46E7AEDAFDF06673B28BE0BB64D45DAB715DA090000000000061196064240045638ED1C3BB142A5FC5B5704969F1E3D4D755637517D8519DF9EFDA23DE3478AE5D47BE73A5CF0989DDD5EB3E0DB564AC56BCA67AFD471A67BA8BAB9D961CD1745F76E517E479F409000000000000000C704827CD433395FE8F3F77BE5595F67BE044C97A8B79998F50A8F53BEA01E66C5EEB489B47AAAA3D5B3DD41E66E4E28BCF7CD6BAF7ABE99EF10FEA625311FEA27B37706CF3EA5F86419F478D84482400000000000000000000004649667C53713D03D3E705B580000000EFE1B467BFC567B38E602FA4001D5CB255FBB08E57540000000000000000000000000031112E9F14D4CC37539A1678000007A24643A2BB836F30DF8800004DC259335FDE39FD10000000000000000000000000000310936F55D352917D3E7059E0001311769CBA78ABFBF459585D500000B655ADF8B66463D80000000000000000000000000000018809FC7BAE9C918EE9F343DF91BE26552556C3B350DF88000003AECF033DCEDF919F480000000000000000000000000000001E6BB63F36554F76F174F9CB044D8F2E98B86F7E34501656000001392DC7D9C9E9E478B4000000000000000000000000000000003C56ECDE6CAB8F865AAB751E46FC600000036C4DA76E33C7EB0240000000000000000000000000000000000D55BB46AB69A93A39FA7CE0980001E85873DDCFDF919B48000000000000000000000000000000000006A85EEAEEBC76CACC8C9F9F5556DD5BF104C0F7058B3D9CFDF919F4800000000000000000000000000000000000010513D3CDD4E5A66193169AD4C75E3D5587BCEEC6B1E7AB9FBF228D00000000000000000000000000000000000000635ED8E9F15D1D8E50199E80DD4DB3FB37FAE6F43223D800000000000000000000000000000000000000620E72AF7E6E51D2C03A227163F5BB9BD0C8A6F00000000000000000000000000000000000000003554AC35DDD8474E9CD8B2676F37A39155C0000000000000000000000000000000000000000010513D5EBA5CDC58F3EF16CC8AAE0000000000000000000000000000000000000000006BD9A515FB1BD595E457680000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001FFC40002FFDA000C0301000200030000002100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000104100000000000000000001CF3D04000002178938E38E38111D84000000000000534000173DBE9BC0FBD0ABDB8EDDB810000000000000000313AFF7F09F3CEF8F4918627A10000000000000000000000002D608208208281D0820AD00000000000000000000000000003FFC208209978208208B000000000000000000000000000000BFA0820AC7C20820B800000000000000000000000000000000A9C2E130820820B500000000000000000000000000000000037C93C0820820B500000000000000000000000000000000000E0C2082082E08000000000000000000000000000000000000B35082099100000000000000000000000000000000000000556F826D50000000000000000000000000000000000000007BF2F77800000000000000000000000000000000000000378023A600000000000000000000000000000000000000002B0B950000000000000000000000000000000000000000002CFF00E00000000000000000000000000000000000000000003254000000000000000000000000000000000000000000012C000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000FFC40002FFDA000C03010002000300000010F3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF31C71F3CF3CF3CF3CF3CF3CF22E71D7CF3CF396D3CB0CB0C452EF73CF3CF3CF3CF3DF7CF3DB898F163CC81F4628DB3633DF3CF3CF3CF3CF3CF306118D17420D04D1995B84504F3CF3CF3CF3CF3CF3CF3CF3C2C5FBEFBEFBE7E1FBEF91F3CF3CF3CF3CF3CF3CF3CF3CF3CF2A43EFBEFA5B7EFBEFB7F3CF3CF3CF3CF3CF3CF3CF3CF3CF3C4EEFBEF8683EFBEF96F3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF1CD3E058FBEFBEFB9F3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3C500C98FBEFBEFA7F3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF38DFEFBEFBE0C9F3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CAC8FBEFA5A3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CE2C07E9ECF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3C2C87CAD7CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF21F7E453F3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF1BF807FCF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF2C136F3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF0C03CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3C6A7F3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CF3CFFC4004611000103020106070C080407000000000002010304000512061113212232203140415152A210144244616272819293C1D1233033435491A1E11582B1F0245370718083C2FFDA0008010201013F00FF008536D38E32DB490189A3D93CFCD9F9EA5E4AB07B519DC3E45DA1A9765B8C5D66C620EB8ED270AD76A913DDCC9B2D8EFB9576B03230C4A286DB5C7E7A7CEAC2FC396CE85D61AD307989B43D35DE30FF000CCFBB4AEF087F8667DDA5778C3FC333EED2BBC21FE199F7694B0A1278B33EED29F7EC2C7DA6833F420E75FD2A45F6D63A98B681FA4823522E6F3DBACB0DA798DA52AAAAE75FAEB5E50C4186C84A3C2E06ADD55CF497FB42F8C764A9F3C9E9DBE6C62EBE2C0552ACB0F7A2DC595F30CD3FAA53B19E6B787D68B887F34EE5A2CAECE3C67B0CA76BC834C30DB0D8B4D06101EE5DE1396D98DCE8DA814BF22F92D409CDCE8C0F0F1F843D0B4F4C8D1D33BAFB43E953F94F6F6B3A3626EFA3A93B55232A669EA69B004F6969F9F3247DABE65EBD5F5AC3EEB0E83AD96121AB64C87736B3934D69137C337EA94B0202F1C46BD81A2B55B4BC49AF65296C56A5F161F6969727AD4BE2DDA2F9D164CDB4B891D4FE6A2C95B7AFDEBA9FCC9F2A3C938FE04873F4A5C931445FF19D8A896C29734E3B0E6211CFF499B56AE7A4C9EBB369842722227419257F06BF8EECEED952DBB294789F35FF00B29F859444C98BC464DF859CC569B9525912169E3042E3C2B9A9549573AAF218D25E8CF03AD16624AB6DC9AB8318877FEF03ABC3CA19E916268817E95DD9F573D582077A42122FB57368BFDB993817777456D925E610FE7AB924396F437C5D69732A76BC8B56EB8B53D8D2071F843D5E0998802996A44A8C0579BC9BA5F60D7F44E24F5F07299D50B690F5DD11F8FC392C29AF427D1D697D21E624E85AB7CE66747171BE34DE1E8E0652CFD133DEA1BEEEF7A3FBD592077941012DF3DA738395AEEB8AD7A45C9ADD707A0BE8E36BABC30E624A8535998C8BCD96CF38F47917B8F3E0C32E38E6E055A993BA5D8E5BBB81AFE49EAE165339A4B910F50053E3C9EDB727A03F8C7680B7C3A52A24B665320EB45884BF4ACA69CAAADC16B78B3693E0356A8230A18349BFF79E970AE8E696E12897FCD5ECEAE516CBA3F01EC43B4D96F8558631CE9CF4E7B890B57A5FB709E745B65D70BC01A2555225E5369BABB6F7BACD16F87C69979B7DA075A2C405C0330005235CC957ABE1CB526185CCCA71975FF6E5563B53332DEFABA3ACCF30AF4614E3A892A559262B0FA6260FFBC434DB80E0038D9E303EE198340A66B9812AF57B2984AD33A994ED7EDCAECEC682DD14578F067F6B6AAE16E6A74756DCE3FBB5EAD409B26CF2D62CA42D162FEC87C944FB22CE995CFA3E3D255E6F4734F44D6C329DAF2AF2B88C2BF258693C3752913322772F1062CA8A6AE9E050DD73AB452A42B1DEFA6256C4B779664CB1A4B889F3340ABFF9EE3CF34C346E3878006AEF78767B984765A1DD1EB795796E4A31863C87FAE787D9A7E4371DA375D73080D5DAEEECF77AAD0EE87C579741266DF6860DE3C22818FD65B59AAE9757A7BBD5687703E2BCB830E31C5C5571B9BD39C452D96C7500747FAABFFFC4004111000102030208080D020700000000000002030400010512220611132021324052101431427292A2B2303341445361627191C1D1E1F0518115547080A1B1C2FFDA0008010301013F00FEC671CB831CBC354535C9B112076540BC3F486D84AE02EB84EDF64A1AD65838D02B592FD0AEE754AA88B24F794E68452EB6AF1B2E325715ECFDA2B6DDCB5572A9AAAE48FDAD5F5471B73E9D5EB4E38DB9F4EAF5A71C6DCFA757AD38E36E7D3ABD69C71A75E995EB4E106D575FC5C95F8C2142A8CFC73D21F74E650852504B59554FA45381190CB14BC16397EB9950A0BB9B9326C9DA4CBDA944E8954979BF76109571A6A038EADA186F59792C5274C55E908CFF00D422ED15F50BE374B82AB580663934EF2BDDF7C2CB28BA84A195A328D314A749D41A9B271AFF00F3F5943E666D1C1245FB422D1C2D3C492265FB421838FD5D2A584BF3D50860D350D2AA867D984183343C5A003E15741370912672BA515066EE9EB59B6563987127AEE5C8BABD69C0D49F8F9CABD69C0D62A72F3938957AA92F38ECCBE9038455297383AB12C267D2E6A5D5FBC4B0A1D79504BFCC0E1417F2DA7A50E6A526ACC17553BE5CC89D7698658CD8E9E8CA3F8B50E7CAC7B231C7F07A7CADBB3083AC1F1580931B27D12855AB65884D444088792242232C5296C2E9AA4E9224D41BB151A7AAC95B25A9CC3DECFA131939776CB512BDF48AD3EE34ECA43A81743329A9E51FB61F6C76478D12768924A43E62AB35F26A4B47927BD9A02465211E59C3821A4D24511F1AAFE4FE19B83895BA8896E0117CB657AC927884D3525EE9EEC3D66AB358933CCC1F63955E6E14D44BBDF68ABBD9BB76452D40BA19B82C9E972AF447667F4F49EA530395FE61EEC3B68AB45493506F7022912AA0261AC515230A6D301A25AE7F93CEC1C4AC30B7BE78FE5B3D469C93D4ACCE57C750E1C3755B2A49A836486307D98CA46F15D50D4F9CE2A4EC9DBB3567C9CCE8E752D2C953DB0FB1DED3B454A9893E4F7541D438AD2E0CD922C91E59F77EF9C926466012E74E006400232DA6AB4C4DEA5A2EAA3A87F28552510508141B26398024656479628F4516D215D696357BBB556EA4AB5A823932D001A65D2872D9BD65A65D0BAA8FE592851324C880C6C98F00012856465A628F4616A32596D2ACFB3B5D517CBBF725E4B7DDD10C1F2ACD7CA0727965BD0F1A37AB36E34DFC6FE689FAE0515495C9482FC5228E0D064A2B7959F676B78AC906AB2BBA1389E99CF8294F1CB572324A56A45CCDE8068DF2DC63238942DB308D6B0C2C6F9CA5C0924A2AA0A60368CA295484D905B3BCA9767DDB6E13AF8DCA296E877A104145D414931B46514AA526C93C73BCA973FE9B73D92AFAA8B8A436888FBB762994B49927BCA16B9EDCA5BC9959D68A75352641BCA16B9FF557FFC400371000010301020B06050501010000000000020103040011120513213031324150515391101415205271226162A1B1234042438190A0FFDA0008010100013F02FF00C49C8912233FC41745B4D61364B5914684C4D2D1245CF1108A2AAAD894F6113575317AA8BD69A705D0431DB5352432791D3B8BA32D63DFE71F5AEF0FF38FAD7787F9C7D6BBC3FCE3EB5DE1FE71F5AEF0FF0038FAD7787F9C7D6BBC3FCE3EB5DE1FE71F5AC7BFCE3EB58F7F9C7D6B1EFF0034FAD63DFE69F5AC7BFCD3EB48F485D0E38BFEAD031840FF0091A7B950427BF9CA73FC5A06D03692FBADBFBB9CC63595E29953B048816D1254A6F09BC3AD615353E39FF2BABF3AB6DCD38E0362A44B92A54B37D780F0EC832712774B5569E685D6D4169D6C9B3502D99B08CF9EAB6B4182DC5D7344A0C1D1C74A5EF7A10114F84513F7F358C53CBC172A791B79D6F50D529AC285FD816FB5352D87341E5E1E77DF0646F153F20DF2B4B46C4F260E95793145A53454E8D8E0BC3AE9E716CCF545568306C82D360D060B6935C94BED411D96F541371C88C3205117258B4B82539BF6A5C127CDFB52E0A7BD635E1927E9EB4B83A57A3EF5DC6527F5537E20CE813B38596D3739CFED60D3E68940E01A7C2BDB2650303974EC4A75D374AF12F94494490934A5467D1F6D0B6EDAC2316EAE34742E9EC44B7425041927FC2CF7A0C15EB73A50428C1FD76FBFEFA6444792D4D74A557056CB551691E7B985D6BBCC8E6975AEFB2B9AB5DFE5F33EC95E252B8A74AF1491C02BC55DF40D78B17293AD78B2727EF5E2ADF2CABC518F49D78946F9F4AF118BEBFB2D77E8BCD4AEF71B9A358F617FB43AD6303D49DA519835B481156BB8C5E525787C4E5FDD6BC3A2FA57AD78647FABAD785B1EA3AF0A67D6751E12307689AFCD2885091515322D060E8E3B14BDE81B004F84513DB714D878E4BC3AE9F7A54545B17F63098C4B3974AE55A9D2489EB0495106B1EF734FAD77A91CD2AEFB2B9AB5E212BD7F64AF1293F4F4AF1491C02BC55DF40D0E1422244C5695E3B9A6C3C6FC61AFF9FD840631AEDABAA3531FC4B2BC572266618DE92D7BDBB9E6C2BFFA8DA7C5B538E7AC55C95159465941DBB6A6BF8D797D29913338307F5D5780EE89D0AF5AE369976A67706B17DCC62E81FCD4F7F14CD89AC593358247E174BE689BA6742D2EB69EE99B11522444D2B4CB62CB423C2A53D8E794B66CCD60E1B230FCF2EEA9D0ACB5D6D3DD3358318CAAEAFB256117EE35713497E3371C6EB2DA7D29BAE742B96B8DA64DA9986DB270C4536D088B4DA26C14A90F2BCE91F4CD36378C078AA6ED9B0F17F186AEDF979F063160ABABB747B56137EE8A349A574FB66E08DE94DF5DDAA96D4D878A5BE1A9F8F2B0D2BAE8875A55169BE08294EB8AEB846BB73782C6D78CB80EEE54454B16A6445656F0EA7E3C98398B8DDF5D25F8AC26FE8693DD7398287F4DC2E25BBC85092C54C952E2AB056A6A2F644631CF20ECDB4E98B4DA92E844A33533225D2B9CC1E376287CF2EF0301315124C8B52A29305F4AE85A82C6299CBAC5956B09BF692349B34E75A1B8D80F014DE2402496125B4FBA8D34474AAA4AAABA5738D0DE75B1E249BCDC6C5C05124C8B5263130766CD8B9B115254444B56A1C34652F16BFE37A3AD03A0A254FB06C1DD5D1B17322244B62265A8910584B5729EF474EE3645C12A14DB9FA6E2E4D8BC29E641E0BA54FB04C9DD2F380119208A5AB51220B036E92DABBD7091DD8F67A96CEC8336CB1A717D969F601F0BA5FE2D3AD1346A25E500270904532D458A2C0FD5B577B6153B5C00E096F6C19BA1A717D96A4C717C2C5D3B169C6C9B35124CBDADB64E1208A65A8D14181FAB6AEF79677E438BF3B3A7920CDBDFA6E2FC5B178D4A8C2F87D5B168C080944932D36D9BA6822951A303036269DABBDDD3B8D99704F342998C4C59EB7E6A5C447C7812685A8F1C180B134ED5DF1848EEC7B3D4B6799969C71C440EBC28515051156D5DF3854ED300E096F95964DE3BA3D69860190BA3D77D4B3BF25C5F9D9D3C8C306F9DD1FF00569964190BA3BE9D2B8D91704F2478E6F9589A36AD34C834174537DE113BB1D53D4B676C78C6F964D1B569A6C1A14114C9BF30A9FC6D8704B7B234537CBE9DAB4DB62D8A08A64DFB30EFC9717E7674A8B149F2FA76AD00080A08A589BF5C3B8045C12A2C539056AEADB956800405045326FE75BC60282EDA111144444C9FF4ABFFC4002C1001000102030606030101010000000000010011213141513050617191F0102081C1D1F140A1E1B190A0FFDA0008010100013F21FF00C33D77638071A3FC56500678DC94A0351AED8DB062B162CC37BE259612ABC4B76DC27DEE7DAE7DAE7DAE7DAE7DAE7DAE7DAE7DAE7DEE7DEE7DF67DF67DFE2F453834CABF18FECCF4E084C338E7FF005F97631DE53C2AC0706929411E8CA28F016C00A8EC8D9026631C3DEF85D4BF7E0EB305573D1D60F975D767979D5B7FB2F9C82F2FE8B8A51C06814FCFC0DDE53C88D78065D20EC1C563D251C2E259879AAF7919B2B5BF44F25CDB57EA4B2166DC4D3CB7F07FA79597C21C5ABFA973FD32615DD697EB29F935D8B4AAA824C8391602323FB621AFB7080C03C84714BA8C5D4851984E2A69D255557F4F4F1A9AE7EACBED39191E55C689521D38068CB1B73D2EBE0AE88BA134975B6677A47E661A16B74002814FCDC17859D78311B11A257080C3AF817CE807F081406A707F11F9866A4333BBCA198A4CDFD13EA8F986B18173F670827F4827CF0C274104C3AD047C38C1C629F231EC1EF1FED22B07FB87C4D2FD5F1103625CC1953B05122F57987C4A101E0A6E2053A07D220044B272FC1A651DE522AB73B34AB9C0F0EB607F340BE0203958039A83F8CC335A529AC1B9944859DBD62228944CB6F492CD79E44241DCDF63487617DCF7BD80EBB6100C6B40E739EA73CB51ED17635BBE3BA3984EBF1E7B5AA0E845F0C872CDD9730741BA7B83E26CC37AA50861CB77573669D6DCA6CAAED6FB37565431D3E26CAA8587F565FBCBE59B67C1FDD6547F89B8F2D86336FA42E5B19CA2130C390D970316EC4ADA57277E0ED879E8C6F6CAA2737667040BD06ED0089522305DDBD3CA68C1E808D5F65099F0BA1B3E581D5FE6EE76151C6536553F4F25BF9B1DF6E1B4A5A40E8437727328B931629674E0F85422DBF293B4E584C6CDABB4F54BA9DE00410A24D67F50CA723B0095136BB9DDAF0D074378D04068C74645B9C73AA957D769DD82BBCEA44C49592EF6754AC3626261177FC1BD013A8FEB8C73EE83620EB9604C7205DD381BD38DFBD23AC4717B5A332B64E8EB12072724F3D4004AA177E837AD5743EEF0CAC61A7C18E7DC060477C9C935F2D7A0A6BE7F41BDBB493E35B10C3DB660C8FA529EE1E353B2949175BDDEEFB0792C7B8DD669A1F44A0C04AE197F53158FD5DEE0CE7BD22AB573F20DED298B6E0C55C53E90CC75AE63BE2A3A0F779B1D22FEE4A4082EEBBE7B183E5341CF2042C1CF32EFAE117B0F25185BD02183E6E6BBE853CF7A45555CFC724EF4616A63F6EFBD640F778D2761851AC37E550662F5F0A4CB0FA494FB0DFBA407B099B83F4129E032DFA4B673D229AE7AC70200001637F1B8428AD3486D80583FE957FFC4002C10010002000405030500030101000000000100112131415150617181C11030B12091A1D1F040E1F190A0FFDA0008010100013F10FF00E19AC94964B2592C964B2592C964B259B930DE61BCB37986F30DFF00CB1E5090E1772DC0D99CDD8FCB20D73D10FC7BB86103B8DE080258B678CF43C86C4BC05C37371E64437CAB9ED5FBB1861861861861C71DE7A1F595D31107B0CA96C75F270307F81CAB0FA5354CF655FE563193775F6B3EE251A439B84CBF139CB998E96D5F2CA14022588D8FB59ED517E0941C4A45DB1F0C98D9967468C2E6C7019E809420A97A0D1393EDD0B699057EF59543F637F012A773BC4510F6DFA1F884657F8787B0910657FDFC64CBF4CD47BC56FAAC194A737FF22529D75FDA9898C72CFD6DA225E8FCDD8261502E8C9F2EEFD147671C397E4878A14EFD69A6D129332130F4B82B695CDF2D07574957AA921589750F809589EC8DBEE6301FE4D6EAC966F2C964BFA6BAE021764C62F2FD43E499C9EB5F2C067FAA7C332C7A4BC89FC6CF9A4CE0F4F8CCC19235546C675309BC91EE459288B708875549EB906B819F33B116E9CC80D83D32F563642EC928C01FCDD1967A59357D055DB2055EC4AE4E7093C16EFE441C772FFB30F04190601FE6E12F96460BAF56428990FE83E6653DD6F96652BD45F24CF2FD7F54367D40F1019B7F5A417F18A4367BA23CA69E740F823F2FD1507CC227E7D5C6605D64CACBA83E4991F789F333C9D1E6777A16196316376AD0C678303E18AFD646E45D3CECD187486E41D3CD0AF992AFAC04723B90CA388C918F175D9FA293923C0F8702189DB09AA3E9350523987D6FDABF4B36F443D55EE9B764BAF05DBB14C9CCF2BEEB7E6657DC7F92675D67889F393F560B34EDF986FC5291AEE9B5AD7A7AE1C0C8781C4D09A7831DE2294523B7BC985CC57E9DA6463EBB62E7D9155B5B7D8E4EFE2BC1492F065532A581961116C44C13DD22550016AE8941CB971AB96EBEDFE4D6561F592F8306079F0731395C0FB47A12BDBC555EB6B1655EDE4FB414FF00552BE783B2A22E35997E654FB540410E6C46C0FCB091C25FF6577F6581AFBDF7A7C70A458D6C477140BF672F6BC42C206ADF51ED119D2933D431E13B6330466741C44CFB3D8035650766ABC83189D18EAD0C4ACBA5134BA651ED1D259F7D42050070B20A2C4C63B3AD63AE0FA32F44CC5B941F2930401E887CBEDD052D572B93868564111C9366594334336FF2A5FD16F225A3AA626EB243439133EEBC2FA2763DB4D03B67F5439F0D01E240E223A31223BB3DDCB67E87C08226E68941B678616FDB1D4BB0DDE60E1A1818C7B0A10B1257A79E6FF8A7D13FE51D77653B17ABF00EB947A6D3FA0E465EE05B292DDCA837C3EED0C5924D78E9587353BA1E122652BCECA3DDC22F990388B069468B2C6C947FA5DDE011FB22FBAADF730A2C03D11703025F110946A0C5AEBD774D9E67B694A888B5609AB970389AE4E30888F0DD681DE1236ADD3FDDB9ECB9E6D04315F22C41AAE267547E4C40CB5F9C6CB16CA589E7A02733F7DF47A67F4A765E0130303C8CBC1C56AB71ED063F8F4B189E94F63428A93103AA257D4E21D00FA523372F2EC7383322E4FF00C09A715A03265D5D789A4B88B7A273DA4BF30A39A8995FD9344751F57A4EEC1AABA10CE05C6317F4717C44C0A7A7A23532611DA09A76606181D76F9B93127674EBE2280CD3A0D55D095D428B18AE2F90C7D8D71322AAD5D5FA100A446C471180421E3E93CC08A2629FC10C6405CC5E30FADFF6BB7D3892CB4610500399944912B0B062D1BC78BD4A53255D5D1F1EB97A7F71657FAD6735BB774F1959B715BA7D111A411D17F7B129F2669DC3C6B254FB0AE3B6AAB5DD997A051AA1D21E5D8952B335CCDDDDE375E35E52FC12B07D2A9AF36CE46EC175F78BBB2CC78DE843AA1D1F13498C17E57FD18144B807CBC7576A0E93B0A2F14DB8E8137E399192FD9710615B5DE6C2AE0E03038EE151B09079908A1D6AA52D958200FF00D2AFFFD9);
GO
CREATE TABLE Schedule(
  Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  StartTime TIME NOT NULL,
  EndTime TIME NOT NULL
  );
GO
CREATE TABLE Trainer(
    Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Code VARCHAR(20) NOT NULL,
    [Name] VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Dui VARCHAR(10) NOT NULL,
    DateOfBirth DATE NOT NULL,
    Age VARCHAR(3) NOT NULL,
    Gender VARCHAR(20) NOT NULL,
    CivilStatus VARCHAR(20) NOT NULL,
    Phone VARCHAR(9) NOT NULL,
    [Address] VARCHAR(100) NOT NULL,
	[Status] TINYINT NOT NULL,
    CommentsOrObservations VARCHAR(100) NOT NULL,
    DateCreated DATETIME NOT NULL,
    DateModification DATETIME NOT NULL,
    ImageData VARBINARY(MAX) NOT NULL,
    );
GO
CREATE TABLE Course (
  Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  Code VARCHAR(15) NOT NULL,
  [Name] VARCHAR(100) NOT NULL,
  ExternalFee MONEY NOT NULL,
  ScholarshipFee MONEY NOT NULL,
  StartTime DATE NOT NULL,
  EndTime DATE NOT NULL,
  MaxStudent INT NULL,
  [Status] TINYINT NOT NULL,
  DateCreated DATETIME NOT NULL,
  DateModification DATETIME NOT NULL,
  IdSchedule INT NOT NULL FOREIGN KEY REFERENCES Schedule(Id) ON DELETE CASCADE,
  IdTrainer INT NOT NULL FOREIGN KEY REFERENCES Trainer(Id) ON DELETE CASCADE
  );
GO
CREATE TABLE Student (
    Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    StudentCode VARCHAR(6) NOT NULL,
    ProjectCode VARCHAR(6) NULL,
    ParticipantCode VARCHAR(5) NULL,
    [Name] VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    DateOfBirth DATE NOT NULL,
    Age VARCHAR(3) NOT NULL,
    ChurchName VARCHAR(100) NULL,
    [Status] TINYINT NOT NULL,
    ImageData VARBINARY(MAX) NOT NULL,
    DateCreated DATETIME NOT NULL,
    DateModification DATETIME NOT NULL
);
GO
CREATE TABLE CourseAssignment(
  Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  IdStudent INT NOT NULL FOREIGN KEY REFERENCES Student(Id) ON DELETE CASCADE,
  IdCourse INT NOT NULL FOREIGN KEY REFERENCES Course(Id) ON DELETE CASCADE,
  DateCreated DATETIME NOT NULL,
  DateModification DATETIME NOT NULL,
  );
GO