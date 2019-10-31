ì
LD:\Cliente XM\IntegrationOracle\Common.Utils\AutoMapper\SettingAutomapper.cs
	namespace 	
Common
 
. 
Utils 
. 

AutoMapper !
{ 
public		 

partial		 
class		 
SettingAutomapper		 *
{

 
public 
static 
void 

CreateMaps %
(% &
)& '
{ 	
Mapper 
. 

Initialize 
( 
cfg !
=>" $
{ 
cfg 
. !
CreateMissingTypeMaps )
=* +
true, 0
;0 1
cfg 
. 
ValidateInlineMaps &
=' (
false) .
;. /
} 
) 
; 
} 	
} 
} ¯
>D:\Cliente XM\IntegrationOracle\Common.Utils\Constant\Const.cs
	namespace 	
Common
 
. 
Utils 
. 
Constant 
{ 
public 

struct 
State 
{ 
public		 
const		 
string		 
Successfull

 
=

 
$str

 #
,

# $
Pending 
= 
$str !
,! "
Error 
= 
$str 
; 
} 
} ƒ
@D:\Cliente XM\IntegrationOracle\Common.Utils\DTO\FtpParameter.cs
	namespace 	
Common
 
. 
Utils 
. 
Dto 
{ 
public 

class 
FtpParameter 
{ 
public 
string 
FtpPath 
{ 
get  #
;# $
set% (
;( )
}* +
public 
string 
FilePath 
{  
get! $
;$ %
set& )
;) *
}+ ,
public		 
string		 
FileName		 
{		  
get		! $
;		$ %
set		& )
;		) *
}		+ ,
public 
string 
Username 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
Password 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
bool 
	KeepAlive 
{ 
get  #
;# $
set% (
;( )
}* +
public 
bool 

UsePassive 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
bool 
	UseBinary 
{ 
get  #
;# $
set% (
;( )
}* +
} 
} ³
:D:\Cliente XM\IntegrationOracle\Common.Utils\Enums\Enum.cs
	namespace 	
Common
 
. 
Utils 
. 
Enums 
{ 
public 

class 
Enum 
{ 
public		 
enum		 
State		 
{

 	
Successfull 
= 
$num 
, 
Pending 
= 
$num 
, 
Error 
= 
$num 
} 	
} 
} †
KD:\Cliente XM\IntegrationOracle\Common.Utils\Excepcions\BusinessExeption.cs
	namespace 	
Common
 
. 
Utils 
. 

Excepcions !
{ 
public 

class 
BusinessExeption !
:" #
	Exception$ -
{ 
public 
BusinessExeption 
(  
)  !
:" #
base$ (
(( )
)) *
{+ ,
}- .
public		 
BusinessExeption		 
(		  
string		  &
message		' .
)		. /
:		0 1
base		2 6
(		6 7
message		7 >
)		> ?
{		@ A
}		B C
public 
BusinessExeption 
(  
string  &
message' .
,. /
	Exception0 9
inner: ?
)? @
:A B
baseC G
(G H
messageH O
,O P
innerQ V
)V W
{X Y
}Z [
	protected 
BusinessExeption "
(" #
System# )
.) *
Runtime* 1
.1 2
Serialization2 ?
.? @
SerializationInfo@ Q
infoR V
,V W
System 
. 
Runtime 
. 
Serialization (
.( )
StreamingContext) 9
context: A
)A B
{ 	
}
 
} 
} °
>D:\Cliente XM\IntegrationOracle\Common.Utils\JWT\JwtSetting.cs
	namespace 	
Common
 
. 
Utils 
. 
JWT 
{ 
[ #
ExcludeFromCodeCoverage 
] 
public 

sealed 
class 

JwtSetting "
{ 
public 
string 
	SecretKey 
{  !
get" %
;% &
set' *
;* +
}, -
public

 
string

 
Issuer

 
{

 
get

 "
;

" #
set

$ '
;

' (
}

) *
} 
} î

