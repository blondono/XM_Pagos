ÿ
JD:\Cliente XM\IntegrationOracle\Infraestructure.Core\Context\ContextSQL.cs
	namespace 	
Infraestructure
 
. 
Core 
. 
Context &
.& '
	SQLServer' 0
{ 
public 

class 

ContextSQL 
: 
	DbContext '
{ 
public 

ContextSQL 
( 
DbContextOptions *
dbContextOptions+ ;
); <
: 
base 
( 
dbContextOptions "
)" #
{		 	
}

 	
	protected 
override 
void 
OnModelCreating  /
(/ 0
ModelBuilder0 <
modelBuilder= I
)I J
{ 	
base 
. 
OnModelCreating  
(  !
modelBuilder! -
)- .
;. /
} 	
} 
} Ç
^D:\Cliente XM\IntegrationOracle\Infraestructure.Core\Repository\Interface\IOracleRepository.cs
	namespace 	
Infraestructure
 
. 
Core 
. 

Repository )
.) *
	Interface* 3
{ 
public 

	interface 
IOracleRepository &
{ 
} 
} ¶5
XD:\Cliente XM\IntegrationOracle\Infraestructure.Core\Repository\Interface\IRepository.cs
	namespace 	
Infraestructure
 
. 
Core 
. 

Repository )
.) *
	Interface* 3
{ 
public 

	interface 
IRepository  
<  !
TEntity! (
>( )
where* /
TEntity0 7
:8 9
class: ?
{		 

IQueryable 
< 
TEntity 
> 
AsQueryable '
(' (
)( )
;) *
IEnumerable 
< 
TEntity 
> 
GetAll #
(# $
params$ *

Expression+ 5
<5 6
Func6 :
<: ;
TEntity; B
,B C
objectD J
>J K
>K L
[L M
]M N
includePropertiesO `
)` a
;a b
ICollection 
< 
TType 
> 
	GetSelect $
<$ %
TType% *
>* +
(+ ,

Expression, 6
<6 7
Func7 ;
<; <
TEntity< C
,C D
boolE I
>I J
>J K
whereL Q
,Q R

ExpressionS ]
<] ^
Func^ b
<b c
TEntityc j
,j k
TTypel q
>q r
>r s
selectt z
)z {
;{ |
TEntity   
Find   
(   

Expression   
<    
Func    $
<  $ %
TEntity  % ,
,  , -
bool  . 2
>  2 3
>  3 4
	predicate  5 >
)  > ?
;  ? @
IEnumerable$$ 
<$$ 
TEntity$$ 
>$$ 
FindAll$$ $
($$$ %

Expression$$% /
<$$/ 0
Func$$0 4
<$$4 5
TEntity$$5 <
,$$< =
bool$$> B
>$$B C
>$$C D
where$$E J
,$$J K
params$$L R

Expression$$S ]
<$$] ^
Func$$^ b
<$$b c
TEntity$$c j
,$$j k
object$$l r
>$$r s
>$$s t
[$$t u
]$$u v
includeProperties	$$w à
)
$$à â
;
$$â ä
TEntity(( 
First(( 
((( 

Expression((  
<((  !
Func((! %
<((% &
TEntity((& -
,((- .
bool((/ 3
>((3 4
>((4 5
where((6 ;
,((; <
params((= C

Expression((D N
<((N O
Func((O S
<((S T
TEntity((T [
,(([ \
object((] c
>((c d
>((d e
[((e f
]((f g
includeProperties((h y
)((y z
;((z {
TEntity,, 
Last,, 
(,, 

Expression,, 
<,,  
Func,,  $
<,,$ %
TEntity,,% ,
,,,, -
bool,,. 2
>,,2 3
>,,3 4
where,,5 :
,,,: ;
params,,< B

Expression,,C M
<,,M N
Func,,N R
<,,R S
TEntity,,S Z
,,,Z [
object,,\ b
>,,b c
>,,c d
[,,d e
],,e f
includeProperties,,g x
),,x y
;,,y z
TEntity00 
FirstOrDefault00 
(00 

Expression00 )
<00) *
Func00* .
<00. /
TEntity00/ 6
,006 7
bool008 <
>00< =
>00= >
where00? D
,00D E
params00F L

Expression00M W
<00W X
Func00X \
<00\ ]
TEntity00] d
,00d e
object00f l
>00l m
>00m n
[00n o
]00o p
includeProperties	00q Ç
)
00Ç É
;
00É Ñ
TEntity33 
LastOrDefault33 
(33 

Expression33 (
<33( )
Func33) -
<33- .
TEntity33. 5
,335 6
bool337 ;
>33; <
>33< =
where33> C
,33C D
params33E K

Expression33L V
<33V W
Func33W [
<33[ \
TEntity33\ c
,33c d
object33e k
>33k l
>33l m
[33m n
]33n o
includeProperties	33p Å
)
33Å Ç
;
33Ç É
TEntity77 
Single77 
(77 

Expression77 !
<77! "
Func77" &
<77& '
TEntity77' .
,77. /
bool770 4
>774 5
>775 6
where777 <
,77< =
params77> D

Expression77E O
<77O P
Func77P T
<77T U
TEntity77U \
,77\ ]
object77^ d
>77d e
>77e f
[77f g
]77g h
includeProperties77i z
)77z {
;77{ |
TEntity;; 
SingleOrDefault;; 
(;;  

Expression;;  *
<;;* +
Func;;+ /
<;;/ 0
TEntity;;0 7
,;;7 8
bool;;9 =
>;;= >
>;;> ?
where;;@ E
,;;E F
params;;G M

Expression;;N X
<;;X Y
Func;;Y ]
<;;] ^
TEntity;;^ e
,;;e f
object;;g m
>;;m n
>;;n o
[;;o p
];;p q
includeProperties	;;r É
)
;;É Ñ
;
;;Ñ Ö
void?? 
Insert?? 
(?? 
TEntity?? 
entity?? "
)??" #
;??# $
voidCC 
InsertCC 
(CC 
IEnumerableCC 
<CC  
TEntityCC  '
>CC' (
entitiesCC) 1
)CC1 2
;CC2 3
voidGG 
UpdateGG 
(GG 
TEntityGG 
entityGG "
)GG" #
;GG# $
voidKK 
UpdateKK 
(KK 
IEnumerableKK 
<KK  
TEntityKK  '
>KK' (
entitiesKK) 1
)KK1 2
;KK2 3
voidOO 
DeleteOO 
(OO 
TEntityOO 
entityOO "
)OO" #
;OO# $
voidSS 
DeleteSS 
(SS 
objectSS 
idSS 
)SS 
;SS 
voidWW 
DeleteWW 
(WW 
IEnumerableWW 
<WW  
TEntityWW  '
>WW' (
entitiesWW) 1
)WW1 2
;WW2 3
intff 
ExecuteSqlCommandff 
(ff 
stringff $
queryff% *
,ff* +
paramsff, 2
objectff3 9
[ff9 :
]ff: ;

parametersff< F
)ffF G
;ffG H
}ii 
}jj Ï
SD:\Cliente XM\IntegrationOracle\Infraestructure.Core\Repository\OracleRepository.cs
	namespace 	
Infraestructure
 
. 
Core 
. 

Repository )
{ 
public 

class 
OracleRepository !
:" #
IOracleRepository$ 5
{ 
public 
OracleRepository 
(  
)  !
{ 	
} 	
}
ïï 
}ññ ⁄É
MD:\Cliente XM\IntegrationOracle\Infraestructure.Core\Repository\Repository.cs
	namespace 	
Infraestructure
 
. 
Core 
. 

Repository )
{		 
public

 

class

 

Repository

 
<

 
TEntity

 #
>

# $
:

% &
IRepository

' 2
<

2 3
TEntity

3 :
>

: ;
where

< A
TEntity

B I
:

J K
class

L Q
{ 
private 
readonly 
	DbContext "

_dbcontext# -
;- .
private 
readonly 
DbSet 
< 
TEntity &
>& '
	_entities( 1
;1 2
public 

Repository 
( 
	DbContext #
	dbcontext$ -
)- .
{ 	
this 
. 

_dbcontext 
= 
	dbcontext '
;' (
this 
. 
	_entities 
= 
	dbcontext &
.& '
Set' *
<* +
TEntity+ 2
>2 3
(3 4
)4 5
;5 6
} 	
private 

IQueryable 
< 
TEntity "
>" #
PerformInclusions$ 5
(5 6
IEnumerable6 A
<A B

ExpressionB L
<L M
FuncM Q
<Q R
TEntityR Y
,Y Z
object[ a
>a b
>b c
>c d
includePropertiese v
,v w

IQueryable0 :
<: ;
TEntity; B
>B C
queryD I
)I J
{ 	
return 
includeProperties $
.$ %
	Aggregate% .
(. /
query/ 4
,4 5
(6 7
current7 >
,> ?
includeProperty@ O
)O P
=>Q S
currentT [
.[ \
Include\ c
(c d
includePropertyd s
)s t
)t u
;u v
} 	
public 

IQueryable 
< 
TEntity !
>! "
AsQueryable# .
(. /
)/ 0
{ 	
return   
	_entities   
.   
AsQueryable   (
<  ( )
TEntity  ) 0
>  0 1
(  1 2
)  2 3
;  3 4
}!! 	
public## 
IEnumerable## 
<## 
TEntity## "
>##" #
GetAll##$ *
(##* +
params##+ 1

Expression##2 <
<##< =
Func##= A
<##A B
TEntity##B I
,##I J
object##K Q
>##Q R
>##R S
[##S T
]##T U
includeProperties##V g
)##g h
{$$ 	

IQueryable%% 
<%% 
TEntity%% 
>%% 
query%%  %
=%%& '
AsQueryable%%( 3
(%%3 4
)%%4 5
;%%5 6
return&& 
PerformInclusions&& $
(&&$ %
includeProperties&&% 6
,&&6 7
query&&8 =
)&&= >
;&&> ?
}'' 	
public)) 
ICollection)) 
<)) 
TType))  
>))  !
	GetSelect))" +
<))+ ,
TType)), 1
>))1 2
())2 3

Expression))3 =
<))= >
Func))> B
<))B C
TEntity))C J
,))J K
bool))L P
>))P Q
>))Q R
where))S X
,))X Y

Expression))Z d
<))d e
Func))e i
<))i j
TEntity))j q
,))q r
TType))s x
>))x y
>))y z
select	)){ Å
)
))Å Ç
{** 	
return++ 
	_entities++ 
.++ 
Where++ "
(++" #
where++# (
)++( )
.++) *
Select++* 0
(++0 1
select++1 7
)++7 8
.++8 9
ToList++9 ?
(++? @
)++@ A
;++A B
},, 	
public.. 
TEntity.. 
Find.. 
(.. 

Expression.. &
<..& '
Func..' +
<..+ ,
TEntity.., 3
,..3 4
bool..5 9
>..9 :
>..: ;
	predicate..< E
)..E F
{// 	

IQueryable00 
<00 
TEntity00 
>00 
query00  %
=00& '
AsQueryable00( 3
(003 4
)004 5
;005 6
return11 
query11 
.11 
FirstOrDefault11 '
(11' (
	predicate11( 1
)111 2
;112 3
}22 	
public44 
IEnumerable44 
<44 
TEntity44 "
>44" #
FindAll44$ +
(44+ ,

Expression44, 6
<446 7
Func447 ;
<44; <
TEntity44< C
,44C D
bool44E I
>44I J
>44J K
where44L Q
,44Q R
params44S Y

Expression44Z d
<44d e
Func44e i
<44i j
TEntity44j q
,44q r
object44s y
>44y z
>44z {
[44{ |
]44| }
includeProperties	44~ è
)
44è ê
{55 	

IQueryable66 
<66 
TEntity66 
>66 
query66  %
=66& '
AsQueryable66( 3
(663 4
)664 5
;665 6
query77 
=77 
PerformInclusions77 %
(77% &
includeProperties77& 7
,777 8
query779 >
)77> ?
;77? @
return88 
query88 
.88 
Where88 
(88 
where88 $
)88$ %
;88% &
}99 	
public;; 
TEntity;; 
First;; 
(;; 

Expression;; '
<;;' (
Func;;( ,
<;;, -
TEntity;;- 4
,;;4 5
bool;;6 :
>;;: ;
>;;; <
where;;= B
,;;B C
params;;D J

Expression;;K U
<;;U V
Func;;V Z
<;;Z [
TEntity;;[ b
,;;b c
object;;d j
>;;j k
>;;k l
[;;l m
];;m n
includeProperties	;;o Ä
)
;;Ä Å
{<< 	

IQueryable== 
<== 
TEntity== 
>== 
query==  %
===& '
AsQueryable==( 3
(==3 4
)==4 5
;==5 6
query>> 
=>> 
PerformInclusions>> %
(>>% &
includeProperties>>& 7
,>>7 8
query>>9 >
)>>> ?
;>>? @
return?? 
query?? 
.?? 
First?? 
(?? 
where?? $
)??$ %
;??% &
}@@ 	
publicBB 
TEntityBB 
LastBB 
(BB 

ExpressionBB &
<BB& '
FuncBB' +
<BB+ ,
TEntityBB, 3
,BB3 4
boolBB5 9
>BB9 :
>BB: ;
whereBB< A
,BBA B
paramsBBC I

ExpressionBBJ T
<BBT U
FuncBBU Y
<BBY Z
TEntityBBZ a
,BBa b
objectBBc i
>BBi j
>BBj k
[BBk l
]BBl m
includePropertiesBBn 
)	BB Ä
{CC 	

IQueryableDD 
<DD 
TEntityDD 
>DD 
queryDD  %
=DD& '
AsQueryableDD( 3
(DD3 4
)DD4 5
;DD5 6
queryEE 
=EE 
PerformInclusionsEE %
(EE% &
includePropertiesEE& 7
,EE7 8
queryEE9 >
)EE> ?
;EE? @
returnFF 
queryFF 
.FF 
LastFF 
(FF 
whereFF #
)FF# $
;FF$ %
}GG 	
publicII 
TEntityII 
FirstOrDefaultII %
(II% &

ExpressionII& 0
<II0 1
FuncII1 5
<II5 6
TEntityII6 =
,II= >
boolII? C
>IIC D
>IID E
whereIIF K
,IIK L
paramsIIM S

ExpressionIIT ^
<II^ _
FuncII_ c
<IIc d
TEntityIId k
,IIk l
objectIIm s
>IIs t
>IIt u
[IIu v
]IIv w
includeProperties	IIx â
)
IIâ ä
{JJ 	

IQueryableKK 
<KK 
TEntityKK 
>KK 
queryKK  %
=KK& '
AsQueryableKK( 3
(KK3 4
)KK4 5
;KK5 6
queryLL 
=LL 
PerformInclusionsLL %
(LL% &
includePropertiesLL& 7
,LL7 8
queryLL9 >
)LL> ?
;LL? @
returnMM 
queryMM 
.MM 
FirstOrDefaultMM '
(MM' (
whereMM( -
)MM- .
;MM. /
}NN 	
publicPP 
TEntityPP 
LastOrDefaultPP $
(PP$ %

ExpressionPP% /
<PP/ 0
FuncPP0 4
<PP4 5
TEntityPP5 <
,PP< =
boolPP> B
>PPB C
>PPC D
wherePPE J
,PPJ K
paramsPPL R

ExpressionPPS ]
<PP] ^
FuncPP^ b
<PPb c
TEntityPPc j
,PPj k
objectPPl r
>PPr s
>PPs t
[PPt u
]PPu v
includeProperties	PPw à
)
PPà â
{QQ 	

IQueryableRR 
<RR 
TEntityRR 
>RR 
queryRR  %
=RR& '
AsQueryableRR( 3
(RR3 4
)RR4 5
;RR5 6
querySS 
=SS 
PerformInclusionsSS %
(SS% &
includePropertiesSS& 7
,SS7 8
querySS9 >
)SS> ?
;SS? @
returnTT 
queryTT 
.TT 
LastOrDefaultTT &
(TT& '
whereTT' ,
)TT, -
;TT- .
}UU 	
publicWW 
TEntityWW 
SingleWW 
(WW 

ExpressionWW (
<WW( )
FuncWW) -
<WW- .
TEntityWW. 5
,WW5 6
boolWW7 ;
>WW; <
>WW< =
whereWW> C
,WWC D
paramsWWE K

ExpressionWWL V
<WWV W
FuncWWW [
<WW[ \
TEntityWW\ c
,WWc d
objectWWe k
>WWk l
>WWl m
[WWm n
]WWn o
includeProperties	WWp Å
)
WWÅ Ç
{XX 	

IQueryableYY 
<YY 
TEntityYY 
>YY 
queryYY  %
=YY& '
AsQueryableYY( 3
(YY3 4
)YY4 5
;YY5 6
queryZZ 
=ZZ 
PerformInclusionsZZ %
(ZZ% &
includePropertiesZZ& 7
,ZZ7 8
queryZZ9 >
)ZZ> ?
;ZZ? @
return[[ 
query[[ 
.[[ 
Single[[ 
([[  
where[[  %
)[[% &
;[[& '
}\\ 	
public^^ 
TEntity^^ 
SingleOrDefault^^ &
(^^& '

Expression^^' 1
<^^1 2
Func^^2 6
<^^6 7
TEntity^^7 >
,^^> ?
bool^^@ D
>^^D E
>^^E F
where^^G L
,^^L M
params^^N T

Expression^^U _
<^^_ `
Func^^` d
<^^d e
TEntity^^e l
,^^l m
object^^n t
>^^t u
>^^u v
[^^v w
]^^w x
includeProperties	^^y ä
)
^^ä ã
{__ 	

IQueryable`` 
<`` 
TEntity`` 
>`` 
query``  %
=``& '
AsQueryable``( 3
(``3 4
)``4 5
;``5 6
queryaa 
=aa 
PerformInclusionsaa %
(aa% &
includePropertiesaa& 7
,aa7 8
queryaa9 >
)aa> ?
;aa? @
returnbb 
querybb 
.bb 
SingleOrDefaultbb (
(bb( )
wherebb) .
)bb. /
;bb/ 0
}cc 	
publicee 
voidee 
Insertee 
(ee 
TEntityee "
entityee# )
)ee) *
{ff 	
	_entitiesgg 
.gg 
Addgg 
(gg 
entitygg  
)gg  !
;gg! "
}hh 	
publicjj 
voidjj 
Insertjj 
(jj 
IEnumerablejj &
<jj& '
TEntityjj' .
>jj. /
entitiesjj0 8
)jj8 9
{kk 	
intmm 
countmm 
=mm 
+mm 
$nummm 
;mm 
foreachoo 
(oo 
varoo 
eoo 
inoo 
entitiesoo &
)oo& '
{pp 

_dbcontextqq 
.qq 
Entryqq  
(qq  !
eqq! "
)qq" #
.qq# $
Stateqq$ )
=qq* +
EntityStateqq, 7
.qq7 8
Addedqq8 =
;qq= >
}rr 
}ss 	
publictt 
voidtt 
Updatett 
(tt 
TEntitytt "
entitytt# )
)tt) *
{uu 	
	_entitiesvv 
.vv 
Attachvv 
(vv 
entityvv #
)vv# $
;vv$ %

_dbcontextww 
.ww 
Entryww 
(ww 
entityww #
)ww# $
.ww$ %
Stateww% *
=ww+ ,
EntityStateww- 8
.ww8 9
Modifiedww9 A
;wwA B
}xx 	
publiczz 
voidzz 
Updatezz 
(zz 
IEnumerablezz &
<zz& '
TEntityzz' .
>zz. /
entitieszz0 8
)zz8 9
{{{ 	
foreach|| 
(|| 
var|| 
e|| 
in|| 
entities|| &
)||& '
{}} 

_dbcontext~~ 
.~~ 
Entry~~  
(~~  !
e~~! "
)~~" #
.~~# $
State~~$ )
=~~* +
EntityState~~, 7
.~~7 8
Modified~~8 @
;~~@ A
} 
}
ÄÄ 	
public
ÉÉ 
void
ÉÉ 
Delete
ÉÉ 
(
ÉÉ 
TEntity
ÉÉ "
entity
ÉÉ# )
)
ÉÉ) *
{
ÑÑ 	
if
ÖÖ 
(
ÖÖ 

_dbcontext
ÖÖ 
.
ÖÖ 
Entry
ÖÖ  
(
ÖÖ  !
entity
ÖÖ! '
)
ÖÖ' (
.
ÖÖ( )
State
ÖÖ) .
==
ÖÖ/ 1
EntityState
ÖÖ2 =
.
ÖÖ= >
Detached
ÖÖ> F
)
ÖÖF G
{
ÜÜ 
	_entities
áá 
.
áá 
Attach
áá  
(
áá  !
entity
áá! '
)
áá' (
;
áá( )
}
àà 
	_entities
ââ 
.
ââ 
Remove
ââ 
(
ââ 
entity
ââ #
)
ââ# $
;
ââ$ %
}
ää 	
public
åå 
void
åå 
Delete
åå 
(
åå 
object
åå !
id
åå" $
)
åå$ %
{
çç 	
TEntity
éé 
entityToDelete
éé "
=
éé# $
	_entities
éé% .
.
éé. /
Find
éé/ 3
(
éé3 4
id
éé4 6
)
éé6 7
;
éé7 8
	_entities
èè 
.
èè 
Remove
èè 
(
èè 
entityToDelete
èè +
)
èè+ ,
;
èè, -
}
êê 	
public
íí 
void
íí 
Delete
íí 
(
íí 
IEnumerable
íí &
<
íí& '
TEntity
íí' .
>
íí. /
entities
íí0 8
)
íí8 9
{
ìì 	
foreach
îî 
(
îî 
var
îî 
e
îî 
in
îî 
entities
îî &
)
îî& '
{
ïï 

_dbcontext
ññ 
.
ññ 
Entry
ññ  
(
ññ  !
e
ññ! "
)
ññ" #
.
ññ# $
State
ññ$ )
=
ññ* +
EntityState
ññ, 7
.
ññ7 8
Deleted
ññ8 ?
;
ññ? @
}
óó 
}
òò 	
public
ùù 
int
ùù 
ExecuteSqlCommand
ùù $
(
ùù$ %
string
ùù% +
query
ùù, 1
,
ùù1 2
params
ùù3 9
object
ùù: @
[
ùù@ A
]
ùùA B

parameters
ùùC M
)
ùùM N
{
ûû 	
return
üü 

_dbcontext
üü 
.
üü 
Database
üü &
.
üü& '
ExecuteSqlCommand
üü' 8
(
üü8 9
query
üü9 >
,
üü> ?

parameters
üü@ J
)
üüJ K
;
üüK L
}
†† 	
}
¢¢ 
}££ Ÿ
[D:\Cliente XM\IntegrationOracle\Infraestructure.Core\RestServices\Interface\IRestService.cs
	namespace 	
Infraestructure
 
. 
Core 
. 
RestServices +
.+ ,
	Interface, 5
{ 
public 

	interface 
IRestService !
{ 
Task 
< 
T 
> 
GetRestServiceAsync #
<# $
T$ %
>% &
(& '
string' -
url. 1
,1 2
string3 9
method: @
,@ A
IDictionaryB M
<M N
stringN T
,T U
string		 
>		 

parameters		 
,		 
IDictionary		 *
<		* +
string		+ 1
,		1 2
string		3 9
>		9 :
headeres		; C
)		C D
;		D E
Task 
< 
T 
>  
PostRestServiceAsync $
<$ %
T% &
>& '
(' (
string( .
url/ 2
,2 3
string4 :

controller; E
,E F
string 
method 
, 
object !

parameters" ,
,, -
IDictionary. 9
<9 :
string: @
,@ A
stringB H
>H I
headersJ Q
)Q R
;R S
} 
} ì;
PD:\Cliente XM\IntegrationOracle\Infraestructure.Core\RestServices\RestService.cs
	namespace 	
Infraestructure
 
. 
Core 
. 
RestServices +
{ 
public 

class 
RestService 
: 
IRestService +
{ 
public 
async 
Task 
< 
T 
>  
PostRestServiceAsync 1
<1 2
T2 3
>3 4
(4 5
string5 ;
url< ?
,? @
stringA G

controllerH R
,R S
string 
method 
, 
object  

parameters! +
,+ ,
IDictionary- 8
<8 9
string9 ?
,? @
stringA G
>G H
headersI P
)P Q
{ 	
var 
baseUrl 
= 
string  
.  !
Format! '
(' (
$str( 5
,5 6
url7 :
,: ;

controller< F
,F G
methodH N
)N O
;O P
try 
{ 
using 
( 

HttpClient !
client" (
=) *
new+ .

HttpClient/ 9
(9 :
): ;
); <
{ 
client 
. !
DefaultRequestHeaders 0
.0 1
Accept1 7
.7 8
Add8 ;
(; <
new< ?+
MediaTypeWithQualityHeaderValue@ _
(_ `
$str` r
)r s
)s t
;t u
if 
( 
headers 
.  
Count  %
>& '
$num( )
)) *
{ 
foreach 
(  !
var! $
header% +
in, .
headers/ 6
)6 7
{ 
client "
." #!
DefaultRequestHeaders# 8
.8 9
Add9 <
(< =
header= C
.C D
KeyD G
,G H
headerI O
.O P
ValueP U
)U V
;V W
} 
}   
HttpContent!! 

jsonObject!!  *
=!!+ ,
new!!- 0
StringContent!!1 >
(!!> ?
JsonConvert!!? J
.!!J K
SerializeObject!!K Z
(!!Z [

parameters!![ e
)!!e f
,!!f g
Encoding!!h p
.!!p q
UTF8!!q u
,!!u v
$str	!!w â
)
!!â ä
;
!!ä ã
HttpResponseMessage"" '
res""( +
="", -
await"". 3
client""4 :
."": ;
	PostAsync""; D
(""D E
baseUrl""E L
,""L M

jsonObject""N X
)""X Y
;""Y Z
if$$ 
($$ 
res$$ 
.$$ 
IsSuccessStatusCode$$ /
)$$/ 0
{%% 
var&& 
data&&  
=&&! "
await&&# (
res&&) ,
.&&, -
Content&&- 4
.&&4 5
ReadAsStringAsync&&5 F
(&&F G
)&&G H
;&&H I
return'' 
JsonConvert'' *
.''* +
DeserializeObject''+ <
<''< =
T''= >
>''> ?
(''? @
data''@ D
)''D E
;''E F
}(( 
throw** 
new** 
	Exception** '
(**' (
$str**( H
)**H I
;**I J
}++ 
},, 
catch-- 
(-- 
	Exception-- 
ex-- 
)--  
{.. 
throw// 
;// 
}00 
}11 	
public55 
async55 
Task55 
<55 
T55 
>55 
GetRestServiceAsync55 0
<550 1
T551 2
>552 3
(553 4
string554 :
url55; >
,55> ?
string55@ F
method55G M
,55M N
IDictionary66 
<66 
string66 
,66 
string66  &
>66& '

parameters66( 2
,662 3
IDictionary664 ?
<66? @
string66@ F
,66F G
string66H N
>66N O
headers66P W
)66W X
{77 	
var88 
baseUrl88 
=88 
string88  
.88  !
Format88! '
(88' (
$str88( 1
,881 2
url883 6
,886 7
method888 >
)88> ?
;88? @
if99 
(99 

parameters99 
.99 
Count99  
>99! "
$num99# $
)99$ %
baseUrl:: 
=:: 
baseUrl:: !
+::" #
$str::$ '
+::( )
string::* 0
.::0 1
Join::1 5
(::5 6
$str::6 9
,::9 :

parameters;; 
.;; 
Select;; %
(;;% &
p;;& '
=>;;( *
p;;+ ,
.;;, -
Key;;- 0
+;;1 2
$str;;3 6
+;;7 8
p;;9 :
.;;: ;
Value;;; @
);;@ A
.;;A B
ToArray;;B I
(;;I J
);;J K
);;K L
;;;L M
try== 
{>> 
using?? 
(?? 

HttpClient?? !
client??" (
=??) *
new??+ .

HttpClient??/ 9
(??9 :
)??: ;
)??; <
{@@ 
clientAA 
.AA !
DefaultRequestHeadersAA 0
.AA0 1
AcceptAA1 7
.AA7 8
AddAA8 ;
(AA; <
newAA< ?+
MediaTypeWithQualityHeaderValueAA@ _
(AA_ `
$strAA` r
)AAr s
)AAs t
;AAt u
ifBB 
(BB 
headersBB 
.BB  
CountBB  %
>BB& '
$numBB( )
)BB) *
{CC 
foreachDD 
(DD  !
varDD! $
headerDD% +
inDD, .
headersDD/ 6
)DD6 7
{EE 
clientFF "
.FF" #!
DefaultRequestHeadersFF# 8
.FF8 9
AddFF9 <
(FF< =
headerFF= C
.FFC D
KeyFFD G
,FFG H
headerFFI O
.FFO P
ValueFFP U
)FFU V
;FFV W
}GG 
}HH 
HttpResponseMessageJJ '
resJJ( +
=JJ, -
awaitJJ. 3
clientJJ4 :
.JJ: ;
GetAsyncJJ; C
(JJC D
baseUrlJJD K
)JJK L
;JJL M
ifLL 
(LL 
resLL 
.LL 
IsSuccessStatusCodeLL /
)LL/ 0
{MM 
varNN 
dataNN  
=NN! "
awaitNN# (
resNN) ,
.NN, -
ContentNN- 4
.NN4 5
ReadAsStringAsyncNN5 F
(NNF G
)NNG H
;NNH I
returnOO 
JsonConvertOO *
.OO* +
DeserializeObjectOO+ <
<OO< =
TOO= >
>OO> ?
(OO? @
dataOO@ D
)OOD E
;OOE F
}PP 
throwRR 
newRR 
	ExceptionRR '
(RR' (
$strRR( H
)RRH I
;RRI J
}SS 
}TT 
catchUU 
(UU 
	ExceptionUU 
exUU 
)UU  
{VV 
throwWW 
;WW 
}XX 
}YY 	
}ZZ 
}[[ ”
XD:\Cliente XM\IntegrationOracle\Infraestructure.Core\UnitOfWork\Interface\IUnitOfWork.cs
	namespace 	
Infraestructure
 
. 
Core 
. 

UnitOfWork )
.) *
	Interface* 3
{ 
public 

	interface 
IUnitOfWork  
:! "
IDisposable# .
{ 
new 
void 
Dispose 
( 
) 
; 
int 
Save 
( 
) 
; 
} 
} î
MD:\Cliente XM\IntegrationOracle\Infraestructure.Core\UnitOfWork\UnitOfWork.cs
	namespace		 	
Infraestructure		
 
.		 
Core		 
.		 

UnitOfWork		 )
{

 
public 

class 

UnitOfWork 
: 
IUnitOfWork )
{ 
private 
readonly 

ContextSQL #
_context$ ,
;, -
private 
readonly 
IServiceProvider )
serv* .
;. /
private 
bool 
disposed 
= 
false  %
;% &
public 

UnitOfWork 
( 
IServiceProvider *
serv+ /
)/ 0
{ 	
var 
serviceScope 
= 
serv #
.# $
CreateScope$ /
(/ 0
)0 1
;1 2
this 
. 
_context 
= 
new 

ContextSQL  *
(* +
serviceScope+ 7
.7 8
ServiceProvider8 G
.G H
GetRequiredServiceH Z
<Z [
DbContextOptions[ k
<k l

ContextSQLl v
>v w
>w x
(x y
)y z
)z {
;{ |
} 	
	protected:: 
virtual:: 
void:: 
Dispose:: &
(::& '
bool::' +
	disposing::, 5
)::5 6
{;; 	
if<< 
(<< 
!<< 
this<< 
.<< 
disposed<< 
)<< 
{== 
if>> 
(>> 
	disposing>> 
)>> 
{?? 
_context@@ 
.@@ 
Dispose@@ $
(@@$ %
)@@% &
;@@& '
}AA 
}BB 
thisCC 
.CC 
disposedCC 
=CC 
trueCC  
;CC  !
}DD 	
publicFF 
voidFF 
DisposeFF 
(FF 
)FF 
{GG 	
DisposeHH 
(HH 
trueHH 
)HH 
;HH 
GCII 
.II 
SuppressFinalizeII 
(II  
thisII  $
)II$ %
;II% &
}JJ 	
publicLL 
intLL 
SaveLL 
(LL 
)LL 
=>LL 
_contextLL %
.LL% &
SaveChangesLL& 1
(LL1 2
)LL2 3
;LL3 4
}NN 
}OO 