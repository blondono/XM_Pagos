Ä'
YD:\Cliente XM\IntegrationOracle\Applicacion.Expirations.WebApi\Areas\Job\HostedService.cs
	namespace		 	
Applicacion		
 
.		 
Expirations		 !
.		! "
WebApi		" (
.		( )
Areas		) .
.		. /
Job		/ 2
{

 
public 

class 
HostedService 
:  
IHostedService! /
{ 
private 
readonly 
ISchedulerFactory *
_schedulerFactory+ <
;< =
private 
readonly 
IJobFactory $
_jobFactory% 0
;0 1
private 
readonly 
IEnumerable $
<$ %
JobScheduleModel% 5
>5 6
_jobSchedules7 D
;D E
public 

IScheduler 
	Scheduler #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 
HostedService 
( 
ISchedulerFactory 
schedulerFactory .
,. /
IJobFactory 

jobFactory "
," #
IEnumerable 
< 
JobScheduleModel (
>( )
jobSchedules* 6
)6 7
{ 	
_schedulerFactory 
= 
schedulerFactory  0
;0 1
_jobSchedules 
= 
jobSchedules (
;( )
_jobFactory 
= 

jobFactory $
;$ %
} 	
public 
async 
Task 

StartAsync $
($ %
CancellationToken% 6
cancellationToken7 H
)H I
{ 	
	Scheduler   
=   
await   
_schedulerFactory   /
.  / 0
GetScheduler  0 <
(  < =
cancellationToken  = N
)  N O
;  O P
	Scheduler!! 
.!! 

JobFactory!!  
=!!! "
_jobFactory!!# .
;!!. /
foreach## 
(## 
var## 
jobSchedule## $
in##% '
_jobSchedules##( 5
)##5 6
{$$ 
var%% 
job%% 
=%% 
	CreateJob%% #
(%%# $
jobSchedule%%$ /
)%%/ 0
;%%0 1
var&& 
trigger&& 
=&& 
CreateTrigger&& +
(&&+ ,
jobSchedule&&, 7
)&&7 8
;&&8 9
await(( 
	Scheduler(( 
.((  
ScheduleJob((  +
(((+ ,
job((, /
,((/ 0
trigger((1 8
,((8 9
cancellationToken((: K
)((K L
;((L M
})) 
await++ 
	Scheduler++ 
.++ 
Start++ !
(++! "
cancellationToken++" 3
)++3 4
;++4 5
},, 	
public.. 
async.. 
Task.. 
	StopAsync.. #
(..# $
CancellationToken..$ 5
cancellationToken..6 G
)..G H
{// 	
await00 
	Scheduler00 
?00 
.00 
Shutdown00 %
(00% &
cancellationToken00& 7
)007 8
;008 9
}11 	
private33 
static33 

IJobDetail33 !
	CreateJob33" +
(33+ ,
JobScheduleModel33, <
schedule33= E
)33E F
{44 	
var55 
jobType55 
=55 
schedule55 "
.55" #
JobType55# *
;55* +
return66 

JobBuilder66 
.77 
Create77 
(77 
jobType77 
)77  
.88 
WithIdentity88 
(88 
jobType88 %
.88% &
FullName88& .
)88. /
.99 
WithDescription99  
(99  !
jobType99! (
.99( )
Name99) -
)99- .
.:: 
Build:: 
(:: 
):: 
;:: 
};; 	
private== 
static== 
ITrigger== 
CreateTrigger==  -
(==- .
JobScheduleModel==. >
schedule==? G
)==G H
{>> 	
return?? 
TriggerBuilder?? !
.@@ 
Create@@ 
(@@ 
)@@ 
.AA 
WithIdentityAA 
(AA 
$"AA  
{AA  !
scheduleAA! )
.AA) *
JobTypeAA* 1
.AA1 2
FullNameAA2 :
}AA: ;
.triggerAA; C
"AAC D
)AAD E
.BB 
WithCronScheduleBB !
(BB! "
scheduleBB" *
.BB* +
CronExpressionBB+ 9
)BB9 :
.CC 
WithDescriptionCC  
(CC  !
scheduleCC! )
.CC) *
CronExpressionCC* 8
)CC8 9
.DD 
BuildDD 
(DD 
)DD 
;DD 
}EE 	
}FF 
}GG Ò
OD:\Cliente XM\IntegrationOracle\Applicacion.Expirations.WebApi\Areas\Job\Job.cs
	namespace		 	
Applicacion		
 
.		 
Expirations		 !
.		! "
WebApi		" (
.		( )
Areas		) .
.		. /
Job		/ 2
{

 
[ '
DisallowConcurrentExecution  
]  !
public 

class 
Job 
: 
IJob 
{ 
public 
Job 
( 
) 
{ 	
} 	
public 
Task 
Execute 
(  
IJobExecutionContext 0
context1 8
)8 9
{ 	
return   
Task   
.   
CompletedTask   %
;  % &
}!! 	
}$$ 
}%% ¶
VD:\Cliente XM\IntegrationOracle\Applicacion.Expirations.WebApi\Areas\Job\JobFactory.cs
	namespace 	
Applicacion
 
. 
Expirations !
.! "
WebApi" (
.( )
Areas) .
.. /
Job/ 2
{ 
public		 

class		 

JobFactory		 
:		 
IJobFactory		 )
{

 
private 
readonly 
IServiceProvider )
_serviceProvider* :
;: ;
public 

JobFactory 
( 
IServiceProvider *
serviceProvider+ :
): ;
{ 	
_serviceProvider 
= 
serviceProvider .
;. /
} 	
public 
IJob 
NewJob 
( 
TriggerFiredBundle -
bundle. 4
,4 5

IScheduler6 @
	schedulerA J
)J K
{ 	
return 
_serviceProvider #
.# $
GetRequiredService$ 6
(6 7
bundle7 =
.= >
	JobDetail> G
.G H
JobTypeH O
)O P
asQ S
IJobT X
;X Y
} 	
public 
void 
	ReturnJob 
( 
IJob "
job# &
)& '
{( )
}* +
} 
} ­
cD:\Cliente XM\IntegrationOracle\Applicacion.Expirations.WebApi\Areas\Job\Models\JobScheduleModel.cs
	namespace 	
Applicacion
 
. 
Expirations !
.! "
WebApi" (
.( )
Areas) .
.. /
Job/ 2
.2 3
Models3 9
{ 
public 

class 
JobScheduleModel !
{		 
public

 
JobScheduleModel

 
(

  
Type

  $
jobType

% ,
,

, -
string

. 4
cronExpression

5 C
)

C D
{ 	
JobType 
= 
jobType 
; 
CronExpression 
= 
cronExpression +
;+ ,
} 	
public 
Type 
JobType 
{ 
get !
;! "
}# $
public 
string 
CronExpression $
{% &
get' *
;* +
}, -
} 
} ·
\D:\Cliente XM\IntegrationOracle\Applicacion.Expirations.WebApi\Controllers\LoadController.cs
	namespace 	
Applicacion
 
. 
Expirations !
.! "
WebApi" (
.( )
Controllers) 4
{ 
[ 
	Authorize 
] 
[ 
Route 

(
 
$str 
) 
] 
[ 
ApiController 
] 
public 

class 
LoadController 
:  !
ControllerBase" 0
{ 
private 
readonly 
IHeaderClaims &
_headerClaims' 4
;4 5
private 
string 
userName 
;  
public 
LoadController 
( 
IHeaderClaims +
headerClaims, 8
)8 9
{ 	
this 
. 
_headerClaims 
=  
headerClaims! -
;- .
} 	
[%% 	
HttpPost%%	 
]%% 
[&& 	
Route&&	 
(&& 
$str&& "
)&&" #
]&&# $
public'' 
IActionResult'' 
ProcessExpiration'' .
(''. /
)''/ 0
{(( 	
return)) 
Ok)) 
()) 
))) 
;)) 
}** 	
}-- 
}.. ¿
eD:\Cliente XM\IntegrationOracle\Applicacion.Expirations.WebApi\Handlers\DependencyInyectionHandler.cs
	namespace 	
Applicacion
 
. 
Expirations !
.! "
WebApi" (
.( )
Handlers) 1
{ 
public 

static 
class &
DependencyInyectionHandler 2
{ 
public 
static 
void %
DependencyInyectionConfig 4
(4 5
IServiceCollection5 G
servicesH P
)P Q
{ 	
services 
. 
	AddScoped 
< 

UnitOfWork )
,) *

UnitOfWork+ 5
>5 6
(6 7
)7 8
;8 9
services 
. 
AddTransient !
<! "
IUnitOfWork" -
,- .

UnitOfWork/ 9
>9 :
(: ;
); <
;< =
services 
. 
AddTransient !
(! "
typeof" (
(( )
IRepository) 4
<4 5
>5 6
)6 7
,7 8
typeof9 ?
(? @

Repository@ J
<J K
>K L
)L M
)M N
;N O
services 
. 
AddTransient !
<! "
IOracleRepository" 3
,3 4
OracleRepository5 E
>E F
(F G
)G H
;H I
services$$ 
.$$ 
AddTransient$$ !
<$$! "
IHeaderClaims$$" /
,$$/ 0
HeaderClaims$$1 =
>$$= >
($$> ?
)$$? @
;$$@ A
services%% 
.%% 
AddTransient%% !
<%%! "
IRestService%%" .
,%%. /
RestService%%0 ;
>%%; <
(%%< =
)%%= >
;%%> ?
}(( 	
})) 
}** Á
bD:\Cliente XM\IntegrationOracle\Applicacion.Expirations.WebApi\Handlers\JwtConfigurationHandler.cs
	namespace 	
Applicacion
 
. 
Expirations !
.! "
WebApi" (
.( )
Handlers) 1
{ 
public 

static 
class #
JwtConfigurationHandler /
{ 
public 
static 
void &
ConfigureJwtAuthentication 5
(5 6
IServiceCollection6 H
servicesI Q
,Q R!
IConfigurationSectionS h
jwtAppSettingsi w
)w x
{ 	

JwtSetting 
appSettings "
=# $
jwtAppSettings% 3
.3 4
Get4 7
<7 8

JwtSetting8 B
>B C
(C D
)D E
;E F
byte 
[ 
] 
	secretKey 
= 
Encoding '
.' (
ASCII( -
.- .
GetBytes. 6
(6 7
appSettings7 B
.B C
	SecretKeyC L
)L M
;M N
services 
. 
AddAuthentication &
(& '
JwtBearerDefaults' 8
.8 9 
AuthenticationScheme9 M
)M N
. 
AddJwtBearer 
( 
JwtBearerDefaults .
.. / 
AuthenticationScheme/ C
,C D
jwtBearerOptionsE U
=>V X
{ 
jwtBearerOptions #
.# $%
TokenValidationParameters$ =
=> ?
new@ C%
TokenValidationParametersD ]
{ 
IssuerSigningKey '
=( )
new* - 
SymmetricSecurityKey. B
(B C
	secretKeyC L
)L M
,M N
ValidIssuer "
=# $
appSettings% 0
.0 1
Issuer1 7
,7 8
ValidAudience $
=% &
appSettings' 2
.2 3
Issuer3 9
,9 :
} 
; 
} 
) 
; 
} 	
}!! 
}"" û 
YD:\Cliente XM\IntegrationOracle\Applicacion.Expirations.WebApi\Handlers\SwaggerHandler.cs
	namespace 	
Applicacion
 
. 
Expirations !
.! "
WebApi" (
.( )
Handlers) 1
{ 
public 

static 
class 
SwaggerHandler &
{ 
public 
static 
void 
SwaggerConfig (
(( )
IServiceCollection) ;
services< D
)D E
{ 	
services 
. 
AddSwaggerGen "
(" #
options# *
=>+ -
{ 
options 
. %
DescribeAllEnumsAsStrings 1
(1 2
)2 3
;3 4
options 
. 
IncludeXmlComments *
(* +
Path+ /
./ 0
ChangeExtension0 ?
(? @
typeof@ F
(F G
StartupG N
)N O
.O P
AssemblyP X
.X Y
LocationY a
,a b
$strc h
)h i
)i j
;j k
options 
. 

SwaggerDoc "
(" # 
SwaggerConfiguration# 7
.7 8
DocInfoVersion8 F
,F G
newH K
InfoL P
{ 
Version 
=  
SwaggerConfiguration 2
.2 3
DocInfoVersion3 A
,A B
Title 
=  
SwaggerConfiguration 0
.0 1
DocInfoTitle1 =
,= >
Description 
=  ! 
SwaggerConfiguration" 6
.6 7
DocInfoDescription7 I
} 
) 
; 
options 
. 
CustomSchemaIds '
(' (
x( )
=>* ,
x- .
.. /
FullName/ 7
)7 8
;8 9
var 
security 
= 
new "

Dictionary# -
<- .
string. 4
,4 5
IEnumerable6 A
<A B
stringB H
>H I
>I J
{   
{!! 
$str!! 
,!! 
Array!!  %
.!!% &
Empty!!& +
<!!+ ,
string!!, 2
>!!2 3
(!!3 4
)!!4 5
}!!6 7
}"" 
;"" 
options$$ 
.$$ !
AddSecurityDefinition$$ -
($$- .
$str$$. 6
,$$6 7
new$$8 ;
ApiKeyScheme$$< H
{%% 
Description&& 
=&&  !
$str	&&" €
,
&&€ 
Name'' 
='' 
$str'' *
,''* +
In(( 
=(( 
$str(( !
,((! "
Type)) 
=)) 
$str)) #
}** 
)** 
;** 
options,, 
.,, "
AddSecurityRequirement,, .
(,,. /
security,,/ 7
),,7 8
;,,8 9
}.. 
).. 
;.. 
}00 	
public33 
static33 
void33 

UseSwagger33 %
(33% &
IApplicationBuilder33& 9
app33: =
)33= >
{44 	
app66 
.66 

UseSwagger66 
(66 
)66 
;66 
app88 
.88 
UseSwaggerUI88 
(88 
c88 
=>88 !
{99 
string:: 
swaggerJsonBasePath:: *
=::+ ,
string::- 3
.::3 4
IsNullOrWhiteSpace::4 F
(::F G
c::G H
.::H I
RoutePrefix::I T
)::T U
?::V W
$str::X [
:::\ ]
$str::^ b
;::b c
c;; 
.;; 
SwaggerEndpoint;; !
(;;! "
$";;" $
{;;$ %
swaggerJsonBasePath;;% 8
};;8 9$
/swagger/v1/swagger.json;;9 Q
";;Q R
,;;R S
$str;;T s
);;s t
;;;t u
}<< 
)<< 
;<< 
}== 	
}>> 
}?? ¬

ID:\Cliente XM\IntegrationOracle\Applicacion.Expirations.WebApi\Program.cs
	namespace 	
Applicacion
 
. 
Expirations !
.! "
WebApi" (
{ 
public 

class 
Program 
{ 
public 
static 
void 
Main 
(  
string  &
[& '
]' (
args) -
)- .
{ 	
SettingAutomapper 
. 

CreateMaps (
(( )
)) *
;* + 
CreateWebHostBuilder  
(  !
args! %
)% &
.& '
Build' ,
(, -
)- .
.. /
Run/ 2
(2 3
)3 4
;4 5
} 	
public 
static 
IWebHostBuilder % 
CreateWebHostBuilder& :
(: ;
string; A
[A B
]B C
argsD H
)H I
=>J L
WebHost 
.  
CreateDefaultBuilder (
(( )
args) -
)- .
. 

UseStartup 
< 
Startup #
># $
($ %
)% &
;& '
} 
} ç7
ID:\Cliente XM\IntegrationOracle\Applicacion.Expirations.WebApi\Startup.cs
	namespace&& 	
Applicacion&&
 
.&& 
Expirations&& !
.&&! "
WebApi&&" (
{'' 
public(( 

class(( 
Startup(( 
{)) 
public** 
Startup** 
(** 
IHostingEnvironment** *
env**+ .
,**. /
IConfiguration**0 >
configuration**? L
)**L M
{++ 	
var,, 
builder,, 
=,, 
new,,  
ConfigurationBuilder,, 2
(,,2 3
),,3 4
.-- 
SetBasePath-- 
(-- 
env-- 
.-- 
ContentRootPath-- +
)--+ ,
... 
AddJsonFile.. 
(.. 
$str.. *
,..* +
optional.., 4
:..4 5
false..6 ;
,..; <
reloadOnChange..= K
:..K L
true..M Q
)..Q R
.// 
AddJsonFile// 
(// 
$"// 
appsettings.// &
{//& '
env//' *
.//* +
EnvironmentName//+ :
}//: ;
.json//; @
"//@ A
,//A B
optional//C K
://K L
true//M Q
)//Q R
.00 #
AddEnvironmentVariables00 #
(00# $
)00$ %
;00% &
var22 
e22 
=22 
env22 
.22 
EnvironmentName22 '
;22' (
Configuration44 
=44 
builder44 #
.44# $
Build44$ )
(44) *
)44* +
;44+ ,
}55 	
public77 
IConfiguration77 
Configuration77 +
{77, -
get77. 1
;771 2
}773 4
public:: 
void:: 
ConfigureServices:: %
(::% &
IServiceCollection::& 8
services::9 A
)::A B
{;; 	
services<< 
.<< 
AddMvc<< 
(<< 
)<< 
.<< #
SetCompatibilityVersion<< 5
(<<5 6 
CompatibilityVersion<<6 J
.<<J K
Version_2_2<<K V
)<<V W
;<<W X!
IConfigurationSection== !
jwtAppSettings==" 0
===1 2
Configuration==3 @
.==@ A

GetSection==A K
(==K L
$str==L Q
)==Q R
;==R S
services>> 
.>> 
	Configure>> 
<>> 

JwtSetting>> )
>>>) *
(>>* +
jwtAppSettings>>+ 9
)>>9 :
;>>: ;
services@@ 
.@@ 
AddCors@@ 
(@@ 
options@@ $
=>@@% '
{AA 
optionsBB 
.BB 
	AddPolicyBB !
(BB! "
$strBB" .
,BB. /
pCC 
=>CC 
pCC 
.CC 
AllowAnyOriginCC )
(CC) *
)CC* +
.DD 
AllowAnyMethodDD #
(DD# $
)DD$ %
.EE 
AllowAnyHeaderEE #
(EE# $
)EE$ %
.FF 
AllowCredentialsFF %
(FF% &
)FF& '
)FF' (
;FF( )
}GG 
)GG 
;GG 
servicesII 
.II %
AddDistributedMemoryCacheII .
(II. /
)II/ 0
;II0 1
servicesJJ 
.JJ 

AddSessionJJ 
(JJ  
)JJ  !
;JJ! "
SwaggerHandlerNN 
.NN 
SwaggerConfigNN (
(NN( )
servicesNN) 1
)NN1 2
;NN2 3#
JwtConfigurationHandlerTT #
.TT# $&
ConfigureJwtAuthenticationTT$ >
(TT> ?
servicesTT? G
,TTG H
jwtAppSettingsTTI W
)TTW X
;TTX Y
servicesZZ 
.ZZ 
AddDbContextZZ !
<ZZ! "
InfraestructureZZ" 1
.ZZ1 2
CoreZZ2 6
.ZZ6 7
ContextZZ7 >
.ZZ> ?
	SQLServerZZ? H
.ZZH I

ContextSQLZZI S
>ZZS T
(ZZT U
optionsZZU \
=>ZZ] _
options[[ 
.[[ 
UseSqlServer[[ #
([[# $
Configuration[[$ 1
.[[1 2
GetConnectionString[[2 E
([[E F
$str[[F a
)[[a b
,[[b c
providerOptions\\ 
=>\\ !
providerOptions\\" 1
.\\1 2 
EnableRetryOnFailure\\2 F
(\\F G
)\\G H
)\\H I
)\\I J
;\\J K&
DependencyInyectionHandleraa &
.aa& '%
DependencyInyectionConfigaa' @
(aa@ A
servicesaaA I
)aaI J
;aaJ K
}yy 	
public~~ 
void~~ 
	Configure~~ 
(~~ 
IApplicationBuilder~~ 1
app~~2 5
,~~5 6
IHostingEnvironment~~7 J
env~~K N
,~~N O 
IApplicationLifetime~~P d
appLifetime~~e p
)~~p q
{ 	
var
€€ 
cultureInfo
€€ 
=
€€ 
new
€€ !
CultureInfo
€€" -
(
€€- .
$str
€€. 5
)
€€5 6
;
€€6 7
CultureInfo
‚‚ 
.
‚‚ )
DefaultThreadCurrentCulture
‚‚ 3
=
‚‚4 5
cultureInfo
‚‚6 A
;
‚‚A B
CultureInfo
ƒƒ 
.
ƒƒ +
DefaultThreadCurrentUICulture
ƒƒ 5
=
ƒƒ6 7
cultureInfo
ƒƒ8 C
;
ƒƒC D
if
…… 
(
…… 
env
…… 
.
…… 
IsDevelopment
…… !
(
……! "
)
……" #
)
……# $
{
†† 
app
‡‡ 
.
‡‡ '
UseDeveloperExceptionPage
‡‡ -
(
‡‡- .
)
‡‡. /
;
‡‡/ 0
}
ˆˆ 
app
‰‰ 
.
‰‰ 
UseCors
‰‰ 
(
‰‰ 
$str
‰‰ $
)
‰‰$ %
;
‰‰% &
app
ŠŠ 
.
ŠŠ 
UseAuthentication
ŠŠ !
(
ŠŠ! "
)
ŠŠ" #
;
ŠŠ# $
app
‹‹ 
.
‹‹ 

UseSession
‹‹ 
(
‹‹ 
)
‹‹ 
;
‹‹ 
SwaggerHandler
ŒŒ 
.
ŒŒ 

UseSwagger
ŒŒ %
(
ŒŒ% &
app
ŒŒ& )
)
ŒŒ) *
;
ŒŒ* +
app
 
.
 '
UseDeveloperExceptionPage
 )
(
) *
)
* +
;
+ ,
app
ŽŽ 
.
ŽŽ 
UseMvc
ŽŽ 
(
ŽŽ 
)
ŽŽ 
;
ŽŽ 
appLifetime
‘‘ 
.
‘‘  
ApplicationStarted
‘‘ *
.
‘‘* +
Register
‘‘+ 3
(
‘‘3 4
(
‘‘4 5
)
‘‘5 6
=>
‘‘7 9
{
’’ 
}
”” 
)
”” 
;
”” 
appLifetime
–– 
.
––  
ApplicationStopped
–– *
.
––* +
Register
––+ 3
(
––3 4
(
––4 5
)
––5 6
=>
––7 9
{
—— 
}
™™ 
)
™™ 
;
™™ 
}
šš 	
}
›› 
}œœ 