LD:\Cliente XM\IntegrationOracle\Common.Utils\Swagger\SwaggerConfiguration.cs
	namespace 	
Common
 
. 
Utils 
. 
Swagger 
{ 
public 

class  
SwaggerConfiguration %
{ 
public		 
const		 
string		 
EndpointDescription		 /
=		0 1
$str		2 P
;		P Q
public 
const 
string 
EndpointUrl '
=( )
$str* D
;D E
public 
const 
string 
ContactName '
=( )
$str* 7
;7 8
public 
const 
string 

ContactUrl &
=' (
$str) A
;A B
public 
const 
string 
	DocNameV1 %
=& '
$str( ,
;, -
public"" 
const"" 
string"" 
DocInfoTitle"" (
="") *
$str""+ E
;""E F
public'' 
const'' 
string'' 
DocInfoVersion'' *
=''+ ,
$str''- 1
;''1 2
public,, 
const,, 
string,, 
DocInfoDescription,, .
=,,/ 0
$str,,1 a
;,,a b
}.. 
}// Î
ED:\Cliente XM\IntegrationOracle\Common.Utils\Utils\ExtendedMethods.cs
	namespace 	
Common
 
. 
Utils 
. 
Utils 
{ 
public 

static 
class 
ExtendedMethods '
{ 
public 
static 
string !
ToStringDateFormatted 2
(2 3
this3 7
DateTime8 @
?@ A
dateB F
)F G
{ 	
return 
Convert 
. 

ToDateTime %
(% &
date& *
)* +
.+ ,
ToString, 4
(4 5
$str5 A
)A B
;B C
} 	
public 
static 
string !
ToStringDateFormatted 2
(2 3
this3 7
DateTime8 @
dateA E
)E F
{ 	
return 
date 
. 
ToString  
(  !
$str! -
)- .
;. /
} 	
public"" 
static"" 
string"" %
ToStringDateTimeFormatted"" 6
(""6 7
this""7 ;
DateTime""< D
date""E I
)""I J
{## 	
return$$ 
date$$ 
.$$ 
ToString$$  
($$  !
$str$$! 6
)$$6 7
;$$7 8
}%% 	
}&& 
}'' 0
AD:\Cliente XM\IntegrationOracle\Common.Utils\Utils\FileService.cs
	namespace 	
Common
 
. 
Utils 
. 
Utils 
{

 
public 

class 
FileService 
: 
IFileService +
{ 
public 
bool 
CreateCsvFile !
(! "
string" (
filePath) 1
,1 2
string3 9
fileName: B
,B C
stringD J
dataK O
,O P
boolQ U
encodingV ^
)^ _
{ 	
try 
{ 
if 
( 
! 
	Directory 
. 
Exists %
(% &
filePath& .
). /
)/ 0
	Directory 
. 
CreateDirectory -
(- .
filePath. 6
)6 7
;7 8
using 
( 
StreamWriter #
io$ &
=' (
new) ,
StreamWriter- 9
(9 :
Path: >
.> ?
Combine? F
(F G
filePathG O
,O P
fileNameQ Y
)Y Z
,Z [
encoding\ d
)d e
)e f
{ 
io 
. 
Write 
( 
data !
)! "
;" #
return   
true   
;    
}!! 
}"" 
catch## 
(## 
	Exception## 
ex## 
)##  
{$$ 
return%% 
false%% 
;%% 
}&& 
}'' 	
public)) 
void)) 
SendFileToFtp)) !
())! "
string))" (
filePath))) 1
,))1 2
string))3 9
fileName)): B
,))B C
string))D J

keyPathFtp))K U
,))U V
string))W ]
username))^ f
,))f g
string))h n
password))o w
)))w x
{** 	
try++ 
{,, 
FtpParameter-- 
ftpParameter-- )
=--* +
new--, /
FtpParameter--0 <
{.. 
	KeepAlive// 
=// 
false//  %
,//% &

UsePassive00 
=00  
false00! &
,00& '
FileName11 
=11 
fileName11 '
,11' (
FilePath22 
=22 
filePath22 '
,22' (
FtpPath33 
=33 

keyPathFtp33 (
,33( )
Username44 
=44 
username44 '
,44' (
Password55 
=55 
password55 '
}66 
;66 
SendFileToFtp88 
(88 
ftpParameter88 *
)88* +
;88+ ,
}99 
catch:: 
(:: 
	Exception:: 
ex:: 
)::  
{;; 
throw<< 
;<< 
}== 
}>> 	
private@@ 
void@@ 
SendFileToFtp@@ "
(@@" #
FtpParameter@@# /
	ftpParams@@0 9
)@@9 :
{AA 	
FtpWebRequestBB 

requestFtpBB $
=BB% &
(BB' (
FtpWebRequestBB( 5
)BB5 6

WebRequestBB6 @
.BB@ A
CreateBBA G
(BBG H
	ftpParamsBBH Q
.BBQ R
FtpPathBBR Y
+BBZ [
	ftpParamsBB\ e
.BBe f
FileNameBBf n
)BBn o
;BBo p

requestFtpCC 
.CC 
MethodCC 
=CC 
WebRequestMethodsCC  1
.CC1 2
FtpCC2 5
.CC5 6

UploadFileCC6 @
;CC@ A

requestFtpDD 
.DD 
	KeepAliveDD  
=DD! "
	ftpParamsDD# ,
.DD, -
	KeepAliveDD- 6
;DD6 7

requestFtpEE 
.EE 

UsePassiveEE !
=EE" #
	ftpParamsEE$ -
.EE- .

UsePassiveEE. 8
;EE8 9

requestFtpFF 
.FF 
CredentialsFF "
=FF# $
newFF% (
NetworkCredentialFF) :
(FF: ;
	ftpParamsFF; D
.FFD E
UsernameFFE M
,FFM N
	ftpParamsFFO X
.FFX Y
PasswordFFY a
)FFa b
;FFb c
StreamReaderGG 
strmLecturaGG $
=GG% &
newGG' *
StreamReaderGG+ 7
(GG7 8
	ftpParamsGG8 A
.GGA B
FilePathGGB J
+GGK L
	ftpParamsGGM V
.GGV W
FileNameGGW _
)GG_ `
;GG` a
byteHH 
[HH 
]HH 
bInfoArchivoHH 
=HH  !
EncodingHH" *
.HH* +
UTF8HH+ /
.HH/ 0
GetBytesHH0 8
(HH8 9
strmLecturaHH9 D
.HHD E
	ReadToEndHHE N
(HHN O
)HHO P
)HHP Q
;HHQ R
strmLecturaII 
.II 
CloseII 
(II 
)II 
;II  

requestFtpJJ 
.JJ 
ContentLengthJJ $
=JJ% &
bInfoArchivoJJ' 3
.JJ3 4
LengthJJ4 :
;JJ: ;
StreamKK 
strmRequestKK 
=KK  

requestFtpKK! +
.KK+ ,
GetRequestStreamKK, <
(KK< =
)KK= >
;KK> ?
strmRequestLL 
.LL 
WriteLL 
(LL 
bInfoArchivoLL *
,LL* +
$numLL, -
,LL- .
bInfoArchivoLL/ ;
.LL; <
LengthLL< B
)LLB C
;LLC D
strmRequestMM 
.MM 
CloseMM 
(MM 
)MM 
;MM  
FtpWebResponseNN 
responseNN #
=NN$ %
(NN& '
FtpWebResponseNN' 5
)NN5 6

requestFtpNN6 @
.NN@ A
GetResponseNNA L
(NNL M
)NNM N
;NNN O
responseOO 
.OO 
CloseOO 
(OO 
)OO 
;OO 
}PP 	
}QQ 
}RR Ì
BD:\Cliente XM\IntegrationOracle\Common.Utils\Utils\HeaderClaims.cs
	namespace 	
Common
 
. 
Utils 
. 
Utils 
. 
	Interface &
{ 
public 

class 
HeaderClaims 
: 
IHeaderClaims  -
{ 
public 
string 
GetClaimValue #
(# $
string$ *
authorization+ 8
,8 9
string: @
claimA F
)F G
{ 	
var 
handler 
= 
new #
JwtSecurityTokenHandler 5
(5 6
)6 7
;7 8
string 

authHeader 
= 
authorization  -
.- .
Replace. 5
(5 6
$str6 ?
,? @
$strA C
)C D
.D E
ReplaceE L
(L M
$strM V
,V W
$strX Z
)Z [
;[ \
var 
	jsonToken 
= 
handler #
.# $
	ReadToken$ -
(- .

authHeader. 8
)8 9
;9 :
var 
tokenS 
= 
handler  
.  !
	ReadToken! *
(* +

authHeader+ 5
)5 6
as7 9
JwtSecurityToken: J
;J K
Claim 
	claimData 
= 
tokenS $
.$ %
Claims% +
.+ ,
FirstOrDefault, :
(: ;
cl; =
=>> @
clA C
.C D
TypeD H
.H I
ToUpperI P
(P Q
)Q R
==S U
claimV [
.[ \
ToUpper\ c
(c d
)d e
)e f
;f g
return 
	claimData 
!= 
null  $
?% &
	claimData' 0
.0 1
Value1 6
:7 8
string9 ?
.? @
Empty@ E
;E F
}   	
public'' 
string'' 
GetUserNameAuth'' %
(''% &
string''& ,
authorization''- :
)'': ;
{(( 	
var)) 
handler)) 
=)) 
new)) #
JwtSecurityTokenHandler)) 5
())5 6
)))6 7
;))7 8
string++ 

authHeader++ 
=++ 
authorization++  -
.++- .
Replace++. 5
(++5 6
$str++6 ?
,++? @
$str++A C
)++C D
.++D E
Replace++E L
(++L M
$str++M V
,++V W
$str++X Z
)++Z [
;++[ \
var,, 
	jsonToken,, 
=,, 
handler,, #
.,,# $
	ReadToken,,$ -
(,,- .

authHeader,,. 8
),,8 9
;,,9 :
var-- 
tokenS-- 
=-- 
handler--  
.--  !
	ReadToken--! *
(--* +

authHeader--+ 5
)--5 6
as--7 9
JwtSecurityToken--: J
;--J K
var11 
	claimData11 
=11 
tokenS11 "
.11" #
Claims11# )
.11) *
FirstOrDefault11* 8
(118 9
cl119 ;
=>11< >
cl11? A
.11A B
Type11B F
==11G I
$str11J U
)11U V
.11V W
Value11W \
;11\ ]
return22 
	claimData22 
;22 
}44 	
}55 
}66 ð
LD:\Cliente XM\IntegrationOracle\Common.Utils\Utils\Interface\IFileService.cs
	namespace 	
Common
 
. 
Utils 
. 
Utils 
. 
	Interface &
{ 
public 

	interface 
IFileService !
{ 
bool 
CreateCsvFile 
( 
string !
filePath" *
,* +
string, 2
fileName3 ;
,; <
string= C
dataD H
,H I
boolJ N
rewriteO V
)V W
;W X
void 
SendFileToFtp 
( 
string !
filePath" *
,* +
string, 2
fileName3 ;
,; <
string= C

keyPathFtpD N
,N O
stringP V
usernameW _
,_ `
stringa g
passwordh p
)p q
;q r
} 
}		 ¦
MD:\Cliente XM\IntegrationOracle\Common.Utils\Utils\Interface\IHeaderClaims.cs
	namespace 	
Common
 
. 
Utils 
. 
Utils 
. 
	Interface &
{ 
public 

	interface 
IHeaderClaims "
{ 
string 
GetClaimValue 
( 
string #
token$ )
,) *
string+ 1
claim2 7
)7 8
;8 9
string 
GetUserNameAuth 
( 
string %
authorization& 3
)3 4
;4 5
} 
} 